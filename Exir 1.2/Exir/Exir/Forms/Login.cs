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
    public partial class Login : Form
    {
        char Visibility = '1';

        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_MouseEnter(object sender, EventArgs e)
        {
            btn_Login.BackColor = Color.FromArgb(38, 48, 61);
        }

        private void btn_Login_MouseLeave(object sender, EventArgs e)
        {
            btn_Login.BackColor = Color.FromArgb(11, 100, 141);
        }

        private void btn_Secure_Password_Click(object sender, EventArgs e)
        {
            if (Visibility.ToString() == "1")
            {
                btn_Secure_Password.BackgroundImage = Properties.Resources.invisible;
                Visibility = '0';
            }

            else
            {
                btn_Secure_Password.BackgroundImage = Properties.Resources.visibility;
                Visibility = '1';
            }

            if (Visibility == '0')
            {
                txt_Password.PasswordChar = txt_Username.PasswordChar;
                txt_Password.UseSystemPasswordChar = true;
            }

            else
                txt_Password.UseSystemPasswordChar = false;

            Select();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (chk_Remember_Me.Checked)
            {
                Forms.MessageBox M = new Forms.MessageBox();

                M.ShowDialog();

                if (!M.Accept)
                    chk_Remember_Me.Checked = false;
            }
        }
    }
}