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
using MetroFramework.Forms;

namespace PalletMaster
{
    public partial class MainForm : MetroForm
    {       
        PalletMaster PalletMaster { get; set; }
        IOHelper IOHelper = new IOHelper();

        // データセット作成
        DataSet dS = new DataSet("dS");

        //ユーザーコントロール作成
        SkillControl skillControl = new SkillControl();
        SANControl sanControl = new SANControl();
        FightControl fightControl = new FightControl();
        HistoryAbilityControl historyAbilityControl = new HistoryAbilityControl();
        MemoControl memoControl = new MemoControl();


        public MainForm(Searcher d)
        {
            InitializeComponent(); //フォームの初期化
            PalletMaster = new PalletMaster();

            //設定の読込と初期設定
            PalletMaster.Setting = IOHelper.toLoadSetting();
            var templeteTextSelected = PalletMaster.Setting.useBCDiceAPIFlg ||
                PalletMaster.Setting.offlineMode;
            skillControl.SetButtonTempleteUserCopyName
                (
                templeteTextSelected ?
                "ダイス" : 
                "コピー"
                );
            if (PalletMaster.Setting.useDiceBotFlg == 0)
                toChangeBCDice();
            else
                toChageSidekick();

            var defaultSkills = Proccess.GetSkillSet();
            PalletMaster.Searcher.SetDefaultSkills(defaultSkills);

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

            //HistoryAbibilityControlを技能タブに割り当てる
            historyAbilityControl.SetPalletMaster(PalletMaster);
            setTab(historyAbilityControl, tabHistoryAblityRole);

            //MemoControlを技能タブに割り当てる
            memoControl.SetMainForm(PalletMaster);
            setTab(memoControl, tabPageMemo);

            formFontChange(PalletMaster.Setting.font, PalletMaster.Setting.fontSize);
        }

        private void formFontChange(string fontName, int fontSize)
        {
            this.Font = new Font(fontName, fontSize);
            skillControl.Font = new Font(fontName, fontSize);
            sanControl.Font = new Font(fontName, fontSize);
            fightControl.Font = new Font(fontName, fontSize);
            historyAbilityControl.Font = new Font(fontName, fontSize);
            memoControl.Font = new Font(fontName, fontSize);
            menuStrip1.Font = new Font(fontName, fontSize);
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
        }

        //設定を押したときの制御
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm u_form = new SettingForm(PalletMaster);
            TopMost = false;
            u_form.ShowDialog();
            if (u_form.OK)
            {
                PalletMaster.Setting = u_form.iOData.Setting;
                TopMost = PalletMaster.Setting.checkTopMostFlg;
                IOHelper.toSaveSetting(PalletMaster.Setting);

                skillControl.SetButtonTempleteUserCopyName
                    (
                    u_form.iOData.Setting.useBCDiceAPIFlg ?
                    "ダイス" :
                    "コピー"
                    );
                formFontChange(PalletMaster.Setting.font, PalletMaster.Setting.fontSize);

            }
        }
        
        //キャラを押したときの制御
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PalletMaster.Searcher.searcherInfos["SAN"] = sanControl.GetSanText();
            CharaInfoForm u_form = new CharaInfoForm(PalletMaster.Searcher);
            u_form.Font = new Font(PalletMaster.Setting.font, PalletMaster.Setting.fontSize);
            TopMost = false;
            u_form.ShowDialog();

            PalletMaster.Searcher = u_form.Searcher;
            PalletMaster.AbilityDataSet();

            sanControl.SetSanText(PalletMaster.Searcher.searcherInfos["SAN"]); //SAN情報の入力
            fightControl.SetFightText(PalletMaster.Searcher.searcherInfos["HP"]); //HP情報の入力
            fightControl.SetFightDamageBonusText(PalletMaster.Searcher.searcherInfos["ダメージボーナス"]); //HP情報の入力

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

