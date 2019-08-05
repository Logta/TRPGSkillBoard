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
    public partial class InfoMemoForm : Form
    {
        public string infoMemo = "";

        public InfoMemoForm(string background)
        {
            InitializeComponent();
            infoMemo = memoTextBox.Text = background;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            infoMemo = memoTextBox.Text;
            this.Close();
        }
    }
}
