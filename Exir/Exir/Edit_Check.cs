using CEWorld.Convert;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Exir
{
    public partial class Edit_Check : Form
    {
        string Person_Id = "";
        string Name = "";
        string Date_Issuance = "";
        string Account_Side = "";
        string Bank_Name = "";
        string Bank_Account = "";
        string Date_Expiration = "";
        string Check_Number = "";
        string Price_In_Number = "";
        string Price_In_String = "";
        bool Recived = false;
        bool Payment = false;

        public Edit_Check(string person_id, string name, string date_issuance, string bank_name, string bank_account, string date_expiration, string check_number, string price_in_number, string price_in_string, bool recived, bool payment, string account_side)
        {
            InitializeComponent();

            Person_Id = person_id;
            Name = name;
            Date_Issuance = date_issuance;
            Bank_Name = bank_name;
            Bank_Account = bank_account;
            Date_Expiration = date_expiration;
            Check_Number = check_number;
            Price_In_Number = price_in_number;
            Price_In_String = price_in_string;
            Account_Side = account_side;
            Recived = recived;
            Payment = payment;

            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);


            Form_Load();
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

                if (Data_Checks.Count() != 0)
                {
                    foreach (string Find in Data_Checks)
                    {
                        Cmb_Name_Checks.Items.Add(Find.Split(Paths.Split_Char)[0]);
                    }
                }
                else
                {
                    Cmb_Name_Checks.Items.Add("چکی در سیستم ثبت نشده");
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

                Txt_Day_Issuance.Text = Date_Issuance.Split('_')[2];
                Txt_Month_Issuance.Text = Date_Issuance.Split('_')[1];
                Txt_Year_Issuance.Text = Date_Issuance.Split('_')[0];
                Txt_Day_Expiration.Text = Date_Expiration.Split('_')[2];
                Txt_Month_Expiration.Text = Date_Expiration.Split('_')[1];
                Txt_Year_Expiration.Text = Date_Expiration.Split('_')[0];
                Txt_Price_In_Number.Text = Price_In_Number;
                Lbl_Price_In_String.Text = Price_In_String;
                Cmb_Name_Checks.Text = Name;
                Cmb_Banks_Name.Text = Bank_Name;
                Cmb_Bank_Account.Text = Bank_Account;
                Cmb_Account_Side.Text = Account_Side;
                Txt_Check_Number.Text = Check_Number;
                Rad_Received.Checked = Recived;
                Rad_Payment.Checked = Payment;
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

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            try
            {
                Remove_Check RCC = new Remove_Check();

                string Result_Remove = RCC.Action(Person_Id, Name);

                Add_Check_Class ACC = new Add_Check_Class();

                string Date_Issuance = Txt_Year_Issuance.Text + '_' + Txt_Month_Issuance.Text + '_' + Txt_Day_Issuance.Text;
                string Date_Expieration = Txt_Year_Expiration.Text + '_' + Txt_Month_Expiration.Text + '_' + Txt_Day_Expiration.Text;

                string Result_Add = ACC.Action(Person_Id, Cmb_Name_Checks.Text, Date_Issuance, Cmb_Banks_Name.Text.Replace(Paths.Split_Char.ToString(), ""), Cmb_Bank_Account.Text, Date_Expieration, Txt_Check_Number.Text, Txt_Price_In_Number.Text.Replace(",", "").Replace(",", ""), Lbl_Price_In_String.Text, Cmb_Account_Side.Text, Rad_Received.Checked);

                if (Result_Add == "Try" && Result_Remove == "Try")
                {
                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                    popupNotifier2.Popup();

                    Close();
                }
                else
                {
                    if (Result_Remove == "Try")
                        ACC.Action(Person_Id, Name, Date_Issuance, Bank_Name, Bank_Account, Date_Expieration, Check_Number, Price_In_Number, Price_In_String, Cmb_Account_Side.Text, Rad_Received.Checked);

                    if (Result_Add == "Try")
                        RCC.Action(Person_Id, Cmb_Name_Checks.Text);

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                    popupNotifier1.Popup();
                }
            }
            catch { }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
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

        private void Edit_Check_TextChanged(object sender, EventArgs e)
        {
            Anty_Slash(sender);
        }

        private void Cmb_Name_Checks_TextChanged(object sender, EventArgs e)
        {
            Anty_Slash_Cmb(sender);
        }

        void Anty_Slash_Cmb_Telerik(object obj)
        {
            Telerik.WinControls.UI.RadDropDownList Cmb = (Telerik.WinControls.UI.RadDropDownList)obj;

            if (Cmb.Text.Contains(Paths.Split_Char))
                Error_Sound();

            Cmb.Text = Cmb.Text.Replace(Paths.Split_Char.ToString(), "");
            Cmb.Text = Cmb.Text;
        }

        private void Cmb_Banks_Name_TextChanged(object sender, EventArgs e)
        {
            Anty_Slash_Cmb_Telerik(sender);
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
    }
}