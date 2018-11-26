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
using Newtonsoft.Json;
using System.Net;

namespace ChaPalle
{
    public partial class MainForm : Form
    {
        Dictionary<string, string> m_defaultSkillList = new Dictionary<string, string>();
        Dictionary<string, string> m_uniqueSkillList = new Dictionary<string, string>();
        SkillHistoryData m_skillHistoryList = new SkillHistoryData();
        
        Dataset m_data = new Dataset();
        SettingData m_settingData = new SettingData();
        enum ロール {技能, 能力 };

        // データセット作成
        DataSet dS = new DataSet("dS");

        public MainForm(ref Dataset d)
        {
            InitializeComponent(); //フォームの初期化

            //設定の読込と初期設定
            m_settingData = toLoadSetting();
            if (m_settingData.m_useDiceBotFlg == 0)
                toChangeBCDice();
            else
                toChageSidekick();

            readCSV(System.AppDomain.CurrentDomain.BaseDirectory + "defaultSkill.csv", m_defaultSkillList);
            readCSV(System.AppDomain.CurrentDomain.BaseDirectory + "defaultSkill.csv", m_data.m_defaultSkillList);
            TopMost = m_settingData.m_checkTopMostFlg;
        }

        //
        //
        //===============================　共通
        //
        //
        
        //保存→CSVを押したときの制御
        private void cSVImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var al = new List<string>();
            OpenFileDialog ofDialog = new OpenFileDialog();

            // デフォルトのフォルダを指定する
            ofDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            //ダイアログのタイトルを指定する
            ofDialog.Title = "CSVファイル読み込み";
            ofDialog.Filter = "csvファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*";

            //ダイアログを表示する
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                readCSV(ofDialog.FileName, m_data.m_uniqueSkillList);
            }

