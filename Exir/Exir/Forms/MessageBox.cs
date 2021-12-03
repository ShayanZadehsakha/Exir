using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exir.Forms
{
    public partial class MessageBox : Form
    {
        public bool Accept = false;

        Form1 form1 = new Form1();

        public MessageBox()
        {
            InitializeComponent();

            Classes.Form_Actions.DragControl(this);
            Classes.Form_Actions.Border_Radius(this);
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            Accept = true;

            Close();
        }

        private void btn_Refuse_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
