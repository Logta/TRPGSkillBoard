namespace PalletMaster
{
    partial class memoTabControl
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
            this.memoTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // memoTextBox
            // 
            this.memoTextBox.Location = new System.Drawing.Point(1, 1);
            this.memoTextBox.Name = "memoTextBox";
            this.memoTextBox.Size = new System.Drawing.Size(329, 308);
            this.memoTextBox.TabIndex = 0;
            this.memoTextBox.Text = "";
            // 
            // memoTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.memoTextBox);
            this.Name = "memoTabControl";
            this.Size = new System.Drawing.Size(390, 314);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox memoTextBox;
    }
}
