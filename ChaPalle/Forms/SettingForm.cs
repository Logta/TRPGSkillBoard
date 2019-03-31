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
    public partial class SettingForm : Form
    {
        public bool OK = false;
        public PalletMaster iOData = new PalletMaster();

        public SettingForm(PalletMaster IOData)
        {
            InitializeComponent();
            checkBoxTopMost.Checked = IOData.Setting.checkTopMostFlg;
            checkBoxClipCheck.Checked = IOData.Setting.checkMessageFlg;
            webHookTextBox.Text = IOData.Setting.webhookURL;
            userNameTextBox.Text = IOData.Setting.userName;
            if (IOData.Setting.webhookURL != "" && IOData.Setting.userName != "")
            {
                webhookYesRadioButton.Checked = IOData.Setting.useWebhookFlg;
                webhookNoRadioButton.Checked = !IOData.Setting.useWebhookFlg;
            }
            else
            {
                webhookYesRadioButton.Checked = false;
                webhookNoRadioButton.Checked = true;
                webhookYesRadioButton.Enabled = false;
                webhookNoRadioButton.Enabled = false;
            }
            bcdiceAPITextBox.Text = IOData.Setting.bcdiceAPIURL;
            if (IOData.Setting.bcdiceAPIURL != "")
            {
                radioButton2.Checked = IOData.Setting.useWebhookFlg;
                radioButton1.Checked = !IOData.Setting.useWebhookFlg;
            }
            else
            {
                radioButton2.Checked = false;
                radioButton1.Checked = true;
                radioButton2.Enabled = false;
                radioButton1.Enabled = false;
            }
        }

        private void buttonDecide_Click(object sender, EventArgs e)
        {
            iOData.Setting.checkTopMostFlg = checkBoxTopMost.Checked;
            iOData.Setting.checkMessageFlg = checkBoxClipCheck.Checked;
            iOData.Setting.webhookURL = webHookTextBox.Text;
            iOData.Setting.userName = userNameTextBox.Text;
            iOData.Setting.useWebhookFlg = webhookYesRadioButton.Checked;
            if (webHookTextBox.Text == "" || userNameTextBox.Text == "")
               webhookYesRadioButton.Checked = false;
            else
               webhookYesRadioButton.Checked = iOData.Setting.useWebhookFlg;
            iOData.Setting.bcdiceAPIURL = bcdiceAPITextBox.Text;
            iOData.Setting.useBCDiceAPIFlg = radioButton2.Checked;
            
            OK = true;
            this.Close();
        }

        private void webHookTextBox_TextChanged(object sender, EventArgs e)
        {
            if (webHookTextBox.Text == "" || userNameTextBox.Text == "")
            {
                webhookYesRadioButton.Enabled = false;
                webhookNoRadioButton.Enabled = false;
            }
            else
            {
                webhookYesRadioButton.Enabled = true;
                webhookNoRadioButton.Enabled = true;
            }
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (webHookTextBox.Text == "" || userNameTextBox.Text == "")
            {
                webhookYesRadioButton.Enabled = false;
                webhookNoRadioButton.Enabled = false;
            }
            else
            {
                webhookYesRadioButton.Enabled = true;
                webhookNoRadioButton.Enabled = true;
            }
        }

        private void bcdiceAPITextBox_TextChanged(object sender, EventArgs e)
        {
            if (bcdiceAPITextBox.Text == "")
            {
                radioButton2.Enabled = false;
                radioButton1.Enabled = false;
            }
            else
            {
                radioButton2.Enabled = true;
                radioButton1.Enabled = true;
            }
        }
    }
}
