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
    public partial class UserForm : Form
    {
        dataset datas = new dataset();
        public UserForm(dataset d)
        {
            InitializeComponent();
            datas = d;
        }

        private void buttonDecide_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
