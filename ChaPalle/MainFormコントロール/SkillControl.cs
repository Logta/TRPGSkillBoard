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
using System.Net.Http;
using Newtonsoft.Json;

namespace PalletMaster
{
    public partial class SkillControl : UserControl
    {
        PalletMaster PalletMaster = new PalletMaster();
        Proccess Proccesser = new Proccess();

        bool correctionFlg = false;

        public SkillControl()
        {
            InitializeComponent();
            correctionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            correctionSetButton.Checked = correctionFlg;
        }

        public void SetPalletMaster(PalletMaster palletMaster)
        {
            PalletMaster = palletMaster;
        }

        public void SetButtonTempleteUserCopyName(string name)
        {
            buttonTempleteUserCopy.Text = name;
        }

        //「クリップボードにコピー」を押したときの制御
        private void buttonClipboardCopy_ClickAsync(object sender, EventArgs e)
        {
            bcDiceAccess(PalletMaster.Setting.webhookURL);
        }

        private async Task bcDiceAccess(string url)
        {
            //BCDice-APIにGET通信してダイスを振る
            var result = new Proccess().SendGetBCDice_API(textResult.Text,
                PalletMaster.Setting.bcdiceAPIURL);

            using(var hc = new HttpClient()) { 
                
                var json = JsonConvert.SerializeObject(new
                {
                    username = PalletMaster.Setting.userName,
                    content = textResult.Text.Length == 0 ?
                            DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") :
                            textResult.Text,
                });

                //var content = new StringContent(json, Encoding.UTF8, "application/json");
                //var res = hc.PostAsync(url, content).Result;
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var res = await hc.SendAsync(request);

            }
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
            PalletMaster.Searcher.uniqueSkills[tSkill] = tValue;

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
            PalletMaster.Searcher.uniqueSkills.Remove(itemx.Text);
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
            textResult.Text = PalletMaster.GetDiceText(correctValue(itemx.SubItems[1].Text), itemx.Text);// +" " + itemx.Text;

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
                    PalletMaster.Searcher.uniqueSkills = Proccesser.ReadCSV(ofDialog.FileName);
                }
            }
            PalletMaster.RefreshListView();
        }

        //「検索」を押したときの制御
        private void buttonSerch_Click(object sender, EventArgs e)
        {
            var value = toSearchSkillValue(textSerch.Text);
            if (value is null) return;

            value = correctValue(value);

            PalletMaster.SetTextRole(value, textSerch.Text);

            textResult.Text = PalletMaster.GetDiceText(value, textSerch.Text);
            PalletMaster.SetSkillHistory(textSerch.Text, ロール.技能);
        }

        //指定された文字列に合致する技能の技能値をクリップボードに貼り付ける関数
        private string toSearchSkillValue(string skillName)
        {
            ////LINQ文とラムダ式を活用した処理
            var skillDict = PalletMaster.Searcher.uniqueSkills.Where(s => s.Key == skillName).ToDictionary(s => s.Key, s => s.Value);

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
        }

        //「検索」のテキストボードで[Enter]を押したときの制御
        private void textSerch_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Enterを押したときのみ反応するよう設定
            if (e.KeyChar == (char)Keys.Enter)
            {
                var value = toSearchSkillValue(textSerch.Text);
                if (value is null) return;

                value = correctValue(value);

                PalletMaster.SetTextRole(value, textSerch.Text);

                textResult.Text = PalletMaster.GetDiceText(value, textSerch.Text);
                PalletMaster.SetSkillHistory(textSerch.Text, ロール.技能);
            }
        }

        //ユーザー指定の文をクリップボードにコピー
        private void buttonTempleteUserCopy_Click(object sender, EventArgs e)
        {
            if (PalletMaster.Setting.useBCDiceAPIFlg)
            {
                new Proccess().SendPostWebhookBCDiceAPI(textTempleteUser.Text,
                     PalletMaster.Setting.webhookURL, PalletMaster.Setting.bcdiceAPIURL,
                     PalletMaster.Setting.userName, "定型");
            }
            else
            {
                PalletMaster.SetClipBoard(textTempleteUser.Text);
            }
        }

        //ダイス1つの文をクリップボードにコピー
        private void buttonTemplete1Copy_Click(object sender, EventArgs e)
        {
            textTempleteUser.Text = buttonTemplete1Copy.Text;
        }

        //ダイス2つの文をクリップボードにコピー
        private void buttonTemplete2Copy_Click(object sender, EventArgs e)
        {
            textTempleteUser.Text = buttonTemplete2Copy.Text;
        }

        //ダイス3つの文をクリップボードにコピー
        private void buttonTemplete3Copy_Click(object sender, EventArgs e)
        {
            if (int.TryParse(diceNumberComboBox.Text, out var count))
            {
                if (buttonTemplete3Copy.Text == "/r d")
                    textTempleteUser.Text = "/r " + diceNumberComboBox.Text +"d";
                else
                textTempleteUser.Text = diceNumberComboBox.Text +
                    buttonTemplete3Copy.Text;
            }
        }

        //対抗ロール
        private void buttonOppCheck_Click(object sender, EventArgs e)
        {
            int m_buff;
            if (int.TryParse(comboBoxOppChara.Text, out m_buff))
            {
                var value = 50 + (m_buff - int.Parse(textOppEnemy.Text)) * 5;
                value = correctValue(value);
                PalletMaster.SetTextRole(PalletMaster.GetDiceText(Convert.ToString(value), "対抗ロール"), "対抗ロール");
            }
            else
            {
                try
                {
                    var value = 50 + (int.Parse(PalletMaster.Searcher.abilityValues[comboBoxOppChara.Text]) -
                        int.Parse(textOppEnemy.Text)) * 5;
                    value = correctValue(value);
                    PalletMaster.SetTextRole(PalletMaster.GetDiceText(Convert.ToString(value), "対抗ロール"), "対抗ロール");
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
            Proccesser.RefreshSkillList(listViewSkill, PalletMaster.Searcher.uniqueSkills);
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
            var tValue = PalletMaster.GetDiceText(correctValue(itemx.SubItems[1].Text), itemx.Text);
            PalletMaster.SetTextRole(tValue, itemx.Text);
            PalletMaster.SetSkillHistory(itemx.Text, ロール.技能);
        }

        internal void SetButtonTempletesText(string v)
        {
            if (v == "BCDice")
            {
                buttonTemplete1Copy.Text = "1d";
                buttonTemplete2Copy.Text = "2d";
                buttonTemplete3Copy.Text = "d";
            }
            else if (v == "Sidekick")
            {
                buttonTemplete1Copy.Text = "/r 1d";
                buttonTemplete2Copy.Text = "/r 2d";
                buttonTemplete3Copy.Text = "/r d";
            }
        }

        private void correctionSetButton_Click(object sender, EventArgs e)
        {
            correctionSetButton.Checked = correctionFlg = !correctionFlg;
        }

        private string correctValue(string value)
        {
            var tempValue = 0;

            if (correctionFlg)
            {
                int tempCorrect, tempCorrectLabel;
                if (int.TryParse(value, out tempCorrect) && int.TryParse(correctionValueComboBox.Text, out tempCorrectLabel))
                {
                    if (correctionComboBox.Text == "+")
                        tempValue = tempCorrect + tempCorrectLabel;
                    else
                        tempValue = tempCorrect - tempCorrectLabel;
                }
            }
            else
                return value;

            if (tempValue <= 0) return "0";
            else if (tempValue >= 100) return "100";
            else return tempValue.ToString();
        }

        private int correctValue(int value)
        {
            var tempValue = 0;

            if (correctionFlg)
            {
                int tempCorrectLabel;
                if (int.TryParse(correctionValueComboBox.Text, out tempCorrectLabel))
                {
                    if (correctionComboBox.Text == "+")
                        tempValue = value + tempCorrectLabel;
                    else
                        tempValue = value - tempCorrectLabel;
                }
            }
            else
                return value;

            if (tempValue <= 0) return 0;
            else if (tempValue >= 100) return 100;
            else return tempValue;
        }
    }
}
