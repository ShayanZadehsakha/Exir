using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Exir
{
    public partial class Login_Frm : Telerik.WinControls.UI.RadForm
    {
        Color Color_Btn = Color.FromArgb(255, 232, 207);
        Color Color_Btn2 = Color.FromArgb(227, 93, 59);

        Color Hover_Color = Color.FromArgb(153, 180, 209);

        bool Close_Form = false;
        bool Time_End = false;
        bool Value_User_Name = false;
        bool Value_Pass = false;
        bool Value_Email = false;

        string User_Name_Change_Pass = "";
        string VF = "";
        string Verfication_Code = "3456";

        char[] Code = new char[36];

        int Enabled_Txts = 0;

        List<string> Data = new List<string>();

        Image[] Code_Picture = new Image[36];

        public Login_Frm()
        {
            InitializeComponent();

            Size = new Size(899, 565);
            Size a = Size;

            KeyPreview = true; ;

            Location = Grb_Forgot_Pass.Location;

            pictureBox1.Select();

            Code_Picture = Verfication_Codes_Image();
            Code = Verfication_Codes_Char();

            Paths.Exists_Files_Without_Input();

            Txt_Verfication_Code.TextBoxElement.FocusBorderColor = Color.AliceBlue;
        }

        char[] Verfication_Codes_Char()
        {
            char[] C = new char[36];

            C[0] = 'A';
            C[1] = 'B';
            C[2] = 'C';
            C[3] = 'D';
            C[4] = 'E';
            C[5] = 'F';
            C[6] = 'G';
            C[7] = 'H';
            C[8] = 'I';
            C[9] = 'J';
            C[10] = 'K';
            C[11] = 'L';
            C[12] = 'M';
            C[13] = 'N';
            C[14] = 'O';
            C[15] = 'P';
            C[16] = 'Q';
            C[17] = 'R';
            C[18] = 'S';
            C[19] = 'T';
            C[20] = 'U';
            C[21] = 'V';
            C[22] = 'W';
            C[23] = 'X';
            C[24] = 'Y';
            C[25] = 'Z';
            C[26] = '0';
            C[27] = '1';
            C[28] = '2';
            C[29] = '3';
            C[30] = '4';
            C[31] = '5';
            C[32] = '6';
            C[33] = '7';
            C[34] = '8';
            C[35] = '9';

            return C;
        }

        Image[] Verfication_Codes_Image()
        {
            Image[] CP = new Image[36];

            CP[0] = Properties.Resources._A;
            CP[1] = Properties.Resources._B;
            CP[2] = Properties.Resources._C;
            CP[3] = Properties.Resources._D;
            CP[4] = Properties.Resources._E;
            CP[5] = Properties.Resources._F;
            CP[6] = Properties.Resources._G;
            CP[7] = Properties.Resources._H;
            CP[8] = Properties.Resources._I;
            CP[9] = Properties.Resources._J;
            CP[10] = Properties.Resources._K;
            CP[11] = Properties.Resources._L;
            CP[12] = Properties.Resources._M;
            CP[13] = Properties.Resources._N;
            CP[14] = Properties.Resources._O;
            CP[15] = Properties.Resources._P;
            CP[16] = Properties.Resources._Q;
            CP[17] = Properties.Resources._R;
            CP[18] = Properties.Resources._S;
            CP[19] = Properties.Resources._T;
            CP[20] = Properties.Resources._U;
            CP[21] = Properties.Resources._V;
            CP[22] = Properties.Resources._W;
            CP[23] = Properties.Resources._X;
            CP[24] = Properties.Resources._Y;
            CP[25] = Properties.Resources._Z;
            CP[26] = Properties.Resources._0;
            CP[27] = Properties.Resources._1;
            CP[28] = Properties.Resources._2;
            CP[29] = Properties.Resources._3;
            CP[30] = Properties.Resources._4;
            CP[31] = Properties.Resources._5;
            CP[32] = Properties.Resources._6;
            CP[33] = Properties.Resources._7;
            CP[34] = Properties.Resources._8;
            CP[35] = Properties.Resources._9;

            return CP;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Btn_Login_click(Btn_Login);
        }

        void Btn_Login_click(object sender)
        {
            pictureBox1.Select();

            bool Color_Check = true;

            Telerik.WinControls.UI.RadButton Button = (Telerik.WinControls.UI.RadButton)sender;

            if (Button.BackColor != Color_Btn)
            {
                Button.BackColor = Color_Btn;
                Button.ForeColor = Color_Btn;
                Grb_Welcome_picture.Hide();
                Grb_Forgot_Pass.Hide();
                Grb_Login.Location = Grb_Welcome_picture.Location;
                Grb_Login.Show();

                Color_Check = true;
            }
            else
            {
                Button.BackColor = Color_Btn2;
                Button.ForeColor = Color_Btn2;
                Show_Welcome();
                Color_Check = false;
            }

            Telerik.WinControls.UI.RadButton[] BTNS = new Telerik.WinControls.UI.RadButton[3];

            BTNS[0] = Btn_Login;
            BTNS[1] = Btn_Register;
            BTNS[2] = Btn_Forgot_Pass;

            if (Color_Check)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (BTNS[i].Name != Button.Name)
                        BTNS[i].BackColor = Color_Btn2;
                }
            }

            Empty_Text();

            Login();

            Show_Welcome();

            Txt_User_Name.Select();
        }

        void Empty_Text()
        {
            try
            {
                Empty_Text_Action(Txt_User_Name);
                Empty_Text_Action(Txt_Password);
                Empty_Text_Action(Txt_Verfication_Code);
                Empty_Text_Action(Txt_User_Name_SG1);
                Empty_Text_Action(Txt_Password_SG1);
                Txt_Password_SG1.UseSystemPasswordChar = false;
                Empty_Text_Action(Txt_Email_SG);
                Empty_Text_Action(Txt_User_Name_FP);
                Empty_Text_Action(Txt_Email_FP);
                Empty_Text_Action(Txtpass);
                Empty_Text_Action(Txtpass2);
                Default_Txt(Txt_Verfication_Code);
                Default_Txt(Txt_User_Name_SG1);
                Default_Txt(Txt_Password_SG1);
                Default_Txt(Txt_Email_SG);
                Clp_Progress1.Value = 0;
            }
            catch { }
        }

        void Empty_Text_Action(RadTextBox txt)
        {
            txt.Text = "";
        }

        void Show_Welcome()
        {
            if (Btn_Login.BackColor == Color_Btn2 && Btn_Register.BackColor == Color_Btn2 && Btn_Forgot_Pass.BackColor == Color_Btn2)
            {
                Grb_Register.Hide();
                Grb_Login.Hide();
                Grb_Welcome_picture.Show();
            }
        }
        public void Login()
        {
            Grb_Login.Show();
            Random R = new Random();

            int _1 = R.Next(0, Code_Picture.Count());
            Imb1.Image = Code_Picture[_1];
            Imb1.Rotation = R.Next(0, 45);

            int _2 = R.Next(0, Code_Picture.Count());
            Imb2.Image = Code_Picture[_2];
            Imb2.Rotation = R.Next(0, 45);

            int _3 = R.Next(0, Code_Picture.Count());
            Imb3.Image = Code_Picture[_3];
            Imb3.Rotation = R.Next(0, 45);

            int _4 = R.Next(0, Code_Picture.Count());
            Imb4.Image = Code_Picture[_4];
            Imb4.Rotation = R.Next(0, 45);

            Verfication_Code = Code[_1].ToString() + Code[_2].ToString() + Code[_3].ToString() + Code[_4].ToString();
        }

        private void Login_Frm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists("C:/Exir"))
                    Directory.CreateDirectory("C:/Exir");

                if (!File.Exists("C:/Exir/Login.txt"))
                {
                    var a = File.Create("C:/Exir/Login.txt");
                    a.Close();
                }

                Data = File.ReadAllLines("C:/Exir/Login.txt").ToList();

            }
            catch
            {
                try
                {
                    if (MessageBox.Show("داده های ذخیره شده ناموجود است \n آیا برنامه مجدد باز بشود ؟", "مشکل", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Yes) ;
                    Application.Restart();
                }
                catch { }
            }
            Grb_Login.Hide();
            Grb_Forgot_Pass.Hide();
            Grb_Register.Hide();
        }

        private void Txt_Verfication_Code_OnValueChanged_1(object sender, EventArgs e)
        {
            Txt_Verfication_Code.CharacterCasing = CharacterCasing.Upper;
            Txt_Verfication_Code_OnValueChanged_Action();
        }

        void Txt_Verfication_Code_OnValueChanged_Action()
        {
            if (Txt_Verfication_Code.Text != "")
            {
                if (Txt_Verfication_Code.Text.ToUpper() == Verfication_Code)
                {
                    Green_Txt(Txt_Verfication_Code);
                }

                else
                    Orange_Txt(Txt_Verfication_Code);
            }
        }

        private void Txt_User_Name_SG_OnValueChanged(object sender, EventArgs e)
        {
            Txt_User_Name_SG_OnValueChanged();
        }

        void Txt_User_Name_SG_OnValueChanged()
        {
            if (Txt_User_Name_SG1.Text != "")
            {
                if (Txt_User_Name_SG1.Text.Length > 2 && !Txt_User_Name_SG1.Text.Contains('/'))
                {
                    if (!Value_User_Name)
                    {
                        Clp_Progress1.Value += 33;
                        Value_User_Name = true;
                    }

                    Green_Txt(Txt_User_Name_SG1);
                }
                else if (Txt_User_Name_SG1.Text.Length <= 2 && !Txt_User_Name_SG1.Text.Contains('/'))
                {
                    if (Value_User_Name)
                    {
                        Clp_Progress1.Value -= 33;
                        Value_User_Name = false;
                    }

                    Orange_Txt(Txt_User_Name_SG1);
                }
                else if (Txt_User_Name_SG1.Text.Contains(Paths.Split_Char))
                {
                    Error_Sound();
                    Txt_User_Name_SG1.Text = Txt_User_Name_SG1.Text.Replace("/", "");
                }
                Fill_Clp(Btn_Register_Apply, Txt_User_Name_SG1, Txt_Password_SG1, Txt_Email_SG);
            }
        }

        private void Txt_Password_SG_OnValueChanged(object sender, EventArgs e)
        {
            if (Txt_Password_SG1.Text != "")
            {
                Txt_Password_SG1.UseSystemPasswordChar = true;
                if (Txt_Password_SG1.Text.Length >= 4 && !Txt_Password_SG1.Text.Contains('/'))
                {
                    if (!Value_Pass)
                    {
                        Clp_Progress1.Value += 33;
                        Value_Pass = true;
                    }

                    Green_Txt(Txt_Password_SG1);

                    Fill_Clp(Btn_Register_Apply, Txt_User_Name_SG1, Txt_Password_SG1, Txt_Email_SG);
                }

                else if (!Txt_Password_SG1.Text.Contains('/') && Txt_Password_SG1.Text.Length < 4)
                {
                    if (Value_Pass)
                    {
                        Clp_Progress1.Value -= 33;
                        Value_Pass = false;
                    }

                    Orange_Txt(Txt_Password_SG1);
                }

                else if (Txt_Password_SG1.Text.Contains('/'))
                {
                    Error_Sound();
                    Txt_Password_SG1.Text = Txt_Password_SG1.Text.Replace("/", "");
                }

                if (Txt_Password_SG1.Text != "" && Txt_Password_SG1.Text != "رمز عبور")
                    Txt_Password_SG1.UseSystemPasswordChar = true;
            }
            else
                Txt_Password_SG1.UseSystemPasswordChar = false;
        }

        private void Txt_Email_SG_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                string Email_Check = Txt_Email_SG.Text.ToLower();
                int Email_Check_Lengh = Email_Check.Length;

                if (Email_Check_Lengh > 11)
                {
                    string Email_com = "";

                    if (Email_Check.Contains('@'))
                        Email_com = '@' + Email_Check.Split('@')[1];

                    if (Email_com == "@gmail.com" && Email_Check_Lengh > 15 || Email_com == "@yahoo.com" && Email_Check_Lengh > 15 || Email_com == "@icloud.com" && Email_Check_Lengh > 15 || Email_com == "@outlook.com" && Email_Check_Lengh > 15 || Email_com == "@hotmail.com" && Email_Check_Lengh > 15)
                    {
                        Green_Txt(Txt_Email_SG);

                        if (!Value_Email)
                        {
                            Clp_Progress1.Value += 34;
                            Value_Email = true;
                        }
                    }

                    else
                    {
                        Orange_Txt(Txt_Email_SG);

                        if (Value_Email)
                        {
                            Clp_Progress1.Value -= 34;
                            Value_Email = false;
                        }
                    }
                }
                Fill_Clp(Btn_Register_Apply, Txt_User_Name_SG1, Txt_Password_SG1, Txt_Email_SG);
            }
            catch
            {
                Orange_Txt(Txt_Email_SG);
                Txt_Email_SG.Text = "";

                popupNotifier1.ContentText = "لطفا پست الکترونیک را مجدد وارد کنید";
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.Popup();
            }
        }

        public void Error_Sound()
        {
            SystemSounds.Beep.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }


        void Green_Txt(RadTextBox Txt)
        {
            Txt.TextBoxElement.FocusBorderColor = Color.Green;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(Txt.GetChildAt(0).GetChildAt(2))).BottomWidth = 5;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(Txt.GetChildAt(0).GetChildAt(2))).BottomShadowColor = Color.Green;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(Txt.GetChildAt(0).GetChildAt(2))).BottomColor = Color.Green;
            Txt.TextBoxElement.FocusBorderWidth = 0;
        }

        void Orange_Txt(RadTextBox Txt)
        {
            Default_Txt(Txt);
            Txt.TextBoxElement.FocusBorderColor = Color_Btn2;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(Txt.GetChildAt(0).GetChildAt(2))).BottomWidth = 5;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(Txt.GetChildAt(0).GetChildAt(2))).BottomShadowColor = Color_Btn2;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(Txt.GetChildAt(0).GetChildAt(2))).BottomColor = Color_Btn2;
            Txt.TextBoxElement.FocusBorderWidth = 0;
        }

        void Default_Txt(RadTextBox Txt)
        {
            ((Telerik.WinControls.Primitives.BorderPrimitive)(Txt_Verfication_Code.GetChildAt(0).GetChildAt(2))).BottomColor = Color.Gray;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(Txt.GetChildAt(0).GetChildAt(2))).BottomShadowColor = Color.Gray;
            Txt.TextBoxElement.FocusBorderColor = Color.Gray;
            Hover_Color = Color.FromArgb(153, 180, 209);
        }

        private void Btn_Register_Click(object sender, EventArgs e)
        {
            Btn_Register_click(sender);
        }

        void Btn_Register_click(object sender)
        {
            pictureBox1.Select();

            bool Color_Check = true;

            Telerik.WinControls.UI.RadButton Button = (Telerik.WinControls.UI.RadButton)sender;

            if (Button.BackColor == Color_Btn2)
            {
                Button.BackColor = Color_Btn;
                Button.ForeColor = Color_Btn;

                Grb_Register.Location = Grb_Welcome_picture.Location;
                Grb_Forgot_Pass.Hide();
                Grb_Welcome_picture.Hide();
                Grb_Login.Hide();

                Grb_Register.Visible = true;
                Txt_Password_SG1.Visible = true;
                Txt_User_Name_SG1.Visible = true;
                Txt_Email_SG.Visible = true;
                Clp_Progress1.Visible = true;
                Btn_Register_Apply.Visible = true;
                label2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;

                Color_Check = true;
            }
            else
            {
                Button.BackColor = Color_Btn2;
                Button.ForeColor = Color_Btn2;
                Show_Welcome();
                Color_Check = false;
            }

            Telerik.WinControls.UI.RadButton[] BTNS = new Telerik.WinControls.UI.RadButton[3];

            BTNS[0] = Btn_Login;
            BTNS[1] = Btn_Register;
            BTNS[2] = Btn_Forgot_Pass;

            if (Color_Check)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (BTNS[i].Name != Button.Name)
                        BTNS[i].BackColor = Color_Btn2;
                }
            }

            Txt_User_Name_SG1.Select();
        }

        private void Show_Dialog_Main_Form(string Find)
        {
            try
            {
                Hide();
                Main_Form MF = new Main_Form(Find);
                MF.ShowDialog();
                Close();
            }
            catch
            {
                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.Popup();

                Show_Dialog_Main_Form(Find);
            }
        }

        private void Btn_Login_Apply_Click(object sender, EventArgs e)
        {
            bool Code_Color = false;
            bool login = false;

            if (Txt_Verfication_Code.Text.ToUpper() == Verfication_Code)
                Code_Color = true;

            Login L = new Login();

            Data = File.ReadAllLines("C:/Exir/Login.txt").ToList();

            if (Data != null)
            {
                L.User_Name = Txt_User_Name.Text;
                L.Pass = Txt_Password.Text;
                L.Data = Data;
                L.Verfication_Code = Code_Color;
                login = L.Check_For_Login();
            }
            else
            {
                login = false;
            }

            if (login)
            {
                Close_Form = true;

                popupNotifier2.ContentText = Txt_User_Name.Text + " " + "خوش آمدید";
                popupNotifier2.TitleText = "";
                popupNotifier2.Popup();

                foreach (string Find in Data)
                {
                    if (Find.Split('/')[0] == Txt_User_Name.Text)
                    {
                        Show_Dialog_Main_Form(Find);

                        break;
                    }
                }
            }

            else
            {
                Login();
                Txt_Verfication_Code.Text = "";

                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = " اطلاعات وارد شده نادرست است";
                popupNotifier1.Popup();
            }
        }

        private void Txt_Password_TextChanged(object sender, EventArgs e)
        {
            if (Txt_Password.Text != "" && Txt_Password.Text != "رمز عبور")
                Txt_Password.UseSystemPasswordChar = true;

            else if (Txt_Password.Text == "" && Txt_Password.UseSystemPasswordChar)
                Txt_Password.UseSystemPasswordChar = false; ;
        }

        void Fill_Clp(Guna.UI2.WinForms.Guna2Button Btn, RadTextBox User_Name, RadTextBox Pass, RadTextBox Verfication_Code)
        {
            if (User_Name.Text.Length > 2 && Pass.Text.Length >= 4 && ((Telerik.WinControls.Primitives.BorderPrimitive)Txt_Verfication_Code.GetChildAt(0).GetChildAt(2)).BottomColor == Color.Green)
            {
                if (Btn.Name == Btn_Register.Name)
                    Clp_Progress1.Value = 100;
            }
        }

        private void Btn_Register_Apply_Click(object sender, EventArgs e)
        {
            Sign_Up SU = new Sign_Up();

            if (!File.Exists("C:/Exir/Login.txt"))
            {
                var a = File.Create("C:/Exir/Login.txt");
                a.Close();
            }

            SU.User_Name = Txt_User_Name_SG1.Text;
            SU.Pass = Txt_Password_SG1.Text;
            SU.Email = Txt_Email_SG.Text;
            SU.Data = File.ReadAllLines("C:/Exir/Login.txt").ToList();
            SU.Path = "C:/Exir/Login.txt";

            string Result = SU.Su();

            if (Result == "Try")
            {
                popupNotifier2.TitleText = "انجام شد";
                popupNotifier2.ContentText = "حساب کاربری جدید ثبت شد";
                popupNotifier2.Popup();
                Txt_User_Name_SG1.Text = "";
                Txt_Password_SG1.Text = "";
                Txt_Email_SG.Text = "";
                Default_Txt(Txt_User_Name_SG1);
                Default_Txt(Txt_Password_SG1);
                Txt_Password_SG1.NullText = "";
                Default_Txt(Txt_Email_SG);
                Clp_Progress1.Value = 0;
                Txt_Password.UseSystemPasswordChar = false;
                Txt_Password_SG1.NullText = "رمز عبور";

                Value_User_Name = false;
                Value_Pass = false;
                Value_Email = false;
            }
            else if (Result == "catch")
            {
                popupNotifier1.TitleText = "انجام نشد";
                popupNotifier1.ContentText = "عملیات با خطا مواجه شد لطفا دوباره تلاش کنید";
                popupNotifier1.Popup();
            }
            else if (Result == "Repaet")
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "حسابی با این اطلاعات در سیستم ثبت شده";
                popupNotifier1.Popup();
            }
        }

        private void Btn_Forgot_Pass_Click(object sender, EventArgs e)
        {
            Btn_Forgot_Pass_click();
        }

        void Btn_Forgot_Pass_click()
        {
            pictureBox1.Select();

            bool Value_Color = false;

            if (Btn_Forgot_Pass.BackColor == Color_Btn2)
            {
                Btn_Forgot_Pass.BackColor = Color_Btn;
                Btn_Forgot_Pass.ForeColor = Color_Btn;
                Grb_Forgot_Pass.Location = Grb_Welcome_picture.Location;
                Grb_Forgot_Pass.Visible = true;
                Txt_User_Name_FP.Visible = true;
                Txt_Email_FP.Visible = true;
                Btn_Forgot_Pass_Apply.Visible = true;
                pictureBox7.Visible = true;
                pictureBox8.Visible = true;
                Grb_Welcome_picture.Hide();
                Grb_Forgot_Pass.Show();
                Value_Color = true;
            }
            else if (Btn_Forgot_Pass.BackColor == Color_Btn)
            {
                Btn_Forgot_Pass.BackColor = Color_Btn2;
                Btn_Forgot_Pass.ForeColor = Color_Btn2;
                Grb_Forgot_Pass.Location = Location;
                Grb_Forgot_Pass.Hide();
                Value_Color = false;
            }

            Telerik.WinControls.UI.RadButton[] BTNS = new Telerik.WinControls.UI.RadButton[3];

            BTNS[0] = Btn_Login;
            BTNS[1] = Btn_Register;
            BTNS[2] = Btn_Forgot_Pass;

            if (Value_Color)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (BTNS[i].Name != Btn_Forgot_Pass.Name)
                        BTNS[i].BackColor = Color_Btn2;
                }
            }

            Show_Welcome();

            Txt_User_Name_FP.Select();
        }

        private void Btn_Forgot_Pass_Apply_Click(object sender, EventArgs e)
        {
            string Return = Send_Email();

            if (Return != "")
            {
                if (Return.Split('/')[1] == "T")
                {
                    User_Name_Change_Pass = Txt_User_Name_FP.Text;
                    VF = Return.Split('/')[0];
                    Grb_Enter_Code.Visible = true;
                    bunifuMaterialTextbox6.Visible = true;
                    Btn_Forgot_Pass_Apply.Visible = false;
                    Tns_Forgot_Pass.Show(Grb_Enter_Code);
                    Tns_Forgot_Pass.Show(bunifuMaterialTextbox6);
                    Lbl_Time.Text = "1:30";
                    Timer(1000);

                    Grb_Change_Pass.Visible = false;
                    Txt_User_Name_FP.Visible = false;
                    Txt_Email_FP.Visible = false;
                }
                else if (Return.Split('/')[1] == "F")
                {
                    popupNotifier1.ContentText = "ایمیل فرستاده نشد \n لطفا دوباره تلاش کنید";
                    popupNotifier1.TitleText = "خطا";
                    popupNotifier1.Popup();
                }
            }
            else
            {
                popupNotifier1.ContentText = "حسابی با این اطلاعات وجود ندارد";
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.Popup();
            }
        }

        string Send_Email()
        {
            Forgot_Pass_Send_Email FPSE = new Forgot_Pass_Send_Email();

            FPSE.Data = File.ReadAllLines("C:/Exir/Login.txt").ToList();
            FPSE.Email = Txt_Email_FP.Text;
            FPSE.Path = "C:/Exir/Login.txt";
            FPSE.User_Name = Txt_User_Name_FP.Text;

            return FPSE.FPSE();
        }

        private void Txt_User_Name_SG1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                Txt_Password_SG1.Select();
        }

        private void Txt_Password_SG1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                Txt_Email_SG.Select();
        }

        private void Txt_Email_SG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                Btn_Register_Apply.Select();
        }

        private void Txt_User_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                Txt_Password.Select();
        }

        private void Txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                Txt_Verfication_Code.Select();
        }

        private void Txt_Verfication_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                Btn_Login_Apply.Select();
        }

        private void bunifuMaterialTextbox6_OnValueChanged(object sender, EventArgs e)
        {
            if (Check_Code())
            {
                Grb_Change_Pass.Visible = true;
                Txtpass.Visible = true;
                Txtpass2.Visible = true;
                BtnChange.Visible = true;

                Tns_Forgot_Pass.Show(Grb_Change_Pass);
                Tns_Forgot_Pass.Show(Txtpass);
                Tns_Forgot_Pass.Show(Txtpass2);
                Tns_Forgot_Pass.Show(BtnChange);

                Grb_Change_Pass.Select();
                Grb_Enter_Code.Hide();
            }
        }

        bool Check_Code()
        {
            string Code_Input = bunifuMaterialTextbox6.Text;

            if (VF == Code_Input && VF != null)
                return true;

            return false;
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            Change_Pass CHP = new Change_Pass();

            CHP.Email = Txt_Email_FP.Text;
            CHP.Data = File.ReadAllLines(Paths.Login_txt).ToList();
            CHP.New_Pass = Txtpass.Text;
            CHP.User_Name = User_Name_Change_Pass;
            CHP.Path = Paths.Login_txt;

            if (CHP.Change())
            {
                Txtpass.Text = "";
                Txtpass2.Text = "";
                Orange_Txt(Txtpass);
                Orange_Txt(Txtpass2);
                Grb_Change_Pass.Visible = false;
                Txtpass.Visible = false;
                Txtpass2.Visible = false;
                bunifuMaterialTextbox6.Visible = false; ;
                BtnChange.Visible = false;
                bunifuMaterialTextbox6.Text = "";
                Txt_Email_FP.Text = "";
                Txt_User_Name_FP.Text = "";
                Btn_Forgot_Pass_Apply.Visible = false;
                Txtpass.Text = "";
                Txtpass2.Text = "";
                //
                Btn_Forgot_Pass.BackColor = Color_Btn;
                Lbl_Time.Visible = true;
                Btn_Forgot_Pass.ForeColor = Color_Btn;
                Grb_Forgot_Pass.Location = Grb_Welcome_picture.Location;
                Grb_Forgot_Pass.Visible = true;
                Txt_User_Name_FP.Visible = true;
                Txt_Email_FP.Visible = true;
                Btn_Forgot_Pass_Apply.Visible = true;
                pictureBox7.Visible = true;
                pictureBox8.Visible = true;
                Grb_Welcome_picture.Hide();
                Grb_Forgot_Pass.Show();
                popupNotifier2.TitleText = "انجام شد";
                popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                popupNotifier2.Popup();

                Grb_Change_Pass.Visible = true;
                Txt_User_Name_FP.Visible = true;
                Txt_Email_FP.Visible = true;
            }
            else
            {
                popupNotifier1.TitleText = "انجام نشد";
                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد لطفا مجدد تلاش کنید";
                popupNotifier1.Popup();
            }
        }

        private void Txtpass_OnValueChanged(object sender, EventArgs e)
        {
            if (Txtpass.Text == "")
            {
                Txtpass.NullText = "";
                Txtpass.UseSystemPasswordChar = true;
            }

            if (Txtpass.Text.Length >= 4 && !Txtpass.Text.Contains('/'))
            {
                if (!Value_Pass)
                {
                    Clp_Progress1.Value += 33;
                    Value_Pass = true;
                }

                Green_Txt(Txtpass);

                Enabled_Txts++;

                if (Txtpass.TextBoxElement.FocusBorderColor == Color.ForestGreen && Txtpass.TextBoxElement.FocusBorderColor == Color.ForestGreen)
                    BtnChange.Enabled = true;
            }
            else if (Txtpass.Text.Contains('/'))
            {
                Txtpass.Text = Txtpass.Text.Replace("/", "");
                Error_Sound();
            }
            else if (Txtpass.Text.Length < 4 && !Txtpass.Text.Contains('/'))
            {
                Orange_Txt(Txtpass);
                BtnChange.Enabled = false;
            }
        }

        public void Timer(int Interval)
        {
            Timer T = new Timer();

            T.Interval = Interval;
            T.Tick += T_Tick;
            T.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (!Close_Form)
            {
                string time = Lbl_Time.Text;

                if (time.Contains(':'))
                {
                    int Minute = Convert.ToInt32(time.Split(':')[0]);
                    int Second = Convert.ToInt32(time.Split(':')[1]);

                    if (!Grb_Change_Pass.Visible)
                    {
                        if (Second == 0)
                        {
                            if (Minute != 0)
                            {
                                Minute--;
                                Second = 59;
                            }
                            else
                            {
                                Lbl_Time.Text = "رسید به اتمام زمان";

                                if (!Time_End)
                                {
                                    Send_Email_And_Error();
                                    Time_End = true;
                                }
                            }
                        }
                        else if (Minute == 0 && Second == 00)
                        {
                            Grb_Welcome_picture.Show();
                        }
                        else
                            Second--;

                        string New_Time = Minute.ToString() + ':';

                        if (Second.ToString().Length == 1)
                            New_Time += '0' + Second.ToString();
                        else
                            New_Time += Second.ToString();

                        Lbl_Time.Text = New_Time;
                    }
                }
            }
        }

        void Send_Email_And_Error()
        {
            VF = null;

            Lbl_Time.Text = "رسید به اتمام زمان";
            popupNotifier1.TitleText = "پایان زمان";
            popupNotifier1.ContentText = "زمان وارد کردن کد امنیتی\n به پایان رسید\nسیستم در حال برگشت شما است ";
            popupNotifier1.Size = new Size(400, 180);
            popupNotifier1.Popup();
            Btn_Forgot_Pass_click();
        }

        private void Txtpass2_OnValueChanged(object sender, EventArgs e)
        {
            if (Txtpass2.Text == "")
            {
                Txtpass2.NullText = "";
                Txtpass2.UseSystemPasswordChar = true;
            }

            if (Txtpass2.Text.Length >= 4 && !Txtpass2.Text.Contains('/'))
            {
                Green_Txt(Txtpass2);

                if (Txtpass.TextBoxElement.FocusBorderColor == Color.ForestGreen && Txtpass.TextBoxElement.FocusBorderColor == Color.ForestGreen)
                    BtnChange.Enabled = true;
            }
            else if (Txtpass2.Text.Contains('/'))
            {
                Txtpass2.Text = Txtpass2.Text.Replace("/", "");
                Error_Sound();
            }
            else if (Txtpass2.Text.Length < 4 && !Txtpass2.Text.Contains('/'))
            {
                Orange_Txt(Txtpass2);
            }
            if (Txtpass.Text != Txtpass2.Text)
            {
                Orange_Txt(Txtpass2);
                BtnChange.Enabled = false;
            }
        }

        private void Txt_User_Name_FP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                Txt_Email_FP.Select();
        }

        private void Login_Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.L)
                Btn_Login_click(Btn_Login);

            else if (e.Control && e.KeyCode == Keys.R)
                Btn_Register_click(Btn_Register);

            else if (e.Control && e.KeyCode == Keys.F)
                Btn_Forgot_Pass_click();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting("10001");
            setting.Show();
        }

        private void Login_Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close_Form = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Btn_Login_click(Btn_Login);

            Txt_User_Name.Text = "شایان";
            Txt_Password.Text = "1234";
            Txt_Verfication_Code.Text = Verfication_Code;
            Btn_Login_Apply_Click(Btn_Login_Apply, null);
        }

        private void Txt_Verfication_Code_Enter(object sender, EventArgs e)
        {
            if (Txt_Verfication_Code.TextBoxElement.FocusBorderColor == Color.Gray)
                Orange_Txt(Txt_Verfication_Code);

            else
                Txt_Verfication_Code.TextBoxElement.FocusBorderColor = Txt_Verfication_Code.TextBoxElement.FocusBorderColor;
        }
    }
}