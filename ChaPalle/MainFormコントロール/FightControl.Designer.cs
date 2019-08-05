namespace PalletMaster
{
    partial class FightControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonKick = new System.Windows.Forms.Button();
            this.buttonFist = new System.Windows.Forms.Button();
            this.buttonAvoid = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.comboBoxHPValue = new System.Windows.Forms.ComboBox();
            this.buttonHPMinus = new System.Windows.Forms.Button();
            this.buttonHPPlus = new System.Windows.Forms.Button();
            this.labelHPValue = new System.Windows.Forms.Label();
            this.listViewFight = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonDeleteFight = new System.Windows.Forms.Button();
            this.textSkillFight = new System.Windows.Forms.TextBox();
            this.buttonAddFight = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textValueFight = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.attack = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.attackLabel = new MetroFramework.Drawing.Html.HtmlLabel();
            this.damageBonusTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonKick
            // 
            this.buttonKick.Location = new System.Drawing.Point(433, 150);
            this.buttonKick.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonKick.Name = "buttonKick";
            this.buttonKick.Size = new System.Drawing.Size(55, 25);
            this.buttonKick.TabIndex = 36;
            this.buttonKick.Text = "キック";
            this.buttonKick.UseVisualStyleBackColor = true;
            this.buttonKick.Click += new System.EventHandler(this.buttonKick_Click);
            // 
            // buttonFist
            // 
            this.buttonFist.Location = new System.Drawing.Point(321, 150);
            this.buttonFist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonFist.Name = "buttonFist";
            this.buttonFist.Size = new System.Drawing.Size(106, 25);
            this.buttonFist.TabIndex = 35;
            this.buttonFist.Text = "こぶし(パンチ)";
            this.buttonFist.UseVisualStyleBackColor = true;
            this.buttonFist.Click += new System.EventHandler(this.buttonFist_Click);
            // 
            // buttonAvoid
            // 
            this.buttonAvoid.Location = new System.Drawing.Point(262, 150);
            this.buttonAvoid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAvoid.Name = "buttonAvoid";
            this.buttonAvoid.Size = new System.Drawing.Size(51, 25);
            this.buttonAvoid.TabIndex = 34;
            this.buttonAvoid.Text = "回避";
            this.buttonAvoid.UseVisualStyleBackColor = true;
            this.buttonAvoid.Click += new System.EventHandler(this.buttonAvoid_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.comboBoxHPValue);
            this.groupBox7.Controls.Add(this.buttonHPMinus);
            this.groupBox7.Controls.Add(this.buttonHPPlus);
            this.groupBox7.Controls.Add(this.labelHPValue);
            this.groupBox7.Location = new System.Drawing.Point(245, 46);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox7.Size = new System.Drawing.Size(243, 90);
            this.groupBox7.TabIndex = 33;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "HP";
            // 
            // comboBoxHPValue
            // 
            this.comboBoxHPValue.FormattingEnabled = true;
            this.comboBoxHPValue.Items.AddRange(new object[] {
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
            this.comboBoxHPValue.Location = new System.Drawing.Point(81, 34);
            this.comboBoxHPValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxHPValue.Name = "comboBoxHPValue";
            this.comboBoxHPValue.Size = new System.Drawing.Size(56, 20);
            this.comboBoxHPValue.TabIndex = 24;
            this.comboBoxHPValue.Text = "1";
            // 
            // buttonHPMinus
            // 
            this.buttonHPMinus.Location = new System.Drawing.Point(162, 56);
            this.buttonHPMinus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonHPMinus.Name = "buttonHPMinus";
            this.buttonHPMinus.Size = new System.Drawing.Size(51, 22);
            this.buttonHPMinus.TabIndex = 23;
            this.buttonHPMinus.Text = "-";
            this.buttonHPMinus.UseVisualStyleBackColor = true;
            this.buttonHPMinus.Click += new System.EventHandler(this.buttonHPMinus_Click);
            // 
            // buttonHPPlus
            // 
            this.buttonHPPlus.Location = new System.Drawing.Point(162, 26);
            this.buttonHPPlus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonHPPlus.Name = "buttonHPPlus";
            this.buttonHPPlus.Size = new System.Drawing.Size(51, 22);
            this.buttonHPPlus.TabIndex = 22;
            this.buttonHPPlus.Text = "+";
            this.buttonHPPlus.UseVisualStyleBackColor = true;
            this.buttonHPPlus.Click += new System.EventHandler(this.buttonHPPlus_Click);
            // 
            // labelHPValue
            // 
            this.labelHPValue.AutoSize = true;
            this.labelHPValue.Font = new System.Drawing.Font("UD デジタル 教科書体 N-B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelHPValue.Location = new System.Drawing.Point(36, 34);
            this.labelHPValue.Name = "labelHPValue";
            this.labelHPValue.Size = new System.Drawing.Size(11, 12);
            this.labelHPValue.TabIndex = 0;
            this.labelHPValue.Text = "0";
            // 
            // listViewFight
            // 
            this.listViewFight.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewFight.Location = new System.Drawing.Point(9, 45);
            this.listViewFight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewFight.Name = "listViewFight";
            this.listViewFight.Size = new System.Drawing.Size(230, 284);
            this.listViewFight.TabIndex = 31;
            this.listViewFight.UseCompatibleStateImageBehavior = false;
            this.listViewFight.View = System.Windows.Forms.View.Details;
            this.listViewFight.SelectedIndexChanged += new System.EventHandler(this.listViewFight_SelectedIndexChanged);
            this.listViewFight.DoubleClick += new System.EventHandler(this.listViewFight_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "技能";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "値";
            // 
            // buttonDeleteFight
            // 
            this.buttonDeleteFight.Location = new System.Drawing.Point(152, 339);
            this.buttonDeleteFight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDeleteFight.Name = "buttonDeleteFight";
            this.buttonDeleteFight.Size = new System.Drawing.Size(87, 23);
            this.buttonDeleteFight.TabIndex = 32;
            this.buttonDeleteFight.Text = "削除";
            this.buttonDeleteFight.UseVisualStyleBackColor = true;
            this.buttonDeleteFight.Click += new System.EventHandler(this.buttonDeleteFight_Click);
            // 
            // textSkillFight
            // 
            this.textSkillFight.Location = new System.Drawing.Point(65, 12);
            this.textSkillFight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSkillFight.Name = "textSkillFight";
            this.textSkillFight.Size = new System.Drawing.Size(116, 19);
            this.textSkillFight.TabIndex = 25;
            // 
            // buttonAddFight
            // 
            this.buttonAddFight.Location = new System.Drawing.Point(361, 13);
            this.buttonAddFight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAddFight.Name = "buttonAddFight";
            this.buttonAddFight.Size = new System.Drawing.Size(51, 25);
            this.buttonAddFight.TabIndex = 26;
            this.buttonAddFight.Text = "追加";
            this.buttonAddFight.UseVisualStyleBackColor = true;
            this.buttonAddFight.Click += new System.EventHandler(this.buttonAddFight_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "技能";
            // 
            // textValueFight
            // 
            this.textValueFight.Location = new System.Drawing.Point(225, 12);
            this.textValueFight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textValueFight.Name = "textValueFight";
            this.textValueFight.Size = new System.Drawing.Size(116, 19);
            this.textValueFight.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(198, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 29;
            this.label11.Text = "値";
            // 
            // attack
            // 
            this.attack.Location = new System.Drawing.Point(11, 26);
            this.attack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.attack.Name = "attack";
            this.attack.Size = new System.Drawing.Size(87, 22);
            this.attack.TabIndex = 37;
            this.attack.Text = "攻撃";
            this.attack.UseVisualStyleBackColor = true;
            this.attack.Click += new System.EventHandler(this.attack_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.attackLabel);
            this.groupBox1.Controls.Add(this.damageBonusTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.attack);
            this.groupBox1.Location = new System.Drawing.Point(245, 223);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(243, 139);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "攻撃";
            // 
            // attackLabel
            // 
            this.attackLabel.AutoScroll = true;
            this.attackLabel.AutoScrollMinSize = new System.Drawing.Size(28, 22);
            this.attackLabel.AutoSize = false;
            this.attackLabel.BackColor = System.Drawing.SystemColors.Window;
            this.attackLabel.Location = new System.Drawing.Point(11, 65);
            this.attackLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.attackLabel.Name = "attackLabel";
            this.attackLabel.Size = new System.Drawing.Size(222, 27);
            this.attackLabel.TabIndex = 40;
            this.attackLabel.Text = "---";
            // 
            // damageBonusTextBox
            // 
            this.damageBonusTextBox.Location = new System.Drawing.Point(117, 100);
            this.damageBonusTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.damageBonusTextBox.Name = "damageBonusTextBox";
            this.damageBonusTextBox.Size = new System.Drawing.Size(116, 19);
            this.damageBonusTextBox.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "ダメージボーナス";
            // 
            // FightControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonKick);
            this.Controls.Add(this.buttonFist);
            this.Controls.Add(this.buttonAvoid);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.listViewFight);
            this.Controls.Add(this.buttonDeleteFight);
            this.Controls.Add(this.textSkillFight);
            this.Controls.Add(this.buttonAddFight);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textValueFight);
            this.Controls.Add(this.label11);
            this.Font = new System.Drawing.Font("UD デジタル 教科書体 N-B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FightControl";
            this.Size = new System.Drawing.Size(499, 369);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonKick;
        private System.Windows.Forms.Button buttonFist;
        private System.Windows.Forms.Button buttonAvoid;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox comboBoxHPValue;
        private System.Windows.Forms.Button buttonHPMinus;
        private System.Windows.Forms.Button buttonHPPlus;
        private System.Windows.Forms.Label labelHPValue;
        private System.Windows.Forms.ListView listViewFight;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonDeleteFight;
        private System.Windows.Forms.TextBox textSkillFight;
        private System.Windows.Forms.Button buttonAddFight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textValueFight;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button attack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox damageBonusTextBox;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Drawing.Html.HtmlLabel attackLabel;
    }
}
