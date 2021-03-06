﻿using System;
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

            iOData = IOData;

            checkBoxTopMost.Checked = IOData.Setting.checkTopMostFlg;
            checkBoxClipCheck.Checked = IOData.Setting.checkMessageFlg;
            webHookTextBox.Text = IOData.Setting.webhookURL;
            userNameTextBox.Text = IOData.Setting.userName;
            comboBoxFont.Text = (IOData.Setting.font != "" && IOData.Setting.font != null) ? IOData.Setting.font : this.Font.Name.ToString();
            comboBoxFontSize.Text = (IOData.Setting.fontSize.ToString() != "" && IOData.Setting.fontSize != 0)?
                 IOData.Setting.fontSize.ToString() : this.Font.Size.ToString();
            this.Font = new Font(comboBoxFont.Text, int.Parse(comboBoxFontSize.Text));

            if (IOData.Setting.webhookURL != "" && 
                (IOData.Setting.userName != "" || IOData.Setting.charaNameToUserNameFlg))
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

            if (IOData.Setting.charaNameToUserNameFlg)
                userNameTextBox.Enabled = false;
            else
                userNameTextBox.Enabled = true;
            charaNameToUserNameCheckBox.Checked = IOData.Setting.charaNameToUserNameFlg;

            if (IOData.Setting.offlineMode)
                offlineModeChecked(true);
            else
                offlineModeChecked(false);

        }

        private void buttonDecide_Click(object sender, EventArgs e)
        {
            iOData.Setting.checkTopMostFlg = checkBoxTopMost.Checked;
            iOData.Setting.checkMessageFlg = checkBoxClipCheck.Checked;
            iOData.Setting.offlineMode = offlineModeCheckBox.Checked;

            iOData.Setting.webhookURL = webHookTextBox.Text;
            iOData.Setting.useWebhookFlg = webhookYesRadioButton.Checked;

            if (webHookTextBox.Text == "" || userNameTextBox.Text == "")
               webhookYesRadioButton.Checked = false;
            else
               webhookYesRadioButton.Checked = iOData.Setting.useWebhookFlg;

            iOData.Setting.bcdiceAPIURL = bcdiceAPITextBox.Text;
            iOData.Setting.useBCDiceAPIFlg = radioButton2.Checked;

            if (userNameTextBox.Text != iOData.Searcher.characterInfos.characterName
                && charaNameToUserNameCheckBox.Checked)
                iOData.Setting.userName = iOData.Searcher.characterInfos.characterName;
            else
                iOData.Setting.userName = userNameTextBox.Text;
            iOData.Setting.charaNameToUserNameFlg = charaNameToUserNameCheckBox.Checked;

            iOData.Setting.font = comboBoxFont.Text;
            iOData.Setting.fontSize = int.Parse(comboBoxFontSize.Text);

            OK = true;
            this.Close();
        }

        private void webHookTextBox_TextChanged(object sender, EventArgs e)
        {
            if (webHookTextBox.Text == "" || 
                (userNameTextBox.Text == "" && !charaNameToUserNameCheckBox.Checked))
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
            if (webHookTextBox.Text == "" ||
                (userNameTextBox.Text == "" && !charaNameToUserNameCheckBox.Checked))
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

        private void charaNameToUserNameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (charaNameToUserNameCheckBox.Checked)
            {
                userNameTextBox.Enabled = false;
            }
            else
            {
                userNameTextBox.Enabled = true;
            }

            if (userNameTextBox.Text == "" && userNameTextBox.Enabled)
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

        private void offlineModeChecked(bool check)
        {
            offlineModeCheckBox.Checked = check;
            webHookTextBox.Enabled = !check;
            userNameTextBox.Enabled = !check;
            
            webhookYesRadioButton.Enabled = !check;
            webhookNoRadioButton.Enabled = !check;

            bcdiceAPITextBox.Enabled = !check;
            radioButton2.Enabled = !check;
            radioButton1.Enabled = !check;
            
            userNameTextBox.Enabled = !check;
            charaNameToUserNameCheckBox.Enabled = !check;
        }

        private void offlineModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            offlineModeChecked(offlineModeCheckBox.Checked);
        }
    }
}
