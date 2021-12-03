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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Classes.Form_Actions.Border_Radius(this);
            Classes.Form_Actions.DragControl(this);

            Login L = new Login();

            pnl_View.Controls.Add(L.pnl_Login);
            pnl_View.BackColor = Color.White;
        }

        private void pic_Minimize_MouseEnter(object sender, EventArgs e)
        {
            pic_Minimize.BackgroundImage = Properties.Resources.Minimize_Gray;
        }

        private void pic_Minimize_MouseLeave(object sender, EventArgs e)
        {
            pic_Minimize.BackgroundImage = Properties.Resources.Minimize_Blue;
        }

        private void pic_Close_MouseEnter(object sender, EventArgs e)
        {
            pic_Close.BackgroundImage = Properties.Resources.Close_Gray;
        }

        private void pic_Close_MouseLeave(object sender, EventArgs e)
        {
            pic_Close.BackgroundImage = Properties.Resources.Close_Blue;
        }

        private void pic_Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pic_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
