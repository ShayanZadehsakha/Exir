using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace Exir
{
    public partial class Setting : Telerik.WinControls.UI.RadForm
    {
        string[] Data = File.ReadAllLines("C:/Exir/Login.txt");

        Color Color_Btn = Color.FromArgb(255, 232, 207);
        Color Color_Btn2 = Color.FromArgb(227, 93, 59);

        Image Edit_Profile = null;
        string Path_Image = "";
        string Edit_Username = "";
        string Edit_Password = "";
        string Edit_Email = "";
        string Pass = "";
        string Email = "";
        string Username = "";

        int R1, G1, B1, R2, G2, B2 = 0;

        Font Font1 = new Font("Lalezar", 10, FontStyle.Regular);
        Font Font2 = new Font("IRRoya", 14, FontStyle.Bold);

        string Person_Id = "";

        public Setting(string Person_ID)
        {
            InitializeComponent();

            Person_Id = Person_ID;

            Pnl_Acount.Hide();
            Pnl_Color.Hide();
            Pnl_Font.Hide();
            Pnl_Theme.Hide();

            Pib_Profile.Tag = "C:/Exir/" + Person_Id + "/Profile" + File.ReadAllText("C:/Exir/" + Person_Id + "/Selected_Profile.txt") + ".png";

            Image Profile = Image.FromFile(Pib_Profile.Tag.ToString());

            Pib_Profile.Image = Profile;

            Pib_Color1.Image = null;
            Pib_Color2.Image = null;

            if (!File.Exists("C:/Exir/" + Person_ID + "/Theme.txt"))
            {
                var a = File.Create("C:/Exir/" + Person_ID + "/Theme.txt");
                a.Close();
            }

            string Theme_Name = File.ReadAllText("C:/Exir/" + Person_ID + "/Theme.txt");

            Cmb_Theme.Text = Theme_Name;
            Change_Theme(Theme_Name);

            foreach (string Find in Data)
            {
                if (Find.Split('/')[4] == Person_ID)
                {
                    Username = Find.Split('/')[0];
                    Email = Find.Split('/')[2];

                    Txt_User_Name_SG1.HintText = Username;
                    Txt_Email_SG.HintText = Email;

                    for (int i = 0; i < Convert.ToInt32(Find.Split('/')[3]); i++)
                    {
                        Pass += '.';
                    }

                    Txt_Password_SG1.HintText = Pass;
                }
            }
        }

        private void Txtpass_OnValueChanged(object sender, EventArgs e)
        {
            if (Txt_Password_SG1.Text.Length >= 4 && !Txt_Password_SG1.Text.Contains('/'))
            {
                Green_Txt(Txt_Password_SG1);
            }

            else if (!Txt_Password_SG1.Text.Contains('/') && Txt_Password_SG1.Text.Length < 4)
            {
                Orange_Txt(Txt_Password_SG1);
            }

            else if (Txt_Password_SG1.Text.Contains('/'))
            {
                Error_Sound();
                Txt_Password_SG1.Text = Txt_Password_SG1.Text.Replace("/", "");
            }

            if (Txt_Password_SG1.Text == "" && Txt_Password_SG1.Text != Pass && Txt_Password_SG1.HintText != Pass)
                Txt_Password_SG1.isPassword = true;
        }
        void Green_Txt(Bunifu.Framework.UI.BunifuMaterialTextbox Txt)
        {
            Txt.LineMouseHoverColor = Color.ForestGreen;
            Txt.LineFocusedColor = Color.ForestGreen;
            Txt.LineIdleColor = Color.ForestGreen;
        }
        void Orange_Txt(Bunifu.Framework.UI.BunifuMaterialTextbox Txt)
        {
            Txt.LineMouseHoverColor = Color_Btn2;
            Txt.LineFocusedColor = Color_Btn2;
            Txt.LineIdleColor = Color_Btn2;
        }

        private void Txt_User_Name_SG1_OnValueChanged(object sender, EventArgs e)
        {
            if (Txt_User_Name_SG1.Text.Length > 2 && !Txt_User_Name_SG1.Text.Contains('/'))
            {
                Green_Txt(Txt_User_Name_SG1);
            }
            else if (Txt_User_Name_SG1.Text.Length <= 2 && !Txt_User_Name_SG1.Text.Contains('/'))
            {
                Orange_Txt(Txt_User_Name_SG1);
            }
            else if (Txt_User_Name_SG1.Text.Contains('/'))
            {
                Error_Sound();
                Txt_User_Name_SG1.Text = Txt_User_Name_SG1.Text.Replace("/", "");
            }
            Check_Enabled(Btn_Save, Txt_User_Name_SG1, Txt_Password_SG1, Txt_Email_SG);
        }
        void Check_Enabled(Button Btn, Bunifu.Framework.UI.BunifuMaterialTextbox User_Name, Bunifu.Framework.UI.BunifuMaterialTextbox Pass, Bunifu.Framework.UI.BunifuMaterialTextbox Verfication_Code)
        {
            if (Pib_Profile.Image != null && User_Name.Text.Length > 2 && Pass.Text.Length >= 4 && Verfication_Code.LineIdleColor == Color.ForestGreen)
            {
                Btn.Enabled = true;
            }
        }
        public void Error_Sound()
        {
            SystemSounds.Beep.Play();
        }

        private void Txt_Email_SG_OnValueChanged(object sender, EventArgs e)
        {
            string Email_Check = Txt_Email_SG.Text.ToLower();
            int Email_Check_Lengh = Email_Check.Length;

            if (Email_Check_Lengh > 11)
            {
                string Email_com = Email_Check[Email_Check_Lengh - 10].ToString() + Email_Check[Email_Check_Lengh - 9].ToString() + Email_Check[Email_Check_Lengh - 8].ToString() + Email_Check[Email_Check_Lengh - 7].ToString() + Email_Check[Email_Check_Lengh - 6].ToString() + Email_Check[Email_Check_Lengh - 5].ToString() + Email_Check[Email_Check_Lengh - 4].ToString() + Email_Check[Email_Check_Lengh - 3].ToString() + Email_Check[Email_Check_Lengh - 2].ToString() + Email_Check[Email_Check_Lengh - 1].ToString();

                if (Email_com == "@gmail.com" && Email_Check_Lengh > 15 || Email_com == "@yahoo.com" && Email_Check_Lengh > 15 || Email_Check[Email_Check_Lengh - 11] == '@' && Email_com == "icloud.com" && Email_Check_Lengh > 15 || Email_Check[Email_Check_Lengh - 11] == 'o' && Email_Check[Email_Check_Lengh - 12] == '@' && Email_com == "utlook.com" && Email_Check_Lengh > 15)
                {
                    Green_Txt(Txt_Email_SG);
                }

                else
                {
                    Orange_Txt(Txt_Email_SG);
                }
            }
            Check_Enabled(Btn_Save, Txt_User_Name_SG1, Txt_Password_SG1, Txt_Email_SG);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            radColorDialog1.SelectedColor = Color_Btn;
            radColorDialog1.ShowDialog();

            R2 = radColorDialog1.SelectedColor.R;
            G2 = radColorDialog1.SelectedColor.G;
            B2 = radColorDialog1.SelectedColor.B;

            Pib_Color2.Image = null;
            Pib_Color2.BackColor = Color.FromArgb(R2, G2, B2);
        }

        private void Btn_Color_Click(object sender, EventArgs e)
        {
            Change_Color((Telerik.WinControls.UI.RadButton)sender, Pnl_Color);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Lst_Actions.Items.Add("تغییر رنگ ها");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();

            Font1 = new Font(fontDialog1.Font.Name, 10, fontDialog1.Font.Style);

            label5.Text = Font1.Name;
            label5.Font = Font1;
            richTextBox1.Font = Font1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();

            Font2 = new Font(fontDialog1.Font.Name, 11, fontDialog1.Font.Style);

            label7.Text = Font2.Name;
            label7.Font = Font2;
            richTextBox2.Font = Font2;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Lst_Actions.Items.Add("تغییر فونت ها");
        }

        private void Btn_Accept_Click(object sender, EventArgs e)
        {
            bool Font = false;
            bool Acount = false;
            bool Color = false;
            bool Theme = false;

            foreach (string Find in Lst_Actions.Items)
            {
                if (Find == "تغییر فونت ها")
                    Font = true;

                else if (Find == "تغییر اطلاعات حساب کاربری")
                    Acount = true;

                else if (Find == "تغییر رنگ ها")
                    Color = true;

                else if (Find == "تغییر تم برنامه")
                    Theme = true;
            }

            string find = "";

            foreach (string Find in Data)
            {
                if (Find.Split('/')[4] == Person_Id)
                    find = Find;
            }
        }

        private void Btn_Font_Click(object sender, EventArgs e)
        {
            Change_Color((Telerik.WinControls.UI.RadButton)sender, Pnl_Font);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cmb_Theme_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            Cmb_Theme.Text = Cmb_Theme.SelectedItem.Text;
            Change_Theme(Cmb_Theme.Text);
        }

        void Change_Theme(string Theme)
        {
            radTitleBar1.ThemeName = Theme;
            radClock1.ThemeName = Theme;
            radButton4.ThemeName = Theme;
            radGridView1.ThemeName = Theme;
            radTextBox1.ThemeName = Theme;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Lst_Actions.Items.Add("تغییر تم برنامه");
        }

        private void Btn_Theme_Click(object sender, EventArgs e)
        {
            Change_Color((Telerik.WinControls.UI.RadButton)sender, Pnl_Theme);
        }

        private void Btn_Forgot_Pass_Click(object sender, EventArgs e)
        {
            Change_Color((Telerik.WinControls.UI.RadButton)sender, Pnl_Acount);
        }

        void Change_Color(Telerik.WinControls.UI.RadButton Button, Panel Pnl)
        {
            bool Color_Check = true;

            if (Button.BackColor != Color_Btn)
            {
                Button.BackColor = Color_Btn;
                Button.ForeColor = Color_Btn;
                Pnl.Show();
                Color_Check = true;
            }
            else
            {
                Button.BackColor = Color_Btn2;
                Button.ForeColor = Color_Btn2;
                Pnl.Hide();
                Color_Check = false;
            }

            Telerik.WinControls.UI.RadButton[] BTNS = new Telerik.WinControls.UI.RadButton[5];

            BTNS[0] = Btn_Acount;
            BTNS[1] = Btn_Color;
            BTNS[2] = Btn_Font;
            BTNS[3] = Btn_Restore;
            BTNS[4] = Btn_Theme;

            if (Color_Check)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (BTNS[i].Name != Button.Name)
                        BTNS[i].BackColor = Color_Btn2;
                }
            }

            Panel[] panels = new Panel[4];

            panels[0] = Pnl_Acount;
            panels[1] = Pnl_Color;
            panels[2] = Pnl_Font;
            panels[3] = Pnl_Theme;

            for (int i = 0; i < 4; i++)
            {
                if (panels[i].Name != Pnl.Name)
                    panels[i].Hide();
            }
        }

        private void Profile(object sender, EventArgs e)
        {
            try
            {
                string Path_Image = "";
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.bmp;*.jpeg;*.png;*.jpg;";

                if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.OpenFile() != null)
                {
                    Path_Image = openFileDialog.FileName;
                }
                if (Path_Image != "")
                {
                    Pib_Profile.Tag = Path_Image;
                    Pib_Profile.Image = Image.FromFile(Path_Image);
                }
            }
            catch
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد \n امکان دارداین مشکل با تغییر محل عکس رفع شود";
                popupNotifier1.Popup();
            }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Edit_Profile = Pib_Profile.Image;
            Path_Image = Pib_Profile.Tag.ToString();
            Edit_Username = Txt_User_Name_SG1.Text;
            Edit_Password = Txt_Password_SG1.Text;
            Edit_Email = Txt_Email_SG.Text;

            if (Txt_User_Name_SG1.Text != "")
                Username = Txt_User_Name_SG1.Text;

            if (Txt_Password_SG1.Text != "")
                Pass = Txt_Password_SG1.Text;

            if (Txt_Email_SG.Text != "")
                Email = Txt_Email_SG.Text;

            Lst_Actions.Items.Add("تغییر اطلاعات حساب کاربری");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            radColorDialog1.SelectedColor = Color_Btn2;
            radColorDialog1.ShowDialog();

            R1 = radColorDialog1.SelectedColor.R;
            G1 = radColorDialog1.SelectedColor.G;
            B1 = radColorDialog1.SelectedColor.B;

            Pib_Color1.Image = null;
            Pib_Color1.BackColor = Color.FromArgb(R1, G1, B1);
        }
    }
}