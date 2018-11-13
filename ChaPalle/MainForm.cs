using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace ChaPalle
{
    public partial class MainForm : Form
    {
        Dictionary<string, string> m_defaultSkillList = new Dictionary<string, string>();
        Dictionary<string, string> m_uniqueSkillList = new Dictionary<string, string>();
        int m_useDiceBotFlg = 0;
        bool mainFormTopMostFlg = true;
        dataset datas = new dataset();

        public MainForm(ref dataset d)
        {
            InitializeComponent();
            readCSV(System.AppDomain.CurrentDomain.BaseDirectory + "defaultSkill.csv", m_defaultSkillList);
            readCSV(System.AppDomain.CurrentDomain.BaseDirectory + "defaultSkill.csv", datas.m_defaultSkillList);
            TopMost = mainFormTopMostFlg;
        }

        private void buttonClipboardCopy_Click(object sender, EventArgs e)
        {
            string tValue = textResult.Text;
            Clipboard.SetText(tValue);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string tSkill = textSkill.Text;
            string tValue = textValue.Text;
            if (tSkill == "" || tValue == "") { MessageBox.Show("各値を入力してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            datas.m_uniqueSkillList.Add(tSkill, tValue);

            listView_refesh();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //項目が１つも選択されていない場合
            if (listView1.SelectedItems.Count == 0)
                //処理を抜ける
                return;

            ListViewItem itemx = new ListViewItem();

            //1番目に選択されれいるアイテムをitemxに格納
            itemx = listView1.SelectedItems[0];

            //選択されているアイテムを取得、削除
            datas.m_uniqueSkillList.Remove(itemx.Text);
            listView_refesh();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //項目が１つも選択されていない場合
            if (listView1.SelectedItems.Count == 0)
                //処理を抜ける
                return;

            ListViewItem itemx = new ListViewItem();

            //1番目に選択されれいるアイテムをitemxに格納
            itemx = listView1.SelectedItems[0];

            //選択されているアイテムを取得する
            textResult.Text = toGetBotDiceText(itemx.SubItems[1].Text);// +" " + itemx.Text;

        }

        public void readCSV(string filePath, Dictionary<string, string> list)
        {
            try
            {
                StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("Shift_JIS"));
                while (reader.Peek() >= 0)
                {
                    string[] cols = reader.ReadLine().Split(',');
                    //try
                    //{
                        list.Add(cols[0], cols[1]);
                    //}
                    //catch (ArgumentException) { }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("正しいファイル名を入力してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void listView_refesh()
        {
            listView1.Items.Clear();
            foreach (KeyValuePair < string, string > kvp in datas.m_uniqueSkillList)
            {
                string id = kvp.Key;
                string name = kvp.Value;

                string[] item1 = { id , name };
                listView1.Items.Add(new ListViewItem(item1));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textCSV.Text != "") {
                readCSV(AppDomain.CurrentDomain.BaseDirectory + textCSV.Text, datas.m_uniqueSkillList);
            }
            else
            {
                string line = "";
                var al = new List<string>();
                OpenFileDialog ofDialog = new OpenFileDialog();

                // デフォルトのフォルダを指定する
                ofDialog.InitialDirectory = @"C:";

                //ダイアログのタイトルを指定する
                ofDialog.Title = "CSVファイル読み込み";

                //ダイアログを表示する
                if (ofDialog.ShowDialog() == DialogResult.OK)
                {
                    readCSV(ofDialog.FileName, datas.m_uniqueSkillList); 
                }
            }
            listView_refesh();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //項目が１つも選択されていない場合
            if (listView1.SelectedItems.Count == 0)
                //処理を抜ける
                return;

            ListViewItem itemx = new ListViewItem();

            //1番目に選択されれいるアイテムをitemxに格納
            itemx = listView1.SelectedItems[0];

            //選択されているアイテムを取得する
            string tValue = toGetBotDiceText(itemx.SubItems[1].Text);// +" " + itemx.Text; ;
            Clipboard.SetText(tValue);
        }

        private void buttonSerch_Click(object sender, EventArgs e)
        {
            try
            {
                string tValue = toGetBotDiceText(datas.m_uniqueSkillList[textSerch.Text]);// +" " + textSerch.Text;
                Clipboard.SetText(tValue);
                textResult.Text = tValue;
                MessageBox.Show("クリップボードにコピーしました", "成功", MessageBoxButtons.OK);
            }
            catch (KeyNotFoundException) {
                try
                {
                    string tValue = toGetBotDiceText(datas.m_defaultSkillList[textSerch.Text]);// +" " + textSerch.Text;
                    Clipboard.SetText(tValue);
                    textResult.Text = tValue;
                    MessageBox.Show("クリップボードにコピーしました", "成功", MessageBoxButtons.OK);
                }
                catch (KeyNotFoundException)
                {
                    MessageBox.Show("正しい技能名を入力してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                }
            }
        }

        private void textSerch_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Enterを押したときのみ反応するよう設定
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    string tValue = toGetBotDiceText(datas.m_uniqueSkillList[textSerch.Text]);// +" " + textSerch.Text;
                    Clipboard.SetText(tValue);
                    textResult.Text = tValue;
                    MessageBox.Show("クリップボードにコピーしました","成功", MessageBoxButtons.OK);
                }
                catch (KeyNotFoundException)
                {
                    try
                    {
                        string tValue = toGetBotDiceText(datas.m_defaultSkillList[textSerch.Text]);// +" " + textSerch.Text;
                        Clipboard.SetText(tValue);
                        textResult.Text = tValue;
                        MessageBox.Show("クリップボードにコピーしました", "成功", MessageBoxButtons.OK);
                    }
                    catch (KeyNotFoundException)
                    {
                        MessageBox.Show("正しい技能名を入力してください。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    }
                }


            }
        }

        private void buttonBCDice_Click(object sender, EventArgs e)
        {
            m_useDiceBotFlg = 0;
            buttonBCDice.Enabled = false;
            buttonSideKick.Enabled = true;
        }

        private void buttonSideKick_Click(object sender, EventArgs e)
        {
            m_useDiceBotFlg = 1;
            buttonBCDice.Enabled = true;
            buttonSideKick.Enabled = false;
        }

        private void toCreateCSV()
        {
            try
            {
                // ファイルを書き込み型式（上書き）で開く
                StreamWriter file = new StreamWriter(datas.m_sarcherInfoList["キャラクター名"]+".csv", false, Encoding.UTF8);
                foreach (KeyValuePair<string, string> kvp in datas.m_uniqueSkillList)
                {
                    file.WriteLine(string.Format("{0},{1}",  kvp.Key,  kvp.Value));
                }
                file.Close();
                Console.WriteLine("ファイルに書き込みました");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);       // エラーメッセージを表示
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toCreateCSV();
        }

        private void キャラクター保管所ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datas.m_fightSkillList = new Dictionary<string, string>();
            datas.m_uniqueSkillList = new Dictionary<string, string>();
            datas.charaBankTxtRead();
            listView_refesh();
        }

        private void tabPageSAN_Click(object sender, EventArgs e)
        {
            textSANValue.Text = datas.m_sarcherInfoList["SAN"];
        }

        private void buttonSANCheck_Click(object sender, EventArgs e)
        {
            string setSanCheck = "SANチェック文："+toGetBotDiceText(textSANValue.Text);
            label7.Text = setSanCheck;
            Clipboard.SetText(toGetBotDiceText(textSANValue.Text));
        }

        private string toGetBotDiceText(string value)
        {
            return m_useDiceBotFlg == 0 ? "1d100<=" + value
                : "/r 1d100<=" + value;
        }

        private void buttonSANUpDown_Click(object sender, EventArgs e)
        {
            string setSanCheck = m_useDiceBotFlg == 0 ? comboBox1.Text+"d"+ comboBox2.Text
                : "/r "+ comboBox1.Text + "d" + comboBox2.Text;
            label8.Text = setSanCheck;
            Clipboard.SetText(toGetBotDiceText(textSANValue.Text));
        }

        private void buttonSANUp_Click(object sender, EventArgs e)
        {
            textSANValue.Text = Convert.ToString(int.Parse(textSANValue.Text) + 1);
        }

        private void buttonSANDown_Click(object sender, EventArgs e)
        {
            textSANValue.Text = Convert.ToString(int.Parse(textSANValue.Text) - 1);
        }

        private void cSVImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var al = new List<string>();
            OpenFileDialog ofDialog = new OpenFileDialog();

            // デフォルトのフォルダを指定する
            ofDialog.InitialDirectory = @"C:";

            //ダイアログのタイトルを指定する
            ofDialog.Title = "CSVファイル読み込み";

            //ダイアログを表示する
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                readCSV(ofDialog.FileName, datas.m_uniqueSkillList);
            }

            listView_refesh();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm u_form = new SettingForm(mainFormTopMostFlg);
            TopMost = false;
            u_form.ShowDialog();

            mainFormTopMostFlg = u_form.m_checkTopMostFlg;
            TopMost = mainFormTopMostFlg;

        }
        
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm u_form = new UserForm(datas);
            TopMost = false;
            u_form.ShowDialog();
            TopMost = mainFormTopMostFlg;
        }
    }
}
