using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalletMaster
{
    public class PalletMaster
    {
        public Setting Setting { get; set; }
        public Searcher Searcher { get; set; }
        public List<ActionHistory> ActionHistorys { get; set; }

        public MainForm MainForm { get; set; }

        public PalletMaster()
        {
            Setting = new Setting();
            Searcher = new Searcher();
            ActionHistorys = new List<ActionHistory>();
        }

        //MainFormのインスタンスをセットする
        public void SetMainForm(MainForm mainForm)
        {
            MainForm = mainForm;
        }

        //クリップボードに文字列を入力する際に用いる関数
        public void SetClipBoard(string m_copy)
        {
            if (m_copy == "") return;

            Clipboard.SetText(m_copy);
            MainForm.SetClipboardText(m_copy);

            if (Setting.checkMessageFlg)
                MessageBox.Show("クリップボードにコピーしました", "成功", MessageBoxButtons.OK);
            else
                System.Media.SystemSounds.Asterisk.Play();
        }

        //能力値を設定する
        public void AbilityDataSet()
        {

            int buff_1;
            if (int.TryParse(Searcher.abilityValues["INT"], out buff_1)) //能力値が入力されていなければ無視する
                Searcher.SetSkill(new Skill("アイデア", buff_1 * 5, "探索"));
            if (int.TryParse(Searcher.abilityValues["POW"], out buff_1))
                Searcher.SetSkill(new Skill("幸運", buff_1 * 5, "探索"));
            if (int.TryParse(Searcher.abilityValues["EDU"], out buff_1))
                Searcher.SetSkill(new Skill("知識", buff_1 * 5, "探索"));
            if (int.TryParse(Searcher.abilityValues["DEX"], out buff_1)
                && Searcher.skills.FindAll(s => s.name == "回避").Count == 0)
                Searcher.SetSkill(new Skill("回避", buff_1 * 2, "戦闘"));

            if (int.TryParse(Searcher.abilityValues["STR"], out buff_1) &&
               int.TryParse(Searcher.abilityValues["SIZ"], out int buff_2))
                Searcher.searcherInfos["ダメージボーナス"] = GetBonusDamege(buff_1 + buff_2);
        }

        //能力値を設定する
        public static Searcher AbilityDataSet(Searcher searcher)
        {
            int buff_1;
            int buff_2;

            if (int.TryParse(searcher.abilityValues["INT"], out buff_1)) //能力値が入力されていなければ無視する
                searcher.SetSkill(new Skill("アイデア", buff_1 * 5, "探索"));
            if (int.TryParse(searcher.abilityValues["POW"], out buff_1))
                searcher.SetSkill(new Skill("幸運", buff_1 * 5, "探索"));
            if (int.TryParse(searcher.abilityValues["EDU"], out buff_1))
                searcher.SetSkill(new Skill("知識", buff_1 * 5, "探索"));
            if (int.TryParse(searcher.abilityValues["DEX"], out buff_1)
                && searcher.skills.FindAll(s => s.name == "回避").Count == 0)
                searcher.SetSkill(new Skill("回避", buff_1 * 2, "戦闘"));

            if (int.TryParse(searcher.abilityValues["STR"], out buff_1) &&
               int.TryParse(searcher.abilityValues["SIZ"], out buff_2))
                searcher.searcherInfos["ダメージボーナス"] = GetBonusDamege(buff_1 + buff_2);

            return searcher;
        }

        private static string GetBonusDamege(int strPlusSiz)
        {
            switch (strPlusSiz)
            {
                case int n when n < 12: return "-1D6";
                case int n when n < 16: return "-1D4";
                case int n when n < 24: return "";
                case int n when n < 32: return "+1D4";
                case int n when n < 40: return "+1D6";
                case int n when n < 56: return "+2D6";
                case int n when n < 72: return "+3D6";
                default: return null;
            }
        }

        //技能・能力ロールを行った履歴をリストに入力する
        public void SetSkillHistory(string m_skill, ロール m_type)
        {
            DateTime dt = DateTime.Now;
            ActionHistorys.Add(
                new ActionHistory().Set(m_skill, dt.ToString("yyyy/MM/dd HH:mm:ss"), m_type));
        }

        public string GetBCDiceAPISkillText(string value)
        {
            return "CCB<=" + value;
        }

        public string GetBotDiceText(string value, string name = "")
        {
            return Setting.useDiceBotFlg == 0 ? "1d100<=" + value + " " + name
                : "/r 1d100<=" + value;
        }

        //ダイスボット用の文字列を取得する
        //valueに判定値を、nameに技能など
        public string GetDiceText(string value, string name = "")
        {
            return Setting.useBCDiceAPIFlg ? GetBCDiceAPISkillText(value) :
                GetBotDiceText(value, name);
        }

        //listviewに関係する配列（m_uniqueSkillListなど）が変更された際に
        //listviewの中身を変更、更新する
        public void RefreshListView()
        {
            //能力値で技能値の決まる技能を代入
            if (Searcher != null)
            {
                AbilityDataSet();

                MainForm.RefreshList();
            }
        }

        internal void SetClipboardSearchSkillValue(string text)
        {
            var value = toSearchSkillValue(text);
            if (value is null) return;

            SetTextRole(GetDiceText(value, text), text);
            SetSkillHistory(text, ロール.技能);
        }

        //指定された文字列に合致する技能の技能値をクリップボードに貼り付ける関数
        public string toSearchSkillValue(string skillName)
        {

            //LINQ文とラムダ式を活用した処理
            var skill = Searcher.skills.FindAll(s => s.name == skillName);

            if (skill.Count != 0) return skill[0].value.ToString();
            else { 
                MessageBox.Show("正しい技能名を入力してください。", "エラー", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
                
            }
        }

        internal void SetTextRole(string text, string skill)
        {
            if (Setting.offlineMode)
                new Proccess().ShowResultDialog(text, skill);
            else if (Setting.useBCDiceAPIFlg)
                new Proccess().SendPostWebhookBCDiceAPI(text,
                    Setting.webhookURL, Setting.bcdiceAPIURL, Setting.userName, skill);
            else if (Setting.useWebhookFlg)
                _ = new Proccess().SendPostWebhookAsync(text + " " + Setting.userName,
                    Setting.webhookURL, Setting.userName);
            else
                SetClipBoard(text);
        }
    }
}
