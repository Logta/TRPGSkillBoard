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
using System.Collections;

using Newtonsoft.Json;
using System.Net;
using System.Threading;

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
            Searcher searcher = new Searcher();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormSplash fs = new FormSplash();
            fs.Show();
            fs.Refresh();
            Thread.Sleep(3000);//時間のかかる処理
            fs.Close();

            Application.Run(new MainForm(searcher));
        }
    }

    public enum ロール { 技能, 能力 };

    public class Searcher : Character
    {
        public Dictionary<string, string> DefaultSkillList { get; set; }    //初期値技能のリスト

        public Searcher()
        {
            DefaultSkillList = new Dictionary<string, string>();

            abilityValueList = new Dictionary<string, string>()//探索者の能力値のリスト
                { { "STR", ""}, { "CON", ""}, { "POW", ""}, { "DEX", ""}, { "APP", ""}, { "SIZ", ""}, { "INT", ""}, { "EDU", ""}, { "HP", ""}, { "MP", ""} };
            searcherInfoList = new Dictionary<string, string>()      //探索者情報のリスト
                { { "キャラクター名", ""}, { "HP", ""}, { "MP", ""}, { "SAN", ""},{ "ダメージボーナス", ""}};
            uniqueSkillList = new Dictionary<string, string>();
            fightSkillList = new Dictionary<string, string>();
        }
        
        public void SetDefaultSkills(Dictionary<string, string> defaultSkills)
        {
            DefaultSkillList = defaultSkills;
        }
        
        public void SetSearcher(Character chara)
        {
            abilityValueList = chara.abilityValueList;
            searcherInfoList = chara.searcherInfoList;
            uniqueSkillList = chara.uniqueSkillList;
            fightSkillList = chara.fightSkillList;
        }

    }

    //履歴保存のためのクラスの定義
    public class ActionHistory
    {
        public string Skill { get; set; }
        public string Time { get; set; }
        public ロール Type { get; set; }

        public ActionHistory Set(string sk, string ti, ロール ty)
        {
            this.Skill = sk;
            this.Time = ti;
            this.Type = ty;

            return this;
        }
    }

    [JsonObject("character")]
    public class Character
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
    public class Setting
    {
        [JsonProperty("diceBotFlg")]
        public int useDiceBotFlg { get; set; }
        [JsonProperty("topMostFlg")]
        public bool checkTopMostFlg { get; set; }
        [JsonProperty("clipboardMessageFlg")]
        public bool checkMessageFlg { get; set; }
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
}
