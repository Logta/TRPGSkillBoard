namespace PalletMaster
{
    partial class HistoryAbilityControl
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
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.buttonAbilityRole = new System.Windows.Forms.Button();
            this.listBoxValue = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.listBoxAbility = new System.Windows.Forms.ListBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.listViewHistory = new System.Windows.Forms.ListView();
            this.SkillHistory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeHistory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TypeHistory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.buttonAbilityRole);
            this.groupBox9.Controls.Add(this.listBoxValue);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.listBoxAbility);
            this.groupBox9.Location = new System.Drawing.Point(319, 15);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox9.Size = new System.Drawing.Size(169, 348);
            this.groupBox9.TabIndex = 3;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "能力値ロール";
            // 
            // buttonAbilityRole
            // 
            this.buttonAbilityRole.Location = new System.Drawing.Point(29, 264);
            this.buttonAbilityRole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAbilityRole.Name = "buttonAbilityRole";
            this.buttonAbilityRole.Size = new System.Drawing.Size(106, 21);
            this.buttonAbilityRole.TabIndex = 3;
            this.buttonAbilityRole.Text = "能力値ロール";
            this.buttonAbilityRole.UseVisualStyleBackColor = true;
            this.buttonAbilityRole.Click += new System.EventHandler(this.buttonAbilityRole_Click);
            // 
            // listBoxValue
            // 
            this.listBoxValue.FormattingEnabled = true;
            this.listBoxValue.ItemHeight = 12;
            this.listBoxValue.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.listBoxValue.Location = new System.Drawing.Point(102, 60);
            this.listBoxValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxValue.Name = "listBoxValue";
            this.listBoxValue.Size = new System.Drawing.Size(48, 196);
            this.listBoxValue.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(79, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "×";
            // 
            // listBoxAbility
            // 
            this.listBoxAbility.FormattingEnabled = true;
            this.listBoxAbility.ItemHeight = 12;
            this.listBoxAbility.Items.AddRange(new object[] {
            "STR",
            "CON",
            "POW",
            "DEX",
            "APP",
            "SIZ",
            "INT",
            "EDU"});
            this.listBoxAbility.Location = new System.Drawing.Point(19, 60);
            this.listBoxAbility.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxAbility.Name = "listBoxAbility";
            this.listBoxAbility.Size = new System.Drawing.Size(54, 112);
            this.listBoxAbility.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.listViewHistory);
            this.groupBox8.Location = new System.Drawing.Point(7, 15);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox8.Size = new System.Drawing.Size(306, 348);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "履歴";
            // 
            // listViewHistory
            // 
            this.listViewHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SkillHistory,
            this.TimeHistory,
            this.TypeHistory});
            this.listViewHistory.Location = new System.Drawing.Point(9, 20);
            this.listViewHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewHistory.Name = "listViewHistory";
            this.listViewHistory.Size = new System.Drawing.Size(291, 317);
            this.listViewHistory.TabIndex = 0;
            this.listViewHistory.UseCompatibleStateImageBehavior = false;
            this.listViewHistory.View = System.Windows.Forms.View.Details;
            this.listViewHistory.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewHistory_ColumnClick_1);
            this.listViewHistory.DoubleClick += new System.EventHandler(this.listViewHistory_DoubleClick);
            // 
            // SkillHistory
            // 
            this.SkillHistory.Text = "技能";
            // 
            // TimeHistory
            // 
            this.TimeHistory.Text = "時間";
            this.TimeHistory.Width = 107;
            // 
            // TypeHistory
            // 
            this.TypeHistory.Text = "ロール";
            // 
            // HistoryAbilityControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Name = "HistoryAbilityControl";
            this.Size = new System.Drawing.Size(495, 369);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button buttonAbilityRole;
        private System.Windows.Forms.ListBox listBoxValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listBoxAbility;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ListView listViewHistory;
        private System.Windows.Forms.ColumnHeader SkillHistory;
        private System.Windows.Forms.ColumnHeader TimeHistory;
        private System.Windows.Forms.ColumnHeader TypeHistory;
    }
}
