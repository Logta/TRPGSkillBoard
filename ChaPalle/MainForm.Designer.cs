namespace ChaPalle
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textSkill = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textValue = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.skill = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.textResult = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonClipboardCopy = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSerch = new System.Windows.Forms.Button();
            this.textSerch = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCSV = new System.Windows.Forms.Button();
            this.textCSV = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.キャラクター保管所ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonBCDice = new System.Windows.Forms.Button();
            this.buttonSideKick = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabCthu = new System.Windows.Forms.TabControl();
            this.tabPageSkill = new System.Windows.Forms.TabPage();
            this.tabPageSAN = new System.Windows.Forms.TabPage();
            this.buttonSANDown = new System.Windows.Forms.Button();
            this.buttonSANUp = new System.Windows.Forms.Button();
            this.textSANValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonSANUpDown = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonSANCheck = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPageFight = new System.Windows.Forms.TabPage();
            this.cSVImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabCthu.SuspendLayout();
            this.tabPageSkill.SuspendLayout();
            this.tabPageSAN.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textSkill
            // 
            this.textSkill.Location = new System.Drawing.Point(57, 25);
            this.textSkill.Name = "textSkill";
            this.textSkill.Size = new System.Drawing.Size(100, 19);
            this.textSkill.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(326, 23);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "追加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "技能";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "値";
            // 
            // textValue
            // 
            this.textValue.Location = new System.Drawing.Point(194, 25);
            this.textValue.Name = "textValue";
            this.textValue.Size = new System.Drawing.Size(100, 19);
            this.textValue.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.skill,
            this.value});
            this.listView1.Location = new System.Drawing.Point(14, 57);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(198, 202);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // skill
            // 
            this.skill.Text = "技能";
            this.skill.Width = 120;
            // 
            // value
            // 
            this.value.Text = "値";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "結果：";
            // 
            // textResult
            // 
            this.textResult.Location = new System.Drawing.Point(228, 228);
            this.textResult.Name = "textResult";
            this.textResult.Size = new System.Drawing.Size(171, 19);
            this.textResult.TabIndex = 7;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(137, 262);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "削除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonClipboardCopy
            // 
            this.buttonClipboardCopy.Location = new System.Drawing.Point(285, 253);
            this.buttonClipboardCopy.Name = "buttonClipboardCopy";
            this.buttonClipboardCopy.Size = new System.Drawing.Size(114, 23);
            this.buttonClipboardCopy.TabIndex = 9;
            this.buttonClipboardCopy.Text = "クリップボードにコピー";
            this.buttonClipboardCopy.UseVisualStyleBackColor = true;
            this.buttonClipboardCopy.Click += new System.EventHandler(this.buttonClipboardCopy_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSerch);
            this.groupBox1.Controls.Add(this.textSerch);
            this.groupBox1.Location = new System.Drawing.Point(218, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 51);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索";
            // 
            // buttonSerch
            // 
            this.buttonSerch.Location = new System.Drawing.Point(121, 14);
            this.buttonSerch.Name = "buttonSerch";
            this.buttonSerch.Size = new System.Drawing.Size(52, 23);
            this.buttonSerch.TabIndex = 11;
            this.buttonSerch.Text = "検索";
            this.buttonSerch.UseVisualStyleBackColor = true;
            this.buttonSerch.Click += new System.EventHandler(this.buttonSerch_Click);
            // 
            // textSerch
            // 
            this.textSerch.Location = new System.Drawing.Point(10, 18);
            this.textSerch.Name = "textSerch";
            this.textSerch.Size = new System.Drawing.Size(100, 19);
            this.textSerch.TabIndex = 11;
            this.textSerch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textSerch_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.buttonCSV);
            this.groupBox2.Controls.Add(this.textCSV);
            this.groupBox2.Location = new System.Drawing.Point(218, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 63);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CSV読み込み";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "ファイル名";
            // 
            // buttonCSV
            // 
            this.buttonCSV.Location = new System.Drawing.Point(121, 36);
            this.buttonCSV.Name = "buttonCSV";
            this.buttonCSV.Size = new System.Drawing.Size(52, 23);
            this.buttonCSV.TabIndex = 12;
            this.buttonCSV.Text = "読込";
            this.buttonCSV.UseVisualStyleBackColor = true;
            this.buttonCSV.Click += new System.EventHandler(this.button1_Click);
            // 
            // textCSV
            // 
            this.textCSV.Location = new System.Drawing.Point(6, 38);
            this.textCSV.Name = "textCSV";
            this.textCSV.Size = new System.Drawing.Size(100, 19);
            this.textCSV.TabIndex = 12;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.userToolStripMenuItem,
            this.textImportToolStripMenuItem,
            this.cSVImportToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(464, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Enabled = false;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // textImportToolStripMenuItem
            // 
            this.textImportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.キャラクター保管所ToolStripMenuItem});
            this.textImportToolStripMenuItem.Name = "textImportToolStripMenuItem";
            this.textImportToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.textImportToolStripMenuItem.Text = "TextImport";
            // 
            // キャラクター保管所ToolStripMenuItem
            // 
            this.キャラクター保管所ToolStripMenuItem.Name = "キャラクター保管所ToolStripMenuItem";
            this.キャラクター保管所ToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.キャラクター保管所ToolStripMenuItem.Text = "キャラクター保管所";
            this.キャラクター保管所ToolStripMenuItem.Click += new System.EventHandler(this.キャラクター保管所ToolStripMenuItem_Click);
            // 
            // buttonBCDice
            // 
            this.buttonBCDice.Enabled = false;
            this.buttonBCDice.Location = new System.Drawing.Point(43, 27);
            this.buttonBCDice.Name = "buttonBCDice";
            this.buttonBCDice.Size = new System.Drawing.Size(75, 23);
            this.buttonBCDice.TabIndex = 13;
            this.buttonBCDice.Text = "bcdice";
            this.buttonBCDice.UseVisualStyleBackColor = true;
            this.buttonBCDice.Click += new System.EventHandler(this.buttonBCDice_Click);
            // 
            // buttonSideKick
            // 
            this.buttonSideKick.Location = new System.Drawing.Point(124, 27);
            this.buttonSideKick.Name = "buttonSideKick";
            this.buttonSideKick.Size = new System.Drawing.Size(75, 23);
            this.buttonSideKick.TabIndex = 14;
            this.buttonSideKick.Text = "SideKick";
            this.buttonSideKick.UseVisualStyleBackColor = true;
            this.buttonSideKick.Click += new System.EventHandler(this.buttonSideKick_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "使用ダイスbot";
            // 
            // tabCthu
            // 
            this.tabCthu.Controls.Add(this.tabPageSkill);
            this.tabCthu.Controls.Add(this.tabPageSAN);
            this.tabCthu.Controls.Add(this.tabPageFight);
            this.tabCthu.Location = new System.Drawing.Point(12, 56);
            this.tabCthu.Name = "tabCthu";
            this.tabCthu.SelectedIndex = 0;
            this.tabCthu.Size = new System.Drawing.Size(440, 322);
            this.tabCthu.TabIndex = 16;
            this.tabCthu.Click += new System.EventHandler(this.tabPageSAN_Click);
            // 
            // tabPageSkill
            // 
            this.tabPageSkill.Controls.Add(this.listView1);
            this.tabPageSkill.Controls.Add(this.textSkill);
            this.tabPageSkill.Controls.Add(this.buttonAdd);
            this.tabPageSkill.Controls.Add(this.label1);
            this.tabPageSkill.Controls.Add(this.groupBox2);
            this.tabPageSkill.Controls.Add(this.textValue);
            this.tabPageSkill.Controls.Add(this.groupBox1);
            this.tabPageSkill.Controls.Add(this.label2);
            this.tabPageSkill.Controls.Add(this.buttonClipboardCopy);
            this.tabPageSkill.Controls.Add(this.label3);
            this.tabPageSkill.Controls.Add(this.buttonDelete);
            this.tabPageSkill.Controls.Add(this.textResult);
            this.tabPageSkill.Location = new System.Drawing.Point(4, 22);
            this.tabPageSkill.Name = "tabPageSkill";
            this.tabPageSkill.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSkill.Size = new System.Drawing.Size(432, 296);
            this.tabPageSkill.TabIndex = 0;
            this.tabPageSkill.Text = "技能";
            this.tabPageSkill.UseVisualStyleBackColor = true;
            // 
            // tabPageSAN
            // 
            this.tabPageSAN.Controls.Add(this.buttonSANDown);
            this.tabPageSAN.Controls.Add(this.buttonSANUp);
            this.tabPageSAN.Controls.Add(this.textSANValue);
            this.tabPageSAN.Controls.Add(this.label6);
            this.tabPageSAN.Controls.Add(this.groupBox4);
            this.tabPageSAN.Controls.Add(this.groupBox3);
            this.tabPageSAN.Location = new System.Drawing.Point(4, 22);
            this.tabPageSAN.Name = "tabPageSAN";
            this.tabPageSAN.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSAN.Size = new System.Drawing.Size(432, 296);
            this.tabPageSAN.TabIndex = 1;
            this.tabPageSAN.Text = "SAN値";
            this.tabPageSAN.UseVisualStyleBackColor = true;
            this.tabPageSAN.Click += new System.EventHandler(this.tabPageSAN_Click);
            // 
            // buttonSANDown
            // 
            this.buttonSANDown.Location = new System.Drawing.Point(229, 10);
            this.buttonSANDown.Name = "buttonSANDown";
            this.buttonSANDown.Size = new System.Drawing.Size(20, 23);
            this.buttonSANDown.TabIndex = 18;
            this.buttonSANDown.Text = "-";
            this.buttonSANDown.UseVisualStyleBackColor = true;
            this.buttonSANDown.Click += new System.EventHandler(this.buttonSANDown_Click);
            // 
            // buttonSANUp
            // 
            this.buttonSANUp.Location = new System.Drawing.Point(203, 10);
            this.buttonSANUp.Name = "buttonSANUp";
            this.buttonSANUp.Size = new System.Drawing.Size(20, 23);
            this.buttonSANUp.TabIndex = 17;
            this.buttonSANUp.Text = "+";
            this.buttonSANUp.UseVisualStyleBackColor = true;
            this.buttonSANUp.Click += new System.EventHandler(this.buttonSANUp_Click);
            // 
            // textSANValue
            // 
            this.textSANValue.Location = new System.Drawing.Point(97, 12);
            this.textSANValue.Name = "textSANValue";
            this.textSANValue.Size = new System.Drawing.Size(100, 19);
            this.textSANValue.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "現在SAN値";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonSANUpDown);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.comboBox2);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(18, 155);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(374, 100);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SAN増減";
            // 
            // buttonSANUpDown
            // 
            this.buttonSANUpDown.Location = new System.Drawing.Point(142, 37);
            this.buttonSANUpDown.Name = "buttonSANUpDown";
            this.buttonSANUpDown.Size = new System.Drawing.Size(75, 23);
            this.buttonSANUpDown.TabIndex = 15;
            this.buttonSANUpDown.Text = "判定";
            this.buttonSANUpDown.UseVisualStyleBackColor = true;
            this.buttonSANUpDown.Click += new System.EventHandler(this.buttonSANUpDown_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "D";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "100",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "80",
            "90"});
            this.comboBox2.Location = new System.Drawing.Point(69, 39);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(33, 20);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.Text = "2";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBox1.Location = new System.Drawing.Point(11, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(33, 20);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "----";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonSANCheck);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(18, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(374, 100);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SANチェック";
            // 
            // buttonSANCheck
            // 
            this.buttonSANCheck.Location = new System.Drawing.Point(11, 27);
            this.buttonSANCheck.Name = "buttonSANCheck";
            this.buttonSANCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonSANCheck.TabIndex = 14;
            this.buttonSANCheck.Text = "判定";
            this.buttonSANCheck.UseVisualStyleBackColor = true;
            this.buttonSANCheck.Click += new System.EventHandler(this.buttonSANCheck_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "SANチェック文：";
            // 
            // tabPageFight
            // 
            this.tabPageFight.Location = new System.Drawing.Point(4, 22);
            this.tabPageFight.Name = "tabPageFight";
            this.tabPageFight.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFight.Size = new System.Drawing.Size(432, 296);
            this.tabPageFight.TabIndex = 2;
            this.tabPageFight.Text = "戦闘";
            this.tabPageFight.UseVisualStyleBackColor = true;
            // 
            // cSVImportToolStripMenuItem
            // 
            this.cSVImportToolStripMenuItem.Name = "cSVImportToolStripMenuItem";
            this.cSVImportToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.cSVImportToolStripMenuItem.Text = "CSVImport";
            this.cSVImportToolStripMenuItem.Click += new System.EventHandler(this.cSVImportToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 390);
            this.Controls.Add(this.tabCthu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonSideKick);
            this.Controls.Add(this.buttonBCDice);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "チャッパレ(仮)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabCthu.ResumeLayout(false);
            this.tabPageSkill.ResumeLayout(false);
            this.tabPageSkill.PerformLayout();
            this.tabPageSAN.ResumeLayout(false);
            this.tabPageSAN.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textSkill;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textValue;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader skill;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonClipboardCopy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSerch;
        private System.Windows.Forms.TextBox textSerch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonCSV;
        private System.Windows.Forms.TextBox textCSV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button buttonBCDice;
        private System.Windows.Forms.Button buttonSideKick;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.TabControl tabCthu;
        private System.Windows.Forms.TabPage tabPageSkill;
        private System.Windows.Forms.TabPage tabPageSAN;
        private System.Windows.Forms.TabPage tabPageFight;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textSANValue;
        private System.Windows.Forms.Button buttonSANCheck;
        private System.Windows.Forms.Button buttonSANUpDown;
        private System.Windows.Forms.ToolStripMenuItem textImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem キャラクター保管所ToolStripMenuItem;
        private System.Windows.Forms.Button buttonSANDown;
        private System.Windows.Forms.Button buttonSANUp;
        private System.Windows.Forms.ToolStripMenuItem cSVImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
    }
}

