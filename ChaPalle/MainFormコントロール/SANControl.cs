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
    public partial class SANControl : UserControl
    {
        PalletMaster PalletMaster = new PalletMaster();
        Proccess Proccesser = new Proccess();

        public SANControl()
        {
            InitializeComponent();
        }

        public void SetPalletMaster(PalletMaster palletMaster)
        {
            PalletMaster = palletMaster;
        }

        //「SANチェック→判定」を押したときの制御
        private void buttonSANCheck_Click(object sender, EventArgs e)
        {
            string setSanCheck = "SANチェック文：" + PalletMaster.GetDiceText(textSANValue.Text);
            label7.Text = setSanCheck;
            PalletMaster.SetTextRole(PalletMaster.GetDiceText(textSANValue.Text, "SANチェック"), "SANチェック");
        }

        //「SAN増減→判定」を押したときの制御
        private void buttonSANUpDown_Click(object sender, EventArgs e)
        {
            string setSanCheck = PalletMaster.Setting.useDiceBotFlg == 0 ? comboBox1.Text + "d" + comboBox2.Text
                : "/r " + comboBox1.Text + "d" + comboBox2.Text;
            label8.Text = setSanCheck;
            PalletMaster.SetTextRole(setSanCheck, "SAN増減数");
        }

        //「SANチェック→+」を押したときの制御
        private void buttonSANUp_Click(object sender, EventArgs e)
        {
            var sanValue = int.TryParse(textSANValue.Text, out var m) ? m : -1;
            var sanUpDownValue = int.TryParse(comboBoxSANValue.Text, out var n) ? n : -1;
            if (sanValue == -1 || sanUpDownValue == -1) return;

            SetSanText(Convert.ToString(sanValue + sanUpDownValue));
        }

        //「SANチェック→-」を押したときの制御
        private void buttonSANDown_Click(object sender, EventArgs e)
        {
            var sanVaule = int.TryParse(textSANValue.Text, out var m) ? m : -1 ; //現在SAN値
            var sanDiff = int.TryParse(comboBoxSANValue.Text, out var n) ? n : -1; //SAN変動値

            if ( sanVaule == -1 || sanDiff == -1) return;
            
            textSANValue.Text = Convert.ToString(sanVaule - sanDiff);

            //一時的発狂と不定の狂気の判定
            if (sanDiff >= sanVaule / 5)
            {
                indefiniteMadness();
            }
            else if (sanDiff >= 5)
            {
                temporaryInsanity();
            }
        }

        private void temporaryInsanity()
        {
            MessageBox.Show("一時的発狂です。アイデアロールをしてください。",
            "一時的発狂",
            MessageBoxButtons.OK);
            return;
        }

        private void indefiniteMadness()
        {
            MessageBox.Show("不定の狂気です。", "不定の狂気", MessageBoxButtons.OK);

            var m_setText = PalletMaster.Setting.useDiceBotFlg == 0 ? "1d10" : "/r 1d10";

            PalletMaster.SetTextRole(m_setText, "不定の狂気");
        }

        //狂気表の表示
        private void buttonMadnessTable_Click(object sender, EventArgs e)
        {
            MadnessTableForm u_form = new MadnessTableForm();
            PalletMaster.MainForm.TopMost = false;
            u_form.ShowDialog();

            PalletMaster.MainForm.TopMost = PalletMaster.Setting.checkTopMostFlg;
        }

        public string GetSanText()
        {
            return textSANValue.Text;
        }

        public void SetSanText(string sanText)
        {
            textSANValue.Text = sanText;
        }

        private void ButtonIdea_Click(object sender, EventArgs e)
        {
            if (PalletMaster.Searcher.skills.Count(s => s.name == "アイデア") == 0) return;
            var ideaValue = PalletMaster.Searcher.skills.Find(s => s.name == "アイデア").value;
            PalletMaster.SetTextRole(PalletMaster.GetDiceText(ideaValue.ToString(), "アイデア"), "アイデア");
        }
    }
}
