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
        public string m_charaName;
        public string m_hp;
        public string m_mp;
        public string m_san;
        public string m_str;
        public string m_con;
        public string m_pow;
        public string m_dex;
        public string m_app;
        public string m_siz;
        public string m_int;
        public string m_edu;


        Dataset datas = new Dataset();
        public CharaInfoForm(Dataset d)
        {
            InitializeComponent();

            m_charaName = textCharaName.Text = d.m_sarcherInfoList["キャラクター名"];
            m_hp = textHP.Text = d.m_sarcherInfoList["HP"];
            m_mp = textMP.Text = d.m_sarcherInfoList["MP"];
            m_san = textSAN.Text = d.m_sarcherInfoList["SAN"];
            m_str = textSTR.Text = d.m_abilityValueList["STR"];
            m_con = textCON.Text = d.m_abilityValueList["CON"];
            m_pow = textPOW.Text = d.m_abilityValueList["POW"];
            m_dex = textDEX.Text = d.m_abilityValueList["DEX"];
            m_app = textAPP.Text = d.m_abilityValueList["APP"];
            m_siz = textSIZ.Text = d.m_abilityValueList["SIZ"];
            m_int = textINT.Text = d.m_abilityValueList["INT"];
            m_edu = textEDU.Text = d.m_abilityValueList["EDU"];
        }

        private void buttonDecide_Click(object sender, EventArgs e)
        {
            m_charaName = textCharaName.Text;
            m_hp = textHP.Text;
            m_mp = textMP.Text;
            m_san = textSAN.Text;
            m_str = textSTR.Text;
            m_con = textCON.Text;
            m_pow = textPOW.Text;
            m_dex = textDEX.Text;
            m_app = textAPP.Text;
            m_siz = textSIZ.Text;
            m_int = textINT.Text;
            m_edu = textEDU.Text;

            this.Close();
        }
    }
}
