﻿namespace ChaPalle
{
    partial class SkillControl
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxOppChara = new System.Windows.Forms.ComboBox();
            this.buttonOppCheck = new System.Windows.Forms.Button();
            this.textOppEnemy = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textResult = new System.Windows.Forms.TextBox();
            this.buttonClipboardCopy = new System.Windows.Forms.Button();
            this.listViewSkill = new System.Windows.Forms.ListView();
            this.skill = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonCSV = new System.Windows.Forms.Button();
            this.textSkill = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonTemplete3Copy = new System.Windows.Forms.Button();
            this.buttonTemplete2Copy = new System.Windows.Forms.Button();
            this.buttonTemplete1Copy = new System.Windows.Forms.Button();
            this.buttonTempleteUserCopy = new System.Windows.Forms.Button();
            this.textTempleteUser = new System.Windows.Forms.TextBox();
            this.textValue = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSerch = new System.Windows.Forms.Button();
            this.textSerch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.comboBoxOppChara);
            this.groupBox6.Controls.Add(this.buttonOppCheck);
            this.groupBox6.Controls.Add(this.textOppEnemy);
            this.groupBox6.Location = new System.Drawing.Point(218, 171);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 42);
            this.groupBox6.TabIndex = 29;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "対抗ロール";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "自身";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "敵";
            // 
            // comboBoxOppChara
            // 
            this.comboBoxOppChara.AutoCompleteCustomSource.AddRange(new string[] {
            "STR",
            "CON",
            "POW",
            "DEX",
            "APP",
            "SIZ",
            "INT",
            "EDU"});
            this.comboBoxOppChara.FormattingEnabled = true;
            this.comboBoxOppChara.Items.AddRange(new object[] {
            "STR",
            "CON",
            "POW",
            "DEX",
            "APP",
            "SIZ",
            "INT",
            "EDU"});
            this.comboBoxOppChara.Location = new System.Drawing.Point(89, 17);
            this.comboBoxOppChara.Name = "comboBoxOppChara";
            this.comboBoxOppChara.Size = new System.Drawing.Size(48, 20);
            this.comboBoxOppChara.TabIndex = 15;
            this.comboBoxOppChara.Text = "STR";
            // 
            // buttonOppCheck
            // 
            this.buttonOppCheck.Location = new System.Drawing.Point(142, 16);
            this.buttonOppCheck.Name = "buttonOppCheck";
            this.buttonOppCheck.Size = new System.Drawing.Size(52, 23);
            this.buttonOppCheck.TabIndex = 14;
            this.buttonOppCheck.Text = "判定";
            this.buttonOppCheck.UseVisualStyleBackColor = true;
            this.buttonOppCheck.Click += new System.EventHandler(this.buttonOppCheck_Click);
            // 
            // textOppEnemy
            // 
            this.textOppEnemy.Location = new System.Drawing.Point(23, 17);
            this.textOppEnemy.Name = "textOppEnemy";
            this.textOppEnemy.Size = new System.Drawing.Size(31, 19);
            this.textOppEnemy.TabIndex = 13;
            this.textOppEnemy.Text = "10";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textResult);
            this.groupBox5.Controls.Add(this.buttonClipboardCopy);
            this.groupBox5.Location = new System.Drawing.Point(218, 219);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 69);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "結果";
            // 
            // textResult
            // 
            this.textResult.Location = new System.Drawing.Point(9, 18);
            this.textResult.Name = "textResult";
            this.textResult.Size = new System.Drawing.Size(171, 19);
            this.textResult.TabIndex = 7;
            // 
            // buttonClipboardCopy
            // 
            this.buttonClipboardCopy.Location = new System.Drawing.Point(66, 40);
            this.buttonClipboardCopy.Name = "buttonClipboardCopy";
            this.buttonClipboardCopy.Size = new System.Drawing.Size(114, 23);
            this.buttonClipboardCopy.TabIndex = 9;
            this.buttonClipboardCopy.Text = "クリップボードにコピー";
            this.buttonClipboardCopy.UseVisualStyleBackColor = true;
            this.buttonClipboardCopy.Click += new System.EventHandler(this.buttonClipboardCopy_Click);
            // 
            // listViewSkill
            // 
            this.listViewSkill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.skill,
            this.value});
            this.listViewSkill.Location = new System.Drawing.Point(14, 39);
            this.listViewSkill.Name = "listViewSkill";
            this.listViewSkill.Size = new System.Drawing.Size(198, 202);
            this.listViewSkill.TabIndex = 23;
            this.listViewSkill.UseCompatibleStateImageBehavior = false;
            this.listViewSkill.View = System.Windows.Forms.View.Details;
            this.listViewSkill.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listViewSkill.DoubleClick += new System.EventHandler(this.listView1_MouseDoubleClick);
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
            // buttonCSV
            // 
            this.buttonCSV.Location = new System.Drawing.Point(361, 8);
            this.buttonCSV.Name = "buttonCSV";
            this.buttonCSV.Size = new System.Drawing.Size(52, 23);
            this.buttonCSV.TabIndex = 27;
            this.buttonCSV.Text = "読込";
            this.buttonCSV.UseVisualStyleBackColor = true;
            this.buttonCSV.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // textSkill
            // 
            this.textSkill.Location = new System.Drawing.Point(57, 10);
            this.textSkill.Name = "textSkill";
            this.textSkill.Size = new System.Drawing.Size(100, 19);
            this.textSkill.TabIndex = 18;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(311, 8);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(44, 23);
            this.buttonAdd.TabIndex = 19;
            this.buttonAdd.Text = "追加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "技能";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonTemplete3Copy);
            this.groupBox2.Controls.Add(this.buttonTemplete2Copy);
            this.groupBox2.Controls.Add(this.buttonTemplete1Copy);
            this.groupBox2.Controls.Add(this.buttonTempleteUserCopy);
            this.groupBox2.Controls.Add(this.textTempleteUser);
            this.groupBox2.Location = new System.Drawing.Point(218, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 70);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "定型文";
            // 
            // buttonTemplete3Copy
            // 
            this.buttonTemplete3Copy.Location = new System.Drawing.Point(143, 43);
            this.buttonTemplete3Copy.Name = "buttonTemplete3Copy";
            this.buttonTemplete3Copy.Size = new System.Drawing.Size(52, 23);
            this.buttonTemplete3Copy.TabIndex = 16;
            this.buttonTemplete3Copy.Text = "3d";
            this.buttonTemplete3Copy.UseVisualStyleBackColor = true;
            this.buttonTemplete3Copy.Click += new System.EventHandler(this.buttonTemplete3Copy_Click);
            // 
            // buttonTemplete2Copy
            // 
            this.buttonTemplete2Copy.Location = new System.Drawing.Point(85, 43);
            this.buttonTemplete2Copy.Name = "buttonTemplete2Copy";
            this.buttonTemplete2Copy.Size = new System.Drawing.Size(52, 23);
            this.buttonTemplete2Copy.TabIndex = 15;
            this.buttonTemplete2Copy.Text = "2d";
            this.buttonTemplete2Copy.UseVisualStyleBackColor = true;
            this.buttonTemplete2Copy.Click += new System.EventHandler(this.buttonTemplete2Copy_Click);
            // 
            // buttonTemplete1Copy
            // 
            this.buttonTemplete1Copy.Location = new System.Drawing.Point(27, 43);
            this.buttonTemplete1Copy.Name = "buttonTemplete1Copy";
            this.buttonTemplete1Copy.Size = new System.Drawing.Size(52, 23);
            this.buttonTemplete1Copy.TabIndex = 14;
            this.buttonTemplete1Copy.Text = "1d";
            this.buttonTemplete1Copy.UseVisualStyleBackColor = true;
            this.buttonTemplete1Copy.Click += new System.EventHandler(this.buttonTemplete1Copy_Click);
            // 
            // buttonTempleteUserCopy
            // 
            this.buttonTempleteUserCopy.Location = new System.Drawing.Point(143, 14);
            this.buttonTempleteUserCopy.Name = "buttonTempleteUserCopy";
            this.buttonTempleteUserCopy.Size = new System.Drawing.Size(52, 23);
            this.buttonTempleteUserCopy.TabIndex = 12;
            this.buttonTempleteUserCopy.Text = "コピー";
            this.buttonTempleteUserCopy.UseVisualStyleBackColor = true;
            this.buttonTempleteUserCopy.Click += new System.EventHandler(this.buttonTempleteUserCopy_Click);
            // 
            // textTempleteUser
            // 
            this.textTempleteUser.Location = new System.Drawing.Point(6, 18);
            this.textTempleteUser.Name = "textTempleteUser";
            this.textTempleteUser.Size = new System.Drawing.Size(131, 19);
            this.textTempleteUser.TabIndex = 13;
            // 
            // textValue
            // 
            this.textValue.Location = new System.Drawing.Point(194, 10);
            this.textValue.Name = "textValue";
            this.textValue.Size = new System.Drawing.Size(100, 19);
            this.textValue.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSerch);
            this.groupBox1.Controls.Add(this.textSerch);
            this.groupBox1.Location = new System.Drawing.Point(218, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 51);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索";
            // 
            // buttonSerch
            // 
            this.buttonSerch.Location = new System.Drawing.Point(143, 14);
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
            this.textSerch.Size = new System.Drawing.Size(127, 19);
            this.textSerch.TabIndex = 11;
            this.textSerch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textSerch_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "値";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(137, 251);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 24;
            this.buttonDelete.Text = "削除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // SkillControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.listViewSkill);
            this.Controls.Add(this.buttonCSV);
            this.Controls.Add(this.textSkill);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textValue);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonDelete);
            this.Name = "SkillControl";
            this.Size = new System.Drawing.Size(432, 296);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxOppChara;
        private System.Windows.Forms.Button buttonOppCheck;
        private System.Windows.Forms.TextBox textOppEnemy;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.Button buttonClipboardCopy;
        private System.Windows.Forms.ListView listViewSkill;
        private System.Windows.Forms.ColumnHeader skill;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.Button buttonCSV;
        private System.Windows.Forms.TextBox textSkill;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonTemplete3Copy;
        private System.Windows.Forms.Button buttonTemplete2Copy;
        private System.Windows.Forms.Button buttonTemplete1Copy;
        private System.Windows.Forms.Button buttonTempleteUserCopy;
        private System.Windows.Forms.TextBox textTempleteUser;
        private System.Windows.Forms.TextBox textValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSerch;
        private System.Windows.Forms.TextBox textSerch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDelete;
    }
}