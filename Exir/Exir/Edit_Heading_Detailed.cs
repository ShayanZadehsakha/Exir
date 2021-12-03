using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Exir
{
    public partial class Edit_Heading_Detailed : Form
    {
        string Person_Id = "";
        string Total_Account = "";
        string Defenite_Account = "";
        string Detailed_Account = "";
        string Code = "";

        int i = 0;

        private void Load()
        {
            Cmb_Accounts.Items.Clear();
            Cmb_Defenite_Account.Items.Clear();
            Cmb_Detailed_Account.Items.Clear();

            string[] Data = File.ReadAllLines(Paths.Heading_Total_Account_Txt(Person_Id));

            foreach (string Find in Data)
            {
                Cmb_Accounts.Items.Add(Find.Split(Paths.Split_Char)[0]);

                if (Find.Split(Paths.Split_Char)[0] == Cmb_Accounts.Text)
                {
                    int i = 0;

                    foreach (string Find2 in Find.Split(Paths.Split_Char))
                    {
                        i++;

                        if (i != 1)
                            Cmb_Defenite_Account.Items.Add(Find2);

                        if (Cmb_Detailed_Account.Text == Find2)
                        {
                            string[] Data2 = File.ReadAllLines(Paths.Heading_Detail_Txt(Person_Id, Find, Find2));

                            foreach (string Find3 in Data2)
                            {
                                Cmb_Detailed_Account.Items.Add(Find3);
                            }
                        }
                    }
                }
            }
        }

        public Edit_Heading_Detailed(string person_id, string total_account, string defenite_account, string detailed_account, string code)
        {
            InitializeComponent();

            Person_Id = person_id;

            Load();

            Total_Account = total_account;
            Defenite_Account = defenite_account;
            Detailed_Account = detailed_account;
            Code = code;

            Cmb_Accounts.Text = total_account;
            Cmb_Defenite_Account.Text = defenite_account;
            Cmb_Detailed_Account.Text = detailed_account;
            Num_Code_Det.Value = int.Parse(code);

            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            Cmb_Accounts.SelectedIndexChanged += new EventHandler(Cmb_Accounts_SelectedIndexChanged);
            Cmb_Detailed_Account.SelectedIndexChanged += new EventHandler(Cmb_Accounts_SelectedIndexChanged);
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            string[] Data = File.ReadAllLines(Paths.Heading_Code(Person_Id));

            foreach (string Find_Code in Data)
            {
                if (Find_Code.Split(Paths.Split_Char)[0] == "Det" && Find_Code.Split(Paths.Split_Char)[1] == Cmb_Accounts.Text && Find_Code.Split(Paths.Split_Char)[2] == Cmb_Defenite_Account.Text && Find_Code.Split(Paths.Split_Char)[3] != Cmb_Detailed_Account.Text && Find_Code.Split(Paths.Split_Char)[4] == Num_Code_Det.Text)
                {
                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "حساب تفصیلی با این کد در سیستم وجود دارد";
                    popupNotifier1.Popup();

                    return;
                }
            }

            Heading_Actions HA = new Heading_Actions();

            string Result = HA.Edit_Detailed_Account(Person_Id, Total_Account, Defenite_Account, Cmb_Defenite_Account.Text, Cmb_Accounts.Text, Detailed_Account, Cmb_Detailed_Account.Text, Num_Code_Det.Value.ToString());

            if (Result.Split('_')[0] == "A" && Result.Split('_')[1] == "Exists")
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "حساب تفصیلی با این نام در سیستم وجود دارد";
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

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cmb_Accounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] Data = File.ReadAllLines(Paths.Heading_Total_Account_Txt(Person_Id));

            foreach (string Find in Data)
            {
                if (Find.Split(Paths.Split_Char)[0] == Cmb_Accounts.Text)
                {
                    i = 0;

                    Cmb_Defenite_Account.Items.Clear();
                    Cmb_Defenite_Account.Text = "";

                    foreach (string Find2 in Find.Split(Paths.Split_Char))
                    {
                        i++;

                        if (i != 1)
                            Cmb_Defenite_Account.Items.Add(Find2);
                    }

                    if (Cmb_Defenite_Account.Items.Count == 0)
                        Cmb_Defenite_Account.Items.Add("حساب معینی برای این حساب کل وجود ندارد ");
                }
            }
        }

        private void Cmb_Defenite_Account_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] Data = File.ReadAllLines(Paths.Heading_Detail_Txt(Person_Id, Cmb_Accounts.Text, Cmb_Defenite_Account.Text));

            Cmb_Detailed_Account.Items.Clear();

            foreach (string Find in Data)
            {
                Cmb_Detailed_Account.Items.Add(Find);
            }

            if (Data.Length == 0)
                Cmb_Detailed_Account.Text = "";
        }
    }
}