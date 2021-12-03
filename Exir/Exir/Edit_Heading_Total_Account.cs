using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Exir
{
    public partial class Edit_Heading_Total_Account : Form
    {
        string Person_Id = "";
        string Name = "";
        string Code = "";

        private void Load()
        {
            string[] Data = File.ReadAllLines(Paths.Heading_Total_Account_Txt(Person_Id));

            foreach (string Find in Data)
            {
                Cmb_Accounts.Items.Add(Find.Split(Paths.Split_Char)[0]);
            }
        }

        public Edit_Heading_Total_Account(string person_id, string name, string code, bool Debtor, bool Creditor)
        {
            InitializeComponent();

            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            Chk_Debtor.Checked = Debtor;
            Chk_Creditor.Checked = Creditor;

            Cmb_Accounts.Text = name;

            Person_Id = person_id;
            Name = name;
            Code = code;
            Num_Code_Tot.Value = int.Parse(code);

            Load();
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            string[] Data = File.ReadAllLines(Paths.Heading_Code(Person_Id));

            if (!Chk_Creditor.Checked && !Chk_Debtor.Checked)
            {
                popupNotifier1.TitleText = "خطا!";
                popupNotifier1.ContentText = "لطفا ماهیت حساب را وارد کنید";
                popupNotifier1.Popup();

                return;
            }

            foreach (string Find_Code in Data)
            {
                if (Find_Code.Split(Paths.Split_Char)[0] == "Tot" && Find_Code.Split(Paths.Split_Char)[1] != Name && Find_Code.Split(Paths.Split_Char)[2] == Num_Code_Tot.Value.ToString())
                {
                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "حساب کلی با این کد در سیستم وجود دارد";
                    popupNotifier1.Popup();

                    return;
                }
            }

            Heading_Actions HA = new Heading_Actions();

            string Result = HA.Edit_Total_Account(Person_Id, Name, Cmb_Accounts.Text, Chk_Creditor.Checked.ToString(), Chk_Debtor.Checked.ToString(), Num_Code_Tot.Value.ToString());

            if (Result.Split('_')[0] == "A" && Result.Split('_')[1] == "Exists")
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "حساب کلی با این نام در سیستم وجود دارد";
                popupNotifier1.Popup();
            }

            else if (Result.Split('_')[1] == "catch")
            {
                popupNotifier1.TitleText = "انجام نشد";
                popupNotifier1.ContentText = "عمیات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }

            else
            {
                popupNotifier2.TitleText = "انجام شد";
                popupNotifier2.ContentText = "عمیات با موفقیت انجام شد";
                popupNotifier2.Popup();

                Close();
            }

            Load();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cmb_Accounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Total_Account_Type_Txt(Person_Id));

                foreach (string Find in Data)
                {
                    if (Find.Split(Paths.Split_Char)[0] == Cmb_Accounts.SelectedItem)
                    {
                        Chk_Creditor.Checked = Convert.ToBoolean(Find.Split(Paths.Split_Char)[0]);
                        Chk_Debtor.Checked = Convert.ToBoolean(Find.Split(Paths.Split_Char)[1]);
                    }

                    Fill_Num_Code();
                }
            }
            catch { }
        }

        private void Fill_Num_Code()
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Heading_Code(Person_Id));

                foreach (string Find in Data)
                {
                    if (Find.Split(Paths.Split_Char)[0] == "Tot" && Find.Split(Paths.Split_Char)[1] == Cmb_Accounts.Text)
                        Num_Code_Tot.Value = int.Parse(Find.Split(Paths.Split_Char)[2]);
                }
            }

            catch { }
        }
    }
}