using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalletMaster
{
    public partial class CharaInfoForm : Form
    {
        public Searcher Searcher = new Searcher();

        public CharaInfoForm(Searcher d)
        {
            InitializeComponent();

            textCharaName.Text = d.characterInfos.characterName.ToString();
            textHP.Text = d.characterInfos.HP.ToString();
            textMP.Text = d.characterInfos.MP.ToString();
            textSAN.Text = d.characterInfos.SAN.ToString();
            textSTR.Text = d.abilityValues.STR.ToString();
            textCON.Text = d.abilityValues.CON.ToString();
            textPOW.Text = d.abilityValues.POW.ToString();
            textDEX.Text = d.abilityValues.DEX.ToString();
            textAPP.Text = d.abilityValues.APP.ToString();
            textSIZ.Text = d.abilityValues.SIZ.ToString();
            textINT.Text = d.abilityValues.INT.ToString();
            textEDU.Text = d.abilityValues.EDU.ToString();

            Searcher = d;
        }

        private void buttonDecide_Click(object sender, EventArgs e)
        {
            int r = 0;

            Searcher.characterInfos.characterName = textCharaName.Text;
            Searcher.characterInfos.HP = int.TryParse(textHP.Text, out r) ? r : 0;
            Searcher.characterInfos.MP = int.TryParse(textMP.Text, out r) ? r : 0;
            Searcher.characterInfos.SAN = int.TryParse(textSAN.Text, out r) ? r : 0;
            Searcher.abilityValues.STR = int.TryParse(textSTR.Text, out r) ? r : 0;
            Searcher.abilityValues.CON = int.TryParse(textCON.Text, out r) ? r : 0;
            Searcher.abilityValues.POW = int.TryParse(textPOW.Text, out r) ? r : 0;
            Searcher.abilityValues.DEX = int.TryParse(textDEX.Text, out r) ? r : 0;
            Searcher.abilityValues.APP = int.TryParse(textAPP.Text, out r) ? r : 0;
            Searcher.abilityValues.SIZ = int.TryParse(textSIZ.Text, out r) ? r : 0;
            Searcher.abilityValues.INT = int.TryParse(textINT.Text, out r) ? r : 0;
            Searcher.abilityValues.EDU = int.TryParse(textEDU.Text, out r) ? r : 0;

            this.Close();
        }

        private void charaMemoButton_Click(object sender, EventArgs e)
        {
            var u_form = new InfoMemoForm(Searcher.backgroundString);
            TopMost = false;
            u_form.ShowDialog();

            Searcher.backgroundString = u_form.infoMemo;
        }
    }
}
