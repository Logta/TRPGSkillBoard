namespace PalletMaster
{
    partial class _1InputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_1InputForm));
            this._1button = new MetroFramework.Controls.MetroButton();
            this.textBox = new MetroFramework.Controls.MetroTextBox();
            this._1label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _1button
            // 
            this._1button.Location = new System.Drawing.Point(104, 73);
            this._1button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._1button.Name = "_1button";
            this._1button.Size = new System.Drawing.Size(82, 25);
            this._1button.TabIndex = 0;
            this._1button.Text = "metroButton1";
            this._1button.UseSelectable = true;
            this._1button.Click += new System.EventHandler(this.button_Click);
            // 
            // textBox
            // 
            // 
            // 
            // 
            this.textBox.CustomButton.Image = null;
            this.textBox.CustomButton.Location = new System.Drawing.Point(247, 2);
            this.textBox.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox.CustomButton.Name = "";
            this.textBox.CustomButton.Size = new System.Drawing.Size(29, 29);
            this.textBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox.CustomButton.TabIndex = 1;
            this.textBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox.CustomButton.UseSelectable = true;
            this.textBox.CustomButton.Visible = false;
            this.textBox.Lines = new string[0];
            this.textBox.Location = new System.Drawing.Point(12, 31);
            this.textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox.MaxLength = 32767;
            this.textBox.Name = "textBox";
            this.textBox.PasswordChar = '\0';
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox.SelectedText = "";
            this.textBox.SelectionLength = 0;
            this.textBox.SelectionStart = 0;
            this.textBox.ShortcutsEnabled = true;
            this.textBox.Size = new System.Drawing.Size(279, 34);
            this.textBox.TabIndex = 1;
            this.textBox.UseSelectable = true;
            this.textBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // _1label
            // 
            this._1label.AutoSize = true;
            this._1label.Location = new System.Drawing.Point(12, 9);
            this._1label.Name = "_1label";
            this._1label.Size = new System.Drawing.Size(41, 12);
            this._1label.TabIndex = 2;
            this._1label.Text = "label1";
            // 
            // _1InputForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(299, 105);
            this.Controls.Add(this._1label);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this._1button);
            this.Font = new System.Drawing.Font("UD デジタル 教科書体 N-B", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "_1InputForm";
            this.Text = "_1InputForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton _1button;
        private MetroFramework.Controls.MetroTextBox textBox;
        private System.Windows.Forms.Label _1label;
    }
}