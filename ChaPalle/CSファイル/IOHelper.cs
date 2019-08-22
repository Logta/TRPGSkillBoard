using Newtonsoft.Json;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalletMaster
{
    class IOHelper
    {

        //キャラクター保管所からtxtファイル読込
        public Searcher charaBankTxtFileRead()
        {
            var searcher = new Searcher();

            string line = "";
            var al = new List<string>();
            var ofDialog = new OpenFileDialog
            {

                // デフォルトのフォルダを指定する
                //ofDialog.InitialDirectory = @"C:";

                //ダイアログのタイトルを指定する
                Title = "キャラクター保管所txtファイル読み込み",
                Filter = "txtファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*"
            };

            //ダイアログを表示する
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(
                        ofDialog.FileName, Encoding.GetEncoding("Shift_JIS")))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line == "") continue;
                            if (line == "■所持品■") break;
                            al.Add(line);
                        }
                    }

                    searcher = toChangeTxtToData(al);

                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.Message);
                }
            }
            else
            {
                Console.WriteLine("キャンセルされました");
            }

            // オブジェクトを破棄する
            ofDialog.Dispose();
            searcher.CheckUnique(); //技能値が初期値かそうでないか判定をする

            return searcher;
        }

        //キャラクター保管所からtxtデータ読込
        public Searcher charaBankTxtDataRead(string m_txtData)
        {
            var al = new List<string>();
            string[] lines = m_txtData.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "") continue;
                if (lines[i] == "■所持品■") break;
                al.Add(lines[i]);
            }

            return toChangeTxtToData(al);
        }

        //キャラクター保管所のtxtデータをキャラクターデータに成形
        public Searcher toChangeTxtToData(List<string> al)
        {
            var searcher = new Searcher();
            searcher.SetDefaultSkills(Proccess.GetSkillSet());

            char[] del = { '-', '-', '《', '》', '：', '/', ' ', '％', '　', '●' };
            string importFlg = "base";
            foreach (string charaLine in al)
            {
                string[] arr = charaLine.Split(del, StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length == 0) continue;

                switch (arr[0])
                {
                    //戦闘系技能のインポート
                    case "■技能■":
                        importFlg = "fightSkill";
                        break;

                    case "探索系技能":
                        importFlg = "sarchSkill";
                        break;

                    case "行動系技能":
                        importFlg = "actSkill";
                        break;

                    case "交渉系技能":
                        importFlg = "negotiationSkill";
                        break;

                    case "知識系技能":
                        importFlg = "wisdomSkill";
                        break;

                    case "■戦闘■":
                        importFlg = "fight";
                        break;
                }
                try
                {
                    if (arr[0].IsAny("職業", "年齢", "出身", "髪の色", "身長", "体重", "STR", "作成時", "成長等", "他修正", "習得", "名称")) continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                switch (importFlg)
                {
                    case "base":
                        //能力値のインポート

                        if (arr[0] == "=合計=")
                        {
                            int num;
                            searcher.abilityValues.STR = int.TryParse(arr[1], out num) ? num : 0;
                            searcher.abilityValues.CON = int.TryParse(arr[2], out num) ? num : 0;
                            searcher.abilityValues.POW = int.TryParse(arr[3], out num) ? num : 0;
                            searcher.abilityValues.DEX = int.TryParse(arr[4], out num) ? num : 0;
                            searcher.abilityValues.APP = int.TryParse(arr[5], out num) ? num : 0;
                            searcher.abilityValues.SIZ = int.TryParse(arr[6], out num) ? num : 0;
                            searcher.abilityValues.INT = int.TryParse(arr[7], out num) ? num : 0;
                            searcher.abilityValues.EDU = int.TryParse(arr[8], out num) ? num : 0;
                            searcher.characterInfos.HP = int.TryParse(arr[9], out num) ? num : 0;
                            searcher.characterInfos.MP = int.TryParse(arr[10], out num) ? num : 0;
                        }

                        else
                        {
                            //探索者情報のインポート
                            try
                            {
                                searcher.characterInfos.setParameter(arr[0], arr[1]);
                            }
                            catch (Exception exc)
                            {
                                Console.WriteLine(exc.Message);
                            }
                        }

                        break;


                    case "fightSkill":
                        //探索者情報のインポート
                        try
                        {
                            for (int i = 0; i <= arr.Length; i += 2)
                            {
                                var value = int.TryParse(arr[i + 1], out var x) ? x : -1;
                                if (value != -1)
                                    AddSkillSearcher(arr[i], value, "戦闘", searcher);
                            }
                        }
                        catch(Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                        break;

                    case "actSkill":
                        if (arr.Length % 2 != 0) break;
                        for (int i = 0; i < arr.Length; i += 2) {
                            var value = int.TryParse(arr[i + 1], out var x) ? x : -1;
                            if (value != -1)
                                AddSkillSearcher(arr[i], value, "行動", searcher);
                        }   
                        break;
                    case "sarchSkill":
                        if (arr.Length % 2 != 0) break;
                        //探索者情報のインポート
                        for (int i = 0; i < arr.Length; i += 2)
                        {
                            var value = int.TryParse(arr[i + 1], out var x) ? x : -1;
                            if (value != -1)
                                AddSkillSearcher(arr[i], value, "探索", searcher);
                        }
                        break;
                    case "negotiationSkill":
                        if (arr.Length % 2 != 0) break;
                        //探索者情報のインポート
                        for (int i = 0; i < arr.Length; i += 2)
                        {
                            var value = int.TryParse(arr[i + 1], out var x) ? x : -1;
                            if (value != -1)
                                AddSkillSearcher(arr[i], value, "交渉", searcher);
                        }
                        break;
                    case "wisdomSkill":
                        if (arr.Length % 2 != 0) break;
                        //探索者情報のインポート
                        for (int i = 0; i < arr.Length; i += 2)
                        {
                            var value = int.TryParse(arr[i + 1], out var x) ? x : -1;
                            if (value != -1)
                                AddSkillSearcher(arr[i], value, "知識", searcher);
                        }
                        break;

                    case "fight":
                        if (arr[0] == "ダメージボーナス")
                        {
                            searcher.characterInfos.setParameter(arr[0], arr[1]);
                        }
                        break;
                }
            }

            return searcher;
        }

        //スキルをキャラクターにセットする
        private Searcher AddSkillSearcher(string name, int value, string type, Searcher searcher)
        {
            searcher.SetSkill(new Skill(name, value, type));
            return searcher;
        }

        //キャラクターアーカイブスからキャラクターデータを読込
        public Searcher charaArchiveHTMLRead(string m_URL)
        {
            var searcher = new Searcher();
            var Proccesser = new Proccess();
            var wc = new WebClient();

            var defaultSkillList = Proccess.GetSkillSet();
            searcher.SetDefaultSkills(defaultSkillList);

            try
            {
                wc.Encoding = System.Text.Encoding.UTF8;
                string html = wc.DownloadString(m_URL); //指定URLのHTMLデータを取得

                //HtmlAgilityPackを用いてHTMLデータを抽出
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.OptionAutoCloseOnEnd = false;  //最後に自動で閉じる（？）
                doc.OptionCheckSyntax = false;     //文法チェック。
                doc.OptionFixNestedTags = true;    //閉じタグが欠如している場合の処理
                doc.LoadHtml(html);

                string[] dt;
                //キャラネームの取得
                var name = doc.DocumentNode.SelectNodes("//h1")[0].InnerText;
                char[] removeChars = new char[] { ' ', '　' };
                string m_buff = removeChars.Aggregate(name, (s, c) => s.Replace(c.ToString(), ""));
                dt = m_buff.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                searcher.characterInfos.characterName = dt[0];

                //キャラ能力値の取得
                foreach (var row in doc.DocumentNode.SelectNodes("//tr[@id='status_total']"))
                {
                    var nodes = row.InnerText;
                    if (nodes == null) continue;

                    m_buff = removeChars.Aggregate(nodes, (s, c) => s.Replace(c.ToString(), ""));
                    dt = m_buff.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                }

                int num;
                searcher.characterInfos.HP = int.TryParse(dt[8], out num) ? num : 0;
                searcher.characterInfos.MP = int.TryParse(dt[9], out num) ? num : 0;
                searcher.characterInfos.SAN = int.TryParse(dt[10], out num) ? num : 0;
                searcher.abilityValues.STR = int.TryParse(dt[0], out num) ? num : 0;
                searcher.abilityValues.CON = int.TryParse(dt[1], out num) ? num : 0;
                searcher.abilityValues.POW = int.TryParse(dt[2], out num) ? num : 0;
                searcher.abilityValues.DEX = int.TryParse(dt[3], out num) ? num : 0;
                searcher.abilityValues.APP = int.TryParse(dt[4], out num) ? num : 0;
                searcher.abilityValues.SIZ = int.TryParse(dt[5], out num) ? num : 0;
                searcher.abilityValues.INT = int.TryParse(dt[6], out num) ? num : 0;
                searcher.abilityValues.EDU = int.TryParse(dt[7], out num) ? num : 0;

                //技能の取得
                foreach (var row in doc.DocumentNode.SelectNodes("//div [@id='skill']//tr"))
                {
                    var nodes = row.InnerText;
                    if (nodes == null) continue;

                    m_buff = removeChars.Aggregate(nodes, (s, c) => s.Replace(c.ToString(), ""));
                    dt = m_buff.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    

                    try
                    {
                        if (dt[0] == "種別" || dt[1] == "技能名" || dt[2] == "値") continue;

                        var value = int.TryParse(dt[2], out var m) ? m : -1;
                        if (value == -1) continue;
                        searcher.SetSkill(new Skill(dt[1], value, dt[0]));
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                    }
                }

            }
            catch (WebException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch(NullReferenceException exc)
            {
                Console.WriteLine(exc.Message);
            }               
            searcher.CheckUnique(); //技能値が初期値かそうでないか判定をする
            return searcher;
        }

        //セッティングデータを保存
        public void toSaveSetting(Setting m_sData)
        {
            //ファイルに書き込む
            System.IO.StreamWriter sw = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "setting.json");
            string json = JsonConvert.SerializeObject(m_sData);//, Formatting.Indented);
            sw.Write(json);
            //閉じる
            sw.Close();
        }

        //セッティングデータを読込
        public Setting toLoadSetting()
        {
            try
            {
                string json = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "setting.json");
                return JsonConvert.DeserializeObject<Setting>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Setting m_sData = new Setting
                {
                    checkMessageFlg = true,
                    checkTopMostFlg = true,
                    useDiceBotFlg = 0
                };

                return m_sData;
            }
        }

        public FightDamage ReadFightDamageJson()
        {
            string json = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "fightSkill.json");
            return JsonConvert.DeserializeObject<FightDamage>(json);
        }

        //セッティングデータを保存
        public void SaveMemo(Memo memo)
        {
            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "pmmファイル(*.pmm)|*.pmm|すべてのファイル(*.*)|*.*"
            };
            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream stream;
                stream = sfd.OpenFile();
                if (stream != null)
                {
                    //ファイルに書き込む
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(stream, Encoding.GetEncoding("Shift_JIS"));
                    string json = JsonConvert.SerializeObject(memo);//, Formatting.Indented);
                    sw.Write(json);
                    //閉じる
                    sw.Close();
                }
                stream.Close();
            }
        }

        //メモデータを読込
        public Memo LoadMemo()
        {
            var al = new List<string>();
            OpenFileDialog ofDialog = new OpenFileDialog
            {

                // デフォルトのフォルダを指定する
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,

                //ダイアログのタイトルを指定する
                Title = "PMMファイル読み込み",
                Filter = "pmmファイル(*.pmm)|*.pmm|すべてのファイル(*.*)|*.*"
            };

            //ダイアログを表示する
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                string json = System.IO.File.ReadAllText(ofDialog.FileName, Encoding.GetEncoding("Shift_JIS"));
                return JsonConvert.DeserializeObject<Memo>(json);
            }

            return null;            
        }
    }
}
