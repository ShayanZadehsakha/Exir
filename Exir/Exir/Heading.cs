using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Exir
{
    public partial class Heading : RadForm
    {
        RadButton Btn = new RadButton();
        Heading_Actions HA = new Heading_Actions();

        Color Color_Btn = Color.FromArgb(255, 232, 207);
        Color Color_Btn2 = Color.FromArgb(227, 93, 59);

        string Person_Id = "";
        string Result = "";

        int i = 0;

        public Heading(string person_id)
        {
            InitializeComponent();

            Person_Id = person_id;

            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            Size = new Size(808, 380);

            Btn_Total_Account.BackColor = Color_Btn;

            Btn_Total_Account_Click(Btn_Total_Account, null);

            Load();
        }

        private void Load_Detail()
        {
            string[] Data = File.ReadAllLines(Paths.Heading_Total_Account_Txt(Person_Id));

            Cmb_Total_Account_Det.Items.Clear();
            Cmb_Definite_Account.Items.Clear();
            Cmb_Detail_Account_Det.Items.Clear();

            foreach (string Find in Data)
            {
                Cmb_Total_Account_Det.Items.Add(Find.Split(Paths.Split_Char)[0]);

                if (Find.Split(Paths.Split_Char)[0] == Cmb_Total_Account_Det.Text)
                {
                    int i = 0;

                    foreach (string Find2 in Find.Split(Paths.Split_Char))
                    {
                        i++;

                        if (i != 1 && !Cmb_Defenite_Account_Det.Items.Contains(Find2))
                            Cmb_Defenite_Account_Det.Items.Add(Find2);

                        if (Cmb_Defenite_Account_Det.Text == Find2)
                        {
                            string[] Data2 = File.ReadAllLines(Paths.Heading_Detail_Txt(Person_Id, Find.Split(Paths.Split_Char)[0], Find2));

                            foreach (string Find3 in Data2)
                            {
                                if (!Cmb_Detail_Account_Det.Items.Contains(Find3))
                                    Cmb_Detail_Account_Det.Items.Add(Find3);
                            }
                        }
                    }
                }
            }
        }

        private void Load()
        {
            string[] Data = File.ReadAllLines(Paths.Heading_Total_Account_Txt(Person_Id));
            string[] Data_Code = File.ReadAllLines(Paths.Heading_Code(Person_Id));

            Dgb_Def.Rows.Clear();
            Dgb_Det.Rows.Clear();
            Dgb_Tot.Rows.Clear();

            Cmb_Definite_Account.Items.Clear();
            Cmb_Defenite_Account_Det.Items.Clear();
            Cmb_Detail_Account_Det.Items.Clear();
            Cmb_Tot.Items.Clear();
            Cmb_Total_Account.Items.Clear();
            Cmb_Total_Account_Det.Items.Clear();

            if (Btn_Total_Account.BackColor == Color_Btn)
            {
                foreach (string Find in Data_Code)
                {
                    if (Find.Split(Paths.Split_Char)[0] == "Tot")
                    {
                        Dgb_Tot.Rows.Add(Find.Split(Paths.Split_Char)[1], Find.Split(Paths.Split_Char)[2]);
                        Cmb_Tot.Items.Add(Find.Split(Paths.Split_Char)[1]);
                    }
                }
            }

            else if (Btn_Definite_Account.BackColor == Color_Btn)
            {
                Dgb_Def.Rows.Clear();

                foreach (string Find in Data)
                {
                    i = 0;

                    foreach (string Find2 in Find.Split(Paths.Split_Char))
                    {
                        i++;

                        if (i != 1)
                        {
                            string tot = null;
                            string def = null;

                            if (Cmb_Total_Account.Text == "")
                            {
                                tot = Find.Split(Paths.Split_Char)[0];
                                def = Find2;
                            }

                            else if (Find.Split(Paths.Split_Char)[0] == Cmb_Total_Account.Text)
                            {
                                tot = Find.Split(Paths.Split_Char)[0];
                                def = Find2;
                            }

                            string Code_def = "";

                            if (tot != null && def != null)
                            {
                                foreach (string Find3 in File.ReadAllLines(Paths.Heading_Code(Person_Id)))
                                {
                                    if (Find3.Split(Paths.Split_Char)[0] == "Tot" && Find3.Split(Paths.Split_Char)[1] == tot)
                                        Code_def = Find3.Split(Paths.Split_Char)[2] + '/';
                                }

                                foreach (string Find3 in File.ReadAllLines(Paths.Heading_Code(Person_Id)))
                                {
                                    if (Find3.Split(Paths.Split_Char)[0] == "Def" && Find3.Split(Paths.Split_Char)[1] == tot && Find3.Split(Paths.Split_Char)[2] == def)
                                        Code_def += Find3.Split(Paths.Split_Char)[3];
                                }

                                bool Exist = true;

                                if (Dgb_Def.Rows.Count != 0)
                                {
                                    for (int i = 0; i < Dgb_Def.Rows.Count; i++)
                                    {
                                        if (Dgb_Def.Rows[i].Cells[0].Value == tot && Dgb_Def.Rows[i].Cells[1].Value == def && Dgb_Def.Rows[i].Cells[2].Value == Code_def)
                                            Exist = false;
                                    }
                                }

                                if (Exist)
                                    Dgb_Def.Rows.Add(tot, def, Code_def);
                            }
                        }
                    }

                    Cmb_Total_Account.Items.Add(Find.Split(Paths.Split_Char)[0]);
                    Cmb_Total_Account.Text = "";

                    Cmb_Definite_Account.Text = "لطفا حساب کل را انتخاب کنید";
                }
            }
            else
            {
                Load_Detail();
                Load_Dgb_Detail();
            }
        }

        private void Load_Dgb_Detail()
        {
            Dgb_Det.Rows.Clear();

            string[] Data_Total = File.ReadAllLines(Paths.Heading_Total_Account_Txt(Person_Id));

            foreach (string Find in Data_Total)
            {
                int i = 0;

                foreach (string Find_Split in Find.Split(Paths.Split_Char))
                {
                    i++;

                    if (i != 1)
                    {
                        string tot = null;
                        string def = null;
                        string det = null;
                        string Code_det = "";
                        bool Tot = false;
                        bool Def = false;

                        foreach (string Fill in File.ReadAllLines(Paths.Heading_Detail_Txt(Person_Id, Find.Split(Paths.Split_Char)[0], Find_Split)))
                        {
                            tot = Find.Split(Paths.Split_Char)[0];
                            def = Find_Split;
                            det = Fill;

                            if (tot != null && def != null && det != null)
                            {
                                foreach (string Find2 in File.ReadAllLines(Paths.Heading_Code(Person_Id)))
                                {
                                    if (Find2.Split(Paths.Split_Char)[0] == "Tot" && Find2.Split(Paths.Split_Char)[1] == tot)
                                    {
                                        Tot = true;
                                        Code_det = Find2.Split(Paths.Split_Char)[2] + '/';
                                    }

                                    if (Tot && Find2.Split(Paths.Split_Char)[0] == "Def" && Find2.Split(Paths.Split_Char)[1] == tot && Find2.Split(Paths.Split_Char)[2] == def)
                                    {
                                        Def = true;
                                        Code_det += Find2.Split(Paths.Split_Char)[3] + '/';
                                    }

                                    if (Def && Find2.Split(Paths.Split_Char)[0] == "Det" && Find2.Split(Paths.Split_Char)[1] == tot && Find2.Split(Paths.Split_Char)[2] == def && Find2.Split(Paths.Split_Char)[3] == det)
                                        Code_det += Find2.Split(Paths.Split_Char)[4];
                                }

                                Dgb_Det.Rows.Add(tot, def, det, Code_det);
                            }
                        }
                    }
                }
            }
        }

        private void Set_Code(RadButton Btn)
        {
            string[] Data = File.ReadAllLines(Paths.Heading_Code(Person_Id));

            decimal Code = 10000;

            bool Check = false;

            switch (Btn.Name)
            {
                case "Btn_Total_Account":

                    while (Check)
                    {
                        foreach (string Find in Data)
                        {
                            if (Find.Split(Paths.Split_Char)[0] == "Tot" && Find.Split(Paths.Split_Char)[2] == Code.ToString())
                                Check = true;
                        }

                        Code++;
                    }

                    Num_Code_Tot.Value = Code;

                    break;

                case "Btn_Definite_Account":

                    Code = 999;

                    foreach (string Find in Data)
                    {
                        if (Find.Split(Paths.Split_Char)[0] == "Def" && Find.Split(Paths.Split_Char)[1] == Cmb_Total_Account.Text && int.Parse(Find.Split(Paths.Split_Char)[3]) > Code)
                            Code = decimal.Parse(Find.Split(Paths.Split_Char)[3]);
                    }

                    Num_Code_Def.Value = Code + 1;

                    break;

                case "Btn_Detailed_Account":

                    Code = 99;

                    foreach (string Find in Data)
                    {
                        if (Find.Split(Paths.Split_Char)[0] == "Det" && Find.Split(Paths.Split_Char)[1] == Cmb_Total_Account.Text && Find.Split(Paths.Split_Char)[2] == Cmb_Definite_Account.Text && int.Parse(Find.Split(Paths.Split_Char)[4]) > Code)
                            Code = decimal.Parse(Find.Split(Paths.Split_Char)[4]);
                    }

                    Num_Code_Det.Value = Code + 1;

                    break;
            }
        }

        private void Open_Panel()
        {
            if (Btn_Total_Account.BackColor == Color_Btn)
            {
                Pnl_Def.Hide();
                Pnl_Det.Hide();
                Pnl_Tot.Show();
            }

            else if (Btn_Definite_Account.BackColor == Color_Btn)
            {
                Pnl_Tot.Hide();
                Pnl_Det.Hide();
                Pnl_Def.Location = Pnl_Tot.Location;
                Pnl_Def.Show();
            }

            else
            {
                Pnl_Tot.Hide();
                Pnl_Def.Hide();
                Pnl_Det.Location = Pnl_Tot.Location;
                Pnl_Det.Show();
                Load();
            }
        }

        private void Btn_Total_Account_Click(object sender, EventArgs e)
        {
            Btn = (RadButton)sender;

            if (Btn.BackColor == Color_Btn2)
            {
                Btn.BackColor = Color_Btn;

                if (Btn != Btn_Total_Account)
                    Btn_Total_Account.BackColor = Color_Btn2;

                if (Btn != Btn_Definite_Account)
                    Btn_Definite_Account.BackColor = Color_Btn2;

                if (Btn != Btn_Detailed_Account)
                    Btn_Detailed_Account.BackColor = Color_Btn2;
            }

            Set_Code(Btn);

            Open_Panel();
            Load();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label Lbl = (Label)sender;

            if (Lbl == Lbl_Total_Account)
                Btn_Total_Account_Click(Btn_Total_Account, null);

            else if (Lbl == Lbl_Detailed_Account)
                Btn_Total_Account_Click(Btn_Detailed_Account, null);

            else
                Btn_Total_Account_Click(Btn_Definite_Account, null);
        }

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            string[] Data = File.ReadAllLines(Paths.Heading_Code(Person_Id));

            if (Btn_Total_Account.BackColor == Color_Btn)
            {
                if (Cmb_Tot.Text == "")
                {
                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "لطفا نام حساب کل را وارد کنید";
                    popupNotifier1.Popup();

                    return;
                }

                if (!Chk_Creditor.Checked && !Chk_Debtor.Checked)
                {
                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "لطفا ماهیت حساب را وارد کنید";
                    popupNotifier1.Popup();

                    return;
                }

                foreach (string Find_Code in Data)
                {
                    if (Find_Code.Split(Paths.Split_Char)[0] == "Tot" && Find_Code.Split(Paths.Split_Char)[1] != Cmb_Tot.Text && Find_Code.Split(Paths.Split_Char)[2] == Num_Code_Tot.Value.ToString())
                    {
                        popupNotifier1.TitleText = "خطا!";
                        popupNotifier1.ContentText = "حساب کلی با این کد در سیستم وجود دارد";
                        popupNotifier1.Popup();

                        return;
                    }
                }

                Result = HA.Add_Total_Account(Cmb_Tot.Text, Person_Id, Chk_Creditor.Checked.ToString(), Chk_Debtor.Checked.ToString(), Num_Code_Tot.Value.ToString());

                if (Result == "Exists")
                {
                    popupNotifier1.TitleText = "تکراری است";
                    popupNotifier1.ContentText = "حساب کل بااین نام در سیستم وجود دارد";
                    popupNotifier1.Popup();
                }

                else if (Result == "catch")
                {
                    popupNotifier1.TitleText = "انجام نشد";
                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                    popupNotifier1.Popup();
                }

                else
                {
                    popupNotifier2.TitleText = "انجام شد";
                    popupNotifier2.ContentText = "حساب کل  " + Cmb_Tot.Text + "با موفقیت اضافه شد";
                    popupNotifier2.Popup();
                }
            }

            else if (Btn_Definite_Account.BackColor == Color_Btn)
            {
                if (Cmb_Definite_Account.Text == "")
                {
                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "لطفا نام حساب معین را وارد کنید";
                    popupNotifier1.Popup();

                    return;
                }

                foreach (string Find_Code in Data)
                {
                    if (Find_Code.Split(Paths.Split_Char)[0] == "Def" && Find_Code.Split(Paths.Split_Char)[1] == Cmb_Total_Account.Text && Find_Code.Split(Paths.Split_Char)[2] != Cmb_Definite_Account.Text && Find_Code.Split(Paths.Split_Char)[3] == Num_Code_Def.Text)
                    {
                        popupNotifier1.TitleText = "خطا!";
                        popupNotifier1.ContentText = "حساب معینی با این کد در سیستم وجود دارد";
                        popupNotifier1.Popup();

                        return;
                    }
                }

                Result = HA.Add_Defenite_Account(Cmb_Total_Account.Text, Person_Id, Cmb_Definite_Account.Text, Num_Code_Def.Value.ToString());

                if (Result == "Exists")
                {
                    popupNotifier1.TitleText = "تکراری است";
                    popupNotifier1.ContentText = "حساب معین با این نام در سیستم وجود دارد";
                    popupNotifier1.Popup();
                }

                else if (Result == "catch")
                {
                    popupNotifier1.TitleText = "انجام نشد";
                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                    popupNotifier1.Popup();
                }

                else
                {
                    popupNotifier2.TitleText = "انجام شد";
                    popupNotifier2.ContentText = "حساب معین  " + Cmb_Definite_Account.Text + "با موفقیت اضافه شد";
                    popupNotifier2.Popup();
                }
            }

            else
            {
                foreach (string Find_Code in Data)
                {
                    if (Cmb_Detail_Account_Det.Text == "")
                    {
                        popupNotifier1.TitleText = "خطا!";
                        popupNotifier1.ContentText = "لطفا نام حساب تفصیلی را وارد کنید";
                        popupNotifier1.Popup();

                        return;
                    }

                    if (Find_Code.Split(Paths.Split_Char)[0] == "Det" && Find_Code.Split(Paths.Split_Char)[1] == Cmb_Total_Account_Det.Text && Find_Code.Split(Paths.Split_Char)[2] == Cmb_Defenite_Account_Det.Text && Find_Code.Split(Paths.Split_Char)[3] != Cmb_Detail_Account_Det.Text && Find_Code.Split(Paths.Split_Char)[4] == Num_Code_Det.Text)
                    {
                        popupNotifier1.TitleText = "خطا!";
                        popupNotifier1.ContentText = "حساب تفصیلی با این کد در سیستم وجود دارد";
                        popupNotifier1.Popup();

                        return;
                    }
                }

                Result = HA.Add_Account_Detailed(Cmb_Detail_Account_Det.Text, Person_Id, Cmb_Total_Account_Det.Text, Cmb_Defenite_Account_Det.Text, Num_Code_Det.Value.ToString());

                if (Result == "Exists")
                {
                    popupNotifier1.TitleText = "تکراری است";
                    popupNotifier1.ContentText = "حساب تفصیلی با این نام در سیستم وجود دارد";
                    popupNotifier1.Popup();
                }

                else if (Result == "catch")
                {
                    popupNotifier1.TitleText = "انجام نشد";
                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                    popupNotifier1.Popup();
                }

                else
                {
                    popupNotifier2.TitleText = "انجام شد";
                    popupNotifier2.ContentText = "حساب تفصیلی  " + Cmb_Detail_Account_Det.Text + "با موفقیت اضافه شد";
                    popupNotifier2.Popup();
                }
            }

            Cmb_Definite_Account.Text = "";
            Cmb_Total_Account.Text = "";
            Cmb_Detail_Account_Det.Text = "";
            Cmb_Defenite_Account_Det.Text = "";
            Cmb_Total_Account_Det.Text = "";

            Load();
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btn_Total_Account.BackColor == Color_Btn)
                {
                    if (Dgb_Tot.SelectedRows[0].Cells[0].Value != null)
                    {
                        string Selected_Account = Dgb_Tot.SelectedRows[0].Cells[0].Value.ToString();

                        Edit_Heading_Total_Account EHTA = new Edit_Heading_Total_Account(Person_Id, Selected_Account, Num_Code_Tot.Value.ToString(), Chk_Debtor.Checked, Chk_Creditor.Checked);
                        EHTA.ShowDialog();
                    }
                }

                else if (Btn_Definite_Account.BackColor == Color_Btn)
                {
                    Cmb_Definite_Account.Text = Dgb_Def.SelectedRows[0].Cells[1].Value.ToString();

                    Edit_Heading_Defenite_Account EHDA = new Edit_Heading_Defenite_Account(Person_Id, Cmb_Total_Account.Text, Cmb_Definite_Account.Text, Num_Code_Def.Value.ToString());
                    EHDA.ShowDialog();
                }

                else
                {
                    Edit_Heading_Detailed EHD = new Edit_Heading_Detailed(Person_Id, Cmb_Total_Account_Det.Text, Cmb_Defenite_Account_Det.Text, Cmb_Detail_Account_Det.Text, Num_Code_Det.Value.ToString());
                    EHD.ShowDialog();

                    Btn_Total_Account_Click(Btn_Detailed_Account, null);
                }

                Cmb_Total_Account.Text = "";
                Dgb_Def.Rows.Clear();
                Load();
            }
            catch
            {
                popupNotifier1.TitleText = "انجام نشد";
                popupNotifier1.ContentText = "عمیات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            if (Btn_Total_Account.BackColor == Color_Btn)
            {
                if (Dgb_Tot.SelectedRows[0].Cells[0].Value != null)
                {
                    string Selected_Account = Dgb_Tot.SelectedRows[0].Cells[0].Value.ToString();

                    Result = HA.Remove_Total_Account(Selected_Account, Person_Id);

                    if (Result == "Try")
                    {
                        popupNotifier2.TitleText = "انجام شد";
                        popupNotifier2.ContentText = "حساب کل " + Selected_Account + " با موفقیت حذف شد";
                        popupNotifier2.Popup();
                    }

                    else
                    {
                        popupNotifier1.TitleText = "انجام نشد";
                        popupNotifier1.ContentText = "عمیات با مشکل مواجه شد";
                        popupNotifier1.Popup();
                    }
                }
            }

            else if (Btn_Definite_Account.BackColor == Color_Btn)
            {
                if (Dgb_Def.SelectedRows[0].Cells[0].Value != null)
                {
                    string Selected_Account = Dgb_Def.SelectedRows[0].Cells[0].Value.ToString();

                    Result = HA.Remove_Defenite_Account(Selected_Account, Person_Id, Cmb_Definite_Account.Text);

                    if (Result == "Try")
                    {
                        popupNotifier2.TitleText = "انجام شد";
                        popupNotifier2.ContentText = "حساب معین " + Selected_Account + " با موفقیت حذف شد";
                        popupNotifier2.Popup();
                    }

                    else
                    {
                        popupNotifier1.TitleText = "انجام نشد";
                        popupNotifier1.ContentText = "عمیات با مشکل مواجه شد";
                        popupNotifier1.Popup();
                    }
                }
            }

            else
            {
                if (Dgb_Det.SelectedRows[0].Cells[0].Value != null)
                {
                    string Selected_Account = Dgb_Det.SelectedRows[0].Cells[0].Value.ToString();

                    Result = HA.Remove_Detailed_Account(Selected_Account, Person_Id, Cmb_Defenite_Account_Det.Text, Cmb_Detail_Account_Det.Text);

                    if (Result == "Try")
                    {
                        popupNotifier2.TitleText = "انجام شد";
                        popupNotifier2.ContentText = "حساب تفصیلی " + Selected_Account + " با موفقیت حذف شد";
                        popupNotifier2.Popup();
                    }

                    else
                    {
                        popupNotifier1.TitleText = "انجام نشد";
                        popupNotifier1.ContentText = "عمیات با مشکل مواجه شد";
                        popupNotifier1.Popup();
                    }
                }
            }

            Load();
        }

        private void Dgb_Tot_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string Select = Dgb_Tot.SelectedRows[0].Cells[0].Value.ToString();
                Cmb_Tot.Text = Select;

                string[] Data = File.ReadAllLines(Paths.Total_Account_Type_Txt(Person_Id));

                foreach (string Find in Data)
                {
                    if (Find.Split(Paths.Split_Char)[0] == Select)
                    {
                        Chk_Creditor.Checked = Convert.ToBoolean(Find.Split(Paths.Split_Char)[1]);

                        Chk_Debtor.Checked = Convert.ToBoolean(Find.Split(Paths.Split_Char)[2]);
                    }
                }
            }

            catch { }
        }

        private void Dgb_Det_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (Dgb_Det.SelectedRows != null)
                {
                    Cmb_Total_Account_Det.Text = Dgb_Det.SelectedRows[0].Cells[0].Value.ToString();

                    Cmb_Defenite_Account_Det.Text = Dgb_Det.SelectedRows[0].Cells[1].Value.ToString();
                    Cmb_Detail_Account_Det.Text = Dgb_Det.SelectedRows[0].Cells[2].Value.ToString();
                }
            }

            catch { }
        }

        private void Cmb_Total_Account_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Heading_Total_Account_Txt(Person_Id));

                foreach (string Find in Data)
                {
                    if (Find.Split(Paths.Split_Char)[0] == Cmb_Total_Account.Text)
                    {
                        i = 0;

                        Cmb_Definite_Account.Items.Clear();
                        Cmb_Definite_Account.Text = "";

                        foreach (string Find2 in Find.Split(Paths.Split_Char))
                        {
                            i++;

                            if (i != 1)
                                Cmb_Definite_Account.Items.Add(Find2);
                        }

                        if (Cmb_Definite_Account.Items.Count == 0)
                            Cmb_Definite_Account.Items.Add("حساب معینی برای این حساب کل وجود ندارد ");
                    }
                }

                Fill_Num_Codes("Def");
            }

            catch { }
        }

        private void Cmb_Total_Account_Det_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Heading_Total_Account_Txt(Person_Id));

                foreach (string Find in Data)
                {
                    if (Find.Split(Paths.Split_Char)[0] == Cmb_Total_Account_Det.Text)
                    {
                        Cmb_Detail_Account_Det.Items.Clear();

                        bool Exists_Item = false;

                        foreach (string item in Cmb_Total_Account_Det.Items)
                        {
                            if (item == Find.Split(Paths.Split_Char)[0])
                                Exists_Item = true;
                        }

                        if (!Exists_Item)
                            Cmb_Total_Account_Det.Items.Add(Find.Split(Paths.Split_Char)[0]);

                        int i = 0;

                        if (Find.Split(Paths.Split_Char).Length == 1)
                            Cmb_Defenite_Account_Det.Items.Clear();

                        else
                        {
                            foreach (string Find2 in Find.Split(Paths.Split_Char))
                            {
                                i++;
                                bool Exists_Items = false;

                                if (i != 1)
                                {
                                    foreach (string Item in Cmb_Defenite_Account_Det.Items)
                                    {
                                        foreach (string item in Find.Split(Paths.Split_Char))
                                        {
                                            if (Item == item)
                                            {
                                                Exists_Items = true;
                                            }
                                        }
                                    }

                                    if (!Exists_Items)
                                        Cmb_Defenite_Account_Det.Items.Clear();

                                    Exists_Item = false;

                                    if (Cmb_Definite_Account.Items.Count != 0)
                                    {
                                        foreach (string item in Cmb_Defenite_Account_Det.Items)
                                        {
                                            if (item == Find2)
                                                Exists_Item = true;
                                        }

                                        if (!Exists_Item)
                                        {
                                            i = 0;

                                            for (int j = 0; j < Cmb_Defenite_Account_Det.Items.Count; j++)
                                            {
                                                i++;

                                                if (i != 1 && !Cmb_Defenite_Account_Det.Items.Contains(Find2))
                                                    Cmb_Defenite_Account_Det.Items.Add(Find2);
                                            }
                                        }
                                    }

                                    else if (!Cmb_Defenite_Account_Det.Items.Contains(Find2))
                                        Cmb_Defenite_Account_Det.Items.Add(Find2);

                                    if (Cmb_Defenite_Account_Det.Text == Find2)
                                    {
                                        string[] Data2 = File.ReadAllLines(Paths.Heading_Detail_Txt(Person_Id, Find.Split(Paths.Split_Char)[0], Find2));

                                        foreach (string Find3 in Data2)
                                        {
                                            if (!Cmb_Detail_Account_Det.Items.Contains(Find3))
                                                Cmb_Detail_Account_Det.Items.Add(Find3);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    Cmb_Defenite_Account_Det.Text = "";

                    Fill_Num_Codes("Det");
                }
            }

            catch { }
        }

        private void Fill_Num_Codes(string Type)
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Heading_Code(Person_Id));
                bool Exists = false;

                switch (Type)
                {
                    case "Tot":

                        foreach (string Find in Data)
                        {
                            if (Find.Split(Paths.Split_Char)[0] == "Tot" && Find.Split(Paths.Split_Char)[1] == Cmb_Tot.Text)
                            {
                                Num_Code_Tot.Value = int.Parse(Find.Split(Paths.Split_Char)[2]);
                                Exists = true;
                            }
                        }

                        if (!Exists)
                            Set_Code(Btn_Total_Account);

                        break;

                    case "Def":

                        Lbl_Code_Def.Text = "";

                        foreach (string Find in Data)
                        {
                            if (Find.Split(Paths.Split_Char)[0] == "Tot" && Find.Split(Paths.Split_Char)[1] == Cmb_Total_Account.Text)
                                Lbl_Code_Def.Text += Find.Split(Paths.Split_Char)[2] + '/';

                            if (Find.Split(Paths.Split_Char)[0] == "Def" && Find.Split(Paths.Split_Char)[1] == Cmb_Total_Account.Text && Find.Split(Paths.Split_Char)[2] == Cmb_Definite_Account.Text)
                            {
                                Num_Code_Def.Value = int.Parse(Find.Split(Paths.Split_Char)[3]);
                                Exists = true;
                            }
                        }

                        if (!Exists)
                            Set_Code(Btn_Definite_Account);

                        break;

                    case "Det":

                        Lbl_Code_Det.Text = "";

                        foreach (string Find in Data)
                        {
                            if (Find.Split(Paths.Split_Char)[0] == "Tot" && Find.Split(Paths.Split_Char)[1] == Cmb_Total_Account_Det.Text)
                                Lbl_Code_Det.Text += Find.Split(Paths.Split_Char)[2] + '/';

                            if (Find.Split(Paths.Split_Char)[0] == "Def" && Find.Split(Paths.Split_Char)[1] == Cmb_Total_Account_Det.Text && Find.Split(Paths.Split_Char)[2] == Cmb_Defenite_Account_Det.Text)
                                Lbl_Code_Det.Text += Find.Split(Paths.Split_Char)[3] + '/';

                            if (Find.Split(Paths.Split_Char)[0] == "Det" && Find.Split(Paths.Split_Char)[1] == Cmb_Total_Account_Det.Text && Find.Split(Paths.Split_Char)[2] == Cmb_Defenite_Account_Det.Text && Find.Split(Paths.Split_Char)[3] == Cmb_Detail_Account_Det.Text)
                            {
                                Num_Code_Det.Value = int.Parse(Find.Split(Paths.Split_Char)[4]);
                                Exists = true;
                            }
                        }


                        if (!Exists)
                            Set_Code(Btn_Detailed_Account);

                        break;
                }
            }

            catch { }
        }

        private void Cmb_Definite_Account_Det_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Heading_Detail_Txt(Person_Id, Cmb_Total_Account_Det.Text, Cmb_Defenite_Account_Det.Text));

                foreach (string Find in Data)
                {
                    if (!Cmb_Detail_Account_Det.Items.Contains(Find))
                        Cmb_Detail_Account_Det.Items.Add(Find);
                }

                Fill_Num_Codes("Det");
            }

            catch { }
        }

        private void Cmb_Detail_Account_Det_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Num_Codes("Det");
        }

        private void Cmb_Definite_Account_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Num_Codes("Def");
        }

        private void Cmb_Tot_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Num_Codes("Tot");
        }

        private void Num_Code_Tot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Num_Code_Det_ValueChanging(object sender, EventArgs e)
        {

        }

        private void Total_Account_Det_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            Cmb_Total_Account_Det_SelectedIndexChanged(sender, e);
        }

        private void Tot_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            Cmb_Tot_SelectedIndexChanged(sender, e);
        }

        private void Drp_Defenite_Account_Det_TextChanged(object sender, EventArgs e)
        {
            Cmb_Definite_Account_Det_SelectedIndexChanged(sender, e);
        }

        private void Tot_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Num_Codes("Tot");
        }

        private void Cmb_Defenite_Account_Det_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Heading_Detail_Txt(Person_Id, Cmb_Total_Account_Det.Text, Cmb_Defenite_Account_Det.Text));

                foreach (string Find in Data)
                {
                    if (!Cmb_Detail_Account_Det.Items.Contains(Find))
                        Cmb_Detail_Account_Det.Items.Add(Find);
                }

                Fill_Num_Codes("Det");
            }

            catch { }
        }

        private void Cmb_Total_Account_Det_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Heading_Total_Account_Txt(Person_Id));

                foreach (string Find in Data)
                {
                    if (Find.Split(Paths.Split_Char)[0] == Cmb_Total_Account_Det.Text)
                    {
                        Cmb_Defenite_Account_Det.Text = "";
                        Cmb_Detail_Account_Det.Text = "";

                        Cmb_Detail_Account_Det.Items.Clear();

                        bool Exists_Item = false;

                        foreach (string item in Cmb_Total_Account_Det.Items)
                        {
                            if (item == Find.Split(Paths.Split_Char)[0])
                                Exists_Item = true;
                        }

                        if (!Exists_Item)
                            Cmb_Total_Account_Det.Items.Add(Find.Split(Paths.Split_Char)[0]);

                        int i = 0;

                        Cmb_Defenite_Account_Det.Items.Clear();

                        foreach (string Find2 in Find.Split(Paths.Split_Char))
                        {
                            i++;

                            bool Exists_Items = false;

                            if (i != 1)
                            {
                                foreach (string Item in Cmb_Defenite_Account_Det.Items)
                                {
                                    foreach (string item in Find.Split(Paths.Split_Char))
                                    {
                                        if (Item == item)
                                        {
                                            Exists_Items = true;
                                        }
                                    }
                                }

                                if (Cmb_Definite_Account.Items.Count != 0)
                                {
                                    foreach (string item in Cmb_Defenite_Account_Det.Items)
                                    {
                                        if (item == Find2)
                                            Exists_Item = true;
                                    }

                                    if (!Exists_Item)
                                    {
                                        Cmb_Defenite_Account_Det.Items.Add(Find2);
                                    }
                                }

                                else if (!Cmb_Defenite_Account_Det.Items.Contains(Find2))
                                    Cmb_Defenite_Account_Det.Items.Add(Find2);

                                if (Cmb_Defenite_Account_Det.Text == Find2)
                                {
                                    string[] Data2 = File.ReadAllLines(Paths.Heading_Detail_Txt(Person_Id, Find.Split(Paths.Split_Char)[0], Find2));

                                    foreach (string Find3 in Data2)
                                    {
                                        if (!Cmb_Detail_Account_Det.Items.Contains(Find3))
                                            Cmb_Detail_Account_Det.Items.Add(Find3);
                                    }
                                }
                            }
                        }
                    }

                    Cmb_Defenite_Account_Det.Text = "";

                    Fill_Num_Codes("Det");
                }
            }

            catch { }
        }

        private void Dgb_Def_SelectionChanged(object sender, GridViewCellEventArgs e)
        {
            try
            {
                Cmb_Total_Account.Text = Dgb_Def.SelectedRows[0].Cells[0].Value.ToString();
                Cmb_Definite_Account.Text = Dgb_Def.SelectedRows[0].Cells[1].Value.ToString();
            }

            catch { }
        }
    }
}