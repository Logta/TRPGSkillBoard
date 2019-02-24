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
        public PalletMaster iOData = new PalletMaster();

        public SettingForm(PalletMaster IOData)
        {
            InitializeComponent();
            checkBoxTopMost.Checked = IOData.Setting.checkTopMostFlg;
            checkBoxClipCheck.Checked = IOData.Setting.checkMessageFlg;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxTopMost_CheckedChanged(object sender, EventArgs e)
        {
            iOData.Setting.checkTopMostFlg = checkBoxTopMost.Checked;
        }

        private void checkBoxClipCheck_CheckedChanged(object sender, EventArgs e)
        {
            iOData.Setting.checkMessageFlg = checkBoxClipCheck.Checked;
        }

        private void buttonDecide_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
