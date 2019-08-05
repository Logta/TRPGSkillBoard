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

        public Boolean setSkillSet = true;

        public CharacterMakingForm(PalletMaster palletMaster)
        {
            InitializeComponent();
            PalletMaster = palletMaster;
            if (newCharacter.SkillSet == null) setSkillSet = false;
            refreshSkillListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void diceButton_Click(object sender, EventArgs e)
        {
            textSTR.Text = newCharacter.Searcher.abilityValues["STR"] = Proccess.DDice("3d6").Sum().ToString();
            textAPP.Text = newCharacter.Searcher.abilityValues["APP"] = Proccess.DDice("3d6").Sum().ToString();
            textCON.Text = newCharacter.Searcher.abilityValues["CON"] = Proccess.DDice("3d6").Sum().ToString();
            textDEX.Text = newCharacter.Searcher.abilityValues["DEX"] = Proccess.DDice("3d6").Sum().ToString();
            textEDU.Text = newCharacter.Searcher.abilityValues["EDU"] = Proccess.TotalDice("3d6+3").Sum().ToString();
            textINT.Text = newCharacter.Searcher.abilityValues["INT"] = Proccess.TotalDice("2d6+6").Sum().ToString();
            textPOW.Text = newCharacter.Searcher.abilityValues["POW"] = Proccess.DDice("3d6").Sum().ToString();
            textSIZ.Text = newCharacter.Searcher.abilityValues["SIZ"] = Proccess.TotalDice("2d6+6").Sum().ToString();

            newCharacter.SkillSet.Skills.Where(item => item.Name == "回避").ToList().ForEach(item => item.Value = int.Parse(textDEX.Text) * 2);
            newCharacter.SkillSet.Skills.Where(item => item.Name == "言語").ToList().ForEach(item => item.Value = int.Parse(textEDU.Text) * 1);
            newCharacter.SkillSet.Skills.Where(item => item.Name == "母国語").ToList().ForEach(item => item.Value = int.Parse(textEDU.Text) * 5);

            workMaxPoint.Text = (int.Parse(textEDU.Text) * 20).ToString();
            interestMaxPoint.Text = (int.Parse(textINT.Text) * 10).ToString();

            labelHP.Text = ((int.Parse(textCON.Text) + int.Parse(textSIZ.Text)) / 2).ToString();
            labelMP.Text = textPOW.Text;

            newCharacter.Searcher = PalletMaster.AbilityDataSet(newCharacter.Searcher);

            refreshSkillListView();
        }

        private void refreshSkillListView()
        {
            proccess.RefreshSkillList(listViewFightSkill, 
                newCharacter.SkillSet.Skills.Zip(newCharacter.skillPointTypes,(e, o) => Tuple.Create(e,o)).Where(item => item.Item1.Type == "戦闘")
                .ToList<Tuple<Proccess.Skill, string>>());
            proccess.RefreshSkillList(listViewSearchSkill,
                newCharacter.SkillSet.Skills.Zip(newCharacter.skillPointTypes, (e, o) => Tuple.Create(e, o)).Where(item => item.Item1.Type == "探索")
                .ToList<Tuple<Proccess.Skill, string>>());
            proccess.RefreshSkillList(listViewActSkill,
                newCharacter.SkillSet.Skills.Zip(newCharacter.skillPointTypes, (e, o) => Tuple.Create(e, o)).Where(item => item.Item1.Type == "行動")
                .ToList<Tuple<Proccess.Skill, string>>());
            proccess.RefreshSkillList(listViewNegosiateSkill,
                newCharacter.SkillSet.Skills.Zip(newCharacter.skillPointTypes, (e, o) => Tuple.Create(e, o)).Where(item => item.Item1.Type == "交渉")
                .ToList<Tuple<Proccess.Skill, string>>());
            proccess.RefreshSkillList(listViewWisdomSkill,
                newCharacter.SkillSet.Skills.Zip(newCharacter.skillPointTypes, (e, o) => Tuple.Create(e, o)).Where(item => item.Item1.Type == "知識")
                .ToList<Tuple<Proccess.Skill, string>>());
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
                newCharacter.SkillSet.Skills.Where(item => item.Name == "回避").ToList().ForEach(item => item.Value = dex * 2);
                refreshSkillListView();
            }
        }

        private void textEDU_TextChanged(object sender, EventArgs e)
        {
            int edu;
            if (int.TryParse(textPOW.Text, out edu))
            {
                newCharacter.SkillSet.Skills.Where(item => item.Name == "言語").ToList().ForEach(item => item.Value = edu * 1);
                newCharacter.SkillSet.Skills.Where(item => item.Name == "母国語").ToList().ForEach(item => item.Value = edu * 5);

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

        private Boolean addSkill(ref int sumValue, int addValue, int maxPoint, Label currentPoint)
        {
            var skillDefault = newCharacter.Searcher.DefaultSkillList.Where(s => s.Key == textSkill.Text).ToDictionary(s => s.Key, s => s.Value);
            var skillSet = newCharacter.SkillSet.Skills.Where(item => item.Name == textSkill.Text).ToList<Proccess.Skill>();
            var defaultValue = 0;
            if (skillDefault.Count != 0) defaultValue = int.Parse(skillDefault[textSkill.Text]);

            if (skillSet.Count != 0)
            {
                if (sumValue + addValue - skillSet[0].Value >= maxPoint)
                {
                    MessageBox.Show("職業ポイントが超過しました。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                else if (skillDefault.Count != 0 ? addValue - defaultValue < 0 : addValue < 0)
                {
                    MessageBox.Show("初期値より低い技能値は設定できません。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                else if (addValue - skillSet[0].Value == 0)
                {
                    return false;
                }

                sumValue += addValue - skillSet[0].Value;
                currentPoint.Text = sumValue.ToString();
                newCharacter.SkillSet.Skills.Where(item => item.Name == textSkill.Text).ToList().ForEach(item => item.Value = addValue);

                if (addValue == defaultValue)
                {
                    var foundItems = newCharacter.SkillSet.Skills.Select((item, index) => new { Index = index, Value = item })
                       .Where(item => item.Value.Name == textSkill.Text)
                       .Select(item => item.Index);
                    newCharacter.skillPointTypes[foundItems.First()] = "";
                    
                    return false;
                }

                return true;
            }
            else
            {
                if (sumValue + addValue >= maxPoint)
                {
                    MessageBox.Show("職業ポイントが超過しました。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                else if (addValue < 0)
                {
                    MessageBox.Show("初期値より低い技能値は設定できません。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return false;
                }
                else if (skillSet.Count != 0 && addValue - skillSet[0].Value == 0)
                {
                    return false;
                }

                sumValue += addValue;
                currentPoint.Text = sumValue.ToString();

                Proccess.Skill skill = new Proccess.Skill();
                skill.Name = textSkill.Text;
                skill.Value = addValue;
                skill.Type = tabControlSkill.SelectedTab.Text;

                newCharacter.SkillSet.Skills.Add(skill);
                newCharacter.skillPointTypes.Add("");

                return true;
            }
            return false;
        }

        private void buttonWorkAdd_Click(object sender, EventArgs e)
        {
            int value;
            if(int.TryParse(textValue.Text, out value))
            {
                if(addSkill(ref newCharacter.workSkillsAddValue, value, int.Parse(workMaxPoint.Text), workPoint))
                {
                    var foundItems = newCharacter.SkillSet.Skills.Select((item, index) => new { Index = index, Value = item })
                       .Where(item => item.Value.Name == textSkill.Text)
                       .Select(item => item.Index);
                    newCharacter.skillPointTypes[foundItems.First()] = "職業";
                }
                refreshSkillListView();
                checkPointButton();
            }
        }

        private void buttonInterestAdd_Click(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(textValue.Text, out value))
            {
                if(addSkill(ref newCharacter.interestSkillsAddValue, value, int.Parse(interestMaxPoint.Text), interestPoint))
                {
                    {
                        var foundItems = newCharacter.SkillSet.Skills.Select((item, index) => new { Index = index, Value = item })
                           .Where(item => item.Value.Name == textSkill.Text)
                           .Select(item => item.Index);
                        newCharacter.skillPointTypes[foundItems.First()] = "興味";
                    }
                }
                refreshSkillListView();
                checkPointButton();
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            seacherSkillSet();

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

        private void seacherSkillSet()
        {
            foreach (var item in newCharacter.SkillSet.Skills) {
                try
                {
                    if (newCharacter.Searcher.DefaultSkillList.ContainsKey(item.Name))
                    {
                        if (newCharacter.Searcher.DefaultSkillList[item.Name] != item.Value.ToString())
                        { newCharacter.Searcher.uniqueSkills[item.Name] = item.Value.ToString(); }
                    }
                    else
                    {
                        newCharacter.Searcher.uniqueSkills[item.Name] = item.Value.ToString(); 
                    }
                }
                catch (Exception ee) { }
            }


            foreach (var item in newCharacter.SkillSet.Skills.Where(item => item.Type == "戦闘").ToList<Proccess.Skill>())
            {
                newCharacter.Searcher.fightSkills[item.Name] = item.Value.ToString();
            }
        }

        private void CanselToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textSkill_TextChanged(object sender, EventArgs e)
        {
            checkPointButton();
        }

        private void checkPointButton(){
            
            var tuple = newCharacter.SkillSet.Skills.Zip(newCharacter.skillPointTypes, (skill, point) => Tuple.Create(skill, point)).Where(item => item.Item1.Name == textSkill.Text)
                .ToList<Tuple<Proccess.Skill, string>>();

            if (tuple.Count == 0) return;

            if (tuple[0].Item2 == "職業")
            {
                buttonWorkAdd.Enabled = true;
                buttonInterestAdd.Enabled = false;
                buttonWorkAdd.Text = "職業技能編集";
                buttonInterestAdd.Text = "興味技能編集";
            }
            else if (tuple[0].Item2 == "興味")
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
        private Proccess.SkillSet skillSet = new Proccess.SkillSet();
        public List<string> skillPointTypes = new List<string>();
        public Searcher Searcher { get; set; }
        internal Proccess.SkillSet SkillSet { get => skillSet; set => skillSet = value; }

        public int workSkillsAddValue = 0;
        public int interestSkillsAddValue = 0;

        public NewCharacter()
        {
            Searcher = new Searcher();
            Searcher.SetDefaultSkills(new Proccess().ReadCSV(System.AppDomain.CurrentDomain.BaseDirectory + "defaultSkill.csv"));

            SkillSet = Proccess.GetSkillSet();
            SkillSet.Skills.ForEach(_ => skillPointTypes.Add(""));
        }
    }
}
