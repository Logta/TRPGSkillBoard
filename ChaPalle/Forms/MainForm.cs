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
using System.Collections;
using Newtonsoft.Json;
using System.Net;

namespace ChaPalle
{
    public partial class MainForm : Form
    {       
        PalletMaster PalletMaster { get; set; }
        Proccess Proccesser = new Proccess();
        IOHelper IOHelper = new IOHelper();

        // データセット作成
        DataSet dS = new DataSet("dS");

        //ユーザーコントロール作成
        SkillControl skillControl = new SkillControl();
        SANControl sanControl = new SANControl();
        FightControl fightControl = new FightControl();
        HistoryAbilityControl historyAbilityControl = new HistoryAbilityControl();


        public MainForm(Searcher d)
        {
            InitializeComponent(); //フォームの初期化
            PalletMaster = new PalletMaster();

            //設定の読込と初期設定
            PalletMaster.Setting = toLoadSetting();
            if (PalletMaster.Setting.useDiceBotFlg == 0)
                toChangeBCDice();
            else
                toChageSidekick();

            var defaultSkillList = Proccesser.ReadCSV(System.AppDomain.CurrentDomain.BaseDirectory + "defaultSkill.csv");
            PalletMaster.Searcher.SetDefaultSkills(defaultSkillList);

            historyAbilityControl.SelectedIndexListBoxAbility(0);
            historyAbilityControl.SelectedIndexListBoxValue(4);
            
            //フォームを最前面に表示するか否かをセット
            TopMost = PalletMaster.Setting.checkTopMostFlg;

            //PalletMasterのコンストラクタにMainFormを割り当てる
            //PalletMasterからMainFormの関数を叩けるようにする
            PalletMaster.SetMainForm(this);

            //skillControlを技能タブに割り当てる
            skillControl.SetPalletMaster(PalletMaster);
            setTab(skillControl, tabPageSkill);

            //SANControlを技能タブに割り当てる
            sanControl.SetPalletMaster(PalletMaster);
            setTab(sanControl, tabPageSAN);

            //FightControlを技能タブに割り当てる
            fightControl.SetPalletMaster(PalletMaster);
            setTab(fightControl, tabPageFight);

            //FightControlを技能タブに割り当てる
            historyAbilityControl.SetPalletMaster(PalletMaster);
            setTab(historyAbilityControl, tabHistoryAblityRole);
        }

        private void setTab(UserControl userControl,TabPage tabPage)
        {
            tabPage.Controls.Add(userControl);
            userControl.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        //
        //
        //===============================　共通
        //
        //

        //保存→CSVを押したときの制御
        private void CSVImportToolStripMenuItem_Click(object sender, EventArgs e)
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
                PalletMaster.Searcher.uniqueSkillList = Proccesser.ReadCSV(ofDialog.FileName);
            }

            PalletMaster.RefreshListView();
        }

        //設定を押したときの制御
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm u_form = new SettingForm(PalletMaster);
            TopMost = false;
            u_form.ShowDialog();

