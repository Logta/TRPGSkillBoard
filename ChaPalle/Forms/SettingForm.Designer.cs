namespace PalletMaster
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.checkBoxTopMost = new System.Windows.Forms.CheckBox();
            this.buttonDecide = new System.Windows.Forms.Button();
            this.checkBoxClipCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.charaNameToUserNameCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.webhookNoRadioButton = new System.Windows.Forms.RadioButton();
            this.webhookYesRadioButton = new System.Windows.Forms.RadioButton();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.webHookTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.bcdiceAPITextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxFont = new System.Windows.Forms.ComboBox();
            this.comboBoxFontSize = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxTopMost
            // 
            this.checkBoxTopMost.AutoSize = true;
            this.checkBoxTopMost.Location = new System.Drawing.Point(15, 16);
            this.checkBoxTopMost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxTopMost.Name = "checkBoxTopMost";
            this.checkBoxTopMost.Size = new System.Drawing.Size(192, 16);
            this.checkBoxTopMost.TabIndex = 0;
            this.checkBoxTopMost.Text = "アプリを常に最前面に表示する";
            this.checkBoxTopMost.UseVisualStyleBackColor = true;
            // 
            // buttonDecide
            // 
            this.buttonDecide.Location = new System.Drawing.Point(120, 379);
            this.buttonDecide.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDecide.Name = "buttonDecide";
            this.buttonDecide.Size = new System.Drawing.Size(87, 29);
            this.buttonDecide.TabIndex = 17;
            this.buttonDecide.Text = "決定";
            this.buttonDecide.UseVisualStyleBackColor = true;
            this.buttonDecide.Click += new System.EventHandler(this.buttonDecide_Click);
            // 
            // checkBoxClipCheck
            // 
            this.checkBoxClipCheck.AutoSize = true;
            this.checkBoxClipCheck.Location = new System.Drawing.Point(15, 44);
            this.checkBoxClipCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxClipCheck.Name = "checkBoxClipCheck";
            this.checkBoxClipCheck.Size = new System.Drawing.Size(288, 16);
            this.checkBoxClipCheck.TabIndex = 18;
            this.checkBoxClipCheck.Text = "クリップボードにコピーするとき確認を表示する";
            this.checkBoxClipCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.charaNameToUserNameCheckBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.webhookNoRadioButton);
            this.groupBox1.Controls.Add(this.webhookYesRadioButton);
            this.groupBox1.Controls.Add(this.userNameTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.webHookTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 139);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Webhook通信";
            // 
            // charaNameToUserNameCheckBox
            // 
            this.charaNameToUserNameCheckBox.AutoSize = true;
            this.charaNameToUserNameCheckBox.Checked = true;
            this.charaNameToUserNameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.charaNameToUserNameCheckBox.Location = new System.Drawing.Point(59, 94);
            this.charaNameToUserNameCheckBox.Name = "charaNameToUserNameCheckBox";
            this.charaNameToUserNameCheckBox.Size = new System.Drawing.Size(240, 16);
            this.charaNameToUserNameCheckBox.TabIndex = 7;
            this.charaNameToUserNameCheckBox.Text = "ユーザー名にキャラクター名を使用する";
            this.charaNameToUserNameCheckBox.UseVisualStyleBackColor = true;
            this.charaNameToUserNameCheckBox.CheckedChanged += new System.EventHandler(this.charaNameToUserNameCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Webhook通信";
            // 
            // webhookNoRadioButton
            // 
            this.webhookNoRadioButton.AutoSize = true;
            this.webhookNoRadioButton.Checked = true;
            this.webhookNoRadioButton.Location = new System.Drawing.Point(215, 114);
            this.webhookNoRadioButton.Name = "webhookNoRadioButton";
            this.webhookNoRadioButton.Size = new System.Drawing.Size(83, 16);
            this.webhookNoRadioButton.TabIndex = 5;
            this.webhookNoRadioButton.TabStop = true;
            this.webhookNoRadioButton.Text = "利用しない";
            this.webhookNoRadioButton.UseVisualStyleBackColor = true;
            // 
            // webhookYesRadioButton
            // 
            this.webhookYesRadioButton.AutoSize = true;
            this.webhookYesRadioButton.Location = new System.Drawing.Point(141, 114);
            this.webhookYesRadioButton.Name = "webhookYesRadioButton";
            this.webhookYesRadioButton.Size = new System.Drawing.Size(71, 16);
            this.webhookYesRadioButton.TabIndex = 4;
            this.webhookYesRadioButton.Text = "利用する";
            this.webhookYesRadioButton.UseVisualStyleBackColor = true;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(175, 69);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(125, 19);
            this.userNameTextBox.TabIndex = 3;
            this.userNameTextBox.TextChanged += new System.EventHandler(this.userNameTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "ユーザー名";
            // 
            // webHookTextBox
            // 
            this.webHookTextBox.Location = new System.Drawing.Point(10, 42);
            this.webHookTextBox.Name = "webHookTextBox";
            this.webHookTextBox.Size = new System.Drawing.Size(290, 19);
            this.webHookTextBox.TabIndex = 1;
            this.webHookTextBox.TextChanged += new System.EventHandler(this.webHookTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Webhook URL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.bcdiceAPITextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(13, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 92);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BCDice-API";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(215, 69);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(83, 16);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "利用しない";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(141, 69);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 16);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "利用する";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // bcdiceAPITextBox
            // 
            this.bcdiceAPITextBox.Location = new System.Drawing.Point(10, 42);
            this.bcdiceAPITextBox.Name = "bcdiceAPITextBox";
            this.bcdiceAPITextBox.Size = new System.Drawing.Size(290, 19);
            this.bcdiceAPITextBox.TabIndex = 1;
            this.bcdiceAPITextBox.TextChanged += new System.EventHandler(this.bcdiceAPITextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "BCDice-API URL";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxFont);
            this.groupBox3.Controls.Add(this.comboBoxFontSize);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(15, 314);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(306, 62);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Font";
            // 
            // comboBoxFont
            // 
            this.comboBoxFont.FormattingEnabled = true;
            this.comboBoxFont.Items.AddRange(new object[] {
            "UD デジタル 教科書体 N-B",
            "メイリオ",
            "MS UI Gothic",
            "Times New Roman",
            "Charter"});
            this.comboBoxFont.Location = new System.Drawing.Point(10, 32);
            this.comboBoxFont.Name = "comboBoxFont";
            this.comboBoxFont.Size = new System.Drawing.Size(121, 20);
            this.comboBoxFont.TabIndex = 4;
            // 
            // comboBoxFontSize
            // 
            this.comboBoxFontSize.FormattingEnabled = true;
            this.comboBoxFontSize.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxFontSize.Location = new System.Drawing.Point(159, 32);
            this.comboBoxFontSize.Name = "comboBoxFontSize";
            this.comboBoxFontSize.Size = new System.Drawing.Size(121, 20);
            this.comboBoxFontSize.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "サイズ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "種類";
            // 
            // SettingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(331, 411);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxClipCheck);
            this.Controls.Add(this.buttonDecide);
            this.Controls.Add(this.checkBoxTopMost);
            this.Font = new System.Drawing.Font("UD デジタル 教科書体 N-B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(347, 450);
            this.MinimumSize = new System.Drawing.Size(347, 450);
            this.Name = "SettingForm";
            this.Text = "設定";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxTopMost;
        private System.Windows.Forms.Button buttonDecide;
        private System.Windows.Forms.CheckBox checkBoxClipCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox webHookTextBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton webhookNoRadioButton;
        private System.Windows.Forms.RadioButton webhookYesRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox bcdiceAPITextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox charaNameToUserNameCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxFontSize;
        private System.Windows.Forms.ComboBox comboBoxFont;
    }
}