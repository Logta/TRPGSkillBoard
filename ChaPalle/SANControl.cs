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
            string setSanCheck = "SANチェック文：" + PalletMaster.GetBotDiceText(textSANValue.Text);
            label7.Text = setSanCheck;
            PalletMaster.SetClipBoard(PalletMaster.GetBotDiceText(textSANValue.Text));
        }

        //「SAN増減→判定」を押したときの制御
        private void buttonSANUpDown_Click(object sender, EventArgs e)
        {
            string setSanCheck = PalletMaster.Setting.useDiceBotFlg == 0 ? comboBox1.Text + "d" + comboBox2.Text
                : "/r " + comboBox1.Text + "d" + comboBox2.Text;
            label8.Text = setSanCheck;
            PalletMaster.SetClipBoard(setSanCheck);
        }

        //「SANチェック→+」を押したときの制御
        private void buttonSANUp_Click(object sender, EventArgs e)
        {
            textSANValue.Text = Convert.ToString(int.Parse(textSANValue.Text) + int.Parse(comboBoxSANValue.Text));
        }

        //「SANチェック→-」を押したときの制御
        private void buttonSANDown_Click(object sender, EventArgs e)
        {
            int sanVaule; //現在SAN値
            int sanDiff; //SAN変動値

            if (int.TryParse(textSANValue.Text, out sanVaule) && int.TryParse(comboBoxSANValue.Text, out sanDiff))
            {
                textSANValue.Text = Convert.ToString(sanVaule - sanDiff);

                //一時的発狂と不定の狂気の判定
                if (sanDiff >= sanVaule / 5)
                {
                    MessageBox.Show("不定の狂気です。1d10をクリップボードにコピーしました",
                        "不定の狂気",
                        MessageBoxButtons.OK);

                    var m_setText = PalletMaster.Setting.useDiceBotFlg == 0 ? "1d10" : "/r 1d10";

                    Clipboard.SetText(m_setText);
                }
                else if (sanDiff >= 5)
                {
                    int ideaValue;
                    if (int.TryParse(PalletMaster.Searcher.abilityValueList["INT"], out ideaValue))
                    {
                        var m_setText = PalletMaster.GetBotDiceText(Convert.ToString(ideaValue * 5));

                        Clipboard.SetText(m_setText);

                        MessageBox.Show("一時的発狂です。アイデアロールをクリップボードにコピーしました",
                        "一時的発狂",
                        MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("一時的発狂です。アイデアロールをしてください。",
                        "一時的発狂",
                        MessageBoxButtons.OK);
                        return;
                    }
                }
            }
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

    }
}
