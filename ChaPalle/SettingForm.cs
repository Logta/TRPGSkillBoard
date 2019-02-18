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
    public partial class SettingForm : Form
    {
        public SettingData m_sD = new SettingData();

        public SettingForm(ref SettingData m_settingData)
        {
            InitializeComponent();
            checkBoxTopMost.Checked = m_settingData.checkTopMostFlg;
            checkBoxClipCheck.Checked = m_settingData.checkMessageFlg;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxTopMost_CheckedChanged(object sender, EventArgs e)
        {
            m_sD.checkTopMostFlg = checkBoxTopMost.Checked;
        }

        private void checkBoxClipCheck_CheckedChanged(object sender, EventArgs e)
        {
            m_sD.checkMessageFlg = checkBoxClipCheck.Checked;
        }

        private void buttonDecide_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
