﻿namespace ChaPalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.チャッパレ形式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.チャッパレ形式ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.キャラクター保管所ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.キャラクターアーカイブToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonBCDice = new System.Windows.Forms.Button();
            this.buttonSideKick = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabCthu = new System.Windows.Forms.TabControl();
            this.tabPageSkill = new System.Windows.Forms.TabPage();
            this.tabPageSAN = new System.Windows.Forms.TabPage();
            this.tabHistoryAblityRole = new System.Windows.Forms.TabPage();
            this.tabPageFight = new System.Windows.Forms.TabPage();
            this.memo = new System.Windows.Forms.TabPage();
            this.richTextBox1Memo = new System.Windows.Forms.RichTextBox();
            this.labelCharaName = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ClipboardLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.tabCthu.SuspendLayout();
            this.memo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.userToolStripMenuItem,
            this.textImportToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(541, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.チャッパレ形式ToolStripMenuItem,
            this.cSVToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "保存";
            // 
            // チャッパレ形式ToolStripMenuItem
            // 
            this.チャッパレ形式ToolStripMenuItem.Name = "チャッパレ形式ToolStripMenuItem";
            this.チャッパレ形式ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.チャッパレ形式ToolStripMenuItem.Text = "チャッパレ形式";
            this.チャッパレ形式ToolStripMenuItem.Click += new System.EventHandler(this.チャッパレ形式ToolStripMenuItem_Click);
            // 
            // cSVToolStripMenuItem
            // 
            this.cSVToolStripMenuItem.Enabled = false;
            this.cSVToolStripMenuItem.Name = "cSVToolStripMenuItem";
            this.cSVToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.cSVToolStripMenuItem.Text = "CSV";
            this.cSVToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.チャッパレ形式ToolStripMenuItem1,
            this.cSVToolStripMenuItem1});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.loadToolStripMenuItem.Text = "ロード";
            // 
            // チャッパレ形式ToolStripMenuItem1
            // 
            this.チャッパレ形式ToolStripMenuItem1.Name = "チャッパレ形式ToolStripMenuItem1";
            this.チャッパレ形式ToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.チャッパレ形式ToolStripMenuItem1.Text = "チャッパレ形式";
            this.チャッパレ形式ToolStripMenuItem1.Click += new System.EventHandler(this.チャッパレ形式ToolStripMenuItem1_Click);
            // 
            // cSVToolStripMenuItem1
            // 
            this.cSVToolStripMenuItem1.Enabled = false;
            this.cSVToolStripMenuItem1.Name = "cSVToolStripMenuItem1";
            this.cSVToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.cSVToolStripMenuItem1.Text = "CSV";
            this.cSVToolStripMenuItem1.Click += new System.EventHandler(this.CSVImportToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.userToolStripMenuItem.Text = "キャラ";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // textImportToolStripMenuItem
            // 
            this.textImportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.キャラクター保管所ToolStripMenuItem,
            this.キャラクターアーカイブToolStripMenuItem});
            this.textImportToolStripMenuItem.Name = "textImportToolStripMenuItem";
            this.textImportToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.textImportToolStripMenuItem.Text = "外部読込";
            // 
            // キャラクター保管所ToolStripMenuItem
            // 
            this.キャラクター保管所ToolStripMenuItem.Name = "キャラクター保管所ToolStripMenuItem";
            this.キャラクター保管所ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.キャラクター保管所ToolStripMenuItem.Text = "キャラクター保管所";
            this.キャラクター保管所ToolStripMenuItem.Click += new System.EventHandler(this.キャラクター保管所ToolStripMenuItem_Click);
            // 
            // キャラクターアーカイブToolStripMenuItem
            // 
            this.キャラクターアーカイブToolStripMenuItem.Name = "キャラクターアーカイブToolStripMenuItem";
            this.キャラクターアーカイブToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.キャラクターアーカイブToolStripMenuItem.Text = "キャラクターアーカイブ";
            this.キャラクターアーカイブToolStripMenuItem.Click += new System.EventHandler(this.キャラクターアーカイブToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.settingToolStripMenuItem.Text = "設定";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // buttonBCDice
            // 
            this.buttonBCDice.Enabled = false;
            this.buttonBCDice.Location = new System.Drawing.Point(50, 34);
            this.buttonBCDice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBCDice.Name = "buttonBCDice";
            this.buttonBCDice.Size = new System.Drawing.Size(87, 29);
            this.buttonBCDice.TabIndex = 13;
            this.buttonBCDice.Text = "bcdice";
            this.buttonBCDice.UseVisualStyleBackColor = true;
            this.buttonBCDice.Click += new System.EventHandler(this.buttonBCDice_Click);
            // 
            // buttonSideKick
            // 
            this.buttonSideKick.Location = new System.Drawing.Point(145, 34);
            this.buttonSideKick.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSideKick.Name = "buttonSideKick";
            this.buttonSideKick.Size = new System.Drawing.Size(87, 29);
            this.buttonSideKick.TabIndex = 14;
            this.buttonSideKick.Text = "SideKick";
            this.buttonSideKick.UseVisualStyleBackColor = true;
            this.buttonSideKick.Click += new System.EventHandler(this.buttonSideKick_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "使用ダイスbot";
            // 
            // tabCthu
            // 
            this.tabCthu.Controls.Add(this.tabPageSkill);
            this.tabCthu.Controls.Add(this.tabPageSAN);
            this.tabCthu.Controls.Add(this.tabHistoryAblityRole);
            this.tabCthu.Controls.Add(this.tabPageFight);
            this.tabCthu.Controls.Add(this.memo);
            this.tabCthu.Location = new System.Drawing.Point(14, 70);
            this.tabCthu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabCthu.Name = "tabCthu";
            this.tabCthu.SelectedIndex = 0;
            this.tabCthu.Size = new System.Drawing.Size(513, 402);
            this.tabCthu.TabIndex = 16;
            // 
            // tabPageSkill
            // 
            this.tabPageSkill.Location = new System.Drawing.Point(4, 24);
            this.tabPageSkill.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageSkill.Name = "tabPageSkill";
            this.tabPageSkill.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageSkill.Size = new System.Drawing.Size(505, 374);
            this.tabPageSkill.TabIndex = 0;
            this.tabPageSkill.Text = "技能";
            this.tabPageSkill.UseVisualStyleBackColor = true;
            // 
            // tabPageSAN
            // 
            this.tabPageSAN.Location = new System.Drawing.Point(4, 24);
            this.tabPageSAN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageSAN.Name = "tabPageSAN";
            this.tabPageSAN.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageSAN.Size = new System.Drawing.Size(505, 374);
            this.tabPageSAN.TabIndex = 1;
            this.tabPageSAN.Text = "SAN値";
            this.tabPageSAN.UseVisualStyleBackColor = true;
            // 
            // tabHistoryAblityRole
            // 
            this.tabHistoryAblityRole.Location = new System.Drawing.Point(4, 24);
            this.tabHistoryAblityRole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabHistoryAblityRole.Name = "tabHistoryAblityRole";
            this.tabHistoryAblityRole.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabHistoryAblityRole.Size = new System.Drawing.Size(505, 374);
            this.tabHistoryAblityRole.TabIndex = 3;
            this.tabHistoryAblityRole.Text = "履歴と能力値ロール";
            this.tabHistoryAblityRole.UseVisualStyleBackColor = true;
            // 
            // tabPageFight
            // 
            this.tabPageFight.Location = new System.Drawing.Point(4, 24);
            this.tabPageFight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageFight.Name = "tabPageFight";
            this.tabPageFight.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageFight.Size = new System.Drawing.Size(505, 374);
            this.tabPageFight.TabIndex = 2;
            this.tabPageFight.Text = "戦闘";
            this.tabPageFight.UseVisualStyleBackColor = true;
            // 
            // memo
            // 
            this.memo.Controls.Add(this.groupBox1);
            this.memo.Location = new System.Drawing.Point(4, 24);
            this.memo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.memo.Name = "memo";
            this.memo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.memo.Size = new System.Drawing.Size(505, 374);
            this.memo.TabIndex = 4;
            this.memo.Text = "メモ";
            this.memo.UseVisualStyleBackColor = true;
            // 
            // richTextBox1Memo
            // 
            this.richTextBox1Memo.EnableAutoDragDrop = true;
            this.richTextBox1Memo.Location = new System.Drawing.Point(6, 23);
            this.richTextBox1Memo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox1Memo.Name = "richTextBox1Memo";
            this.richTextBox1Memo.Size = new System.Drawing.Size(480, 329);
            this.richTextBox1Memo.TabIndex = 0;
            this.richTextBox1Memo.Text = "";
            // 
            // labelCharaName
            // 
            this.labelCharaName.AutoSize = true;
            this.labelCharaName.Location = new System.Drawing.Point(341, 40);
            this.labelCharaName.Name = "labelCharaName";
            this.labelCharaName.Size = new System.Drawing.Size(57, 15);
            this.labelCharaName.TabIndex = 17;
            this.labelCharaName.Text = "キャラ名：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(194, 481);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 15);
            this.label13.TabIndex = 18;
            this.label13.Text = "クリップボード：";
            // 
            // ClipboardLabel
            // 
            this.ClipboardLabel.AutoSize = true;
            this.ClipboardLabel.Location = new System.Drawing.Point(275, 481);
            this.ClipboardLabel.Name = "ClipboardLabel";
            this.ClipboardLabel.Size = new System.Drawing.Size(22, 15);
            this.ClipboardLabel.TabIndex = 19;
            this.ClipboardLabel.Text = "---";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1Memo);
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 359);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "メモ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 508);
            this.Controls.Add(this.ClipboardLabel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.labelCharaName);
            this.Controls.Add(this.tabCthu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonSideKick);
            this.Controls.Add(this.buttonBCDice);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Pallet Master";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabCthu.ResumeLayout(false);
            this.memo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.ToolStripMenuItem textImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem キャラクター保管所ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem チャッパレ形式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem チャッパレ形式ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cSVToolStripMenuItem1;
        private System.Windows.Forms.TabPage tabHistoryAblityRole;
        private System.Windows.Forms.ToolStripMenuItem キャラクターアーカイブToolStripMenuItem;
        private System.Windows.Forms.Label labelCharaName;
        private System.Windows.Forms.TabPage memo;
        private System.Windows.Forms.RichTextBox richTextBox1Memo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label ClipboardLabel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

