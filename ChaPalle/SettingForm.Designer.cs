namespace ChaPalle
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
            this.checkBoxTopMost = new System.Windows.Forms.CheckBox();
            this.buttonDecide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxTopMost
            // 
            this.checkBoxTopMost.AutoSize = true;
            this.checkBoxTopMost.Location = new System.Drawing.Point(13, 13);
            this.checkBoxTopMost.Name = "checkBoxTopMost";
            this.checkBoxTopMost.Size = new System.Drawing.Size(167, 16);
            this.checkBoxTopMost.TabIndex = 0;
            this.checkBoxTopMost.Text = "アプリを常に最前面に表示する";
            this.checkBoxTopMost.UseVisualStyleBackColor = true;
            this.checkBoxTopMost.CheckedChanged += new System.EventHandler(this.checkBoxTopMost_CheckedChanged);
            // 
            // buttonDecide
            // 
            this.buttonDecide.Location = new System.Drawing.Point(105, 226);
            this.buttonDecide.Name = "buttonDecide";
            this.buttonDecide.Size = new System.Drawing.Size(75, 23);
            this.buttonDecide.TabIndex = 17;
            this.buttonDecide.Text = "決定";
            this.buttonDecide.UseVisualStyleBackColor = true;
            this.buttonDecide.Click += new System.EventHandler(this.buttonDecide_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonDecide);
            this.Controls.Add(this.checkBoxTopMost);
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxTopMost;
        private System.Windows.Forms.Button buttonDecide;
    }
}