            listView_refresh();
        }

        //設定を押したときの制御
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm u_form = new SettingForm(ref m_settingData);
            TopMost = false;
            u_form.ShowDialog();

            m_settingData = u_form.m_sD;

            TopMost = m_settingData.m_checkTopMostFlg;
            toSaveSetting(m_settingData);
        }
        
        //キャラを押したときの制御
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharaInfoForm u_form = new CharaInfoForm(m_data);
            TopMost = false;
            u_form.ShowDialog();

            m_data.m_sarcherInfoList["キャラクター名"] = u_form.m_charaName;
            m_data.m_sarcherInfoList["HP"] = u_form.m_hp;
            m_data.m_sarcherInfoList["MP"] = u_form.m_mp;
            m_data.m_sarcherInfoList["SAN"] = u_form.m_san;
            m_data.m_abilityValueList["STR"] = u_form.m_str;
            m_data.m_abilityValueList["CON"] = u_form.m_con;
            m_data.m_abilityValueList["POW"] = u_form.m_pow;
            m_data.m_abilityValueList["DEX"] = u_form.m_dex;
            m_data.m_abilityValueList["APP"] = u_form.m_app;
            m_data.m_abilityValueList["SIZ"] = u_form.m_siz;
            m_data.m_abilityValueList["INT"] = u_form.m_int;
            m_data.m_abilityValueList["EDU"] = u_form.m_edu;

            listView_refresh();
            textSANValue.Text = m_data.m_sarcherInfoList["SAN"]; //SAN情報の入力
            labelHPValue.Text = m_data.m_sarcherInfoList["HP"]; //HP情報の入力

            TopMost = m_settingData.m_checkTopMostFlg;
        }

        //保存→チャッパレ形式を押したときの制御
        private void チャッパレ形式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharacterData m_cData = new CharacterData();
            m_cData.m_abilityValueList = m_data.m_abilityValueList;
            m_cData.m_fightSkillList = m_data.m_fightSkillList;
            m_cData.m_sarcherInfoList = m_data.m_sarcherInfoList;
            m_cData.m_uniqueSkillList = m_data.m_uniqueSkillList;

            JSONSave(m_cData);
        }

        //チャッパレ形式保存関数
        void JSONSave(CharacterData tom)
        {
            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "チャッパレファイル(*.chp)|*.chp|すべてのファイル(*.*)|*.*";
            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、
                //選択された名前で新しいファイルを作成し、
                //読み書きアクセス許可でそのファイルを開く。
                //既存のファイルが選択されたときはデータが消える恐れあり。
                System.IO.Stream stream;
                stream = sfd.OpenFile();
                if (stream != null)
                {
                    //ファイルに書き込む
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(stream, Encoding.GetEncoding("Shift_JIS"));
                    string json = JsonConvert.SerializeObject(tom);//, Formatting.Indented);
                    sw.Write(json);
                    //閉じる
                    sw.Close();
                    stream.Close();
                }
            }
        }

        //履歴保存のためのクラスの定義
        class SkillHistoryData
        {
            public List<string> m_skill = new List<string>();
            public List<string> m_time = new List<string>();
            public List<ロール> m_type = new List<ロール>();

            public void Set(string sk, string ti, ロール ty)
            {
                this.m_skill.Add(sk);
                this.m_time.Add(ti);
                this.m_type.Add(ty);
            }
        }

        //チャッパレ形式をロードする再利用する構造体の定義
        struct chpLoad
        {
            internal CharacterData d;
            internal bool f;
        }

        //ロード→チャッパレ形式を押した時の制御
        private void チャッパレ形式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chpLoad m_d;
            m_d = JSONLoad();
            if (m_d.f)
            {

                m_data.m_abilityValueList = m_d.d.m_abilityValueList;
                m_data.m_fightSkillList = m_d.d.m_fightSkillList;
                m_data.m_sarcherInfoList = m_d.d.m_sarcherInfoList;
                m_data.m_uniqueSkillList = m_d.d.m_uniqueSkillList;

                textSANValue.Text = m_data.m_sarcherInfoList["SAN"]; //SAN情報の入力
                labelHPValue.Text = m_data.m_sarcherInfoList["HP"]; //HP情報の入力

                listView_refresh();
            }
        }

        //チャッパレ形式読み取り関数
        chpLoad JSONLoad()
        {
            chpLoad m_d;
            OpenFileDialog ofDialog = new OpenFileDialog();

            // デフォルトのフォルダを指定する
            ofDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            //ダイアログのタイトルを指定する
            ofDialog.Title = "チャッパレ形式ファイル読み込み";
            ofDialog.Filter = "チャッパレファイル(*.chp)|*.chp|すべてのファイル(*.*)|*.*";

            //ダイアログを表示する
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string json = System.IO.File.ReadAllText(ofDialog.FileName, Encoding.GetEncoding("Shift_JIS"));
                    m_d.d = JsonConvert.DeserializeObject<CharacterData>(json);
                    m_d.f = true;
                    return m_d;
                }
                catch(Exception e) { }
            }

            MessageBox.Show("読み込み時エラーが発生しました。",
            "エラー",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
            m_d.d = new CharacterData();
            m_d.f = false;
            return m_d;
            
        }

        //セッティングデータを保存
        public void toSaveSetting(SettingData m_sData)
        {
            //ファイルに書き込む
            System.IO.StreamWriter sw = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "setting.json");
            string json = JsonConvert.SerializeObject(m_sData);//, Formatting.Indented);
            sw.Write(json);
            //閉じる
            sw.Close();
        }

        //セッティングデータを読込
        public SettingData toLoadSetting()
        {
            try
            {
                string json = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "setting.json");
                return JsonConvert.DeserializeObject<SettingData>(json);
            }
            catch (Exception e)
            {
                SettingData m_sData = new SettingData();

                m_sData.m_checkMessageFlg = true;
                m_sData.m_checkTopMostFlg = true;
                m_sData.m_useDiceBotFlg = 0;

                return m_sData;
            }
        }

        //「CSV」を読込したときの制御
        private void toCreateCSV()
        {
            try
            {
                // ファイルを書き込み型式（上書き）で開く
                StreamWriter file = new StreamWriter(m_data.m_sarcherInfoList["キャラクター名"] + ".csv", false, Encoding.UTF8);
                foreach (KeyValuePair<string, string> kvp in m_data.m_uniqueSkillList)
                {
                    file.WriteLine(string.Format("{0},{1}", kvp.Key, kvp.Value));
                }
                file.Close();
                Console.WriteLine("ファイルに書き込みました");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);       // エラーメッセージを表示
            }
        }

        //「保存→CSV」をクリックしたときの制御
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toCreateCSV();
        }

        //「外部読込→キャラクター保管所」をクリックしたときの制御
        private void キャラクター保管所ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharaBankImportForm u_form = new CharaBankImportForm();
            TopMost = false;
            u_form.ShowDialog();

            TopMost = m_settingData.m_checkTopMostFlg;

            if (u_form.m_txtDataImportFlg == 2)
            {
                m_data.m_fightSkillList = new Dictionary<string, string>();
                m_data.m_uniqueSkillList = new Dictionary<string, string>();
                m_data.charaBankTxtFileRead();
                labelHPValue.Text = m_data.m_sarcherInfoList["HP"];
                listView_refresh();
            }
            else if (u_form.m_txtDataImportFlg == 1)
            {
                m_data.m_fightSkillList = new Dictionary<string, string>();
                m_data.m_uniqueSkillList = new Dictionary<string, string>();
                m_data.charaBankTxtDataRead(u_form.m_txtData);
                labelHPValue.Text = m_data.m_sarcherInfoList["HP"];
                listView_refresh();
            }
        }

        //「外部読込→キャラクターアーカイブ」をクリックしたときの制御
        private void キャラクターアーカイブToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharaArchiveImportForm u_form = new CharaArchiveImportForm();
            TopMost = false;
            u_form.ShowDialog();

            TopMost = m_settingData.m_checkTopMostFlg;

            if (u_form.m_URL != "")
                m_data.charaArchiveHTMLRead(u_form.m_URL);

            listView_refresh();
        }

        //「bcdice」をクリックしたときの制御
        private void buttonBCDice_Click(object sender, EventArgs e)
        {
            toChangeBCDice();
        }

        private void toChangeBCDice()
        {
            m_settingData.m_useDiceBotFlg = 0;
            buttonBCDice.Enabled = false;
            buttonSideKick.Enabled = true;
            buttonTemplete1Copy.Text = "1d";
            buttonTemplete2Copy.Text = "2d";
            buttonTemplete3Copy.Text = "3d";

            toSaveSetting(m_settingData);
        }

        //「sidekick」をクリックしたときの制御
        private void buttonSideKick_Click(object sender, EventArgs e)
        {
            toChageSidekick();
        }

        private void toChageSidekick()
        {
            m_settingData.m_useDiceBotFlg = 1;
            buttonBCDice.Enabled = true;
            buttonSideKick.Enabled = false;
            buttonTemplete1Copy.Text = "/r 1d";
            buttonTemplete2Copy.Text = "/r 2d";
            buttonTemplete3Copy.Text = "/r 3d";

            toSaveSetting(m_settingData);
        }

        //ダイスボット用の文字列を取得する関数
        //valueに判定値を、nameに技能など
        private string toGetBotDiceText(string value, string name = "")
        {
            return m_settingData.m_useDiceBotFlg == 0 ? "1d100<=" + value + " " + name
                : "/r 1d100<=" + value;
        }

        //
        public void toSetClipBoard(string m_copy)
        {
            Clipboard.SetText(m_copy);
            if (m_settingData.m_checkMessageFlg)
                MessageBox.Show("クリップボードにコピーしました", "成功", MessageBoxButtons.OK);
            else
                System.Media.SystemSounds.Asterisk.Play();
        }

        private void toSetSkillHistory(string m_skill, ロール m_type)
        {
            DateTime dt = DateTime.Now;
            m_skillHistoryList.Set(m_skill, dt.ToString("yyyy/MM/dd HH:mm:ss"), m_type);
        }

        //
        //
        //===============================　技能
        //
        //

        //「クリップボードにコピー」を押したときの制御
        private void buttonClipboardCopy_Click(object sender, EventArgs e)
        {
            string tValue = textResult.Text;
            toSetClipBoard(tValue);
        }

        //「追加」を押したときの制御
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
            m_data.m_uniqueSkillList[tSkill] = tValue;

            listView_refresh();
        }

        //「削除」を押したときの制御
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
            m_data.m_uniqueSkillList.Remove(itemx.Text);
            listView_refresh();
        }

        //listView1の選択が変化したときの制御
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

            //技能と値のテキストボックスに技能名、技能値を入れる
            textSkill.Text = itemx.Text;
            textValue.Text = itemx.SubItems[1].Text;

        }

        //listviewに関係する配列（m_uniqueSkillListなど）が変更された際に
        //listviewの中身を変更、更新する関数
        private void listView_refresh()
        {
            listView1.Items.Clear();
            listViewFight.Items.Clear();
            listViewHistory.Items.Clear();

            int m_buff;
            //能力値で技能値の決まる技能を代入
            {
                if (int.TryParse(m_data.m_abilityValueList["INT"], out m_buff)) //能力値が入力されていなければ無視する
                    m_data.m_uniqueSkillList["アイデア"] = Convert.ToString(m_buff * 5);
                if (int.TryParse(m_data.m_abilityValueList["POW"], out m_buff))
                    m_data.m_uniqueSkillList["幸運"] = Convert.ToString(m_buff * 5);
                if (int.TryParse(m_data.m_abilityValueList["EDU"], out m_buff))
                    m_data.m_uniqueSkillList["知識"] = Convert.ToString(m_buff * 5);
                if (int.TryParse(m_data.m_abilityValueList["DEX"], out m_buff) && !m_data.m_fightSkillList.ContainsKey("回避"))
                {
                    m_data.m_fightSkillList["回避"] = Convert.ToString(m_buff * 2);
                    m_data.m_uniqueSkillList["回避"] = Convert.ToString(m_buff * 2);
                }
            }

            //探索者固有(成長させた)技能をリストビューに入力
            foreach (KeyValuePair<string, string> kvp in m_data.m_uniqueSkillList)
            {
                string id = kvp.Key;
                string name = kvp.Value;

                string[] item1 = { id, name };
                listView1.Items.Add(new ListViewItem(item1));
            }

            //戦闘技能をリストビューに入力
            foreach (KeyValuePair<string, string> kvp in m_data.m_fightSkillList)
            {
                string id = kvp.Key;
                string name = kvp.Value;

                string[] item1 = { id, name };
                listViewFight.Items.Add(new ListViewItem(item1));
            }

            //使用した技能をリストビューに入力
            for (int i = 0; i < m_skillHistoryList.m_skill.Count(); i++)
            {
                string id = m_skillHistoryList.m_skill[i];
                string name = m_skillHistoryList.m_time[i];
                string type = m_skillHistoryList.m_type[i] == ロール.技能 ? "技能" : "能力";

                string[] item1 = { id, name, type };
                listViewHistory.Items.Add(new ListViewItem(item1));
            }

            if (int.TryParse(m_data.m_sarcherInfoList["SAN"], out m_buff))
                textSANValue.Text = Convert.ToString(m_buff);
            labelCharaName.Text = "キャラ名：" + m_data.m_sarcherInfoList["キャラクター名"];
        }

        //「読込」を押したときの制御
        private void button1_Click(object sender, EventArgs e)
        {
            {
                string line = "";
                var al = new List<string>();
                OpenFileDialog ofDialog = new OpenFileDialog();
                
                //ダイアログのタイトルを指定する
                ofDialog.Title = "CSVファイル読み込み";

                //ダイアログを表示する
                if (ofDialog.ShowDialog() == DialogResult.OK)
                {
                    readCSV(ofDialog.FileName, m_data.m_uniqueSkillList); 
                }
            }
            listView_refresh();
        }

        //csvファイルをlistview1に入力する
        public void readCSV(string filePath, Dictionary<string, string> list)
        {
            try
            {
                StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("Shift_JIS"));
                while (reader.Peek() >= 0)
                {
                    string[] cols = reader.ReadLine().Split(',');
                    list.Add(cols[0], cols[1]);
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

        //「listview1」をダブルクリック動作したときの制御
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
            toSetClipBoard(tValue);
            toSetSkillHistory(itemx.Text, ロール.技能);
        }

        //「検索」を押したときの制御
        private void buttonSerch_Click(object sender, EventArgs e)
        {
            try
            {
                string tValue = toGetBotDiceText(m_data.m_uniqueSkillList[textSerch.Text]);// +" " + textSerch.Text;
                toSetClipBoard(tValue);
                textResult.Text = tValue;
                toSetSkillHistory(textResult.Text, ロール.技能);
            }
            catch (KeyNotFoundException) {
                try
                {
                    string tValue = toGetBotDiceText(m_data.m_defaultSkillList[textSerch.Text]);// +" " + textSerch.Text;
                    toSetClipBoard(tValue);
                    textResult.Text = tValue;
                    toSetSkillHistory(textResult.Text, ロール.技能);
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

        private void toSearchSkillValue(string m_skillName)
        {
            try
            {
                string tValue = toGetBotDiceText(m_data.m_uniqueSkillList[m_skillName]);// +" " + textSerch.Text;
                toSetClipBoard(tValue);
                textResult.Text = tValue;
                toSetSkillHistory(m_skillName, ロール.技能);
            }
            catch (KeyNotFoundException)
            {
                try
                {
                    string tValue = toGetBotDiceText(m_data.m_defaultSkillList[m_skillName]);// +" " + textSerch.Text;
                    toSetClipBoard(tValue);
                    textResult.Text = tValue;
                    toSetSkillHistory(m_skillName, ロール.技能);
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

        //「検索」のテキストボードで[Enter]を押したときの制御
        private void textSerch_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Enterを押したときのみ反応するよう設定
            if (e.KeyChar == (char)Keys.Enter)
            {
                toSearchSkillValue(textSerch.Text);
            }
        }

        //ユーザー指定の文をクリップボードにコピー
        private void buttonTempleteUserCopy_Click(object sender, EventArgs e)
        {
            toSetClipBoard((textTempleteUser.Text));
        }

        //ダイス1つの文をクリップボードにコピー
        private void buttonTemplete1Copy_Click(object sender, EventArgs e)
        {
            toSetClipBoard((buttonTemplete1Copy.Text));
        }

        //ダイス2つの文をクリップボードにコピー
        private void buttonTemplete2Copy_Click(object sender, EventArgs e)
        {
            toSetClipBoard((buttonTemplete2Copy.Text));
        }

        //ダイス3つの文をクリップボードにコピー
        private void buttonTemplete3Copy_Click(object sender, EventArgs e)
        {
            toSetClipBoard((buttonTemplete3Copy.Text));
        }

        //対抗ロール
        private void buttonOppCheck_Click(object sender, EventArgs e)
        {
            int m_buff;
            if (int.TryParse(comboBoxOppChara.Text, out m_buff))
            {
                int value = 50 + (m_buff - int.Parse(textOppEnemy.Text)) * 5;
                Convert.ToString(int.Parse(textSANValue.Text) + 1);
                toSetClipBoard(toGetBotDiceText(buttonTemplete1Copy.Text));
            }
            else
            {
                try
                {
                    int value = 50 + (int.Parse(m_data.m_abilityValueList[comboBoxOppChara.Text]) -
                        int.Parse(textOppEnemy.Text)) * 5;
                    toSetClipBoard(toGetBotDiceText(Convert.ToString(value)));
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

        //
        //
        //===============================　SAN値
        //
        //

        //タブを選択したときの制御
        private void tabPageSAN_Click(object sender, EventArgs e)
        {
            listViewHistory.Items.Clear();

            //使用した技能をリストビューに入力
            for (int i = 0; i < m_skillHistoryList.m_skill.Count(); i++)
            {
                string id = m_skillHistoryList.m_skill[i];
                string name = m_skillHistoryList.m_time[i];
                string type = m_skillHistoryList.m_type[i] == ロール.技能 ? "技能" : "能力";

                string[] item1 = { id, name, type };
                listViewHistory.Items.Add(new ListViewItem(item1));
            }
        }

        //「SANチェック→判定」を押したときの制御
        private void buttonSANCheck_Click(object sender, EventArgs e)
        {
            string setSanCheck = "SANチェック文："+toGetBotDiceText(textSANValue.Text);
            label7.Text = setSanCheck;
            toSetClipBoard(toGetBotDiceText(textSANValue.Text));
        }

        //「SAN増減→判定」を押したときの制御
        private void buttonSANUpDown_Click(object sender, EventArgs e)
        {
            string setSanCheck = m_settingData.m_useDiceBotFlg == 0 ? comboBox1.Text+"d"+ comboBox2.Text
                : "/r "+ comboBox1.Text + "d" + comboBox2.Text;
            label8.Text = setSanCheck;
            toSetClipBoard(toGetBotDiceText(textSANValue.Text));
        }

        //「SANチェック→+」を押したときの制御
        private void buttonSANUp_Click(object sender, EventArgs e)
        {
            textSANValue.Text = Convert.ToString(int.Parse(textSANValue.Text) + int.Parse(comboBoxSANValue.Text));
        }

        //「SANチェック→-」を押したときの制御
        private void buttonSANDown_Click(object sender, EventArgs e)
        {
            int m_sanV; //現在SAN値
            int m_sanDiff; //SAN変動値

            if (int.TryParse(textSANValue.Text, out m_sanV) && int.TryParse(comboBoxSANValue.Text, out m_sanDiff)) {
                textSANValue.Text = Convert.ToString(m_sanV - m_sanDiff);

                //一時的発狂と不定の狂気の判定
                if (m_sanDiff >= m_sanV / 5)
                {
                    MessageBox.Show("不定の狂気です。1d10をクリップボードにコピーしました",
                        "不定の狂気",
                        MessageBoxButtons.OK);
                    Clipboard.SetText(m_settingData.m_useDiceBotFlg == 0 ? "1d10"
                    : "/r 1d10");
                }
                else if (m_sanDiff >= 5)
                {
                    int idea;
                    if (int.TryParse(m_data.m_abilityValueList["INT"], out idea))
                    {
                        Clipboard.SetText(toGetBotDiceText(Convert.ToString(idea * 5)));
                        MessageBox.Show("一時的発狂です。アイデアロールをクリップボードにコピーしました",
                        "一時的発狂",
                        MessageBoxButtons.OK);
                        return;
                    } else
                    {
                        MessageBox.Show("一時的発狂です。アイデアロールをしてください。",
                        "一時的発狂",
                        MessageBoxButtons.OK);
                        return;
                    }
                }
            }
        }

        //狂気表の表示
        private void buttonMadnessTable_Click(object sender, EventArgs e)
        {
            MadnessTableForm u_form = new MadnessTableForm();
            TopMost = false;
            u_form.ShowDialog();

            TopMost = m_settingData.m_checkTopMostFlg;
        }

        //
        //
        //====================================戦闘タブ==========================
        //
        //
        private void listViewFight_SelectedIndexChanged(object sender, EventArgs e)
        {

            //項目が１つも選択されていない場合
            if (listViewFight.SelectedItems.Count == 0)
                //処理を抜ける
                return;

            ListViewItem itemx = new ListViewItem();

            //1番目に選択されれいるアイテムをitemxに格納
            itemx = listViewFight.SelectedItems[0];

            //技能と値のテキストボックスに技能名、技能値を入れる
            textSkillFight.Text = itemx.Text;
            textValueFight.Text = itemx.SubItems[1].Text;
        }

        private void listViewFight_DoubleClick(object sender, EventArgs e)
        {

            //項目が１つも選択されていない場合
            if (listViewFight.SelectedItems.Count == 0)
                //処理を抜ける
                return;

            ListViewItem itemx = new ListViewItem();

            //1番目に選択されているアイテムをitemxに格納
            itemx = listViewFight.SelectedItems[0];

            //選択されているアイテムを取得する
            string tValue = toGetBotDiceText(itemx.SubItems[1].Text);
            toSetClipBoard(tValue);
            toSetSkillHistory(itemx.Text, ロール.技能);
        }

        string getSkillValue(string skillName)
        {

            try
            {
                toSetSkillHistory(skillName, ロール.技能);
                return (toGetBotDiceText(m_data.m_fightSkillList[skillName]));
            }
            catch (KeyNotFoundException)
            {
                MessageBox.Show(skillName + "を設定してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return "";
            }
        }

        private void buttonAvoid_Click(object sender, EventArgs e)
        {
            getSkillValue("回避");
        }

        private void buttonFist_Click(object sender, EventArgs e)
        {
            getSkillValue("こぶし（パンチ）");
        }

        private void buttonKick_Click(object sender, EventArgs e)
        {
            getSkillValue("キック");
        }

        private void buttonHPPlus_Click(object sender, EventArgs e)
        {
            int m_hp; //現在HP
            int m_hpDiff; //HP変動値

            if (int.TryParse(labelHPValue.Text, out m_hp) && 
                int.TryParse(comboBoxHPValue.Text, out m_hpDiff))
                labelHPValue.Text = Convert.ToString(m_hp + m_hpDiff);
        }

        private void buttonHPMinus_Click(object sender, EventArgs e)
        {
            float m_hp; //現在HP
            int m_hpDiff; //HP変動値

            if (float.TryParse(labelHPValue.Text, out m_hp) && 
                int.TryParse(comboBoxHPValue.Text, out m_hpDiff))
            {
                labelHPValue.Text = Convert.ToString(m_hp - m_hpDiff);

                if(m_hp - m_hpDiff <= 2)
                    MessageBox.Show("気絶しました。","気絶",MessageBoxButtons.OK);
                else if (m_hp / 2 <= m_hpDiff)
                {
                    int m_con;
                    if (int.TryParse(m_data.m_abilityValueList["CON"], out m_con))
                    {
                        Clipboard.SetText(toGetBotDiceText(Convert.ToString(m_con * 5)));
                        MessageBox.Show("気絶ロールが発生しました。CON×5をクリップボードにコピーしました",
                        "気絶ロール",
                        MessageBoxButtons.OK);
                    }
                    else
                        MessageBox.Show("気絶ロールが発生しました。",
                            "気絶ロール",
                        MessageBoxButtons.OK);
                }
            }
        }

        private void buttonAddFight_Click(object sender, EventArgs e)
        {
            string tSkill = textSkillFight.Text;
            string tValue = textValueFight.Text;
            if (tSkill == "" || tValue == "")
            {
                MessageBox.Show("各値を入力してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            m_data.m_fightSkillList[tSkill] = tValue;

            listView_refresh();
        }
        
        private void buttonDeleteFight_Click(object sender, EventArgs e)
        {

            //項目が１つも選択されていない場合
            if (listViewFight.SelectedItems.Count == 0)
                //処理を抜ける
                return;

            ListViewItem itemx = new ListViewItem();

            //1番目に選択されれいるアイテムをitemxに格納
            itemx = listViewFight.SelectedItems[0];

            //選択されているアイテムを取得、削除
            m_data.m_fightSkillList.Remove(itemx.Text);
            listView_refresh();
        }
        
        //
        //
        //====================================履歴と能力値ロールタブ==========================
        //
        //

        private void buttonAbilityRole_Click(object sender, EventArgs e)
        {
            int m_ability;
            int m_magni;

            if(int.TryParse(m_data.m_abilityValueList[listBoxAbility.Text], out m_ability) && int.TryParse(listBoxValue.Text, out m_magni))
            {
                toSetSkillHistory(listBoxAbility.Text + "×" + listBoxValue.Text, ロール.能力);
                toSetClipBoard(toGetBotDiceText(Convert.ToString(m_ability * m_magni)));
            }

            listView_refresh();
        }

        private void tabHistoryAblityRole_Click(object sender, EventArgs e)
        {
            listView_refresh();
        }

        private void listViewHistory_DoubleClick(object sender, EventArgs e)
        {
            //項目が１つも選択されていない場合
            if (listViewHistory.SelectedItems.Count == 0)
                //処理を抜ける
                return;

            ListViewItem itemx = new ListViewItem();

            //1番目に選択されているアイテムをitemxに格納
            itemx = listViewHistory.SelectedItems[0];

            //選択されているアイテムを取得する
            if (itemx.SubItems[2].Text == "技能")
            {
                toSearchSkillValue(itemx.SubItems[0].Text);
            }
            else
            {
                int m_ability;
                char[] del = { '×' };
                string[] arr = itemx.SubItems[0].Text.Split(del, StringSplitOptions.RemoveEmptyEntries);
                if (int.TryParse(m_data.m_abilityValueList[arr[0]], out m_ability))
                {
                    Clipboard.SetText(toGetBotDiceText(Convert.ToString(m_ability * int.Parse(arr[1]))));
                    toSetSkillHistory(arr[0] + " × " + arr[1], ロール.能力);
                }
            }

            listView_refresh();

        }

        private void buttonPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();

            // デフォルトのフォルダを指定する
            ofDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            //ダイアログのタイトルを指定する
            ofDialog.Title = "画像ファイル読み込み";
            ofDialog.Filter = "画像ファイル(*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp|すべてのファイル(*.*)|*.*";

            //ダイアログを表示する
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBoxMemo.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBoxMemo.Image = System.Drawing.Image.FromFile(ofDialog.FileName);
                }
                catch (Exception ee) { }

            }
        }
    }
}
