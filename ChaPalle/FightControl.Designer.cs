namespace ChaPalle
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
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonKick
            // 
            this.buttonKick.Location = new System.Drawing.Point(225, 141);
            this.buttonKick.Name = "buttonKick";
            this.buttonKick.Size = new System.Drawing.Size(44, 23);
            this.buttonKick.TabIndex = 36;
            this.buttonKick.Text = "キック";
            this.buttonKick.UseVisualStyleBackColor = true;
            this.buttonKick.Click += new System.EventHandler(this.buttonKick_Click);
            // 
            // buttonFist
            // 
            this.buttonFist.Location = new System.Drawing.Point(275, 112);
            this.buttonFist.Name = "buttonFist";
            this.buttonFist.Size = new System.Drawing.Size(79, 23);
            this.buttonFist.TabIndex = 35;
            this.buttonFist.Text = "こぶし(パンチ)";
            this.buttonFist.UseVisualStyleBackColor = true;
            this.buttonFist.Click += new System.EventHandler(this.buttonFist_Click);
            // 
            // buttonAvoid
            // 
            this.buttonAvoid.Location = new System.Drawing.Point(225, 112);
            this.buttonAvoid.Name = "buttonAvoid";
            this.buttonAvoid.Size = new System.Drawing.Size(44, 23);
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
            this.groupBox7.Location = new System.Drawing.Point(225, 56);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 50);
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
            this.comboBoxHPValue.Location = new System.Drawing.Point(135, 19);
            this.comboBoxHPValue.Name = "comboBoxHPValue";
            this.comboBoxHPValue.Size = new System.Drawing.Size(49, 20);
            this.comboBoxHPValue.TabIndex = 24;
            this.comboBoxHPValue.Text = "1";
            // 
            // buttonHPMinus
            // 
            this.buttonHPMinus.Location = new System.Drawing.Point(66, 30);
            this.buttonHPMinus.Name = "buttonHPMinus";
            this.buttonHPMinus.Size = new System.Drawing.Size(44, 15);
            this.buttonHPMinus.TabIndex = 23;
            this.buttonHPMinus.Text = "-";
            this.buttonHPMinus.UseVisualStyleBackColor = true;
            this.buttonHPMinus.Click += new System.EventHandler(this.buttonHPMinus_Click);
            // 
            // buttonHPPlus
            // 
            this.buttonHPPlus.Location = new System.Drawing.Point(66, 12);
            this.buttonHPPlus.Name = "buttonHPPlus";
            this.buttonHPPlus.Size = new System.Drawing.Size(44, 15);
            this.buttonHPPlus.TabIndex = 22;
            this.buttonHPPlus.Text = "+";
            this.buttonHPPlus.UseVisualStyleBackColor = true;
            this.buttonHPPlus.Click += new System.EventHandler(this.buttonHPPlus_Click);
            // 
            // labelHPValue
            // 
            this.labelHPValue.AutoSize = true;
            this.labelHPValue.Location = new System.Drawing.Point(31, 23);
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
            this.listViewFight.Location = new System.Drawing.Point(8, 56);
            this.listViewFight.Name = "listViewFight";
            this.listViewFight.Size = new System.Drawing.Size(198, 202);
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
            this.buttonDeleteFight.Location = new System.Drawing.Point(131, 268);
            this.buttonDeleteFight.Name = "buttonDeleteFight";
            this.buttonDeleteFight.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteFight.TabIndex = 32;
            this.buttonDeleteFight.Text = "削除";
            this.buttonDeleteFight.UseVisualStyleBackColor = true;
            this.buttonDeleteFight.Click += new System.EventHandler(this.buttonDeleteFight_Click);
            // 
            // textSkillFight
            // 
            this.textSkillFight.Location = new System.Drawing.Point(56, 8);
            this.textSkillFight.Name = "textSkillFight";
            this.textSkillFight.Size = new System.Drawing.Size(100, 19);
            this.textSkillFight.TabIndex = 25;
            // 
            // buttonAddFight
            // 
            this.buttonAddFight.Location = new System.Drawing.Point(310, 6);
            this.buttonAddFight.Name = "buttonAddFight";
            this.buttonAddFight.Size = new System.Drawing.Size(44, 23);
            this.buttonAddFight.TabIndex = 26;
            this.buttonAddFight.Text = "追加";
            this.buttonAddFight.UseVisualStyleBackColor = true;
            this.buttonAddFight.Click += new System.EventHandler(this.buttonAddFight_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "技能";
            // 
            // textValueFight
            // 
            this.textValueFight.Location = new System.Drawing.Point(193, 8);
            this.textValueFight.Name = "textValueFight";
            this.textValueFight.Size = new System.Drawing.Size(100, 19);
            this.textValueFight.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(170, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 29;
            this.label11.Text = "値";
            // 
            // FightControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "FightControl";
            this.Size = new System.Drawing.Size(432, 296);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
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
    }
}
