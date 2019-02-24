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
    public partial class CharaBankImportForm : Form
    {
        public string m_txtData;
        public int m_txtDataImportFlg = 0;

        public CharaBankImportForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                m_txtDataImportFlg = 1;
                m_txtData = textBox1.Text;
                this.Close();
            }
            else
            {

                MessageBox.Show("txtデータを入力してください。",
            "エラー",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_txtDataImportFlg = 2;
            this.Close();
        }
    }
}
