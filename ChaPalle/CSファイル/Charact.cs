using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalletMaster
{
    public enum ロール { 技能, 能力 };

    public class Searcher : Character
    {
        public Dictionary<string, string> DefaultSkillList { get; set; }    //初期値技能のリスト

        public Searcher()
        {
            DefaultSkillList = new Dictionary<string, string>();

            abilityValues = new Dictionary<string, string>()//探索者の能力値のリスト
            { { "STR", ""}, { "CON", ""}, { "POW", ""}, { "DEX", ""}, { "APP", ""}, { "SIZ", ""}, { "INT", ""}, { "EDU", ""}};
            searcherInfos = new Dictionary<string, string>()      //探索者情報のリスト
            { { "キャラクター名", ""}, { "HP", ""}, { "MP", ""}, { "SAN", ""},{ "ダメージボーナス", ""}};
            skills = new List<Skill>();
        }

        public void SetDefaultSkills(Dictionary<string, string> defaultSkills)
        {
            DefaultSkillList = defaultSkills;

            foreach (KeyValuePair<string, string> kvp in defaultSkills)
            {
                var buf = 0;
                if (int.TryParse(kvp.Value, out buf)){
                    SetSkill(new Skill(kvp.Key, buf, "", buf));
                }
            }
        }

        public void SetSearcher(Character chara)
        {
            abilityValues = chara.abilityValues;
            searcherInfos = chara.searcherInfos;
            skills = chara.skills;
            backgroundString = chara.backgroundString;
        }

        //0=>新規追加 1=>更新 -1=>失敗
        public int SetSkill(Skill skill)
        {
            if(skills == null)
            {
                skills = new List<Skill>();
            }

            if (skills.Count(item => item.name == skill.name) == 0)
            {
                skills.Add(skill);
                return 0;
            }
            else if (this.skills.Count(item => item.name == skill.name) == 1)
            {
                Skill charaSkill = skills.Find(item => item.name == skill.name);
                charaSkill.value = skill.value;
                charaSkill.type = skill.type;
                return 1;
            }

            return -1;
        }

        internal void RemoveSkills(string text)
        {
            skills = skills.FindAll(s => s.name != text);
        }

        internal string getSkillValue(string skillName)
        {
            return skills.Find(s => s.name == skillName).value.ToString();
        }

        internal void CheckUnique()
        {
            foreach (var skill in skills)
            {
                skill.unique = skill.value == skill.defaultValue ? false : true;
            }
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
        [JsonProperty("skills")]
        public List<Skill> skills { get; set; }//探索者固有（技能ポイントを割り振った）の技能のリスト
        [JsonProperty("abilityValue")]
        public Dictionary<string, string> abilityValues { get; set; }
        [JsonProperty("characterInfo")]
        public Dictionary<string, string> searcherInfos { get; set; }
        [JsonProperty("characterBackground")]
        public string backgroundString { get; set; }
    }

    [JsonObject("skill")]
    public class Skill
    {
        [JsonProperty("skillName")]
        public string name { get; set; }
        [JsonProperty("skillValue")]
        public int value { get; set; }
        [JsonProperty("skillType")]
        public string type { get; set; }
        [JsonProperty("skillUnique")]
        public bool unique { get; set; }
        [JsonProperty("skillWorkValue")]
        public int workValue { get; set; }
        [JsonProperty("skillInterestValue")]
        public int intererstValue { get; set; }
        [JsonProperty("defaultValue")]
        public int defaultValue { get; set; }

        public Skill() {
            name = "";
            value = 0;
            type = "";
            unique = false;
            workValue = 0;
            intererstValue = 0;
            defaultValue = 0;
        }

        public Skill(string n, int v) : this()
        {
            name = n;
            value = v;
        }

        public Skill(string n, int v, string t) : this(n, v)
        {
            type = t;
        }

        public Skill(string n, int v, string t, int d) : this(n, v, t)
        {
            defaultValue = d;
        }

        public Skill(string n, int v, string t, int d, bool u) : this(n, v, t, d)
        {
            unique = u;
        }

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
        [JsonProperty("webhookURL")]
        public string webhookURL { get; set; }
        [JsonProperty("userName")]
        public string userName { get; set; }
        [JsonProperty("useWebhookFlg")]
        public bool useWebhookFlg { get; set; }
        [JsonProperty("bcdiceAPIURL")]
        public string bcdiceAPIURL { get; set; }
        [JsonProperty("useBCDiceAPIFlg")]
        public bool useBCDiceAPIFlg { get; set; }
        [JsonProperty("charaNameToUserNameFlg")]
        public bool charaNameToUserNameFlg { get; set; }
        [JsonProperty("font")]
        public string font { get; set; }
        [JsonProperty("fontSize")]
        public int fontSize { get; set; }
    }

    [JsonObject("fightDamage")]
    public class FightDamage
    {
        [JsonProperty("fightSkillDamage")]
        public Dictionary<string, string> fightSkillDamage { get; set; }
    }

    [JsonObject("memo")]
    public class Memo
    {
        [JsonProperty("memoString")]
        public List<string> memos { get; set; }
        [JsonProperty("tabString")]
        public List<string> tabs { get; set; }
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
            _order = System.Windows.Forms.SortOrder.Ascending;
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
