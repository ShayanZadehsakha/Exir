using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Exir
{
    public partial class Edit_Account_Side : Form
    {
        string Person_Id;
        string Name_Account;
        string Code;
        string Home_Phone;
        string Email;
        string Mobile_Phone;
        string Address;
        string Description;
        string Bool_Byer;
        string Bool_Seller;
        string Bool_Intermediary;

        public Edit_Account_Side(string person_id, string name, string code, string home_phone, string email, string mobile_phone, string address, string description, string bool_byer, string bool_seller, string bool_intermediary)
        {
            InitializeComponent();

            Person_Id = person_id;
            Name_Account = name;
            Code = code;
            Home_Phone = home_phone;
            Email = email;
            Mobile_Phone = mobile_phone;
            Address = address;
            Description = description;
            Bool_Byer = bool_byer;
            Bool_Seller = bool_seller;
            Bool_Intermediary = bool_intermediary;
            
            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            Cmb_Account_Side.Text = name;

            Load_Data();
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

        void Anty_Slash(object obj)
        {
            Telerik.WinControls.UI.RadTextBox Txt = (Telerik.WinControls.UI.RadTextBox)obj;

            if (Txt.Text.Contains("/"))
                Error_Sound();

            Txt.Text = Txt.Text.Replace(Paths.Split_Char.ToString(), "");
        }

        void Load_Data()
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Account_Side_txt(Person_Id));

                foreach (string Find in Data)
                {
                    Cmb_Account_Side.Items.Clear();

                    if (Find.Split(Paths.Split_Char)[0] == Name_Account)
                    {
                        Paths.Address_Account_Side_txt(Person_Id, Find.Split(Paths.Split_Char)[0]);
                        Paths.Description_Account_Side_txt(Person_Id, Find.Split(Paths.Split_Char)[0]);

                        Cmb_Account_Side.Items.Add(Find.Split(Paths.Split_Char)[0]);

                        if (Find.Split(Paths.Split_Char)[0] == Cmb_Account_Side.Text)
                        {
                            Txt_Code.Text = Find.Split(Paths.Split_Char)[1];
                            Txt_Home_Phone.Text = Find.Split(Paths.Split_Char)[2];
                            Txt_Mobile_Phone.Text = Find.Split(Paths.Split_Char)[3];
                            Txt_Email.Text = Find.Split(Paths.Split_Char)[4];
                            Txt_Mobile_Phone.Text = Find.Split(Paths.Split_Char)[5];
                            Txt_Address.Text = File.ReadAllText(Paths.Address_Account_Side_txt(Person_Id, Find.Split(Paths.Split_Char)[0]));
                            Txt_Description.Text = File.ReadAllText(Paths.Description_Account_Side_txt(Person_Id, Find.Split(Paths.Split_Char)[0]));
                        }
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
        void Create_File(string Path)
        {
            var a = File.Create(Path);
            a.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cmb_Account_Side.Text == Name_Account && Txt_Code.Text == Code && Txt_Email.Text == Email && Txt_Home_Phone.Text == Home_Phone && Txt_Mobile_Phone.Text == Mobile_Phone && Txt_Address.Text == Address && Txt_Description.Text == Description)
                {
                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "حداقل یک فیلد باید تغییر کند";
                    popupNotifier1.Popup();
                }

                else if (Cmb_Account_Side.Text == "" || Txt_Code.Text == "" )
                {
                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "فیلد نام و کد نباید خالی باشد";
                    popupNotifier1.Popup();
                }

                else
                {
                    Remove_Account_Side RAS = new Remove_Account_Side();
                    string Remove_Result = RAS.Action(Person_Id, Name_Account, Code, Home_Phone, Email, Mobile_Phone, Address, Description);

                    Add_Account_Side AAS = new Add_Account_Side();
                    string Add_Result = AAS.Action(Person_Id, Cmb_Account_Side.Text, Txt_Code.Text, Txt_Home_Phone.Text, Txt_Email.Text, Txt_Mobile_Phone.Text, Txt_Address.Text, Txt_Description.Text, Bool_Byer, Bool_Seller, Bool_Intermediary);

                    if (Remove_Result == "Try" && Add_Result == "Try")
                    {
                        popupNotifier2.TitleText = "انجام شد!";
                        popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                        popupNotifier2.Popup();
                    }

                    else if (Add_Result == "Exists" && Remove_Result == "Try")
                    {
                        popupNotifier1.TitleText = "خطا!";
                        popupNotifier1.ContentText = "طرف حساب دیگری با این نام و کد در سیستم وجود دارد";
                        popupNotifier1.Popup();

                        Add_Account_Side Aas = new Add_Account_Side();
                        Aas.Action(Person_Id, Name_Account, Code, Home_Phone, Email, Mobile_Phone, Address, Description, Bool_Byer, Bool_Seller, Bool_Intermediary);
                    }

                    else
                    {
                        try
                        {
                            popupNotifier1.TitleText = "انجام نشد!";
                            popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                            popupNotifier1.Popup();

                            if (Remove_Result == "Try")
                            {
                                Add_Account_Side Aas = new Add_Account_Side();
                                Aas.Action(Person_Id, Name_Account, Code, Home_Phone, Email, Mobile_Phone, Address, Description, Bool_Byer, Bool_Seller, Bool_Intermediary);
                            }

                            if (Add_Result == "Try")
                            {
                                Remove_Account_Side Ras = new Remove_Account_Side();
                                Ras.Action(Person_Id, Cmb_Account_Side.Text, Txt_Code.Text, Txt_Home_Phone.Text, Txt_Email.Text, Txt_Mobile_Phone.Text, Txt_Address.Text, Txt_Description.Text);
                            }
                        }
                        catch
                        {
                            popupNotifier1.TitleText = "انجام نشد!";
                            popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                            popupNotifier1.Popup();
                        }
                    }
                }
            }
            catch
            {
                popupNotifier1.TitleText = "انجام نشد!";
                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        private void anty_slash_cmb(object sender, EventArgs e)
        {
            Anty_Slash_Cmb(sender);
        }

        private void antyslash(object sender, EventArgs e)
        {
            Anty_Slash(sender);
        }
    }
}
