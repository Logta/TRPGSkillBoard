using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaPalle
{
    public partial class CharaInfoForm : Form
    {
        public Searcher Searcher = new Searcher();

        public CharaInfoForm(Searcher d)
        {
            InitializeComponent();

            textCharaName.Text = d.searcherInfoList["キャラクター名"];
            textHP.Text = d.searcherInfoList["HP"];
            textMP.Text = d.searcherInfoList["MP"];
            textSAN.Text = d.searcherInfoList["SAN"];
            textSTR.Text = d.abilityValueList["STR"];
            textCON.Text = d.abilityValueList["CON"];
            textPOW.Text = d.abilityValueList["POW"];
            textDEX.Text = d.abilityValueList["DEX"];
            textAPP.Text = d.abilityValueList["APP"];
            textSIZ.Text = d.abilityValueList["SIZ"];
            textINT.Text = d.abilityValueList["INT"];
            textEDU.Text = d.abilityValueList["EDU"];

            Searcher = d;
        }

        private void buttonDecide_Click(object sender, EventArgs e)
        {
            Searcher.searcherInfoList["キャラクター名"] = textCharaName.Text;
            Searcher.searcherInfoList["HP"] = textHP.Text;
            Searcher.searcherInfoList["MP"] = textMP.Text;
            Searcher.searcherInfoList["SAN"] = textSAN.Text;
            Searcher.abilityValueList["STR"] = textSTR.Text;
            Searcher.abilityValueList["CON"] = textCON.Text;
            Searcher.abilityValueList["POW"] = textPOW.Text;
            Searcher.abilityValueList["DEX"] = textDEX.Text;
            Searcher.abilityValueList["APP"] = textAPP.Text;
            Searcher.abilityValueList["SIZ"] = textSIZ.Text;
            Searcher.abilityValueList["INT"] = textINT.Text;
            Searcher.abilityValueList["EDU"] = textEDU.Text;

            this.Close();
        }
    }
}
