using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalletMaster
{
    public partial class MemoControl : UserControl
    {
        Memo memo = new Memo();
        PalletMaster PalletMaster = new PalletMaster();

        public MemoControl()
        {
            InitializeComponent();
            memo.memos = new List<string>();
            memo.tabs = new List<string>();

            // タブコントロールにタブページを追加
            var tabPage = new System.Windows.Forms.TabPage("メモ");
            memoTabControl.Controls.Add(tabPage);

            // タブページにページの内容（UserControl派生）を追加
            var tabContents = new memoTabControl();
                
            tabPage.Controls.Add(tabContents);
            tabContents.Dock = System.Windows.Forms.DockStyle.Fill;// タブページのサイズに合わせて広げたい場合はこの設定
            
        }

        public void SetMainForm(PalletMaster palletMaster)
        {
            PalletMaster = palletMaster;
        }

        private void memoLoadButton_Click(object sender, EventArgs e)
        {
            memo = new IOHelper().LoadMemo();

            if (memo is null) return;

            memoTabControl.TabPages.Clear();
            for (var i = 0; i < memo.memos.Count; i++)
            {
                var tabPage = new System.Windows.Forms.TabPage(memo.tabs[i]);
                memoTabControl.Controls.Add(tabPage);

                var tabContents = new memoTabControl();
                tabContents.SetRichTextBox(memo.memos[i]);

                tabPage.Controls.Add(tabContents);
                tabContents.Dock = System.Windows.Forms.DockStyle.Fill;// タブページのサイズに合わせて広げたい場合はこの設定
            }
        }

        private void memoSaveButton_Click(object sender, EventArgs e)
        {
            if (memoTabControl.TabPages.Count == 0) return;

            memo.memos = new List<string>();
            memo.tabs = new List<string>();
            
            foreach (TabPage i in memoTabControl.TabPages)
            {
                memo.tabs.Add(i.Text);
                foreach(memoTabControl j in i.Controls)
                    memo.memos.Add(j.GetRichTextBox());
            }

            new IOHelper().SaveMemo(memo);
        }

        private void tabAddButton_Click(object sender, EventArgs e)
        {
            _1InputForm u_form = new _1InputForm();
            PalletMaster.MainForm.TopMost = false;

            u_form.Text = "タブ追加";
            u_form.SetLabel("ラベル名を入力してください");
            u_form.SetButton("決定");
            u_form.ShowDialog();

            if (u_form.OK)
            {
                // タブコントロールにタブページを追加
                var tabPage = new System.Windows.Forms.TabPage(u_form.inputText);
                memoTabControl.Controls.Add(tabPage);

                // タブページにページの内容（UserControl派生）を追加
                var tabContents = new memoTabControl();

                tabPage.Controls.Add(tabContents);
                tabContents.Dock = System.Windows.Forms.DockStyle.Fill;// タブページのサイズに合わせて広げたい場合はこの設定

            }
            
            PalletMaster.MainForm.TopMost = PalletMaster.Setting.checkTopMostFlg;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            memoTabControl.TabPages.Clear();
        }

        private void deleteTabButton_Click(object sender, EventArgs e)
        {
            memoTabControl.TabPages.Remove(memoTabControl.SelectedTab);
        }
    }
}
