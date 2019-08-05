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
    public partial class _1InputForm : Form
    {
        public string inputText;
        public bool OK = false;

        public _1InputForm()
        {
            InitializeComponent();
        }

        public void SetLabel(string label)
        {
            _1label.Text = label;
        }

        public void SetButton(string button)
        {
            _1button.Text = button;
        }

        private void button_Click(object sender, EventArgs e)
        {
            inputText = textBox.Text;
            if (inputText != "")
                OK = true;
            this.Close();
        }
    }
}
