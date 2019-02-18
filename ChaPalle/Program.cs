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
            CharaDataSet m_data = new CharaDataSet();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(ref m_data));
        }
    }

    public enum ロール { 技能, 能力 };

    public class CharaDataSet : CharacterData
    {
        public Dictionary<string, string> m_defaultSkillList = new Dictionary<string, string>();    //初期値技能のリスト

        public CharaDataSet()
        {
            abilityValueList = new Dictionary<string, string>()//探索者の能力値のリスト
                { { "STR", ""}, { "CON", ""}, { "POW", ""}, { "DEX", ""}, { "APP", ""}, { "SIZ", ""}, { "INT", ""}, { "EDU", ""}, { "HP", ""}, { "MP", ""} };
            searcherInfoList = new Dictionary<string, string>()      //探索者情報のリスト
                { { "キャラクター名", ""}, { "HP", ""}, { "MP", ""}, { "SAN", ""},{ "ダメージボーナス", ""}};
            uniqueSkillList = new Dictionary<string, string>();
            fightSkillList = new Dictionary<string, string>();
        }
        
        public void setCharacterData(CharacterData chara)
        {
            abilityValueList = chara.abilityValueList;
            searcherInfoList = chara.searcherInfoList;
            uniqueSkillList = chara.uniqueSkillList;
            fightSkillList = chara.fightSkillList;
        }

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
                            abilityValueList["STR"] = arr[1];
                            abilityValueList["CON"] = arr[2];
                            abilityValueList["POW"] = arr[3];
                            abilityValueList["DEX"] = arr[4];
                            abilityValueList["APP"] = arr[5];
                            abilityValueList["SIZ"] = arr[6];
                            abilityValueList["INT"] = arr[7];
                            abilityValueList["EDU"] = arr[8];
                            abilityValueList["HP"] = arr[9];
                            abilityValueList["MP"] = arr[10];
                        }

                        else
                        {
                            //探索者情報のインポート
                            try
                            {
                                searcherInfoList[arr[0]] = arr[1];
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
                                    fightSkillList[arr[i]] = arr[i + 1];
                                    if (m_defaultSkillList[arr[i]] != arr[i + 1])
                                    { uniqueSkillList[arr[i]] = arr[i + 1]; }
                                }
                                else
                                {
                                    { uniqueSkillList[arr[i]] = arr[i + 1]; }
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
                                    { uniqueSkillList[arr[i]] = arr[i + 1]; }
                                }
                                else
                                {
                                    { uniqueSkillList[arr[i]] = arr[i + 1]; }

                                }
                            }
                            catch (Exception ee) { }
                        }
                        break;

                    case "fight":
                        if (arr[0] == "ダメージボーナス")
                        {
                            abilityValueList[arr[0]] = arr[1];
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

                searcherInfoList["キャラクター名"] = dt[0];

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

                searcherInfoList["HP"] = dt[8];
                searcherInfoList["MP"] = dt[9];
                searcherInfoList["SAN"] = dt[10];
                abilityValueList["STR"] = dt[0];
                abilityValueList["CON"] = dt[1];
                abilityValueList["POW"] = dt[2];
                abilityValueList["DEX"] = dt[3];
                abilityValueList["APP"] = dt[4];
                abilityValueList["SIZ"] = dt[5];
                abilityValueList["INT"] = dt[6];
                abilityValueList["EDU"] = dt[7];

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
                                fightSkillList[dt[1]] = dt[2];
                            if (m_defaultSkillList[dt[1]] != dt[2])
                                uniqueSkillList[dt[1]] = dt[2]; 
                        }
                        else
                        {
                            uniqueSkillList[dt[1]] = dt[2];
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

    public class ListViewItemComparer : IComparer
    {
        /// <summary>
        /// 比較する方法
        /// </summary>
        public enum ComparerMode
        {
            /// <summary>
            /// 文字列として比較
            /// </summary>
            String,
            /// <summary>
            /// 数値（Int32型）として比較
            /// </summary>
            Integer,
            /// <summary>
            /// 日時（DataTime型）として比較
            /// </summary>
            DateTime
        };

        private int _column;
        private SortOrder _order;
        private ComparerMode _mode;
        private ComparerMode[] _columnModes;

        /// <summary>
        /// 並び替えるListView列の番号
        /// </summary>
        public int Column
        {
            set
            {
                //現在と同じ列の時は、昇順降順を切り替える
                if (_column == value)
                {
                    if (_order == SortOrder.Ascending)
                    {
                        _order = SortOrder.Descending;
                    }
                    else if (_order == SortOrder.Descending)
                    {
                        _order = SortOrder.Ascending;
                    }
                }
                _column = value;
            }
            get
            {
                return _column;
            }
        }
        /// <summary>
        /// 昇順か降順か
        /// </summary>
        public SortOrder Order
        {
            set
            {
                _order = value;
            }
            get
            {
                return _order;
            }
        }
        /// <summary>
        /// 並び替えの方法
        /// </summary>
        public ComparerMode Mode
        {
            set
            {
                _mode = value;
            }
            get
            {
                return _mode;
            }
        }
        /// <summary>
        /// 列ごとの並び替えの方法
        /// </summary>
        public ComparerMode[] ColumnModes
        {
            set
            {
                _columnModes = value;
            }
        }

        /// <summary>
        /// ListViewItemComparerクラスのコンストラクタ
        /// </summary>
        /// <param name="col">並び替える列の番号</param>
        /// <param name="ord">昇順か降順か</param>
        /// <param name="cmod">並び替えの方法</param>
        public ListViewItemComparer(
            int col, SortOrder ord, ComparerMode cmod)
        {
            _column = col;
            _order = ord;
            _mode = cmod;
        }
        public ListViewItemComparer()
        {
            _column = 0;
            _order = SortOrder.Ascending;
            _mode = ComparerMode.String;
        }

        //xがyより小さいときはマイナスの数、大きいときはプラスの数、
        //同じときは0を返す
        public int Compare(object x, object y)
        {
            if (_order == SortOrder.None)
            {
                //並び替えない時
                return 0;
            }

            int result = 0;
            //ListViewItemの取得
            ListViewItem itemx = (ListViewItem)x;
            ListViewItem itemy = (ListViewItem)y;

            //並べ替えの方法を決定
            if (_columnModes != null && _columnModes.Length > _column)
            {
                _mode = _columnModes[_column];
            }

            //並び替えの方法別に、xとyを比較する
            switch (_mode)
            {
                case ComparerMode.String:
                    //文字列をとして比較
                    result = string.Compare(itemx.SubItems[_column].Text,
                        itemy.SubItems[_column].Text);
                    break;
                case ComparerMode.Integer:
                    //Int32に変換して比較
                    //.NET Framework 2.0からは、TryParseメソッドを使うこともできる
                    result = int.Parse(itemx.SubItems[_column].Text).CompareTo(
                        int.Parse(itemy.SubItems[_column].Text));
                    break;
                case ComparerMode.DateTime:
                    //DateTimeに変換して比較
                    //.NET Framework 2.0からは、TryParseメソッドを使うこともできる
                    result = DateTime.Compare(
                        DateTime.Parse(itemx.SubItems[_column].Text),
                        DateTime.Parse(itemy.SubItems[_column].Text));
                    break;
            }

            //降順の時は結果を+-逆にする
            if (_order == SortOrder.Descending)
            {
                result = -result;
            }

            //結果を返す
            return result;
        }
    }

    //履歴保存のためのクラスの定義
    public class SkillHistoryData
    {
        public List<string> skill = new List<string>();
        public List<string> time = new List<string>();
        public List<ロール> type = new List<ロール>();

        public void Set(string sk, string ti, ロール ty)
        {
            this.skill.Add(sk);
            this.time.Add(ti);
            this.type.Add(ty);
        }
    }

    [JsonObject("character")]
    public class CharacterData
    {
        [JsonProperty("uniqueSkillList")]
        public Dictionary<string, string> uniqueSkillList { get; set; }//探索者固有（技能ポイントを割り振った）の技能のリスト
        [JsonProperty("fightSkillList")]
        public Dictionary<string, string> fightSkillList { get; set; }//戦闘系技能のリスト
        [JsonProperty("abilityValue")]
        public Dictionary<string, string> abilityValueList { get; set; }
        [JsonProperty("characterInfo")]
        public Dictionary<string, string> searcherInfoList { get; set; }
    }

    [JsonObject("setting")]
    public class SettingData
    {
        [JsonProperty("diceBotFlg")]
        public int useDiceBotFlg { get; set; }
        [JsonProperty("topMostFlg")]
        public bool checkTopMostFlg { get; set; }
        [JsonProperty("clipboardMessageFlg")]
        public bool checkMessageFlg { get; set; }

    }

    
}
