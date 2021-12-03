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
    public partial class Edit_Bank_Account_User : Form
    {
        string Person_Id = "";
        string Name_Account = "";
        string Name_Bank = "";
        string Code = "";
        string Sheba = "";
        string Card_Holder = "";
        string Account_Number = "";
        string Card_Number = "";
        int Check = 0;

        public Edit_Bank_Account_User(string person_id, string name_account, string name_bank, string code, string sheba, string Card_holder, string account_number, string card_number, int check)
        {
            InitializeComponent();

            try
            {
                Person_Id = person_id;
                Name_Account = name_account;
                Name_Bank = name_bank;
                Code = code;
                Sheba = sheba;
                Card_Holder = Card_holder;
                Account_Number = account_number;
                Card_Number = card_number;
                Check = check;

                popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
                popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

                Cmb_Account_Bank.Text = name_account;
                Cmb_Banks_Name.Text = name_bank;
                Txt_Code.Text = code;
                Txt_Sheba.Text = sheba;
                Txt_Card_Holder.Text = Card_holder;
                Txt_Account_Number.Text = account_number;
                Txt_Card_Number.Text = card_number; 
                Chk_Account_Card_Reader.Checked = Convert.ToBoolean(Convert.ToInt32(check));

                Load_Accounts();
            }
            catch { }
        }

        private void Btn_Check_Click(object sender, EventArgs e)
        {
            try
            {
                Remove_Bank_Account_User RBAU = new Remove_Bank_Account_User();
                string Result_Remove = RBAU.Action(Person_Id, Name_Account, Name_Bank, Code, Sheba, Card_Holder, Account_Number, Card_Number, Check);

                Add_Bank_Account_User ABAU = new Add_Bank_Account_User();
                string Result_Add = ABAU.Action(Person_Id, Cmb_Account_Bank.Text, Cmb_Banks_Name.Text, Txt_Code.Text, Txt_Sheba.Text, Txt_Card_Holder.Text, Txt_Account_Number.Text, Txt_Card_Number.Text, Convert.ToInt32(Chk_Account_Card_Reader.Checked));

                if (Result_Add == "Try" && Result_Remove == "Try")
                {
                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                    popupNotifier2.Popup();

                    Close();
                }
                else
                {
                    if (Result_Add == "Try")
                    {
                        Remove_Bank_Account_User rbau = new Remove_Bank_Account_User();
                        rbau.Action(Person_Id, Cmb_Account_Bank.Text, Cmb_Banks_Name.Text, Txt_Code.Text, Txt_Sheba.Text, Txt_Card_Holder.Text, Txt_Account_Number.Text, Txt_Card_Number.Text, Convert.ToInt32(Chk_Account_Card_Reader.Checked));
                    }

                    if (Result_Remove == "Try")
                    {
                        Add_Bank_Account_User abau = new Add_Bank_Account_User();
                        abau.Action(Person_Id, Name_Account, Name_Bank, Code, Sheba, Card_Holder, Account_Number, Card_Number, Check);
                    }

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                    popupNotifier1.Popup();
                }
            }
            catch
            {
                popupNotifier1.TitleText = "انجام نشد!";
                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        void Load_Accounts()
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Bank_Account_User_txt(Person_Id));

                foreach (string Find in Data)
                {
                    Cmb_Account_Bank.Items.Add(Find.Split(Paths.Split_Char)[0]);
                }
            }
            catch
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "عملیات بارگزاری اطلاعات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        void Load_Infos()
        {
            string Item = Cmb_Account_Bank.Text;
            string[] Data = File.ReadAllLines(Paths.Bank_Account_User_txt(Person_Id));

            foreach (string Find in Data)
            {
                if (Find.Split(Paths.Split_Char)[0] == Item)
                {
                    Cmb_Banks_Name.Text = Find.Split(Paths.Split_Char)[1];
                    Txt_Code.Text = Find.Split(Paths.Split_Char)[2];
                    Txt_Sheba.Text = Find.Split(Paths.Split_Char)[3];
                    Txt_Card_Holder.Text = Find.Split(Paths.Split_Char)[4];
                    Txt_Account_Number.Text = Find.Split(Paths.Split_Char)[5];
                    Txt_Card_Number.Text = Find.Split(Paths.Split_Char)[6];
                    Chk_Account_Card_Reader.Checked = Convert.ToBoolean(Convert.ToInt32(Find.Split(Paths.Split_Char)[7]));
                }
            }
        }

        private void Cmb_Account_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Infos();
        }

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void anty_slash(object sender, EventArgs e)
        {
            Anty_Slash(sender);
        }

        void Anty_Slash_Cmb(object obj)
        {
            ComboBox Cmb = (ComboBox)obj;

            if (Cmb.Text.Contains("/"))
                Error_Sound();

            Cmb.Text = Cmb.Text.Replace(Paths.Split_Char.ToString(), "");
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

        void Anty_Slash_Cmb_Telerik(object obj)
        {
            Telerik.WinControls.UI.RadDropDownList Cmb = (Telerik.WinControls.UI.RadDropDownList)obj;

            if (Cmb.Text.Contains("/"))
                Error_Sound();

            Cmb.Text = Cmb.Text.Replace(Paths.Split_Char.ToString(), "");
        }

        private void anty_slash_cmb(object sender, EventArgs e)
        {
            Anty_Slash_Cmb(sender);
        }

        private void anty_slash_cmb_Telerik(object sender, EventArgs e)
        {
            Anty_Slash_Cmb_Telerik(sender);
        }
    }
}