using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Exir
{
    public partial class Edit_Heading_Defenite_Account : Form
    {
        string Person_Id = "";
        string Total_Account = "";
        string Defenite_Account = "";
        string Code = "";

        private void Refresh()
        {
            Cmb_Defenite_Account.Items.Clear();
            Cmb_Total_Account.Items.Clear();

            string[] Data = File.ReadAllLines(Paths.Heading_Total_Account_Txt(Person_Id));

            foreach (string Find in Data)
            {
                Cmb_Total_Account.Items.Add(Find.Split(Paths.Split_Char)[0]);

                if (Find.Split(Paths.Split_Char)[0] == Cmb_Total_Account.Text)
                {
                    int i = 0;

                    foreach (string Find2 in Find.Split(Paths.Split_Char))
                    {
                        i++;

                        if (i != 1)
                            Cmb_Defenite_Account.Items.Add(Find2);
                    }
                }
            }
        }

        public Edit_Heading_Defenite_Account(string person_id, string total_account, string defenite_account, string code)
        {
            InitializeComponent();

            Code = code;
            Num_Code_Def.Value = int.Parse(code);

            Person_Id = person_id;

            Refresh();

            Total_Account = total_account;
            Defenite_Account = defenite_account;

            Cmb_Total_Account.Text = total_account;
            Cmb_Defenite_Account.Text = defenite_account;

            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            string[] Data = File.ReadAllLines(Paths.Heading_Code(Person_Id));

            foreach (string Find_Code in Data)
            {
                if (Find_Code.Split(Paths.Split_Char)[0] == "Def" && Find_Code.Split(Paths.Split_Char)[1] == Cmb_Total_Account.Text && Find_Code.Split(Paths.Split_Char)[2] != Defenite_Account && Find_Code.Split(Paths.Split_Char)[3] == Num_Code_Def.Text)
                {
                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "حساب معینی با این کد در سیستم وجود دارد";
                    popupNotifier1.Popup();

                    return;
                }
            }

            Heading_Actions HA = new Heading_Actions();

            string Result = HA.Edit_Defenite_Account(Person_Id, Total_Account, Defenite_Account, Cmb_Defenite_Account.Text, Cmb_Total_Account.Text, Num_Code_Def.Value.ToString());

            if (Result.Split('_')[0] == "A" && Result.Split('_')[1] == "Exists")
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "حساب معینی با این نام در سیستم وجود دارد";
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

            Refresh();
        }

        private void Cmb_Total_Account_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] Data = File.ReadAllLines(Paths.Heading_Total_Account_Txt(Person_Id));

            Cmb_Defenite_Account.Text = "";
            Cmb_Defenite_Account.Items.Clear();

            foreach (string Find in Data)
            {
                if (Find.Split(Paths.Split_Char)[0] == Cmb_Total_Account.Text)
                {
                    foreach (string Find2 in Find.Split(Paths.Split_Char))
                    {
                        if (Find2 != Find.Split(Paths.Split_Char)[0])
                            Cmb_Defenite_Account.Items.Add(Find2);
                    }
                }
            }

            string[] Data_Code = File.ReadAllLines(Paths.Heading_Code(Person_Id));

            foreach (string Find in Data_Code)
            {
                if (Find.Split(Paths.Split_Char)[0] == "Tot" && Find.Split(Paths.Split_Char)[1] == Cmb_Total_Account.Text)
                    Lbl_Code_Def.Text = Find.Split(Paths.Split_Char)[2] + '/';
            }
        }

        private void Cmb_Total_Account_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}