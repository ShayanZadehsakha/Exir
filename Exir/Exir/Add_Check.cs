using CEWorld.Convert;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Exir
{
    public partial class Add_Check : RadForm
    {
        string Person_Id = "";

        public Add_Check(string person_id)
        {
            InitializeComponent();

            Person_Id = person_id;

            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            PersianCalendar PC = new PersianCalendar();

            Txt_Year_Issuance.Text = PC.GetYear(DateTime.Now).ToString();
            Txt_Month_Issuance.Text = PC.GetMonth(DateTime.Now).ToString();
            Txt_Day_Issuance.Text = PC.GetDayOfMonth(DateTime.Now).ToString();

            Form_Load();
        }

        public Add_Check(string person_id, string PR)
        {
            InitializeComponent();

            Person_Id = person_id;

            PersianCalendar PC = new PersianCalendar();

            Txt_Year_Issuance.Text = PC.GetYear(DateTime.Now).ToString();
            Txt_Month_Issuance.Text = PC.GetMonth(DateTime.Now).ToString();
            Txt_Day_Issuance.Text = PC.GetDayOfMonth(DateTime.Now).ToString();

            Form_Load();

            Rad_Payment.Enabled = false;
            Rad_Received.Enabled = false;

            if (PR == "R")
                Rad_Received.Checked = true;
        }

        void Form_Load()
        {
            try
            {
                if (!File.Exists(Paths.Checks_Txt(Person_Id)))
                {
                    var a = File.Create(Paths.Checks_Txt(Person_Id));
                    a.Close();
                }

                if (!File.Exists(Paths.Bank_Account_txt(Person_Id)))
                {
                    var a = File.Create(Paths.Bank_Account_txt(Person_Id));
                    a.Close();
                }

                Cmb_Name_Checks.Items.Clear();
                Cmb_Bank_Account.Items.Clear();
                Dgb_Checks.Rows.Clear();

                string[] Data_Bank_Accounts = File.ReadAllLines(Paths.Bank_Account_User_txt(Person_Id));
                string[] Data_Checks = File.ReadAllLines(Paths.Checks_Txt(Person_Id));
                string[] Data_Account_Sides = File.ReadAllLines(Paths.Account_Side_txt(Person_Id));

                if (Data_Bank_Accounts.Count() != 0)
                {
                    foreach (string Find in Data_Bank_Accounts)
                    {
                        Cmb_Bank_Account.Items.Add(Find.Split(Paths.Split_Char)[0]);
                    }
                }
                else
                {
                    Cmb_Bank_Account.Items.Add("حساب  بانکی در سیستم ثبت شده");
                }

                if (Data_Account_Sides.Count() != 0)
                {
                    foreach (string Find in Data_Account_Sides)
                    {
                        Cmb_Account_Side.Items.Add(Find.Split(Paths.Split_Char)[0]);
                    }
                }
                else
                {
                    Cmb_Account_Side.Items.Add("طرف حسابی در سیستم ثبت شده");
                }

                if (Data_Checks.Count() != 0)
                {
                    foreach (string Find in Data_Checks)
                    {
                        Cmb_Name_Checks.Items.Add(Find.Split(Paths.Split_Char)[0]);

                        string Day_Issuance = "";
                        string Day_Expiration = "";

                        if (Find.Split(Paths.Split_Char)[1].Replace('_', '/') != "//")
                            Day_Issuance = Find.Split(Paths.Split_Char)[1].Replace('_', '/');

                        if (Find.Split(Paths.Split_Char)[2].Replace('_', '/') != "//")
                            Day_Expiration = Find.Split(Paths.Split_Char)[2].Replace('_', '/');

                        string Check_Type = "دریافتی";

                        if (Find.Split(Paths.Split_Char)[9] == "P")
                            Check_Type = "پرداختی";

                        Dgb_Checks.Rows.Add(Day_Issuance, Day_Expiration, Find.Split(Paths.Split_Char)[0], Find.Split(Paths.Split_Char)[3], Find.Split(Paths.Split_Char)[5], Find.Split(Paths.Split_Char)[4], Find.Split(Paths.Split_Char)[8], Find.Split(Paths.Split_Char)[7], Check_Type);
                    }
                }
                else
                {
                    Cmb_Name_Checks.Items.Add("چکی در سیستم ثبت نشده");
                }
            }
            catch
            {
                try
                {
                    popupNotifier1.TitleText = "خطا !";
                    popupNotifier1.ContentText = "عملیات بارگزاری اطلاعات با مشکل مواجه شد";
                    popupNotifier1.Popup();
                }
                catch { }
            }
        }

        private void Txt_Price_In_Number_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Lbl_Price_In_String.Text = NumberToWord.PersianConvertNumberToWord(Txt_Price_In_Number.Text.Replace(",", ""));
                Separate_Texts.Separatea(sender);
            }
            catch { }
        }

        private void Btn_Apply_Payment_Click(object sender, EventArgs e)
        {
            if (Cmb_Account_Side.Text == "")
            {
                popupNotifier1.TitleText = "خطا !";
                popupNotifier1.ContentText = "لطفا نام طرف حساب را وارد کنید";
                popupNotifier1.Popup();

                return;
            }

            if (Cmb_Bank_Account.Text == "")
            {
                popupNotifier1.TitleText = "خطا !";
                popupNotifier1.ContentText = "لطفا نام حساب بانکی را وارد کنید";
                popupNotifier1.Popup();

                return;
            }

            int result;
            
            if (   Txt_Price_In_Number.Text.Replace(",", "") == "" || !int.TryParse(   Txt_Price_In_Number.Text.Replace(",", ""), out result))
            {
                popupNotifier1.TitleText = "خطا !";
                popupNotifier1.ContentText = "لطفا مبلغ را وارد کنید";
                popupNotifier1.Popup();

                return;
            }

            Add_Check_Class ACC = new Add_Check_Class();

            string Date_Issuance = Txt_Year_Issuance.Text + '_' + Txt_Month_Issuance.Text + '_' + Txt_Day_Issuance.Text;
            string Date_Expieration = Txt_Year_Expiration.Text + '_' + Txt_Month_Expiration.Text + '_' + Txt_Day_Expiration.Text;

            string Result = ACC.Action(Person_Id, Cmb_Name_Checks.Text, Date_Issuance, Cmb_Banks_Name.Text.Replace(Paths.Split_Char.ToString(), ""), Cmb_Bank_Account.Text, Date_Expieration, Txt_Check_Number.Text,    Txt_Price_In_Number.Text.Replace(",", ""), Lbl_Price_In_String.Text, Cmb_Account_Side.Text, Rad_Received.Checked);

            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "چک" + " " + Cmb_Name_Checks.Text + " " + "با موفقیت اضافه شد";
                    popupNotifier2.Popup();

                    Properties.Settings.Default.Check_Financial = Cmb_Name_Checks.Text;

                    Cmb_Name_Checks.Text = "";

                    break;

                case "Exists":

                    popupNotifier1.TitleText = "خطا !";
                    popupNotifier1.ContentText = "چکی با این نام در سیستم وجود دارد";
                    popupNotifier1.Popup();

                    break;

                case "LP":

                    popupNotifier1.TitleText = "خطا !";
                    popupNotifier1.ContentText = "موجودی حساب بانکی کمتر از مبلغ وارد شده است";
                    popupNotifier1.Popup();

                    break;

                case "N_Exists":

                    popupNotifier1.TitleText = "خطا !";
                    popupNotifier1.ContentText = "حساب بانکی با این نام در سیستم وجود ندارد";
                    popupNotifier1.Popup();

                    break;

                case "catch":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                    popupNotifier1.Popup();

                    break;
            }

            Form_Load();
        }

        private void Txt_Day_Expiration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                RadTextBox Txt = (RadTextBox)sender;

                if (Get_Txt(Txt).Text != "")
                {
                    if (Convert.ToInt32(Get_Txt(Txt).Text) <= 6 && Convert.ToInt32(Txt.Text) > 31)
                    {
                        Txt.Text = "31";

                        Error_Sound();
                    }
                    else if (Convert.ToInt32(Get_Txt(Txt).Text) > 6 && Convert.ToInt32(Txt.Text) > 30)
                    {
                        Txt.Text = "30";

                        Error_Sound();
                    }
                }

                if (Txt.TextLength == Txt.MaxLength)
                {
                    Get_Txt(Txt).Select();
                }
            }
            catch { }
        }

        private RadTextBox Get_Txt(RadTextBox Txt)
        {
            if (Txt == Txt_Day_Expiration)
                return Txt_Month_Expiration;

            else if (Txt == Txt_Day_Issuance)
                return Txt_Month_Issuance;

            else if (Txt == Txt_Month_Expiration)
                return Txt_Day_Expiration;

            else
                return Txt_Day_Issuance;
        }

        private void Txt_Month_Expiration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                RadTextBox Txt = (RadTextBox)sender;

                if (Convert.ToInt32(Txt.Text) > 12)
                {
                    Txt.Text = "12";

                    Error_Sound();
                }

                if (Txt.TextLength == Txt.MaxLength)
                {
                    if (Txt == Txt_Month_Expiration)
                        Txt_Year_Expiration.Select();

                    else
                        Txt_Year_Issuance.Select();
                }

                if (Get_Txt(Txt).Text == "31" && Convert.ToInt32(Txt.Text) > 6)
                {
                    Get_Txt(Txt).Text = "30";
                }
            }
            catch { }
        }

        private void Dgb_Checks_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (Dgb_Checks.SelectedRows[0].Cells[0].Value != null)
                {
                    bool P = true;

                    if (Dgb_Checks.SelectedRows[0].Cells[8].Value.ToString() == "دریافتی")
                        P = false;

                    Load_Data_By_Name(Dgb_Checks.SelectedRows[0].Cells[2].Value.ToString(), P);
                    Lbl_Price_In_String.Text = NumberToWord.PersianConvertNumberToWord(   Txt_Price_In_Number.Text.Replace(",", ""));
                }
            }
            catch { }
        }

        void Load_Data_By_Name(string Name, bool P)
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Checks_Txt(Person_Id));

                foreach (string Find in Data)
                {
                    if (Find.Split(Paths.Split_Char)[0] == Name)
                    {
                        Cmb_Name_Checks.Text = Find.Split(Paths.Split_Char)[0];
                        Txt_Day_Issuance.Text = Find.Split(Paths.Split_Char)[1].Split('_')[2];
                        Txt_Month_Issuance.Text = Find.Split(Paths.Split_Char)[1].Split('_')[1];
                        Txt_Year_Issuance.Text = Find.Split(Paths.Split_Char)[1].Split('_')[0];
                        Txt_Day_Expiration.Text = Find.Split(Paths.Split_Char)[2].Split('_')[2];
                        Txt_Month_Expiration.Text = Find.Split(Paths.Split_Char)[2].Split('_')[1];
                        Txt_Year_Expiration.Text = Find.Split(Paths.Split_Char)[2].Split('_')[0];
                        Cmb_Banks_Name.Text = Find.Split(Paths.Split_Char)[3];
                        Cmb_Bank_Account.Text = Find.Split(Paths.Split_Char)[4];
                        Txt_Check_Number.Text = Find.Split(Paths.Split_Char)[5];
                           Txt_Price_In_Number.Text = Find.Split(Paths.Split_Char)[6];
                        Lbl_Price_In_String.Text = Find.Split(Paths.Split_Char)[7];
                        Cmb_Account_Side.Text = Find.Split(Paths.Split_Char)[8];
                        Rad_Payment.Checked = P;
                        Rad_Received.Checked = !P;

                        return;
                    }
                }
            }
            catch
            {
                try
                {
                    popupNotifier1.TitleText = "خطا !";
                    popupNotifier1.ContentText = "عملیات بارگزاری اطلاعات با مشکل مواجه شد";
                    popupNotifier1.Popup();
                }
                catch { }
            }
        }

        void Remove()
        {
            Remove_Check RCC = new Remove_Check();

            string Result = RCC.Action(Person_Id, Cmb_Name_Checks.Text);

            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "چک" + " " + Cmb_Name_Checks.Text + " " + "با موفقیت حذف شد";
                    popupNotifier2.Popup();

                    Cmb_Name_Checks.Text = "";

                    break;

                case "N_Exists":

                    popupNotifier1.TitleText = "خطا !";
                    popupNotifier1.ContentText = "چکی با این نام در سیستم وجود ندارد";
                    popupNotifier1.Popup();

                    break;

                case "catch":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                    popupNotifier1.Popup();

                    break;
            }

            Form_Load();
        }

        void Edit()
        {
            string Date_Issuance = Txt_Year_Issuance.Text + '_' + Txt_Month_Issuance.Text + '_' + Txt_Day_Issuance.Text;
            string Date_Expieration = Txt_Year_Expiration.Text + '_' + Txt_Month_Expiration.Text + '_' + Txt_Day_Expiration.Text;

            Hide();
            Edit_Check ECH = new Edit_Check(Person_Id, Cmb_Name_Checks.Text, Date_Issuance, Cmb_Banks_Name.Text.Replace(Paths.Split_Char.ToString(), ""), Cmb_Bank_Account.Text, Date_Expieration, Txt_Check_Number.Text,    Txt_Price_In_Number.Text.Replace(",", ""), Lbl_Price_In_String.Text, Rad_Received.Checked, Rad_Payment.Checked, Cmb_Account_Side.Text);
            ECH.ShowDialog();
            Show();

            Form_Load();
        }

        private void Btnn_Edit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void تغییرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit();
        }

        public void Error_Sound()
        {
            SystemSounds.Beep.Play();
        }

        void Anty_Slash(object obj)
        {
            Telerik.WinControls.UI.RadTextBox Txt = (Telerik.WinControls.UI.RadTextBox)obj;

            if (Txt.Text.Contains("/"))
                Error_Sound();

            Txt.Text = Txt.Text.Replace(Paths.Split_Char.ToString(), "");
        }

        void Anty_Slash_Cmb(object obj)
        {
            ComboBox Cmb = (ComboBox)obj;

            if (Cmb.Text.Contains("/"))
                Error_Sound();

            Cmb.Text = Cmb.Text.Replace(Paths.Split_Char.ToString(), "");
        }

        private void anty_slash(object sender, EventArgs e)
        {
            Anty_Slash(sender);
        }

        private void anty_slash_cmb(object sender, EventArgs e)
        {
            Anty_Slash_Cmb(sender);
        }

        void Anty_Slash_Cmb_Telerik(object obj)
        {
            RadDropDownList Cmb = (RadDropDownList)obj;

            if (Cmb.Text.Contains(Paths.Split_Char))
                Error_Sound();

            Cmb.Text = Cmb.Text.Replace(Paths.Split_Char.ToString(), "");
            Cmb.Text = Cmb.Text;
        }

        private void Cmb_Banks_Name_TextChanged(object sender, EventArgs e)
        {
            Anty_Slash_Cmb_Telerik(sender);
        }

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            Remove();
        }
    }
}