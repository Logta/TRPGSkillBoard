using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalletMaster
{
    public partial class MinimumForm : Form
    {
        PalletMaster PalletMaster = new PalletMaster();

        public MinimumForm(PalletMaster palletMaster)
        {
            PalletMaster = palletMaster;
            InitializeComponent();

            TopMost = true;
            new Proccess().RefreshSkillList(listViewSkill, PalletMaster.Searcher.uniqueSkills);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSerch_Click(object sender, EventArgs e)
        {
            var value = PalletMaster.toSearchSkillValue(textSerch.Text);
            if (value is null) return;

            PalletMaster.SetTextRole(value, textSerch.Text);

            PalletMaster.SetSkillHistory(textSerch.Text, ロール.技能);
        }

        private void listViewSkill_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //項目が１つも選択されていない場合
            if (listViewSkill.SelectedItems.Count == 0)
                return;//処理を抜ける

            ListViewItem itemx = new ListViewItem();

            //1番目に選択されれいるアイテムをitemxに格納
            itemx = listViewSkill.SelectedItems[0];

            //選択されているアイテムを取得する
            var tValue = PalletMaster.GetDiceText(itemx.SubItems[1].Text, itemx.Text);
            PalletMaster.SetTextRole(tValue, itemx.Text);
            PalletMaster.SetSkillHistory(itemx.Text, ロール.技能);
        }

        private void listViewSkill_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Enterを押したときのみ反応するよう設定
            if (e.KeyChar == (char)Keys.Enter)
            {
                var value = PalletMaster.toSearchSkillValue(textSerch.Text);
                if (value is null) return;
               
                PalletMaster.SetTextRole(value, textSerch.Text);
                
                PalletMaster.SetSkillHistory(textSerch.Text, ロール.技能);
            }
        }
    }
}
