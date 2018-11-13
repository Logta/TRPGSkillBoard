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
        public bool m_checkTopMostFlg;

        public SettingForm(bool topMostFlg)
        {
            InitializeComponent();
            m_checkTopMostFlg = topMostFlg;
            checkBoxTopMost.Checked=topMostFlg;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxTopMost_CheckedChanged(object sender, EventArgs e)
        {
            m_checkTopMostFlg = checkBoxTopMost.Checked;
        }

        private void buttonDecide_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
