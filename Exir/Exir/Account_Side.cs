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
    public partial class Account_Side : Telerik.WinControls.UI.RadTabbedForm
    {
        string Person_Id = "";
        bool Check_Check_Box = true;

        public Account_Side(string person_id)
        {
            InitializeComponent();

            Person_Id = person_id;

            AllowAero = false;
            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            if (!File.Exists(Paths.Account_Side_txt(Person_Id)))
            {
                Create_File(Paths.Account_Side_txt(Person_Id));
            }

            Form_Load();

            Txt_Address.Text = "آدرس";
            Txt_Description.Text = "توضیحات";
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

        void Anty_Slash_Cmb_Telerik(object obj)
        {
            Telerik.WinControls.UI.RadDropDownList Cmb = (Telerik.WinControls.UI.RadDropDownList)obj;

            if (Cmb.Text.Contains("/"))
                Error_Sound();

            Cmb.Text = Cmb.Text.Replace(Paths.Split_Char.ToString(), "");
        }

        void Anty_Slash(object obj)
        {
            Telerik.WinControls.UI.RadTextBox Txt = (Telerik.WinControls.UI.RadTextBox)obj;

            if (Txt.Text.Contains("/"))
                Error_Sound();

            Txt.Text = Txt.Text.Replace(Paths.Split_Char.ToString(), "");
        }

        void Form_Load()
        {
            comboBox1.Items.Clear();
            Cmb_Account_Side1.Items.Clear();
            Cmb_Account_Side2.Items.Clear();

            Load_Cmb_Account_Side(comboBox1);
            Load_Cmb_Account_Side(Cmb_Account_Side1);
            Load_Cmb_Account_Side(Cmb_Account_Side2);

            if (comboBox1.Items.Count == 0)
                comboBox1.Items.Add("صورت حسابی ثبت نشده");

            if (Cmb_Account_Side1.Items.Count == 0)
                Cmb_Account_Side1.Items.Add("صورت حسابی ثبت نشده");

            if (Cmb_Account_Side2.Items.Count == 0)
                Cmb_Account_Side2.Items.Add("صورت حسابی ثبت نشده");

            radTextBox6.Text = "";
            radTextBox5.Text = "";
            radTextBox4.Text = "";
            radTextBox3.Text = "";

            radTextBox1.Text = "";
            radTextBox2.Text = "";

            Load_Cmbs_Info_Tab();
            Load_Data_Bank_Account();

            Cmb_Banks_Name.Text = "";
            Txt_Account_Number.Text = "";
            Txt_Card_Number.Text = "";
            Txt_Card_Holder.Text = "";
            Txt_Sheba.Text = "";
        }

        void Create_File(string Path)
        {
            var a = File.Create(Path);
            a.Close();
        }

        void Load_Cmbs_Info_Tab()
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Account_Side_txt(Person_Id));

                foreach (string Find in Data)
                {
                    if (Find.Split(Paths.Split_Char)[0] == comboBox1.Text)
                    {
                        if (!File.Exists(Paths.Address_Account_Side_txt(Person_Id, Find.Split(Paths.Split_Char)[0])))
                        {
                            Create_File(Paths.Address_Account_Side_txt(Person_Id, Find.Split(Paths.Split_Char)[0]));
                        }

                        if (!File.Exists(Paths.Description_Account_Side_txt(Person_Id, Find.Split(Paths.Split_Char)[0])))
                        {
                            Create_File(Paths.Description_Account_Side_txt(Person_Id, Find.Split(Paths.Split_Char)[0]));
                        }

                        radTextBox6.Text = Find.Split(Paths.Split_Char)[1];
                        radTextBox4.Text = Find.Split(Paths.Split_Char)[2];
                        radTextBox3.Text = Find.Split(Paths.Split_Char)[4];
                        radTextBox5.Text = Find.Split(Paths.Split_Char)[3];
                        radTextBox1.Text = File.ReadAllText(Paths.Address_Account_Side_txt(Person_Id, Find.Split(Paths.Split_Char)[0]));
                        radTextBox2.Text = File.ReadAllText(Paths.Description_Account_Side_txt(Person_Id, Find.Split(Paths.Split_Char)[0]));
                    }
                }
            }
            catch
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "عملیات بارگزاری اطلاعات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        void Load_Cmb_Account_Side(ComboBox Cmb)
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Account_Side_txt(Person_Id));

                if (Data != null)
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

        private void Cmb_Account_Side_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Cmbs_Info_Tab();
        }

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            Add_Account_Side AAS = new Add_Account_Side();
            string Result = AAS.Action(Person_Id, comboBox1.Text, radTextBox6.Text, radTextBox4.Text, radTextBox5.Text, radTextBox3.Text, Txt_Address.Text, Txt_Description.Text, "0", "0", "0");

            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "طرف حساب" + " " + comboBox1.Text + " " + "با موفقیت اضافه شد";
                    popupNotifier2.Popup();

                    break;

                case "Exists":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "طرف حسابی با این نام در سیستم وجود دارد";
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

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Remove_Account_Side RAS = new Remove_Account_Side();
            string Result = RAS.Action(Person_Id, comboBox1.Text, radTextBox6.Text, radTextBox4.Text, radTextBox5.Text, radTextBox3.Text, Txt_Address.Text, Txt_Description.Text);

            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "طرف حساب" + " " + comboBox1.Text + " " + "با موفقیت حذف شد";
                    popupNotifier2.Popup();

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
            Edit_Account_Side EAS = new Edit_Account_Side(Person_Id, comboBox1.Text, radTextBox6.Text, radTextBox4.Text, radTextBox5.Text, radTextBox3.Text, Txt_Address.Text, Txt_Description.Text, "0", "0", "0");
            EAS.ShowDialog();
            Form_Load();
        }

        private void Btn_Byer_Click(object sender, EventArgs e)
        {
            Checked_Check_Box(Chk_Byer);
        }

        void Checked_Check_Box(Telerik.WinControls.UI.RadCheckBox Chk)
        {
            if (Chk != Chk_All)
            {
                if (Chk.Checked)
                {
                    Chk_All.Checked = false;
                    Chk.Checked = false;
                }
                else
                {
                    Chk.Checked = true;

                    if (Chk_Byer.Checked && Chk_Seller.Checked && Chk_Intermediary.Checked)
                        Chk_All.Checked = true;
                }
            }

            else
            {
                if (!Chk_All.Checked)
                {
                    Chk_Byer.Checked = true;
                    Chk_Seller.Checked = true;
                    Chk_Intermediary.Checked = true;
                }

                else
                {
                    Chk_Byer.Checked = false;
                    Chk_Seller.Checked = false;
                    Chk_Intermediary.Checked = false;
                }
            }
        }

        private void Btn_Seller_Click(object sender, EventArgs e)
        {
            Checked_Check_Box(Chk_Seller);
        }

        private void Btn_Intermediary_Click(object sender, EventArgs e)
        {
            Checked_Check_Box(Chk_Intermediary);
        }

        private void anty_slash(object sender, EventArgs e)
        {
            Anty_Slash(sender);
        }

        private void anty_slash_cmb(object sender, EventArgs e)
        {
            Anty_Slash_Cmb(sender);
        }

        private void Btn_All_Click(object sender, EventArgs e)
        {
            Checked_Check_Box(Chk_All);
            Chk_All.Checked = !Chk_All.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Remove_Account_Side RAS = new Remove_Account_Side();
            string Result = RAS.Action(Person_Id, comboBox1.Text, radTextBox6.Text, radTextBox4.Text, radTextBox5.Text, radTextBox3.Text, radTextBox2.Text, radTextBox1.Text);

            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "طرف حساب" + " " + comboBox1.Text + " " + "با موفقیت حذف شد";
                    popupNotifier2.Popup();

                   comboBox1.Text = "";

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

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Edit_Account_Side EAS = new Edit_Account_Side(Person_Id, comboBox1.Text, radTextBox6.Text, radTextBox4.Text, radTextBox5.Text, radTextBox3.Text, radTextBox2.Text, radTextBox1.Text, "0", "0", "0");
            EAS.ShowDialog();
            Close();
            Form_Load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Bool_Byer = Convert.ToInt32(Chk_Byer.Checked);
            int Bool_Seller = Convert.ToInt32(Chk_Seller.Checked);
            int Bool_Intermediary = Convert.ToInt32(Chk_Intermediary.Checked);

            Add_Account_Side AAS = new Add_Account_Side();
            string Result = AAS.Action(Person_Id, comboBox1.Text, radTextBox6.Text, radTextBox4.Text, radTextBox5.Text, radTextBox3.Text, radTextBox2.Text, radTextBox1.Text, Bool_Byer.ToString(), Bool_Seller.ToString(), Bool_Intermediary.ToString());

            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "طرف حساب" + " " + Cmb_Account_Side.Text + " " + "با موفقیت اضافه شد";
                    popupNotifier2.Popup();


                    comboBox1.Text = "نام طرف حساب";

                    break;

                case "Exists":

                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "طرف حسابی با این نام و کد در سیستم وجود دارد";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Cmbs_Info_Tab();
        }

        private void Btn_Add_Bank_Acount_Click(object sender, EventArgs e)
        {
            Add_Bank_Accounts ADB = new Add_Bank_Accounts();
            string Result = ADB.Action(Person_Id, Cmb_Account_Side1.Text, Cmb_Banks_Name.Text, Cmb_Bank_Account.Text, Txt_Account_Number.Text, Txt_Sheba.Text, Txt_Card_Number.Text, Txt_Card_Holder.Text);

            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "حساب" + " " + Cmb_Bank_Account.Text + " " + "با موفقیت اضافه شد";
                    popupNotifier2.Popup();

                    Cmb_Bank_Account.Text = "حساب بانکی";
                    Cmb_Banks_Name.Text = "";
                    Txt_Account_Number.Text = "";
                    Txt_Sheba.Text = "";
                    Txt_Card_Holder.Text = "";
                    Txt_Card_Number.Text = "";

                    break;

                case "Exists":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "حسابی با این اطلاعات در سیستم وجود دارد";
                    popupNotifier1.Popup();

                    break;

                case "N_Exists":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "طرف حسابی با این نام در سیستم وجود دارد";
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

        private void Cmb_Account_Side1_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void Btn_Apply2_Click(object sender, EventArgs e)
        {
            Add_Bank_Account_Side ABA = new Add_Bank_Account_Side();
            string Result = ABA.Action(Person_Id, Cmb_Account_Side1.Text, Cmb_Bank_Account.Text);

            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                    popupNotifier2.Popup();

                    Cmb_Account_Side1.Text = "نام طرف حساب";
                    Cmb_Bank_Account.Text = "حساب بانکی";

                    break;

                case "Exists":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "حساب بانکی با این اطلاعات در سیستم وجود دارد";
                    popupNotifier1.Popup();

                    break;

                case "N_Exists":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "طرف حسابی با این نام در سیستم وجود ندارد";
                    popupNotifier1.Popup();

                    break;

                case "N_Exists_BA":

                    popupNotifier1.TitleText = "انجام نشد!";
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

        private void Btn_Cancel2_Click(object sender, EventArgs e)
        {
            Remove_Bank_Account_Side RBA = new Remove_Bank_Account_Side();
            string Result = RBA.Action(Person_Id, Cmb_Account_Side1.Text, Cmb_Bank_Account.Text);

            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                    popupNotifier2.Popup();

                    break;

                case "N_Exists_BA":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "حساب بانکی با این اطلاعات در سیستم وجود دارد";
                    popupNotifier1.Popup();

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

        private void Btn_Remove_Bank_Accont_Click(object sender, EventArgs e)
        {
            Remove_Bank_Account RBA = new Remove_Bank_Account();
            string Result = RBA.Action(Person_Id, Cmb_Account_Side1.Text, Cmb_Banks_Name.Text, Cmb_Bank_Account.Text, Txt_Account_Number.Text, Txt_Sheba.Text, Txt_Card_Number.Text, Txt_Card_Holder.Text);

            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "حساب" + " " + Cmb_Bank_Account.Text + " " + "با موفقیت اضافه شد";
                    popupNotifier2.Popup();

                    break;

                case "N_Exists_BA":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "حسابی با این اطلاعات در سیستم وجود ندارد";
                    popupNotifier1.Popup();

                    break;

                case "N_Exists_AS":

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

        private void Btn_Edit_Bank_Accont_Click(object sender, EventArgs e)
        {
            Hide();
            Edit_Bank_Account EBA = new Edit_Bank_Account(Person_Id, Cmb_Account_Side1.Text, Cmb_Banks_Name.Text, Txt_Account_Number.Text, Txt_Card_Number.Text, Txt_Sheba.Text, Txt_Card_Holder.Text, Cmb_Bank_Account.Text);
            EBA.ShowDialog();
            Show();
        }

        private void Chk_All_Click(object sender, EventArgs e)
        {
            Checked_Check_Box(Chk_All);
        }

        private void Chk_Seller_Click(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadCheckBox Chk = (Telerik.WinControls.UI.RadCheckBox)sender;
            Checked_Check_Box(Chk);

            Chk.Checked = !Chk.Checked;
        }

        private void Cmb_Account_Side2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chk_All.Checked = false;
            Chk_Seller.Checked = false;
            Chk_Byer.Checked = false;
            Chk_Intermediary.Checked = false;
            Load_Chks();
        }

        void Load_Chks()
        {
            string Account_Side = Cmb_Account_Side2.Text;

            string[] Data = File.ReadAllLines(Paths.Account_Side_txt(Person_Id));

            foreach (string Find in Data)
            {
                if (Find.Split(Paths.Split_Char)[0] == Account_Side)
                {
                    Chk_Seller.Checked = Convert.ToBoolean(Convert.ToInt32(Find.Split(Paths.Split_Char)[5]));
                    Chk_Byer.Checked = Convert.ToBoolean(Convert.ToInt32(Find.Split(Paths.Split_Char)[6]));
                    Chk_Intermediary.Checked = Convert.ToBoolean(Convert.ToInt32(Find.Split(Paths.Split_Char)[7]));
                }
            }

            if (Chk_Seller.Checked && Chk_Byer.Checked && Chk_Intermediary.Checked)
            {
                Chk_All.Checked = true;
            }
        }

        private void Btn_Apply1_Click(object sender, EventArgs e)
        {
            Add_Account_Side_SBI AASS = new Add_Account_Side_SBI();
            string Result = AASS.Action(Person_Id, Cmb_Account_Side2.Text, Convert.ToInt32(Chk_Seller.Checked), Convert.ToInt32(Chk_Byer.Checked), Convert.ToInt32(Chk_Intermediary.Checked));

            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                    popupNotifier2.Popup();

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

        private void Cmb_Banks_Name_TextChanged(object sender, EventArgs e)
        {
            Anty_Slash_Cmb_Telerik(sender);
        }
    }
}