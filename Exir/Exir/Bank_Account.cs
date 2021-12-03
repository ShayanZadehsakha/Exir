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
    public partial class Bank_Account : Telerik.WinControls.UI.RadForm
    {
        string Person_Id = "";
        public Bank_Account(string Person_id)
        {
            InitializeComponent();

            Person_Id = Person_id;

                     popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            Form_Load();
        }

        void Form_Load()
        {
            if (!File.Exists(Paths.Bank_Account_User_txt(Person_Id)))
            {
                var a = File.Create(Paths.Bank_Account_User_txt(Person_Id));
                a.Close();
            }

            Cmb_Account_Bank.Items.Clear();
            Load_Accounts();

            Txt_Code.Text = "";
            Txt_Account_Number.Text = "";
            Txt_Card_Holder.Text = "";
            Txt_Card_Number.Text = "";
            Txt_Sheba.Text = "";
            Cmb_Banks_Name.Text = "";
            Cmb_Account_Bank.Text = "";
            Chk_Account_Card_Reader.Checked = false;
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

        void Load_Accounts()
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Bank_Account_User_txt(Person_Id));

                if (Data.Count() == 0)
                {
                    Cmb_Account_Bank.Items.Add("حساب بانکی در سیستم ثبت نشده");
                    return;
                }

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

        private void Btn_Check_Click(object sender, EventArgs e)
        {
            if(Cmb_Account_Bank.Text =="")
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "لطفا نام حساب بانکی را وارد کنید";
                popupNotifier1.Popup();

                return;
            }

            Add_Bank_Account_User ABAU = new Add_Bank_Account_User();
            string Result = ABAU.Action(Person_Id, Cmb_Account_Bank.Text, Cmb_Banks_Name.Text, Txt_Code.Text, Txt_Sheba.Text, Txt_Card_Holder.Text, Txt_Account_Number.Text, Txt_Card_Number.Text, Convert.ToInt32(Chk_Account_Card_Reader.Checked));

            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "حساب بانکی" + " " + Cmb_Account_Bank.Text + " " + "با موفقیت ثبت شد";
                    popupNotifier2.Popup();


                    Cmb_Account_Bank.Text = "";

                    break;

                case "Exists":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "حساب بانکی با این نام در سیستم وجود دارد";
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

        private void Cmb_Account_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Infos();
        }

     

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            Remove_Bank_Account_User RBAU = new Remove_Bank_Account_User();
            string Result = RBAU.Action(Person_Id, Cmb_Account_Bank.Text, Cmb_Banks_Name.Text, Txt_Code.Text, Txt_Sheba.Text, Txt_Card_Holder.Text, Txt_Account_Number.Text, Txt_Card_Number.Text, Convert.ToInt32(Chk_Account_Card_Reader.Checked));

            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "حساب بانکی" + " " + Cmb_Account_Bank.Text + " " + "با موفقیت حذف شد";
                    popupNotifier2.Popup();


                    Cmb_Account_Bank.Text = "";

                    break;

                case "N_Exists":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "طرف حسابی با این نام در سیستم وجود ندارد";
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

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            Hide();
            Edit_Bank_Account_User EBAU = new Edit_Bank_Account_User(Person_Id, Cmb_Account_Bank.Text, Cmb_Banks_Name.Text, Txt_Code.Text, Txt_Sheba.Text, Txt_Card_Holder.Text, Txt_Account_Number.Text, Txt_Card_Number.Text, Convert.ToInt32(Chk_Account_Card_Reader.Checked));
            EBAU.ShowDialog();
            Form_Load();
            Show();
        }

        private void anty_slash(object sender, EventArgs e)
        {
            Anty_Slash(sender);
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

        private void Cmb_Banks_Name_TextChanged(object sender, EventArgs e)
        {
            Anty_Slash_Cmb_Telerik(sender);
        }

        private void Cmb_Account_Bank_TextChanged(object sender, EventArgs e)
        {
            Anty_Slash_Cmb(sender);
        }

        void Anty_Slash_Cmb(object obj)
        {
            ComboBox Cmb = (ComboBox)obj;

            if (Cmb.Text.Contains("/"))
                Error_Sound();

            Cmb.Text = Cmb.Text.Replace(Paths.Split_Char.ToString(), "");
        }
    }
}