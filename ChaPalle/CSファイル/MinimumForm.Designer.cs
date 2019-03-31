namespace PalletMaster
{
    partial class MinimumForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinimumForm));
            this.listViewSkill = new System.Windows.Forms.ListView();
            this.skill = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSerch = new System.Windows.Forms.Button();
            this.textSerch = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewSkill
            // 
            this.listViewSkill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.skill,
            this.value});
            this.listViewSkill.Location = new System.Drawing.Point(3, 5);
            this.listViewSkill.Name = "listViewSkill";
            this.listViewSkill.Size = new System.Drawing.Size(217, 272);
            this.listViewSkill.TabIndex = 24;
            this.listViewSkill.UseCompatibleStateImageBehavior = false;
            this.listViewSkill.View = System.Windows.Forms.View.Details;
            this.listViewSkill.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listViewSkill_KeyPress);
            this.listViewSkill.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewSkill_MouseDoubleClick);
            // 
            // skill
            // 
            this.skill.Text = "技能";
            this.skill.Width = 94;
            // 
            // value
            // 
            this.value.Text = "値";
            this.value.Width = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSerch);
            this.groupBox1.Controls.Add(this.textSerch);
            this.groupBox1.Location = new System.Drawing.Point(3, 283);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 51);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索";
            // 
            // buttonSerch
            // 
            this.buttonSerch.Location = new System.Drawing.Point(147, 18);
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
            this.textSerch.Size = new System.Drawing.Size(131, 19);
            this.textSerch.TabIndex = 11;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(69, 340);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 27;
            this.backButton.Text = "戻る";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // MinimumForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(221, 375);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listViewSkill);
            this.Font = new System.Drawing.Font("UD デジタル 教科書体 N-B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MinimumForm";
            this.Text = "縮小版";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewSkill;
        private System.Windows.Forms.ColumnHeader skill;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSerch;
        private System.Windows.Forms.TextBox textSerch;
        private System.Windows.Forms.Button backButton;
    }
}