using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalletMaster
{
    public partial class memoTabControl : UserControl
    {
        public memoTabControl()
        {
            InitializeComponent();
        }

        public string GetRichTextBox()
        {
            return memoTextBox.Text;
        }

        public void SetRichTextBox(string set)
        {
            memoTextBox.Text = set;
        }
    }
}
