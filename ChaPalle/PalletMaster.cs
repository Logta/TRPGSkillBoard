using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaPalle
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
        private void AbilityDataSet()
        {
            int buff_1;
            int buff_2;

            if (int.TryParse(Searcher.abilityValueList["INT"], out buff_1)) //能力値が入力されていなければ無視する
                Searcher.uniqueSkillList["アイデア"] = Convert.ToString(buff_1 * 5);
            if (int.TryParse(Searcher.abilityValueList["POW"], out buff_1))
                Searcher.uniqueSkillList["幸運"] = Convert.ToString(buff_1 * 5);
            if (int.TryParse(Searcher.abilityValueList["EDU"], out buff_1))
                Searcher.uniqueSkillList["知識"] = Convert.ToString(buff_1 * 5);
            if (int.TryParse(Searcher.abilityValueList["DEX"], out buff_1) 
                && !Searcher.fightSkillList.ContainsKey("回避"))
            {
                Searcher.fightSkillList["回避"] = Convert.ToString(buff_1 * 2);
                Searcher.uniqueSkillList["回避"] = Convert.ToString(buff_1 * 2);
            }

            if(int.TryParse(Searcher.abilityValueList["STR"], out buff_1) &&
               int.TryParse(Searcher.abilityValueList["SIZ"], out buff_2))
                Searcher.searcherInfoList["ダメージボーナス"] = GetBonusDamege(buff_1 + buff_2);
        }

        private string GetBonusDamege(int strPlusSiz)
        {
            switch (strPlusSiz)
            {
                case int n when n < 12: return "-1D6";
                case int n when n < 16: return "-1D4";
                case int n when n < 24: return "0";
                case int n when n < 32: return "1D4";
                case int n when n < 40: return "1D6";
                case int n when n < 56: return "2D6";
                case int n when n < 72: return "3D6";
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
        
        //ダイスボット用の文字列を取得する
        //valueに判定値を、nameに技能など
        public string GetBotDiceText(string value, string name = "")
        {
            return Setting.useDiceBotFlg == 0 ? "1d100<=" + value + " " + name
                : "/r 1d100<=" + value;
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

            SetClipBoard(GetBotDiceText(value));
            SetSkillHistory(text, ロール.技能);
        }

        //指定された文字列に合致する技能の技能値をクリップボードに貼り付ける関数
        private string toSearchSkillValue(string skillName)
        {

            ////LINQ文とラムダ式を活用した処理
            var skillDict = Searcher.uniqueSkillList.Where(s => s.Key == skillName).ToDictionary(s => s.Key, s => s.Value);

            if (skillDict.Count != 0) return skillDict[skillName];
            else
            {
                skillDict = Searcher.DefaultSkillList.Where(s => s.Key == skillName).ToDictionary(s => s.Key, s => s.Value);

                if (skillDict.Count != 0) return skillDict[skillName];
                else
                {
                    MessageBox.Show("正しい技能名を入力してください。", "エラー", MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                    return null;
                }
            }
        }
    }
}
