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
using System.Windows.Forms;

namespace Exir
{
    public partial class Edit_Bank_Account : Form
    {
        string Result_Remove = "";
        string Result_Add = "";
        string Person_Id = "";
        string Banks_Name = "";
        string Account_Number = "";
        string Card_Number = "";
        string Sheba = "";
        string Card_Holder = "";
        string Account_Side = "";
        string Account_Bank_Name = "";

        public Edit_Bank_Account(string person_id, string account_Side, string banks_Name, string account_Number, string card_Number, string sheba, string card_Holder, string account_Bank_Name)
        {
            InitializeComponent();

            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            Person_Id = person_id;
            Banks_Name = banks_Name;
            Account_Number = account_Number;
            Card_Number = card_Number;
            Sheba = sheba;
            Card_Holder = card_Holder;
            Account_Side = account_Side;
            Account_Bank_Name = account_Bank_Name;

            Cmb_Banks_Name.Text = Banks_Name;
            Txt_Account_Number.Text = Account_Number;
            Txt_Card_Number.Text = Card_Number;
            Txt_Sheba.Text = Sheba;
            Txt_Card_Holder.Text = Card_Holder;

            Load_Cmb_Account_Side(Cmb_Account_Side1);
            Load_Data_Bank_Account();
        }

        public void Load_Data_Bank_Account()
        {
            try
            {
                if (!File.Exists(Paths.Bank_Account_txt(Person_Id)))
                    Create_File(Paths.Bank_Account_txt(Person_Id));

                string Name_Account_Side = Cmb_Account_Side1.Text;

                string[] Data = File.ReadAllLines(Paths.Bank_Account_txt(Person_Id));

                Cmb_Bank_Account.Items.Clear();

                foreach (string Find in Data)
                {
                    Cmb_Bank_Account.Items.Add(Find.Split(Paths.Split_Char)[0]);
                }
            }
            catch
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "عملیات بارگزاری اطلاعات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        void Create_File(string Path)
        {
            var a = File.Create(Path);
            a.Close();
        }

        void Load_Cmb_Account_Side(ComboBox Cmb)
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Account_Side_txt(Person_Id));

                if (Data.Count() != 0)
                {
                    foreach (string Find in Data)
                    {
                        Cmb.Items.Add(Find.Split(Paths.Split_Char)[0]);
                    }
                }

                else
                    Cmb.Text = "طرف حسابی ثبت نشده";
            }
            catch
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "عملیات بارگزاری اطلاعات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        private void Btn_Cancel2_Click(object sender, EventArgs e)
        {
            Close();
        }

        void Anty_Slash(object obj)
        {
            Telerik.WinControls.UI.RadTextBox Txt = (Telerik.WinControls.UI.RadTextBox)obj;

            if (Txt.Text.Contains("/"))
                Error_Sound();

            Txt.Text = Txt.Text.Replace(Paths.Split_Char.ToString(), "");
        }

        public void Error_Sound()
        {
            SystemSounds.Beep.Play();
        }

        void Anty_Slash_Cmb(object obj)
        {
            ComboBox Cmb = (ComboBox)obj;

            if (Cmb.Text.Contains("/"))
                Error_Sound();

            Cmb.Text = Cmb.Text.Replace(Paths.Split_Char.ToString(), "");
        }

        private void Btn_Apply2_Click(object sender, EventArgs e)
        {
            try
            {
                Remove_Bank_Account RBA = new Remove_Bank_Account();
                Result_Remove = RBA.Action(Person_Id, Account_Side, Banks_Name, Account_Bank_Name, Account_Number, Sheba, Card_Number, Card_Holder);

                Add_Bank_Accounts ADB = new Add_Bank_Accounts();
                Result_Add = ADB.Action(Person_Id, Cmb_Account_Side1.Text, Cmb_Banks_Name.Text, Cmb_Bank_Account.Text, Txt_Account_Number.Text, Txt_Sheba.Text, Txt_Card_Number.Text, Txt_Card_Holder.Text);

                if (Result_Add == "Try" && Result_Remove == "Try")
                {
                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                    popupNotifier2.Popup();

                    Close();
                }
                else
                    Catch(Result_Add, Result_Remove);
            }
            catch
            {
                Catch(Result_Add, Result_Remove);
            }
        }

        void Catch(string RA, string RR)
        {
            try
            {
                popupNotifier1.TitleText = "انجام نشد!";
                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                popupNotifier1.Popup();

                if (RA == "Try")
                {
                    Remove_Bank_Account RBA = new Remove_Bank_Account();
                    RBA.Action(Person_Id, Cmb_Account_Side1.Text, Cmb_Banks_Name.Text, Cmb_Banks_Name.Text, Txt_Account_Number.Text, Txt_Sheba.Text, Txt_Card_Number.Text, Txt_Card_Holder.Text);
                }

                if (RR == "Try")
                {
                    Add_Bank_Accounts ADB = new Add_Bank_Accounts();
                    ADB.Action(Person_Id, Cmb_Account_Side1.Text, Cmb_Banks_Name.Text, Cmb_Banks_Name.Text, Txt_Account_Number.Text, Txt_Sheba.Text, Txt_Card_Number.Text, Txt_Card_Holder.Text);
                }
            }
            catch { }
        }

        private void Txt_Card_Holder_TextChanged(object sender, EventArgs e)
        {
            Anty_Slash(sender);
        }

        private void Cmb_Bank_Account_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] Data = File.ReadAllLines(Paths.Bank_Account_txt(Person_Id));

            if (Cmb_Bank_Account.Text == "حساب بانکی")
            {
                Txt_Account_Number.Text = "";
                Txt_Sheba.Text = "";
                Txt_Sheba.Text = "";
                Txt_Card_Number.Text = "";
                Txt_Card_Holder.Text = "";

                return;
            }

            foreach (string Find in Data)
            {
                string Text = Cmb_Account_Side1.Text + Paths.Split_Char + Cmb_Banks_Name.Text + Paths.Split_Char + Txt_Account_Number.Text + Paths.Split_Char + Txt_Sheba.Text + Paths.Split_Char + Txt_Card_Number.Text + Paths.Split_Char + Txt_Card_Holder.Text;

                if (Find.Split(Paths.Split_Char)[0] == Cmb_Bank_Account.Text)
                {
                    Cmb_Banks_Name.Text = Find.Split(Paths.Split_Char)[1];
                    Txt_Account_Number.Text = Find.Split(Paths.Split_Char)[2];
                    Txt_Sheba.Text = Find.Split(Paths.Split_Char)[3];
                    Txt_Sheba.Text = Find.Split(Paths.Split_Char)[3];
                    Txt_Card_Number.Text = Find.Split(Paths.Split_Char)[4];
                    Txt_Card_Holder.Text = Find.Split(Paths.Split_Char)[5];
                }
            }
        }

        private void Cmb_Bank_Account_TextChanged(object sender, EventArgs e)
        {
            Anty_Slash_Cmb(sender);
        }

        void Anty_Slash_Cmb_Telerik(object obj)
        {
            Telerik.WinControls.UI.RadDropDownList Cmb = (Telerik.WinControls.UI.RadDropDownList)obj;

            if (Cmb.Text.Contains("/"))
                Error_Sound();

            Cmb.Text = Cmb.Text.Replace(Paths.Split_Char.ToString(), "");
        }

        private void Cmb_Banks_Name_TextChanged(object sender, EventArgs e)
        {
            Anty_Slash_Cmb_Telerik(sender);
        }
    }
}
