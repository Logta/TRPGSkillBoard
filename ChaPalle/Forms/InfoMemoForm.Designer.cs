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
            this.SuspendLayout();
            // 
            // memoTextBox
            // 
            this.memoTextBox.Location = new System.Drawing.Point(13, 13);
            this.memoTextBox.Name = "memoTextBox";
            this.memoTextBox.Size = new System.Drawing.Size(371, 271);
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
            // InfoMemoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(396, 327);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.memoTextBox);
            this.Font = new System.Drawing.Font("UD デジタル 教科書体 N-B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(412, 366);
            this.MinimumSize = new System.Drawing.Size(412, 366);
            this.Name = "InfoMemoForm";
            this.Text = "キャラ背景入力";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox memoTextBox;
        private System.Windows.Forms.Button OK;
    }
}