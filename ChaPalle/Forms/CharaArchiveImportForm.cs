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
    public partial class CharaArchiveImportForm : Form
    {
        public string m_URL = "";

        public CharaArchiveImportForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_URL = textBox1.Text;
            this.Close();
        }
    }
}
