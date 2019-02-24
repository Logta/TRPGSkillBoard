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
            this.checkBoxClipCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxTopMost
            // 
            this.checkBoxTopMost.AutoSize = true;
            this.checkBoxTopMost.Location = new System.Drawing.Point(15, 16);
            this.checkBoxTopMost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxTopMost.Name = "checkBoxTopMost";
            this.checkBoxTopMost.Size = new System.Drawing.Size(169, 19);
            this.checkBoxTopMost.TabIndex = 0;
            this.checkBoxTopMost.Text = "アプリを常に最前面に表示する";
            this.checkBoxTopMost.UseVisualStyleBackColor = true;
            this.checkBoxTopMost.CheckedChanged += new System.EventHandler(this.checkBoxTopMost_CheckedChanged);
            // 
            // buttonDecide
            // 
            this.buttonDecide.Location = new System.Drawing.Point(122, 282);
            this.buttonDecide.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDecide.Name = "buttonDecide";
            this.buttonDecide.Size = new System.Drawing.Size(87, 29);
            this.buttonDecide.TabIndex = 17;
            this.buttonDecide.Text = "決定";
            this.buttonDecide.UseVisualStyleBackColor = true;
            this.buttonDecide.Click += new System.EventHandler(this.buttonDecide_Click);
            // 
            // checkBoxClipCheck
            // 
            this.checkBoxClipCheck.AutoSize = true;
            this.checkBoxClipCheck.Location = new System.Drawing.Point(15, 44);
            this.checkBoxClipCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxClipCheck.Name = "checkBoxClipCheck";
            this.checkBoxClipCheck.Size = new System.Drawing.Size(233, 19);
            this.checkBoxClipCheck.TabIndex = 18;
            this.checkBoxClipCheck.Text = "クリップボードにコピーするとき確認を表示する";
            this.checkBoxClipCheck.UseVisualStyleBackColor = true;
            this.checkBoxClipCheck.CheckedChanged += new System.EventHandler(this.checkBoxClipCheck_CheckedChanged);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 326);
            this.Controls.Add(this.checkBoxClipCheck);
            this.Controls.Add(this.buttonDecide);
            this.Controls.Add(this.checkBoxTopMost);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingForm";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxTopMost;
        private System.Windows.Forms.Button buttonDecide;
        private System.Windows.Forms.CheckBox checkBoxClipCheck;
    }
}