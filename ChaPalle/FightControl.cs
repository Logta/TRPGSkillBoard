using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaPalle
{
    public partial class FightControl : UserControl
    {
        PalletMaster PalletMaster = new PalletMaster();
        Proccess Proccesser = new Proccess();

        public FightControl()
        {
            InitializeComponent();
        }

        public void SetPalletMaster(PalletMaster palletMaster)
        {
            PalletMaster = palletMaster;
        }

        internal void SetFightText(string v)
        {
            labelHPValue.Text = PalletMaster.Searcher.searcherInfoList["HP"];
        }

        //
        //
        //====================================戦闘タブ==========================
        //
        //
        private void listViewFight_SelectedIndexChanged(object sender, EventArgs e)
        {

            //項目が１つも選択されていない場合
            if (listViewFight.SelectedItems.Count == 0)
                //処理を抜ける
                return;

            ListViewItem itemx = new ListViewItem();

            //1番目に選択されれいるアイテムをitemxに格納
            itemx = listViewFight.SelectedItems[0];

            //技能と値のテキストボックスに技能名、技能値を入れる
            textSkillFight.Text = itemx.Text;
            textValueFight.Text = itemx.SubItems[1].Text;
        }

        private void listViewFight_DoubleClick(object sender, EventArgs e)
        {

            //項目が１つも選択されていない場合
            if (listViewFight.SelectedItems.Count == 0)
                //処理を抜ける
                return;

            ListViewItem itemx = new ListViewItem();

            //1番目に選択されているアイテムをitemxに格納
            itemx = listViewFight.SelectedItems[0];

            //選択されているアイテムを取得する
            string tValue = PalletMaster.GetBotDiceText(itemx.SubItems[1].Text);
            PalletMaster.SetClipBoard(tValue);
            PalletMaster.SetSkillHistory(itemx.Text, ロール.技能);
        }

        string getSkillValue(string skillName)
        {

            try
            {
                PalletMaster.SetSkillHistory(skillName, ロール.技能);
                return (PalletMaster.GetBotDiceText(PalletMaster.Searcher.fightSkillList[skillName]));
            }
            catch (KeyNotFoundException)
            {
                MessageBox.Show(skillName + "を設定してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return "";
            }
        }

        private void buttonAvoid_Click(object sender, EventArgs e)
        {
            string avoidDiceRole = getSkillValue("回避");
            PalletMaster.SetClipBoard(avoidDiceRole);
        }

        private void buttonFist_Click(object sender, EventArgs e)
        {
            string fistDiceRole = getSkillValue("こぶし（パンチ）");
            PalletMaster.SetClipBoard(fistDiceRole);
        }

        private void buttonKick_Click(object sender, EventArgs e)
        {
            string kickDiceRole = getSkillValue("キック");
            PalletMaster.SetClipBoard(kickDiceRole);
        }

        private void buttonHPPlus_Click(object sender, EventArgs e)
        {
            int hp; //現在HP
            int hpDiff; //HP変動値

            if (int.TryParse(labelHPValue.Text, out hp) &&
                int.TryParse(comboBoxHPValue.Text, out hpDiff))
                labelHPValue.Text = Convert.ToString(hp + hpDiff);
        }

        private void buttonHPMinus_Click(object sender, EventArgs e)
        {
            float hp; //現在HP
            int hpDiff; //HP変動値

            if (float.TryParse(labelHPValue.Text, out hp) &&
                int.TryParse(comboBoxHPValue.Text, out hpDiff))
            {
                labelHPValue.Text = Convert.ToString(hp - hpDiff);

                if (hp - hpDiff <= 2)
                    MessageBox.Show("気絶しました。", "気絶", MessageBoxButtons.OK);
                else if (hp / 2 <= hpDiff)
                {
                    int m_con;
                    if (int.TryParse(PalletMaster.Searcher.abilityValueList["CON"], out m_con))
                    {
                        Clipboard.SetText(PalletMaster.GetBotDiceText(Convert.ToString(m_con * 5)));
                        MessageBox.Show("気絶ロールが発生しました。CON×5をクリップボードにコピーしました",
                        "気絶ロール",
                        MessageBoxButtons.OK);
                    }
                    else
                        MessageBox.Show("気絶ロールが発生しました。",
                            "気絶ロール",
                        MessageBoxButtons.OK);
                }
            }
        }

        private void buttonAddFight_Click(object sender, EventArgs e)
        {
            string tSkill = textSkillFight.Text;
            string tValue = textValueFight.Text;
            if (tSkill == "" || tValue == "")
            {
                MessageBox.Show("各値を入力してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            PalletMaster.Searcher.fightSkillList[tSkill] = tValue;

            PalletMaster.RefreshListView();
        }

        private void buttonDeleteFight_Click(object sender, EventArgs e)
        {

            //項目が１つも選択されていない場合
            if (listViewFight.SelectedItems.Count == 0)
                //処理を抜ける
                return;

            ListViewItem itemx = new ListViewItem();

            //1番目に選択されれいるアイテムをitemxに格納
            itemx = listViewFight.SelectedItems[0];

            //選択されているアイテムを取得、削除
            PalletMaster.Searcher.fightSkillList.Remove(itemx.Text);
            PalletMaster.RefreshListView();
        }

        public void RefreshSkillList()
        {
            Proccesser.RefreshSkillList(listViewFight, PalletMaster.Searcher.fightSkillList);
        }
    }
}
