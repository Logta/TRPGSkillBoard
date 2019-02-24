using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaPalle
{
    class IOHelper
    {

        //キャラクター保管所からtxtファイル読込
        public Searcher charaBankTxtFileRead()
        {
            var searcher = new Searcher();

            string line = "";
            var al = new List<string>();
            var ofDialog = new OpenFileDialog();

            // デフォルトのフォルダを指定する
            ofDialog.InitialDirectory = @"C:";

            //ダイアログのタイトルを指定する
            ofDialog.Title = "キャラクター保管所txtファイル読み込み";
            ofDialog.Filter = "txtファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";

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

            char[] del = { '-', '-', '《', '》', '：', '/', ' ', '％', '　', '●' };
            string importFlg = "base";
            foreach (string charaLine in al)
            {
                string[] arr = charaLine.Split(del, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (arr[0].IsAny("職業", "年齢", "出身", "髪の色", "身長", "体重", "STR", "作成時", "成長等", "他修正", "習得", "名称")) continue;
                }
                catch (Exception ee)
                {
                    continue;
                }

                switch (importFlg)
                {
                    case "base":
                        //能力値のインポート

                        if (arr[0] == "=合計=")
                        {
                            searcher.abilityValueList["STR"] = arr[1];
                            searcher.abilityValueList["CON"] = arr[2];
                            searcher.abilityValueList["POW"] = arr[3];
                            searcher.abilityValueList["DEX"] = arr[4];
                            searcher.abilityValueList["APP"] = arr[5];
                            searcher.abilityValueList["SIZ"] = arr[6];
                            searcher.abilityValueList["INT"] = arr[7];
                            searcher.abilityValueList["EDU"] = arr[8];
                            searcher.abilityValueList["HP"] = arr[9];
                            searcher.abilityValueList["MP"] = arr[10];
                        }

                        else
                        {
                            //探索者情報のインポート
                            try
                            {
                                searcher.searcherInfoList[arr[0]] = arr[1];
                            }
                            catch (Exception ee) { }
                        }

                        break;


                    case "fightSkill":
                        //探索者情報のインポート
                        for (int i = 0; i <= arr.Length; i += 2)
                        {
                            try
                            {
                                if (searcher.DefaultSkillList.ContainsKey(arr[i]))
                                {
                                    searcher.fightSkillList[arr[i]] = arr[i + 1];
                                    if (searcher.DefaultSkillList[arr[i]] != arr[i + 1])
                                    { searcher.uniqueSkillList[arr[i]] = arr[i + 1]; }
                                }
                                else
                                {
                                    { searcher.uniqueSkillList[arr[i]] = arr[i + 1]; }
                                }
                            }
                            catch (Exception ee) { }
                        }
                        break;

                    case "actSkill":
                    case "sarchSkill":
                    case "negotiationSkill":
                    case "wisdomSkill":
                        //探索者情報のインポート

                        for (int i = 0; i <= arr.Length; i += 2)
                        {
                            try
                            {
                                if (searcher.DefaultSkillList.ContainsKey(arr[i]))
                                {
                                    if (searcher.DefaultSkillList[arr[i]] != arr[i + 1])
                                    { searcher.uniqueSkillList[arr[i]] = arr[i + 1]; }
                                }
                                else
                                {
                                    { searcher.uniqueSkillList[arr[i]] = arr[i + 1]; }

                                }
                            }
                            catch (Exception ee) { }
                        }
                        break;

                    case "fight":
                        if (arr[0] == "ダメージボーナス")
                        {
                            searcher.abilityValueList[arr[0]] = arr[1];
                        }
                        break;
                }

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
            }

            return searcher;
        }

        public Searcher charaArchiveHTMLRead(string m_URL)
        {
            var searcher = new Searcher();
            var wc = new WebClient();

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

                searcher.searcherInfoList["キャラクター名"] = dt[0];

                //キャラ能力値の取得
                foreach (var row in doc.DocumentNode.SelectNodes("//tr[@id='status_total']"))
                {
                    var nodes = row.InnerText;
                    if (nodes != null)
                    {
                        m_buff = removeChars.Aggregate(nodes, (s, c) => s.Replace(c.ToString(), ""));
                        dt = m_buff.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    }
                }

                searcher.searcherInfoList["HP"] = dt[8];
                searcher.searcherInfoList["MP"] = dt[9];
                searcher.searcherInfoList["SAN"] = dt[10];
                searcher.abilityValueList["STR"] = dt[0];
                searcher.abilityValueList["CON"] = dt[1];
                searcher.abilityValueList["POW"] = dt[2];
                searcher.abilityValueList["DEX"] = dt[3];
                searcher.abilityValueList["APP"] = dt[4];
                searcher.abilityValueList["SIZ"] = dt[5];
                searcher.abilityValueList["INT"] = dt[6];
                searcher.abilityValueList["EDU"] = dt[7];

                //技能の取得
                foreach (var row in doc.DocumentNode.SelectNodes("//div [@id='skill']//tr"))
                {
                    var nodes = row.InnerText;
                    if (nodes != null)
                    {
                        m_buff = removeChars.Aggregate(nodes, (s, c) => s.Replace(c.ToString(), ""));
                        dt = m_buff.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    }

                    try
                    {
                        if (dt[0] == "種別" || dt[1] == "技能名" || dt[2] == "値") continue;

                        if (searcher.DefaultSkillList.ContainsKey(dt[1]))
                        {
                            if (dt[0] == "戦闘")
                                searcher.fightSkillList[dt[1]] = dt[2];
                            if (searcher.DefaultSkillList[dt[1]] != dt[2])
                                searcher.uniqueSkillList[dt[1]] = dt[2];
                        }
                        else
                        {
                            searcher.uniqueSkillList[dt[1]] = dt[2];
                        }
                    }
                    catch (Exception ee) { }
                }

            }
            catch (WebException exc)
            {
            }

            return searcher;
        }
    }
}
