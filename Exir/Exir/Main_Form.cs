using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Exir
{
    public partial class Main_Form : Telerik.WinControls.UI.RadForm
    {
        string[] Data = File.ReadAllLines("C:/Exir/Login.txt");
        string User = "";
        string Person_ID = "";
        string Time = "";

        Image Profile_Image = null;
        FontStyle fontStyle0 = FontStyle.Regular;
        Font Font0_ = null;

        public Main_Form(string Find)
        {
            InitializeComponent();

            Person_ID = Find.Split('/')[4];
            User = Find.Split('/')[0];
            string Font0 = File.ReadAllText(Paths.Font0_txt(Person_ID));

            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            switch (Font0.Split('/')[1])
            {
                case "Bold":
                    fontStyle0 = FontStyle.Bold;
                    break;

                case "Italic":
                    fontStyle0 = FontStyle.Italic;
                    break;

                case "Regular":
                    fontStyle0 = FontStyle.Regular;
                    break;

                case "Strikeout":
                    fontStyle0 = FontStyle.Strikeout;
                    break;

                case "Underline":
                    fontStyle0 = FontStyle.Underline;
                    break;
            }

            Font0_ = new Font(Font0.Split('/')[0], 14, fontStyle0);
            Change_Font(Font0_);
            Profile_Image = Image.FromFile("C:/Exir/" + Person_ID + "/Profile" + File.ReadAllText("C:/Exir/" + Person_ID + "/Selected_Profile.txt") + ".png");
            Pib_Profile.Image = Profile_Image;
            Lbl_Name.Text = User;
        }

        void Change_Font(Font font)
        {
            try
            {
                label1.Font = font;
                label2.Font = font;
                label3.Font = font;
                label5.Font = font;
                label6.Font = font;
                label8.Font = font;
            }
            catch { }
        }

        private void Btn_Good_Click(object sender, EventArgs e)
        {
            foreach (string Find in Data)
            {
                if (Find.Split('/')[0] == User)
                {
                    Add_Goods AG = new Add_Goods(Find.Split('/')[4]);
                    AG.ShowDialog();
                }
            }
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            Size = MinimumSize;

            Timer timer = new Timer();

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                PersianCalendar persianCalendar = new PersianCalendar();

                Time = DateTime.Now.Hour.ToString() + ':' + DateTime.Now.Minute.ToString() + ':' + DateTime.Now.Second.ToString();

                Lbl_Time.Text = Time;

                string Date = persianCalendar.GetYear(DateTime.Now).ToString() + '/' + persianCalendar.GetMonth(DateTime.Now).ToString() + '/' + persianCalendar.GetDayOfMonth(DateTime.Now).ToString();

                if (Lbl_Date.Text != Date)
                {
                    Lbl_Date.Text = Date;
                    Lbl_Day.Text = Get_Persian_Day(persianCalendar);
                }
            }
            catch
            {
                Lbl_Date.Text = "";
                Lbl_Day.Text = "";
                Lbl_Time.Text = "";
            }
        }
        string Get_Persian_Day(PersianCalendar persianCalendar)
        {
            string Day = persianCalendar.GetDayOfWeek(DateTime.Now).ToString();

            switch (Day)
            {
                case "Saturday":
                    return "شنبه";

                case "Sunday":
                    return "یکشنبه";

                case "Monday":
                    return "دوشنبه";

                case "Tuesday":
                    return "سه شنبه";

                case "Wednesday":
                    return "چهارشنبه";

                case "Thursday":
                    return "پنجشنبه";

                case "Friday":
                    return "جمعه";

                default:
                    return "";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting(Person_ID);
            setting.ShowDialog();
        }

        private void Btn_Account_Side_Click(object sender, EventArgs e)
        {
            try
            {
                Account_Side AS = new Account_Side(Person_ID);
                AS.ShowDialog();
            }
            catch
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bank_Account BA = new Bank_Account(Person_ID);
            BA.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Financial_Department FD = new Financial_Department(Person_ID);
            FD.ShowDialog();
        }

        private void ثبتصندوقToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Add_Check AC = new Add_Check(Person_ID);
            AC.ShowDialog();
        }

        private void ثبتچکToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cash_Desk CD = new Cash_Desk(Person_ID);
            CD.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Factor F = new Factor(Person_ID);
            F.ShowDialog();
        }

        private void ثبتکالاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (string Find in Data)
            {
                if (Find.Split('/')[0] == User)
                {
                    Add_Goods AG = new Add_Goods(Find.Split('/')[4]);
                    AG.ShowDialog();
                }
            }
        }

        private void ثبتفاکتورToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Factor F = new Factor(Person_ID);
            F.ShowDialog();
        }

        private void ثبتطرفحسابToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account_Side AS = new Account_Side(Person_ID);
                AS.ShowDialog();
            }
            catch
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        private void ثبتحساببانکیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank_Account BA = new Bank_Account(Person_ID);
            BA.ShowDialog();
        }

        private void ثبتسرفصلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Heading H = new Heading(Person_ID);
            H.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (File.ReadAllLines(Paths.Heading_Code(Person_ID)).Length < 2)
            {
                RadMessageBox.Show("برای ثبت سند تعداد سرفصل ها حداقل باید 1 باشد");
            }

            else
            {
                Document D = new Document(Person_ID);
                D.ShowDialog();
            }
        }

        private void Main_Form_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Pib_Profile.Visible = true;
                Lbl_Name.Visible = true;
            }

            else if (Size.Height <= 761)
            {
                Pib_Profile.Visible = false;
                Lbl_Name.Visible = false;
            }

            else
            {
                Pib_Profile.Visible = true;
                Lbl_Name.Visible = true;
            }
        }
    }
}