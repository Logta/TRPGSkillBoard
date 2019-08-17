using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalletMaster
{
    public partial class FightControl : UserControl
    {
        PalletMaster PalletMaster = new PalletMaster();
        FightDamage FightDamage = new FightDamage();

        string attackSkill = "";

        public FightControl()
        {
            InitializeComponent();

            FightDamage = new IOHelper().ReadFightDamageJson();
        }

        public void SetPalletMaster(PalletMaster palletMaster)
        {
            PalletMaster = palletMaster;
        }

        internal void SetFightText(string v)
        {
            labelHPValue.Text = PalletMaster.Searcher.searcherInfos["HP"];
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
            attackSkill = attackLabel.Text = itemx.Text;
            string tValue = PalletMaster.GetDiceText(itemx.SubItems[1].Text, itemx.Text);
            PalletMaster.SetTextRole(tValue, attackSkill);
            PalletMaster.SetSkillHistory(itemx.Text, ロール.技能);
        }

        string getSkillValue(string skillName)
        {

            try
            {
                PalletMaster.SetSkillHistory(skillName, ロール.技能);
                return (PalletMaster.GetDiceText(PalletMaster.Searcher.getSkillValue(skillName), skillName));
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
            PalletMaster.SetTextRole(avoidDiceRole, "回避");
        }

        private void buttonFist_Click(object sender, EventArgs e)
        {
            attackSkill = attackLabel.Text = "こぶし（パンチ）";
            string fistDiceRole = getSkillValue("こぶし（パンチ）");
            PalletMaster.SetTextRole(fistDiceRole, "こぶし（パンチ）");
        }

        private void buttonKick_Click(object sender, EventArgs e)
        {
            attackSkill = attackLabel.Text = "キック";
            string kickDiceRole = getSkillValue("キック");
            PalletMaster.SetTextRole(kickDiceRole, "キック");
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

            if (!float.TryParse(labelHPValue.Text, out hp) ||
                !int.TryParse(comboBoxHPValue.Text, out hpDiff)) return;

            labelHPValue.Text = Convert.ToString(hp - hpDiff);

            if (hp - hpDiff <= 2)
                MessageBox.Show("気絶しました。", "気絶", MessageBoxButtons.OK);
            else if (hp / 2 <= hpDiff)
            {
                MessageBox.Show("気絶ロールが発生しました。",
                    "気絶ロール",
                MessageBoxButtons.OK);
            }
        }

        internal void SetFightDamageBonusText(string v)
        {
            damageBonusTextBox.Text = v;
        }

        private void buttonAddFight_Click(object sender, EventArgs e)
        {
            string tSkill = textSkillFight.Text;
            int tValue = int.TryParse(textValueFight.Text, out var v) ? v : -1;

            if (tSkill == "" || textValueFight.Text == "")
            {
                MessageBox.Show("各値を入力してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (tValue == -1)
            {
                MessageBox.Show("数字を入力してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            PalletMaster.Searcher.SetSkill(new Skill(tSkill, tValue, "戦闘"));

            PalletMaster.Searcher.CheckUnique();
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
            PalletMaster.Searcher.RemoveSkills(itemx.Text);
            PalletMaster.Searcher.CheckUnique();
            PalletMaster.RefreshListView();
        }

        public void RefreshSkillList()
        {
            Proccess.RefreshSkillList(listViewFight, PalletMaster.Searcher.skills.FindAll(s => s.type == "戦闘"));
        }

        private void attack_Click(object sender, EventArgs e)
        {
            try
            {
                var damageText = FightDamage.fightSkillDamage[attackSkill] + damageBonusTextBox.Text;

                MessageBox.Show("攻撃値：" + Proccess.TotalDice(damageText).Sum(), "攻撃値",
                MessageBoxButtons.OK);
                
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private void ButtonShockRole_Click(object sender, EventArgs e)
        {
            var con = int.TryParse(PalletMaster.Searcher.abilityValues["CON"], out var m) ? m : -1;
            if (con == -1) return;

            PalletMaster.SetTextRole(PalletMaster.GetDiceText(
                Convert.ToString(con * 5), "気絶ロール"),
                "気絶ロール"
                );
        }
    }
}
