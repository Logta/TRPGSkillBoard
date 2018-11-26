using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

using System.Linq;
using Newtonsoft.Json;
using System.Net;

/// <summary>
/// string 型の拡張メソッドを管理するクラス
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// 文字列が指定されたいずれかの文字列と等しいかどうかを返します
    /// </summary>
    public static bool IsAny(this string self, params string[] values)
    {
        return values.Any(c => c == self);
    }
}
namespace ChaPalle
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Dataset m_data = new Dataset();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(ref m_data));
        }
    }

    public class Dataset
    {
        public Dictionary<string, string> m_defaultSkillList = new Dictionary<string, string>();    //初期値技能のリスト
        public Dictionary<string, string> m_uniqueSkillList = new Dictionary<string, string>();     //探索者固有（技能ポイントを割り振った）の技能のリスト
        public Dictionary<string, string> m_fightSkillList = new Dictionary<string, string>();      //戦闘系技能のリスト
                public Dictionary<string, string> m_abilityValueList = new Dictionary<string, string>()//探索者の能力値のリスト
        { { "STR", ""}, { "CON", ""}, { "POW", ""}, { "DEX", ""}, { "APP", ""}, { "SIZ", ""}, { "INT", ""}, { "EDU", ""}, { "HP", ""}, { "MP", ""} };
        public Dictionary<string, string> m_sarcherInfoList = new Dictionary<string, string>()      //探索者情報のリスト
        { { "キャラクター名", ""}, { "HP", ""}, { "MP", ""}, { "SAN", ""},{ "ダメージボーナス", ""}};

        public int m_useDiceBotFlg = 0;     //bcdiceかsidekickのどちらのダイスボットの入力をするかのフラグ

        //キャラクター保管所からtxtファイル読込
        public void charaBankTxtFileRead()
        {
            string line = "";
            var al = new List<string>();
            OpenFileDialog ofDialog = new OpenFileDialog();

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

                    toChangeTxtToData(al);

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
        }

        //キャラクター保管所からtxtデータ読込
        public void charaBankTxtDataRead(string m_txtData)
        {
            var al = new List<string>();
            string[] lines = m_txtData.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "") continue;
                if (lines[i] == "■所持品■") break;
                al.Add(lines[i]);
            }

            toChangeTxtToData(al);
        }

        //キャラクター保管所のtxtデータをキャラクターデータに成形
        public void toChangeTxtToData(List<string> al)
        {
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
                            m_abilityValueList["STR"] = arr[1];
                            m_abilityValueList["CON"] = arr[2];
                            m_abilityValueList["POW"] = arr[3];
                            m_abilityValueList["DEX"] = arr[4];
                            m_abilityValueList["APP"] = arr[5];
                            m_abilityValueList["SIZ"] = arr[6];
                            m_abilityValueList["INT"] = arr[7];
                            m_abilityValueList["EDU"] = arr[8];
                            m_abilityValueList["HP"] = arr[9];
                            m_abilityValueList["MP"] = arr[10];
                        }

                        else
                        {
                            //探索者情報のインポート
                            try
                            {
                                m_sarcherInfoList[arr[0]] = arr[1];
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
                                if (m_defaultSkillList.ContainsKey(arr[i]))
                                {
                                    m_fightSkillList[arr[i]] = arr[i + 1];
                                    if (m_defaultSkillList[arr[i]] != arr[i + 1])
                                    { m_uniqueSkillList[arr[i]] = arr[i + 1]; }
                                }
                                else
                                {
                                    { m_uniqueSkillList[arr[i]] = arr[i + 1]; }
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
                                if (m_defaultSkillList.ContainsKey(arr[i]))
                                {
                                    if (m_defaultSkillList[arr[i]] != arr[i + 1])
                                    { m_uniqueSkillList[arr[i]] = arr[i + 1]; }
                                }
                                else
                                {
                                    { m_uniqueSkillList[arr[i]] = arr[i + 1]; }

                                }
                            }
                            catch (Exception ee) { }
                        }
                        break;

                    case "fight":
                        if (arr[0] == "ダメージボーナス")
                        {
                            m_abilityValueList[arr[0]] = arr[1];
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
        }

        public void charaArchiveHTMLRead(string m_URL)
        {
            WebClient wc = new WebClient();
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

                m_sarcherInfoList["キャラクター名"] = dt[0];

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
                m_sarcherInfoList["HP"] = dt[8];
                m_sarcherInfoList["MP"] = dt[9];
                m_sarcherInfoList["SAN"] = dt[10];
                m_abilityValueList["STR"] = dt[0];
                m_abilityValueList["CON"] = dt[1];
                m_abilityValueList["POW"] = dt[2];
                m_abilityValueList["DEX"] = dt[3];
                m_abilityValueList["APP"] = dt[4];
                m_abilityValueList["SIZ"] = dt[5];
                m_abilityValueList["INT"] = dt[6];
                m_abilityValueList["EDU"] = dt[7];

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

                        if (m_defaultSkillList.ContainsKey(dt[1]))
                        {
                            if (dt[0] == "戦闘")
                                m_fightSkillList[dt[1]] = dt[2];
                            if (m_defaultSkillList[dt[1]] != dt[2])
                                m_uniqueSkillList[dt[1]] = dt[2]; 
                        }
                        else
                        {
                            m_uniqueSkillList[dt[1]] = dt[2];
                        }
                    }
                    catch (Exception ee) { }
                }

            }
            catch (WebException exc)
            {
            }
        }
    }

    [JsonObject("character")]
    public class CharacterData
    {
        [JsonProperty("uniqueSkillList")]
        public Dictionary<string, string> m_uniqueSkillList { get; set; }
        [JsonProperty("fightSkillList")]
        public Dictionary<string, string> m_fightSkillList { get; set; }
        [JsonProperty("abilityValue")]
        public Dictionary<string, string> m_abilityValueList { get; set; }
        [JsonProperty("characterInfo")]
        public Dictionary<string, string> m_sarcherInfoList { get; set; }
    }

    [JsonObject("setting")]
    public class SettingData
    {
        [JsonProperty("diceBotFlg")]
        public int m_useDiceBotFlg { get; set; }
        [JsonProperty("topMostFlg")]
        public bool m_checkTopMostFlg { get; set; }
        [JsonProperty("clipboardMessageFlg")]
        public bool m_checkMessageFlg { get; set; }

    }

    
}
