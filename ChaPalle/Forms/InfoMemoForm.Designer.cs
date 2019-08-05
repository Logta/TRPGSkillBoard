namespace PalletMaster
{
    partial class InfoMemoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoMemoForm));
            this.memoTextBox = new System.Windows.Forms.RichTextBox();
            this.OK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBoxGender = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxOccupation = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // memoTextBox
            // 
            this.memoTextBox.Location = new System.Drawing.Point(0, 0);
            this.memoTextBox.Name = "memoTextBox";
            this.memoTextBox.Size = new System.Drawing.Size(364, 239);
            this.memoTextBox.TabIndex = 0;
            this.memoTextBox.Text = "";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(169, 292);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 1;
            this.OK.Text = "決定";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(372, 265);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.memoTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(364, 239);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "背景";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxFrom);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.textBoxWeight);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.textBoxHeight);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.textBoxGender);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.textBoxAge);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.textBoxOccupation);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(364, 239);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "属性";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(248, 137);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(117, 19);
            this.textBoxFrom.TabIndex = 31;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(246, 122);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 12);
            this.label21.TabIndex = 32;
            this.label21.Text = "出身";
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(125, 137);
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(117, 19);
            this.textBoxWeight.TabIndex = 29;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(123, 122);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 30;
            this.label22.Text = "体重";
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(2, 137);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(117, 19);
            this.textBoxHeight.TabIndex = 27;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(0, 122);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 12);
            this.label23.TabIndex = 28;
            this.label23.Text = "身長";
            // 
            // textBoxGender
            // 
            this.textBoxGender.Location = new System.Drawing.Point(248, 98);
            this.textBoxGender.Name = "textBoxGender";
            this.textBoxGender.Size = new System.Drawing.Size(117, 19);
            this.textBoxGender.TabIndex = 25;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(246, 83);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 26;
            this.label20.Text = "性別";
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(125, 98);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(117, 19);
            this.textBoxAge.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(123, 83);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 24;
            this.label18.Text = "年齢";
            // 
            // textBoxOccupation
            // 
            this.textBoxOccupation.Location = new System.Drawing.Point(2, 98);
            this.textBoxOccupation.Name = "textBoxOccupation";
            this.textBoxOccupation.Size = new System.Drawing.Size(117, 19);
            this.textBoxOccupation.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(0, 83);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 22;
            this.label16.Text = "職業";
            // 
            // InfoMemoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(396, 327);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.OK);
            this.Font = new System.Drawing.Font("UD デジタル 教科書体 N-B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(412, 366);
            this.MinimumSize = new System.Drawing.Size(412, 366);
            this.Name = "InfoMemoForm";
            this.Text = "キャラ背景入力";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox memoTextBox;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBoxGender;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxOccupation;
        private System.Windows.Forms.Label label16;
    }
}