        //パレマス形式保存関数
        void JSONSave(Character tom)
        {
            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "パレマスファイル(*.pmj)|*.pmj|すべてのファイル(*.*)|*.*";
            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                if (sanControl.GetSanText() == "")
                    PalletMaster.Searcher.searcherInfos["SAN"] = sanControl.GetSanText();

                System.IO.Stream stream;
                stream = sfd.OpenFile();
                if (stream != null)
                {
                    //ファイルに書き込む
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(stream, Encoding.GetEncoding("Shift_JIS"));
                    string json = JsonConvert.SerializeObject(tom, Formatting.Indented);//, Formatting.Indented);
                    sw.Write(json);
                    //閉じる
                    sw.Close();
                }
                stream.Close();
            }
        }

        //パレマス形式をロードする再利用する構造体の定義
        struct chpLoad
        {
            internal Character d;
            internal bool f;
        }

        private void パレマス形式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chpLoad m_d;
            m_d = JSONLoad();
            if (m_d.f)
            {
                PalletMaster.Searcher = new Searcher();
                PalletMaster.Searcher.SetSearcher(m_d.d);

                PalletMaster.AbilityDataSet();

                sanControl.SetSanText(PalletMaster.Searcher.searcherInfos["SAN"]); //SAN情報の入力
                fightControl.SetFightText(PalletMaster.Searcher.searcherInfos["HP"]); //HP情報の入力
                fightControl.SetFightDamageBonusText(PalletMaster.Searcher.searcherInfos["ダメージボーナス"]); //HP情報の入力

                PalletMaster.Searcher.CheckUnique();
                PalletMaster.RefreshListView();
            }

            var defaultSkillList = Proccess.GetSkillSet();
            PalletMaster.Searcher.SetDefaultSkills(defaultSkillList);

            if (PalletMaster.Setting.charaNameToUserNameFlg)
                PalletMaster.Setting.userName = PalletMaster.Searcher.searcherInfos["キャラクター名"];
        }

        //ロード→チャッパレ形式を押した時の制御
        private void チャッパレ形式ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChpFileImport chpFileImport = new ChpFileImport();
            PalletMaster.Searcher = chpFileImport.ChpDataImport().ConversionToSearcher();
            if (PalletMaster.Setting.charaNameToUserNameFlg)
                PalletMaster.Setting.userName = PalletMaster.Searcher.searcherInfos["キャラクター名"];

            PalletMaster.RefreshListView();
        }

        //パレマス形式読み取り関数
        chpLoad JSONLoad()
        {
            chpLoad m_d;
            OpenFileDialog ofDialog = new OpenFileDialog();

            // デフォルトのフォルダを指定する
            ofDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            //ダイアログのタイトルを指定する
            ofDialog.Title = "パレマス形式ファイル読み込み";
            ofDialog.Filter = "パレマスファイル(*.pmj)|*.pmj|すべてのファイル(*.*)|*.*";

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
                catch { 
                    try
                    {
                        string json = System.IO.File.ReadAllText(ofDialog.FileName, Encoding.GetEncoding("UTF-8"));
                        m_d.d = JsonConvert.DeserializeObject<Character>(json);
                        m_d.f = true;
                        return m_d;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("読み込み時エラーが発生しました。",
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        m_d.d = new Character();
                        m_d.f = false;
                        return m_d;
                    }
                }
            }

            m_d.d = new Character();
            m_d.f = false;
            return m_d;
        }
                
        //「CSV」を読込したときの制御
        private void toCreateCSV()
        {
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
                PalletMaster.Searcher.skills = new List<Skill>();
                PalletMaster.Searcher = IOHelper.charaBankTxtFileRead();
                PalletMaster.AbilityDataSet();

                sanControl.SetSanText(PalletMaster.Searcher.searcherInfos["SAN"]); //SAN情報の入力
                fightControl.SetFightText(PalletMaster.Searcher.searcherInfos["HP"]); //HP情報の入力
                fightControl.SetFightDamageBonusText(PalletMaster.Searcher.searcherInfos["ダメージボーナス"]); //HP情報の入力

                PalletMaster.RefreshListView();
            }
            else if (u_form.m_txtDataImportFlg == 1)
            {
                PalletMaster.Searcher.skills = new List<Skill>();
                PalletMaster.Searcher = IOHelper.charaBankTxtDataRead(u_form.m_txtData);
                PalletMaster.AbilityDataSet();

                sanControl.SetSanText(PalletMaster.Searcher.searcherInfos["SAN"]); //SAN情報の入力
                fightControl.SetFightText(PalletMaster.Searcher.searcherInfos["HP"]); //HP情報の入力
                fightControl.SetFightDamageBonusText(PalletMaster.Searcher.searcherInfos["ダメージボーナス"]); //HP情報の入力
                PalletMaster.Searcher.CheckUnique(); //技能値が初期値かそうでないか判定をする

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

            PalletMaster.AbilityDataSet();

            sanControl.SetSanText(PalletMaster.Searcher.searcherInfos["SAN"]); //SAN情報の入力
            fightControl.SetFightText(PalletMaster.Searcher.searcherInfos["HP"]); //HP情報の入力
            fightControl.SetFightDamageBonusText(PalletMaster.Searcher.searcherInfos["ダメージボーナス"]); //HP情報の入力

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

            IOHelper.toSaveSetting(PalletMaster.Setting);
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

            IOHelper.toSaveSetting(PalletMaster.Setting);
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

        //下の位置にあるクリップボードにコピーした文字列を確認するラベルに値を代入
        public void SetClipboardText(string clip)
        {
            ClipboardLabel.Text = clip;
        }

        // リスト関連 更新
        public void RefreshList()
        {
            skillControl.RefreshSkillList();
            fightControl.RefreshSkillList();
            historyAbilityControl.RefreshSkillList();

            if (sanControl.GetSanText() == "")
            {
                var tempSAN = 0;
                if (int.TryParse(PalletMaster.Searcher.searcherInfos["SAN"], out tempSAN))
                    sanControl.SetSanText(Convert.ToString(tempSAN));
            }

            labelCharaName.Text = "キャラ名：" + PalletMaster.Searcher.searcherInfos["キャラクター名"];
        }

        private void tabCthu_Click(object sender, EventArgs e)
        {
            PalletMaster.RefreshListView();
        }

        private void 縮小版ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MinimumForm u_form = new MinimumForm(PalletMaster);
            u_form.Font = new Font(PalletMaster.Setting.font, PalletMaster.Setting.fontSize);
            TopMost = false;
            Visible = false;
            u_form.ShowDialog();

            TopMost = PalletMaster.Setting.checkTopMostFlg;
            Visible = true;
        }

        private void キャラクター作成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharacterMakingForm u_form = new CharacterMakingForm(PalletMaster);
            u_form.Font = new Font(PalletMaster.Setting.font, PalletMaster.Setting.fontSize);
            TopMost = false;
            Visible = false;
            if (u_form.setSkillSet) u_form.ShowDialog();

            RefreshList();
            TopMost = PalletMaster.Setting.checkTopMostFlg;
            Visible = true;
        }
    }
}

