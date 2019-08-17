using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalletMaster
{
    class ChpFileImport
    {
        public class ChpSearcher : ChpCharacter
        {
            public Dictionary<string, string> DefaultSkillList { get; set; }    //初期値技能のリスト

            public ChpSearcher()
            {
                DefaultSkillList = new Dictionary<string, string>();

                abilityValues = new Dictionary<string, string>()//探索者の能力値のリスト
            { { "STR", ""}, { "CON", ""}, { "POW", ""}, { "DEX", ""}, { "APP", ""}, { "SIZ", ""}, { "INT", ""}, { "EDU", ""}, { "HP", ""}, { "MP", ""} };
                searcherInfos = new Dictionary<string, string>()      //探索者情報のリスト
            { { "キャラクター名", ""}, { "HP", ""}, { "MP", ""}, { "SAN", ""},{ "ダメージボーナス", ""}};
                uniqueSkills = new Dictionary<string, string>();
                fightSkills = new Dictionary<string, string>();
            }

            public ChpSearcher SetDefaultSkills(Dictionary<string, string> defaultSkills)
            {
                DefaultSkillList = defaultSkills;
                return this;
            }

            public Searcher ConversionToSearcher()
            {
                if (this == null) return new Searcher();

                Searcher searcher = new Searcher();
                searcher.SetDefaultSkills(Proccess.GetSkillSet());
                searcher = ReplacementSkills(uniqueSkills, searcher, "");
                searcher = ReplacementSkills(fightSkills, searcher, "戦闘");

                searcher.abilityValues = abilityValues;
                searcher.searcherInfos = searcherInfos;
                searcher.backgroundString = backgroundString;
                searcher.CheckUnique();

                return searcher;
            }

            private Searcher ReplacementSkills(Dictionary<string, string> skills, Searcher searcher, string type)
            {

                foreach (var item in skills)
                {
                    searcher.SetSkill(new Skill(item.Key, int.Parse(item.Value), type));
                }

                return searcher;
            }
        }

        public ChpSearcher SetSearcher(ChpCharacter chara)
        {
            ChpSearcher chpSearcher = new ChpSearcher
            {
                abilityValues = chara.abilityValues,
                searcherInfos = chara.searcherInfos,
                uniqueSkills = chara.uniqueSkills,
                fightSkills = chara.fightSkills,
                backgroundString = chara.backgroundString
            };

            return chpSearcher;
        }

        [JsonObject("character")]
        public class ChpCharacter
        {
            [JsonProperty("uniqueSkillList")]
            public Dictionary<string, string> uniqueSkills { get; set; }//探索者固有（技能ポイントを割り振った）の技能のリスト
            [JsonProperty("fightSkillList")]
            public Dictionary<string, string> fightSkills { get; set; }//戦闘系技能のリスト
            [JsonProperty("abilityValue")]
            public Dictionary<string, string> abilityValues { get; set; }
            [JsonProperty("characterInfo")]
            public Dictionary<string, string> searcherInfos { get; set; }
            [JsonProperty("characterBackground")]
            public string backgroundString { get; set; }

        }

        //チャッパレ形式をロードする再利用する構造体の定義
        struct chpLoad
        {
            internal ChpCharacter d;
            internal bool f;
        }

        public ChpSearcher ChpDataImport()
        {
            chpLoad m_d;
            m_d = ImportChpFromJSON();
            if (!m_d.f) return new ChpSearcher();
            
            var defaultSkillList = Proccess.ReadCSVToDictionary(System.AppDomain.CurrentDomain.BaseDirectory + "defaultSkill.csv");
            return SetSearcher(m_d.d).SetDefaultSkills(defaultSkillList);
        }

        private chpLoad ImportChpFromJSON()
        {
            chpLoad m_d;
            OpenFileDialog ofDialog = new OpenFileDialog
            {

                // デフォルトのフォルダを指定する
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,

                //ダイアログのタイトルを指定する
                Title = "チャッパレ形式ファイル読み込み",
                Filter = "チャッパレファイル(*.chp)|*.chp|すべてのファイル(*.*)|*.*"
            };

            //ダイアログを表示する
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                m_d = JSONLoad(ofDialog.FileName);
                return m_d;
            }

            m_d.d = new ChpCharacter();
            m_d.f = false;
            return m_d;
        }

        //チャッパレ形式読み取り関数
        chpLoad JSONLoad(string fileName)
        {
            chpLoad chpLoad;
            try
            {
                string json = System.IO.File.ReadAllText(fileName, Encoding.GetEncoding("Shift_JIS"));
                chpLoad.d = JsonConvert.DeserializeObject<ChpCharacter>(json);
                chpLoad.f = true;
                return chpLoad;
            }
            catch
            {
                try
                {
                    string json = System.IO.File.ReadAllText(fileName, Encoding.GetEncoding("UTF-8"));
                    chpLoad.d = JsonConvert.DeserializeObject<ChpCharacter>(json);
                    chpLoad.f = true;
                    return chpLoad;
                }
                catch (Exception e)
                {
                    MessageBox.Show("読み込み時エラーが発生しました。\n" + e.Message,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    chpLoad.d = new ChpCharacter();
                    chpLoad.f = false;
                    return chpLoad;
                }
            }
        }


    }
}
