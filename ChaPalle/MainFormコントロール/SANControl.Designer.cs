namespace PalletMaster
{
    partial class SANControl
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
            this.buttonMadnessTable = new System.Windows.Forms.Button();
            this.comboBoxSANValue = new System.Windows.Forms.ComboBox();
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
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonMadnessTable
            // 
            this.buttonMadnessTable.Location = new System.Drawing.Point(29, 256);
            this.buttonMadnessTable.Name = "buttonMadnessTable";
            this.buttonMadnessTable.Size = new System.Drawing.Size(75, 23);
            this.buttonMadnessTable.TabIndex = 34;
            this.buttonMadnessTable.Text = "狂気表";
            this.buttonMadnessTable.UseVisualStyleBackColor = true;
            this.buttonMadnessTable.Click += new System.EventHandler(this.buttonMadnessTable_Click);
            // 
            // comboBoxSANValue
            // 
            this.comboBoxSANValue.FormattingEnabled = true;
            this.comboBoxSANValue.Items.AddRange(new object[] {
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
            this.comboBoxSANValue.Location = new System.Drawing.Point(266, 19);
            this.comboBoxSANValue.Name = "comboBoxSANValue";
            this.comboBoxSANValue.Size = new System.Drawing.Size(49, 20);
            this.comboBoxSANValue.TabIndex = 33;
            this.comboBoxSANValue.Text = "1";
            // 
            // buttonSANDown
            // 
            this.buttonSANDown.Location = new System.Drawing.Point(240, 18);
            this.buttonSANDown.Name = "buttonSANDown";
            this.buttonSANDown.Size = new System.Drawing.Size(20, 23);
            this.buttonSANDown.TabIndex = 32;
            this.buttonSANDown.Text = "-";
            this.buttonSANDown.UseVisualStyleBackColor = true;
            this.buttonSANDown.Click += new System.EventHandler(this.buttonSANDown_Click);
            // 
            // buttonSANUp
            // 
            this.buttonSANUp.Location = new System.Drawing.Point(214, 18);
            this.buttonSANUp.Name = "buttonSANUp";
            this.buttonSANUp.Size = new System.Drawing.Size(20, 23);
            this.buttonSANUp.TabIndex = 31;
            this.buttonSANUp.Text = "+";
            this.buttonSANUp.UseVisualStyleBackColor = true;
            this.buttonSANUp.Click += new System.EventHandler(this.buttonSANUp_Click);
            // 
            // textSANValue
            // 
            this.textSANValue.Location = new System.Drawing.Point(108, 20);
            this.textSANValue.Name = "textSANValue";
            this.textSANValue.Size = new System.Drawing.Size(100, 19);
            this.textSANValue.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "現在SAN値";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonSANUpDown);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.comboBox2);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(29, 137);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(457, 100);
            this.groupBox4.TabIndex = 28;
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
            this.label8.Location = new System.Drawing.Point(9, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "----";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonSANCheck);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(29, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(457, 83);
            this.groupBox3.TabIndex = 27;
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
            // SANControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.buttonMadnessTable);
            this.Controls.Add(this.comboBoxSANValue);
            this.Controls.Add(this.buttonSANDown);
            this.Controls.Add(this.buttonSANUp);
            this.Controls.Add(this.textSANValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Name = "SANControl";
            this.Size = new System.Drawing.Size(489, 335);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMadnessTable;
        private System.Windows.Forms.ComboBox comboBoxSANValue;
        private System.Windows.Forms.Button buttonSANDown;
        private System.Windows.Forms.Button buttonSANUp;
        private System.Windows.Forms.TextBox textSANValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonSANUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonSANCheck;
        private System.Windows.Forms.Label label7;
    }
}
