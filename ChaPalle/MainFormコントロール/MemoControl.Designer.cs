namespace PalletMaster
{
    partial class MemoControl
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
            this.memoTabControl = new System.Windows.Forms.TabControl();
            this.memoLoadButton = new System.Windows.Forms.Button();
            this.memoSaveButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.tabAddButton = new System.Windows.Forms.Button();
            this.deleteTabButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // memoTabControl
            // 
            this.memoTabControl.Location = new System.Drawing.Point(4, 33);
            this.memoTabControl.Name = "memoTabControl";
            this.memoTabControl.SelectedIndex = 0;
            this.memoTabControl.Size = new System.Drawing.Size(484, 361);
            this.memoTabControl.TabIndex = 1;
            // 
            // memoLoadButton
            // 
            this.memoLoadButton.Location = new System.Drawing.Point(4, 4);
            this.memoLoadButton.Name = "memoLoadButton";
            this.memoLoadButton.Size = new System.Drawing.Size(75, 23);
            this.memoLoadButton.TabIndex = 5;
            this.memoLoadButton.Text = "メモ読込";
            this.memoLoadButton.UseVisualStyleBackColor = true;
            this.memoLoadButton.Click += new System.EventHandler(this.memoLoadButton_Click);
            // 
            // memoSaveButton
            // 
            this.memoSaveButton.Location = new System.Drawing.Point(85, 4);
            this.memoSaveButton.Name = "memoSaveButton";
            this.memoSaveButton.Size = new System.Drawing.Size(75, 23);
            this.memoSaveButton.TabIndex = 6;
            this.memoSaveButton.Text = "メモ保存";
            this.memoSaveButton.UseVisualStyleBackColor = true;
            this.memoSaveButton.Click += new System.EventHandler(this.memoSaveButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(250, 4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // tabAddButton
            // 
            this.tabAddButton.Location = new System.Drawing.Point(332, 4);
            this.tabAddButton.Name = "tabAddButton";
            this.tabAddButton.Size = new System.Drawing.Size(75, 23);
            this.tabAddButton.TabIndex = 8;
            this.tabAddButton.Text = "タブ追加";
            this.tabAddButton.UseVisualStyleBackColor = true;
            this.tabAddButton.Click += new System.EventHandler(this.tabAddButton_Click);
            // 
            // deleteTabButton
            // 
            this.deleteTabButton.Location = new System.Drawing.Point(413, 4);
            this.deleteTabButton.Name = "deleteTabButton";
            this.deleteTabButton.Size = new System.Drawing.Size(75, 23);
            this.deleteTabButton.TabIndex = 9;
            this.deleteTabButton.Text = "タブ削除";
            this.deleteTabButton.UseVisualStyleBackColor = true;
            this.deleteTabButton.Click += new System.EventHandler(this.deleteTabButton_Click);
            // 
            // MemoControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.deleteTabButton);
            this.Controls.Add(this.tabAddButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.memoSaveButton);
            this.Controls.Add(this.memoLoadButton);
            this.Controls.Add(this.memoTabControl);
            this.Name = "MemoControl";
            this.Size = new System.Drawing.Size(497, 397);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl memoTabControl;
        private System.Windows.Forms.Button memoLoadButton;
        private System.Windows.Forms.Button memoSaveButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button tabAddButton;
        private System.Windows.Forms.Button deleteTabButton;
    }
}