            PalletMaster.Setting = u_form.iOData.Setting;
            TopMost = PalletMaster.Setting.checkTopMostFlg;
            toSaveSetting(PalletMaster.Setting);
        }
        
        //キャラを押したときの制御
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PalletMaster.Searcher.searcherInfoList["SAN"] = sanControl.GetSanText();
            CharaInfoForm u_form = new CharaInfoForm(PalletMaster.Searcher);
            TopMost = false;
            u_form.ShowDialog();

            PalletMaster.Searcher = u_form.Searcher;

            sanControl.SetSanText(PalletMaster.Searcher.searcherInfoList["SAN"]); //SAN情報の入力
            fightControl.SetFightText(PalletMaster.Searcher.searcherInfoList["HP"]); //HP情報の入力

            PalletMaster.RefreshListView();
            TopMost = PalletMaster.Setting.checkTopMostFlg;
        }

        //保存→チャッパレ形式を押したときの制御
        private void チャッパレ形式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Character m_cData = new Character();
            m_cData = PalletMaster.Searcher;

            JSONSave(m_cData);
        }

        //チャッパレ形式保存関数
        void JSONSave(Character tom)
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
                }
                stream.Close();
            }
        }

        //チャッパレ形式をロードする再利用する構造体の定義
        struct chpLoad
        {
            internal Character d;
            internal bool f;
        }

        //ロード→チャッパレ形式を押した時の制御
        private void チャッパレ形式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chpLoad m_d;
            m_d = JSONLoad();
            if (m_d.f)
            {
                PalletMaster.Searcher = new Searcher();
                PalletMaster.Searcher.SetSearcher(m_d.d);
                
                sanControl.SetSanText(PalletMaster.Searcher.searcherInfoList["SAN"]); //SAN情報の入力
                fightControl.SetFightText(PalletMaster.Searcher.searcherInfoList["HP"]); //HP情報の入力
                                
                PalletMaster.RefreshListView();
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
                    m_d.d = JsonConvert.DeserializeObject<Character>(json);
                    m_d.f = true;
                    return m_d;
                }
                catch(Exception e) {
                    MessageBox.Show("読み込み時エラーが発生しました。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    m_d.d = new Character();
                    m_d.f = false;
                    return m_d;
                }
            }

            m_d.d = new Character();
            m_d.f = false;
            return m_d;
        }

        //セッティングデータを保存
        public void toSaveSetting(Setting m_sData)
        {
            //ファイルに書き込む
            System.IO.StreamWriter sw = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "setting.json");
            string json = JsonConvert.SerializeObject(m_sData);//, Formatting.Indented);
            sw.Write(json);
            //閉じる
            sw.Close();
        }

        //セッティングデータを読込
        public Setting toLoadSetting()
        {
            try
            {
                string json = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "setting.json");
                return JsonConvert.DeserializeObject<Setting>(json);
            }
            catch (Exception e)
            {
                Setting m_sData = new Setting();

                m_sData.checkMessageFlg = true;
                m_sData.checkTopMostFlg = true;
                m_sData.useDiceBotFlg = 0;

                return m_sData;
            }
        }

        //「CSV」を読込したときの制御
        private void toCreateCSV()
        {
            try
            {
                // ファイルを書き込み型式（上書き）で開く
                StreamWriter file = new StreamWriter(PalletMaster.Searcher.searcherInfoList["キャラクター名"] + ".csv", false, Encoding.UTF8);
                foreach (KeyValuePair<string, string> kvp in PalletMaster.Searcher.uniqueSkillList)
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

            TopMost = PalletMaster.Setting.checkTopMostFlg;

            if (u_form.m_txtDataImportFlg == 2)
            {
                PalletMaster.Searcher.fightSkillList = new Dictionary<string, string>();
                PalletMaster.Searcher.uniqueSkillList = new Dictionary<string, string>();
                PalletMaster.Searcher = IOHelper.charaBankTxtFileRead();
                fightControl.SetFightText(PalletMaster.Searcher.searcherInfoList["HP"]);
                PalletMaster.RefreshListView();
            }
            else if (u_form.m_txtDataImportFlg == 1)
            {
                PalletMaster.Searcher.fightSkillList = new Dictionary<string, string>();
                PalletMaster.Searcher.uniqueSkillList = new Dictionary<string, string>();
                PalletMaster.Searcher = IOHelper.charaBankTxtDataRead(u_form.m_txtData);
                fightControl.SetFightText(PalletMaster.Searcher.searcherInfoList["HP"]);
                PalletMaster.RefreshListView();
            }
        }

        //「外部読込→キャラクターアーカイブ」をクリックしたときの制御
        private void キャラクターアーカイブToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharaArchiveImportForm u_form = new CharaArchiveImportForm();
            TopMost = false;
            u_form.ShowDialog();

            TopMost = PalletMaster.Setting.checkTopMostFlg;

            if (u_form.m_URL != "")
                PalletMaster.Searcher = IOHelper.charaArchiveHTMLRead(u_form.m_URL);

            PalletMaster.RefreshListView();
        }

        //「bcdice」をクリックしたときの制御
        private void buttonBCDice_Click(object sender, EventArgs e)
        {
            toChangeBCDice();
        }

        private void toChangeBCDice()
        {
            PalletMaster.Setting.useDiceBotFlg = 0;
            buttonBCDice.Enabled = false;
            buttonSideKick.Enabled = true;
            skillControl.SetButtonTempletesText("BCDice");

            toSaveSetting(PalletMaster.Setting);
        }

        //「sidekick」をクリックしたときの制御
        private void buttonSideKick_Click(object sender, EventArgs e)
        {
            toChageSidekick();
        }

        private void toChageSidekick()
        {
            PalletMaster.Setting.useDiceBotFlg = 1;
            buttonBCDice.Enabled = true;
            buttonSideKick.Enabled = false;
            skillControl.SetButtonTempletesText("Sidekick");

            toSaveSetting(PalletMaster.Setting);
        }

        //クリップボードに文字列を入力する際に用いる関数
        public void SetClipBoard(string m_copy)
        {
            if (m_copy == "") return;

            Clipboard.SetText(m_copy);
            ClipboardLabel.Text = m_copy;

            if (PalletMaster.Setting.checkMessageFlg)
                MessageBox.Show("クリップボードにコピーしました", "成功", MessageBoxButtons.OK);
            else
                System.Media.SystemSounds.Asterisk.Play();
        }

        public void SetClipboardText(string clip)
        {
            ClipboardLabel.Text = clip;
        }

        //
        //
        //====================================メモ==========================
        //
        //


        public void RefreshList()
        {
            skillControl.RefreshSkillList();
            fightControl.RefreshSkillList();
            historyAbilityControl.RefreshSkillList();
            
            var m_buff = 0;
            if (int.TryParse(PalletMaster.Searcher.searcherInfoList["SAN"], out m_buff))
                sanControl.SetSanText(Convert.ToString(m_buff));
            labelCharaName.Text = "キャラ名：" + PalletMaster.Searcher.searcherInfoList["キャラクター名"];
        }
    }
}

