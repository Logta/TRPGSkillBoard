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

            textCharaName.Text = d.searcherInfos["キャラクター名"];
            textHP.Text = d.searcherInfos["HP"];
            textMP.Text = d.searcherInfos["MP"];
            textSAN.Text = d.searcherInfos["SAN"];
            textSTR.Text = d.abilityValues["STR"];
            textCON.Text = d.abilityValues["CON"];
            textPOW.Text = d.abilityValues["POW"];
            textDEX.Text = d.abilityValues["DEX"];
            textAPP.Text = d.abilityValues["APP"];
            textSIZ.Text = d.abilityValues["SIZ"];
            textINT.Text = d.abilityValues["INT"];
            textEDU.Text = d.abilityValues["EDU"];

            Searcher = d;
        }

        private void buttonDecide_Click(object sender, EventArgs e)
        {
            Searcher.searcherInfos["キャラクター名"] = textCharaName.Text;
            Searcher.searcherInfos["HP"] = textHP.Text;
            Searcher.searcherInfos["MP"] = textMP.Text;
            Searcher.searcherInfos["SAN"] = textSAN.Text;
            Searcher.abilityValues["STR"] = textSTR.Text;
            Searcher.abilityValues["CON"] = textCON.Text;
            Searcher.abilityValues["POW"] = textPOW.Text;
            Searcher.abilityValues["DEX"] = textDEX.Text;
            Searcher.abilityValues["APP"] = textAPP.Text;
            Searcher.abilityValues["SIZ"] = textSIZ.Text;
            Searcher.abilityValues["INT"] = textINT.Text;
            Searcher.abilityValues["EDU"] = textEDU.Text;

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
