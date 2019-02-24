using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ChaPalle
{
    public partial class SkillControl : UserControl
    {
        PalletMaster PalletMaster = new PalletMaster();
        Proccess Proccesser = new Proccess();

        public SkillControl()
        {
            InitializeComponent();
        }

        public void SetPalletMaster(PalletMaster palletMaster)
        {
            PalletMaster = palletMaster;
        }

        //「クリップボードにコピー」を押したときの制御
        private void buttonClipboardCopy_Click(object sender, EventArgs e)
        {
            string tValue = textResult.Text;
            PalletMaster.SetClipBoard(tValue);

            //項目が１つも選択されていない場合
            if (listViewSkill.SelectedItems.Count == 0)
                return;//処理を抜ける

            ListViewItem itemx = new ListViewItem();
            itemx = listViewSkill.SelectedItems[0];

            PalletMaster.SetSkillHistory(itemx.Text, ロール.技能);
        }

        //「追加」を押したときの制御
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string tSkill = textSkill.Text;
            string tValue = textValue.Text;
            if (tSkill == "" || tValue == "")
            {
                MessageBox.Show("各値を入力してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            PalletMaster.Searcher.uniqueSkillList[tSkill] = tValue;

            PalletMaster.RefreshListView();
        }

        //「削除」を押したときの制御
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listViewSkill.SelectedItems.Count == 0) //項目が１つも選択されていない場合
                return; //処理を抜ける

            //1番目に選択されれいるアイテムをitemxに格納
            ListViewItem itemx = new ListViewItem();
            itemx = listViewSkill.SelectedItems[0];

            //選択されているアイテムを取得、削除
            PalletMaster.Searcher.uniqueSkillList.Remove(itemx.Text);
            PalletMaster.RefreshListView();
        }

        //listView1の選択が変化したときの制御
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //項目が１つも選択されていない場合
            if (listViewSkill.SelectedItems.Count == 0)
                return;//処理を抜ける

            //1番目に選択されれいるアイテムをitemxに格納
            ListViewItem itemx = new ListViewItem();
            itemx = listViewSkill.SelectedItems[0];

            //選択されているアイテムを取得する
            textResult.Text = PalletMaster.GetBotDiceText(itemx.SubItems[1].Text);// +" " + itemx.Text;

            //技能と値のテキストボックスに技能名、技能値を入れる
            textSkill.Text = itemx.Text;
            textValue.Text = itemx.SubItems[1].Text;

        }
        
        //「読込」を押したときの制御
        private void buttonRead_Click(object sender, EventArgs e)
        {
            {
                var al = new List<string>();
                OpenFileDialog ofDialog = new OpenFileDialog();

                //ダイアログのタイトルを指定する
                ofDialog.Title = "CSVファイル読み込み";

                //ダイアログを表示する
                if (ofDialog.ShowDialog() == DialogResult.OK)
                {
                    PalletMaster.Searcher.uniqueSkillList = Proccesser.ReadCSV(ofDialog.FileName);
                }
            }
            PalletMaster.RefreshListView();
        }

        //「検索」を押したときの制御
        private void buttonSerch_Click(object sender, EventArgs e)
        {
            var value = toSearchSkillValue(textSerch.Text);
            if (value is null) return;
            
            PalletMaster.SetClipBoard(PalletMaster.GetBotDiceText(value));
            textResult.Text = PalletMaster.GetBotDiceText(value);
            PalletMaster.SetSkillHistory(textSerch.Text, ロール.技能);
        }

        //指定された文字列に合致する技能の技能値をクリップボードに貼り付ける関数
        private string toSearchSkillValue(string skillName)
        {
            ////LINQ文とラムダ式を活用した処理
            var skillDict = PalletMaster.Searcher.uniqueSkillList.Where(s => s.Key == skillName).ToDictionary(s => s.Key, s => s.Value);

            if (skillDict.Count != 0) return skillDict[skillName];
            else
            {
                skillDict = PalletMaster.Searcher.DefaultSkillList.Where(s => s.Key == skillName).ToDictionary(s => s.Key, s => s.Value);

                if (skillDict.Count != 0) return skillDict[skillName];
                else
                {
                    MessageBox.Show("正しい技能名を入力してください。", "エラー", MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                    return null;
                }
            }

            ////例外処理で無理やり行った処理
            //try
            //{
            //    string tValue = PalletMaster.GetBotDiceText(PalletMaster.Searcher.uniqueSkillList[m_skillName]);// +" " + textSerch.Text;
            //    PalletMaster.SetClipBoard(tValue);
            //    textResult.Text = tValue;
            //    PalletMaster.SetSkillHistory(m_skillName, ロール.技能);
            //}
            //catch (Exception exception)
            //{
            //        try
            //        {
            //            string tValue = PalletMaster.GetBotDiceText(PalletMaster.Searcher.DefaultSkillList[m_skillName]);// +" " + textSerch.Text;
            //            PalletMaster.SetClipBoard(tValue);
            //            textResult.Text = tValue;
            //            PalletMaster.SetSkillHistory(m_skillName, ロール.技能);
            //        }
            //        catch (KeyNotFoundException)
            //        {
            //            MessageBox.Show("正しい技能名を入力してください。",
            //        "エラー",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //        }
            //        return;
            //    
            //}
        }

        //「検索」のテキストボードで[Enter]を押したときの制御
        private void textSerch_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Enterを押したときのみ反応するよう設定
            if (e.KeyChar == (char)Keys.Enter)
            {
                var value = toSearchSkillValue(textSerch.Text);
                if (value is null) return;

                PalletMaster.SetClipBoard(PalletMaster.GetBotDiceText(value));
                textResult.Text = PalletMaster.GetBotDiceText(value);
                PalletMaster.SetSkillHistory(textSerch.Text, ロール.技能);
            }
        }

        //ユーザー指定の文をクリップボードにコピー
        private void buttonTempleteUserCopy_Click(object sender, EventArgs e)
        {
            PalletMaster.SetClipBoard((textTempleteUser.Text));
        }

        //ダイス1つの文をクリップボードにコピー
        private void buttonTemplete1Copy_Click(object sender, EventArgs e)
        {
            PalletMaster.SetClipBoard((buttonTemplete1Copy.Text));
        }

        //ダイス2つの文をクリップボードにコピー
        private void buttonTemplete2Copy_Click(object sender, EventArgs e)
        {
            PalletMaster.SetClipBoard((buttonTemplete2Copy.Text));
        }

        //ダイス3つの文をクリップボードにコピー
        private void buttonTemplete3Copy_Click(object sender, EventArgs e)
        {
            PalletMaster.SetClipBoard((buttonTemplete3Copy.Text));
        }

        //対抗ロール
        private void buttonOppCheck_Click(object sender, EventArgs e)
        {
            int m_buff;
            if (int.TryParse(comboBoxOppChara.Text, out m_buff))
            {
                int value = 50 + (m_buff - int.Parse(textOppEnemy.Text)) * 5;
                Convert.ToString(int.Parse(PalletMaster.Searcher.searcherInfoList["SAN"]) + 1);
                PalletMaster.SetClipBoard(PalletMaster.GetBotDiceText(buttonTemplete1Copy.Text));
            }
            else
            {
                try
                {
                    int value = 50 + (int.Parse(PalletMaster.Searcher.abilityValueList[comboBoxOppChara.Text]) -
                        int.Parse(textOppEnemy.Text)) * 5;
                    PalletMaster.SetClipBoard(PalletMaster.GetBotDiceText(Convert.ToString(value)));
                }
                catch (Exception ee)
                {
                    MessageBox.Show("正しい入力をしてください。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        public void RefreshSkillList(){
            Proccesser.RefreshSkillList(listViewSkill, PalletMaster.Searcher.uniqueSkillList);
        }

        //「listview1」がダブルクリックされた時の動作
        private void listView1_MouseDoubleClick(object sender, EventArgs e)
        {
            //項目が１つも選択されていない場合
            if (listViewSkill.SelectedItems.Count == 0)
                return;//処理を抜ける

            ListViewItem itemx = new ListViewItem();

            //1番目に選択されれいるアイテムをitemxに格納
            itemx = listViewSkill.SelectedItems[0];

            //選択されているアイテムを取得する
            string tValue = PalletMaster.GetBotDiceText(itemx.SubItems[1].Text);
            PalletMaster.SetClipBoard(tValue);
            PalletMaster.SetSkillHistory(itemx.Text, ロール.技能);
        }

        internal void SetButtonTempletesText(string v)
        {
            if (v == "BCDice")
            {
                buttonTemplete1Copy.Text = "1d";
                buttonTemplete2Copy.Text = "2d";
                buttonTemplete3Copy.Text = "3d";
            }
            else if (v == "Sidekick")
            {
                buttonTemplete1Copy.Text = "/r 1d";
                buttonTemplete2Copy.Text = "/r 2d";
                buttonTemplete3Copy.Text = "/r 3d";
            }
        }
    }
}
