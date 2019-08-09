using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace PalletMaster
{
    public partial class CharacterMakingForm : MetroForm
    {
        PalletMaster PalletMaster = new PalletMaster();
        private Proccess proccess = new Proccess();
        NewCharacter newCharacter = new NewCharacter();
        private List<NewCharacter> historyNewCharacters = new List<NewCharacter>();

        public bool setSkillSet = true;

        public CharacterMakingForm(PalletMaster palletMaster)
        {
            InitializeComponent();
            PalletMaster = palletMaster;
            if (newCharacter.Searcher.skills == null) setSkillSet = false;
            refreshSkillListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //能力値を決めるダイスロール
        private void diceButton_Click(object sender, EventArgs e)
        {
            //ダイスロール
            textSTR.Text = newCharacter.Searcher.abilityValues["STR"] = Proccess.DDice("3d6").Sum().ToString();
            textAPP.Text = newCharacter.Searcher.abilityValues["APP"] = Proccess.DDice("3d6").Sum().ToString();
            textCON.Text = newCharacter.Searcher.abilityValues["CON"] = Proccess.DDice("3d6").Sum().ToString();
            textDEX.Text = newCharacter.Searcher.abilityValues["DEX"] = Proccess.DDice("3d6").Sum().ToString();
            textEDU.Text = newCharacter.Searcher.abilityValues["EDU"] = Proccess.TotalDice("3d6+3").Sum().ToString();
            textINT.Text = newCharacter.Searcher.abilityValues["INT"] = Proccess.TotalDice("2d6+6").Sum().ToString();
            textPOW.Text = newCharacter.Searcher.abilityValues["POW"] = Proccess.DDice("3d6").Sum().ToString();
            textSIZ.Text = newCharacter.Searcher.abilityValues["SIZ"] = Proccess.TotalDice("2d6+6").Sum().ToString();

            //検索して能力値に基づいた値に更新
            newCharacter.Searcher.skills.Where(item => item.name == "回避").ToList().ForEach(item => item.value = int.Parse(textDEX.Text) * 2);
            newCharacter.Searcher.skills.Where(item => item.name == "言語").ToList().ForEach(item => item.value = int.Parse(textEDU.Text) * 1);
            newCharacter.Searcher.skills.Where(item => item.name == "母国語").ToList().ForEach(item => item.value = int.Parse(textEDU.Text) * 5);

            //能力値によって決まる各値を代入
            workMaxPoint.Text = (int.Parse(textEDU.Text) * 20).ToString(); //職業ポイントの割り当て最大値
            interestMaxPoint.Text = (int.Parse(textINT.Text) * 10).ToString(); //興味ポイントの割り当て最大値

            labelHP.Text = ((int.Parse(textCON.Text) + int.Parse(textSIZ.Text)) / 2).ToString();
            labelMP.Text = textPOW.Text;

            newCharacter.Searcher = PalletMaster.AbilityDataSet(newCharacter.Searcher);

            refreshSkillListView();
        }

        private void refreshSkillListView()
        {
            Proccess.RefreshSkillListNewChara(listViewFightSkill, 
                newCharacter.Searcher.skills.Where(item => item.type == "戦闘").ToList<Skill>());
            Proccess.RefreshSkillListNewChara(listViewSearchSkill,
                newCharacter.Searcher.skills.Where(item => item.type == "探索").ToList<Skill>());
            Proccess.RefreshSkillListNewChara(listViewActSkill,
                newCharacter.Searcher.skills.Where(item => item.type == "行動").ToList<Skill>());
            Proccess.RefreshSkillListNewChara(listViewNegosiateSkill,
                newCharacter.Searcher.skills.Where(item => item.type == "交渉").ToList<Skill>());
            Proccess.RefreshSkillListNewChara(listViewWisdomSkill,
                newCharacter.Searcher.skills.Where(item => item.type == "知識").ToList<Skill>());
        }

        //listView1の選択が変化したときの制御
        private void listView_SelectedIndexChanged(ListView listView)
        {

            //項目が１つも選択されていない場合
            if (listView.SelectedItems.Count == 0)
                return;//処理を抜ける

            //1番目に選択されれいるアイテムをitemxに格納
            ListViewItem itemx = new ListViewItem();
            itemx = listView.SelectedItems[0];

            //技能と値のテキストボックスに技能名、技能値を入れる
            textSkill.Text = itemx.Text;
            textValue.Text = itemx.SubItems[1].Text;

        }

        private void listViewFightSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView_SelectedIndexChanged(listViewFightSkill);
        }

        private void listViewSearchSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView_SelectedIndexChanged(listViewSearchSkill);
        }

        private void listViewActSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView_SelectedIndexChanged(listViewActSkill);
        }

        private void listViewNegosiateSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView_SelectedIndexChanged(listViewNegosiateSkill);
        }

        private void listViewWisdomSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView_SelectedIndexChanged(listViewWisdomSkill);
        }

        private void textDEX_TextChanged(object sender, EventArgs e)
        {
            int dex;
            if (int.TryParse(textPOW.Text, out dex))
            {
                newCharacter.Searcher.skills.Where(item => item.name == "回避").ToList().ForEach(item => item.value = dex * 2);
                refreshSkillListView();
            }
        }

        private void textEDU_TextChanged(object sender, EventArgs e)
        {
            int edu;
            if (int.TryParse(textPOW.Text, out edu))
            {
                newCharacter.Searcher.skills.Where(item => item.name == "言語").ToList().ForEach(item => item.value = edu * 1);
                newCharacter.Searcher.skills.Where(item => item.name == "母国語").ToList().ForEach(item => item.value = edu * 5);

                workMaxPoint.Text = (edu * 20).ToString();
                refreshSkillListView();
            }
        }

        private void textINT_TextChanged(object sender, EventArgs e)
        {
            int @int;
            if (int.TryParse(textPOW.Text, out @int))
            {
                interestMaxPoint.Text = (@int * 10).ToString();
            }
        }

        private void textPOW_TextChanged(object sender, EventArgs e)
        {
            int pow;
            if (int.TryParse(textPOW.Text, out pow)){
                labelMP.Text = newCharacter.Searcher.searcherInfos["MP"] = textPOW.Text;
                labelSAN.Text = newCharacter.Searcher.searcherInfos["SAN"] = (pow * 5).ToString();
            }
        }

        private void textCON_TextChanged(object sender, EventArgs e)
        {
            int con, siz;
            if (int.TryParse(textCON.Text, out con) && int.TryParse(textSIZ.Text, out siz))
                labelHP.Text = newCharacter.Searcher.searcherInfos["HP"] = (con + siz / 2).ToString();
        }

        private void textSIZ_TextChanged(object sender, EventArgs e)
        {
            int con, siz;
            if (int.TryParse(textCON.Text, out con) && int.TryParse(textSIZ.Text, out siz))
                labelHP.Text = newCharacter.Searcher.searcherInfos["HP"] = (con + siz / 2).ToString();
        }

        private void textSTR_TextChanged(object sender, EventArgs e)
        {

        }

        //セットできる値か判定をする
        private bool checkCanSetSkill(int sum, int add, Skill skill, int _max)
        {
            if (sum + add - skill.value >= _max)
            {
                MessageBox.Show("職業ポイントが超過しました。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
            else if (add - skill.defaultValue < 0)
            {
                MessageBox.Show("初期値より低い技能値は設定できません。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
            else if (add - skill.value == 0)
            {
                return false;
            }

            return true;
        }

        //技能値を編集した値をキャラクタークラスに格納する、成功の場合は初期値からの増加分を、失敗の場合は-1を返す
        private int addSkill(ref int sumValue, int addValue, int maxPoint, Label currentPoint)
        {
            //スキルの、キャラクターの技能値とデフォルト値を取得
            var skillDefault = newCharacter.Searcher.skills.Where(s => s.name == textSkill.Text).ToList();
            var charSkill = newCharacter.Searcher.skills.Where(item => item.name == textSkill.Text).ToList();
            var defaultValue = 0;
            if (skillDefault.Count != 0) defaultValue = skillDefault[0].defaultValue;

            //キャラの技能があるかどうか判定
            if (charSkill.Count != 0)
            {
                if (!checkCanSetSkill(sumValue, addValue, charSkill[0], maxPoint)) return -1;

                sumValue += addValue - charSkill[0].value;
                currentPoint.Text = sumValue.ToString();
                newCharacter.Searcher.skills.Where(item => item.name == textSkill.Text).ToList().ForEach(item => item.value = addValue);

                newCharacter.Searcher.CheckUnique();

                return addValue - defaultValue;
            }
            else
            {
                if (!checkCanSetSkill(sumValue, addValue, new Skill(textSkill.Text, 0), maxPoint)) return -1;

                sumValue += addValue;
                currentPoint.Text = sumValue.ToString();

                Skill skill = new Skill();
                skill.name = textSkill.Text;
                skill.value = addValue;
                skill.type = tabControlSkill.SelectedTab.Text;

                newCharacter.Searcher.skills.Add(skill);

                newCharacter.Searcher.CheckUnique();

                return addValue;
            }
        }
        
        //職業技能の追加編集ボタンを押下
        private void buttonWorkAdd_Click(object sender, EventArgs e)
        {
            var value = int.TryParse(textValue.Text, out var v) ? v: -1;
            if (value == -1) return;

            var deffValue = addSkill(ref newCharacter.workSkillsAddValue, value, int.Parse(workMaxPoint.Text), workPoint);//技能値とデフォ値の差分を返してくれる
            if(deffValue != -1)
            {
                var setskill = newCharacter.Searcher.skills.Find(item => item.name == textSkill.Text);
                setskill.workValue = deffValue;
            }
            refreshSkillListView();
            checkPointButton();
            
        }

        //興味技能の追加編集ボタンを押下
        private void buttonInterestAdd_Click(object sender, EventArgs e)
        {
            var value = int.TryParse(textValue.Text, out var v) ? v : -1;
            if (value == -1) return;

            var deffValue = addSkill(ref newCharacter.interestSkillsAddValue, value, int.Parse(interestMaxPoint.Text), interestPoint);//技能値とデフォ値の差分を返してくれる
            if (deffValue != -1)
            {
                var setskill = newCharacter.Searcher.skills.Find(item => item.name == textSkill.Text);
                setskill.intererstValue = deffValue;
            }
            refreshSkillListView();
            checkPointButton();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {

            newCharacter.Searcher.backgroundString = richTextBoxBackgroung.Text;
            newCharacter.Searcher.searcherInfos["職業"] = textBoxOccupation.Text;
            newCharacter.Searcher.searcherInfos["年齢"] = textBoxAge.Text;
            newCharacter.Searcher.searcherInfos["性別"] = textBoxGender.Text;
            newCharacter.Searcher.searcherInfos["身長"] = textBoxHeight.Text;
            newCharacter.Searcher.searcherInfos["体重"] = textBoxWeight.Text;
            newCharacter.Searcher.searcherInfos["出身"] = textBoxFrom.Text;

            PalletMaster.Searcher = newCharacter.Searcher;
            this.Close();
        }

        private void CanselToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textSkill_TextChanged(object sender, EventArgs e)
        {
            checkPointButton();
        }

        private void checkPointButton(){
            
            var skill = newCharacter.Searcher.skills.Where(item => item.name == textSkill.Text)
                .ToList<Skill>();

            if (skill.Count == 0) return;

            if (skill[0].workValue != 0)
            {
                buttonWorkAdd.Enabled = true;
                buttonInterestAdd.Enabled = false;
                buttonWorkAdd.Text = "職業技能編集";
                buttonInterestAdd.Text = "興味技能編集";
            }
            else if (skill[0].intererstValue != 0)
            {
                buttonWorkAdd.Enabled = false;
                buttonInterestAdd.Enabled = true;
                buttonWorkAdd.Text = "職業技能編集";
                buttonInterestAdd.Text = "興味技能編集";
            }
            else
            {
                buttonWorkAdd.Enabled = true;
                buttonInterestAdd.Enabled = true;
                buttonWorkAdd.Text = "職業技能追加";
                buttonInterestAdd.Text = "興味技能追加";
            }
        }
    }

    public class NewCharacter
    {
        public Searcher Searcher { get; set; }

        public int workSkillsAddValue = 0;
        public int interestSkillsAddValue = 0;

        public NewCharacter()
        {
            Searcher = new Searcher();
            Searcher.SetDefaultSkills(Proccess.ReadCSVToDictionary(System.AppDomain.CurrentDomain.BaseDirectory + "defaultSkill.csv"));

            Searcher.skills = Proccess.GetSkillSet();
            Searcher.skills.ForEach(_ => _.defaultValue = _.value);
        }
    }
}
