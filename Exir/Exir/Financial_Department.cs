using CEWorld.Convert;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Exir
{
    public partial class Financial_Department : RadTabbedForm
    {
        string Person_Id = "";
        int Price = 0;

        public Financial_Department(string person_id)
        {
            InitializeComponent();

            AllowAero = false;
            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            Person_Id = person_id;

            Form_Load();
        }

        void Form_Load()
        {
            if (!File.Exists(Paths.Bank_Account_User_txt(Person_Id)))
            {
                var a = File.Create(Paths.Bank_Account_User_txt(Person_Id));
                a.Close();
            }

            if (!File.Exists(Paths.Checks_Txt(Person_Id)))
            {
                var a = File.Create(Paths.Checks_Txt(Person_Id));
                a.Close();
            }

            if (!File.Exists(Paths.Cash_Desk_txt(Person_Id)))
            {
                var a = File.Create(Paths.Cash_Desk_txt(Person_Id));
                a.Close();
            }

            if (!File.Exists(Paths.Account_Side_txt(Person_Id)))
            {
                var a = File.Create(Paths.Account_Side_txt(Person_Id));
                a.Close();
            }

            Cmb_Account_Side_Payment.Items.Clear();
            Cmb_Account_Side_Recive.Items.Clear();

            Cmb_Bank_Account_Payment.Items.Clear();
            Cmb_Bank_Account_Recive.Items.Clear();

            Cmb_Cash_Cmb_Recive.Items.Clear();
            Cmb_Cash_Payment.Items.Clear();

            Cmb_Bank_Account_Recive.Items.Clear();
            Cmb_Bank_Account_Payment.Items.Clear();

            Cmb_Check_Payment.Items.Clear();

            Txt_Price_Deposit.Text = "";
            Txt_Price_Payment.Text = "";
            Txt_Price_Recive.Text = "";
            Txt_Bank_Account_Price_Payment.Text = "";

            Txt_Bank_Account_Price_Payment.Text = "";

            Txt_Check_Price_Payment.Text = "";

            Cmb_Account_Side_Recive.Text = "";
            Cmb_Account_Side_Payment.Text = "";

            Cmb_Cash_Payment.Text = "";
            Cmb_Cash_Cmb_Recive.Text = "";

            Cmb_Bank_Account_Payment.Text = "";
            Cmb_Bank_Account_Recive.Text = "";

            Cmb_Check_Payment.Text = "";

            Load_Cmb_Account_Side(Cmb_Account_Side_Payment);
            Load_Cmb_Account_Side(Cmb_Account_Side_Recive);

            Load_Cmb_Cash_Desk(Cmb_Cash_Payment);
            Load_Cmb_Cash_Desk(Cmb_Cash_Cmb_Recive);

            Load_Cmb_Bank_Account(Cmb_Bank_Account_Payment);
            Load_Cmb_Bank_Account(Cmb_Bank_Account_Recive);
            Load_Cmb_Bank_Account(Cmb_Origin_Deposit);
            Load_Cmb_Bank_Account(Cmb_Destination_Deposit);

            Load_Cmb_Check(Cmb_Check_Payment);
        }

        void Load_Cmb_Check(ComboBox Cmb)
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Checks_Txt(Person_Id));

                if (Data.Count() == 0)
                    Cmb.Items.Add("چکی در سیستم ثبت نشده");

                else
                {
                    foreach (string Find in Data)
                    {
                        if (Find.Split(Paths.Split_Char)[8] == Cmb_Account_Side_Payment.Text)
                            Cmb.Items.Add(Find.Split(Paths.Split_Char)[0]);
                    }

                    if (Cmb.Items.Count == 0)
                        Cmb.Items.Add("چکی در سیستم ثبت نشده");
                }
            }
            catch
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "عملیات بارگزاری اطلاعات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        void Load_Cmb_Bank_Account(ComboBox Cmb)
        {
            try
            {
                Cmb.Items.Clear();

                string[] Data = File.ReadAllLines(Paths.Bank_Account_User_txt(Person_Id));

                foreach (string Find in Data)
                {
                    Cmb.Items.Add(Find.Split(Paths.Split_Char)[0]);
                }
            }
            catch
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "عملیات بارگزاری اطلاعات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        void Load_Cmb_Cash_Desk(ComboBox Cmb)
        {
            try
            {
                if (!File.Exists(Paths.Cash_Desk_txt(Person_Id)))
                {
                    var a = File.Create(Paths.Cash_Desk_txt(Person_Id));
                    a.Close();
                }

                string[] Data = File.ReadAllLines(Paths.Cash_Desk_txt(Person_Id));

                if (Data.Count() == 0)
                    Cmb.Items.Add("صندوقی در سیستم ثبت نشده");

                foreach (string Find in Data)
                {
                    Cmb.Items.Add(Find);
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
                if (!File.Exists(Paths.Account_Side_txt(Person_Id)))
                {
                    var a = File.Create(Paths.Account_Side_txt(Person_Id));
                    a.Close();
                }

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

        private void Btn_Cash_Desk(object sender, EventArgs e)
        {
            Hide();
            Cash_Desk CD = new Cash_Desk(Person_Id);
            CD.ShowDialog();
            Show();

            Form_Load();
        }

        private void Btn_Bank_Account(object sender, EventArgs e)
        {
            Hide();
            Bank_Account BA = new Bank_Account(Person_Id);
            BA.ShowDialog();
            Show();

            Form_Load();
        }

        private void Load_Price()
        {
            if (Txt_Bank_Account_Price_Payment.Text.Replace(",", "").Replace(",", "") != "")
            {
                Price += Convert.ToInt32(Txt_Bank_Account_Price_Payment.Text.Replace(",", "").Replace(",", ""));
            }

            if (Txt_Bank_Account_Price_Payment.Text.Replace(",", "").Replace(",", "") != "")
            {
                Price += Convert.ToInt32(Txt_Bank_Account_Price_Payment.Text.Replace(",", "").Replace(",", ""));
            }

            if (Txt_Check_Price_Payment.Text.Replace(",", "").Replace(",", "") != "")
            {
                Price += Convert.ToInt32(Txt_Check_Price_Payment.Text.Replace(",", "").Replace(",", ""));
            }
        }

        private void Load_Price_Recive()
        {
            if (Txt_Price_Cash_Desk_Recive.Text.Replace(",", "").Replace(",", "").Replace(",", "") != "")
            {
                Price += Convert.ToInt32(Txt_Price_Cash_Desk_Recive.Text.Replace(",", "").Replace(",", "").Replace(",", ""));
            }

            if (Txt_Price_Bank_Account_Recive.Text.Replace(",", "").Replace(",", "") != "")
            {
                Price += Convert.ToInt32(Txt_Price_Bank_Account_Recive.Text.Replace(",", "").Replace(",", ""));
            }
        }

        private void Btn_Apply_Payment_Click(object sender, EventArgs e)
        {
            try
            {
                int Stock = 0;

                Price = 0;

                Load_Price();

                if (Price != Convert.ToInt32(Txt_Price_Payment.Text.Replace(",", "").Replace(",", "")))
                {
                    popupNotifier1.TitleText = "خطا";
                    popupNotifier1.ContentText = "موجودی حساب پرداختی با مبلغ پرداختی مطابقت ندارد";
                    popupNotifier1.Popup();

                    return;
                }

                Financial F = new Financial();

                string Find_AC = F.Stock(Person_Id, "AS", Cmb_Account_Side_Payment.Text);

                switch (Find_AC)
                {
                    case null:

                        popupNotifier1.TitleText = "خطا";
                        popupNotifier1.ContentText = "طرف حسابی با این نام در سیستم وجود ندارد";
                        popupNotifier1.Popup();

                        Form_Load();

                        return;

                    case "Negative":

                        popupNotifier1.TitleText = "خطا";
                        popupNotifier1.ContentText = "موجودی حساب پرداختی با مبلغ پرداختی مطابقت ندارد";
                        popupNotifier1.Popup();

                        Form_Load();

                        return;

                    case "catch":

                        popupNotifier1.TitleText = "خطا";
                        popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                        popupNotifier1.Popup();

                        Form_Load();

                        return;
                }

                string Add_AC = F.Add(Person_Id, "AS", Cmb_Account_Side_Payment.Text, (Convert.ToInt32(Find_AC.Split(Paths.Split_Char)[2]) + Convert.ToInt32(Txt_Price_Payment.Text.Replace(",", "").Replace(",", ""))).ToString());

                if (Add_AC != "Try")
                {
                    popupNotifier1.TitleText = "خطا";
                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                    popupNotifier1.Popup();

                    Form_Load();
                }

                if (Cmb_Cash_Payment.Text != "")
                {
                    string Find_CD = F.Stock(Person_Id, "CD", Cmb_Cash_Payment.Text);

                    switch (Find_CD)
                    {
                        case null:

                            popupNotifier1.TitleText = "خطا";
                            popupNotifier1.ContentText = "صندوقی با این نام در سیستم وجود ندارد";
                            popupNotifier1.Popup();

                            Form_Load();

                            return;

                        case "catch":

                            popupNotifier1.TitleText = "خطا";
                            popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                            popupNotifier1.Popup();

                            Form_Load();

                            return;
                    }

                    Stock = Convert.ToInt32(Find_CD.Split(Paths.Split_Char)[2]) - Convert.ToInt32(Txt_Bank_Account_Price_Payment.Text.Replace(",", "").Replace(",", ""));
                    string Result_CD = F.Add(Person_Id, "CD", Cmb_Cash_Payment.Text, Stock.ToString());

                    switch (Result_CD)
                    {
                        case "Negative":

                            popupNotifier1.TitleText = "خطا!";
                            popupNotifier1.ContentText = "موجودی صندوق کمتر از مبلغ پرداختی است";
                            popupNotifier1.Popup();

                            Form_Load();

                            return;

                        case "catch":

                            popupNotifier1.TitleText = "انجام نشد!";
                            popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                            popupNotifier1.Popup();

                            Form_Load();

                            return;
                    }
                }

                if (Cmb_Bank_Account_Payment.Text != "")
                {
                    string Find_BA = F.Stock(Person_Id, "BA", Cmb_Bank_Account_Payment.Text);

                    switch (Find_BA)
                    {
                        case null:

                            popupNotifier1.TitleText = "خطا";
                            popupNotifier1.ContentText = "طرف حسابی با این نام در سیستم وجود ندارد";
                            popupNotifier1.Popup();

                            Form_Load();

                            return;

                        case "catch":

                            popupNotifier1.TitleText = "خطا";
                            popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                            popupNotifier1.Popup();

                            Form_Load();

                            return;
                    }

                    Stock = Convert.ToInt32(Find_BA.Split(Paths.Split_Char)[2]) - Convert.ToInt32(Txt_Bank_Account_Price_Payment.Text.Replace(",", "").Replace(",", ""));
                    string Result_BA = F.Add(Person_Id, "BA", Cmb_Bank_Account_Payment.Text, Stock.ToString());
                }

                if (Cmb_Check_Payment.Text != "")
                {
                    string[] Data = File.ReadAllLines(Paths.Checks_Txt(Person_Id));
                    string Read_Check = "";

                    foreach (string Find in Data)
                    {
                        if (Find.Split(Paths.Split_Char)[0] == Cmb_Check_Payment.Text)
                            Read_Check = Find;
                    }

                    string Find_CH = F.Stock(Person_Id, "CH", Cmb_Check_Payment.Text);
                    string Find_BA = F.Stock(Person_Id, "BA", Read_Check.Split(Paths.Split_Char)[4]);

                    Remove_Check RCC = new Remove_Check();

                    int Stock_Add_BA = Convert.ToInt32(Find_BA.Split(Paths.Split_Char)[2]) - Convert.ToInt32(Txt_Check_Price_Payment.Text.Replace(",", "").Replace(",", ""));
                    int Stock_Add_AS = Convert.ToInt32(Find_BA.Split(Paths.Split_Char)[2]) + Convert.ToInt32(Txt_Check_Price_Payment.Text.Replace(",", "").Replace(",", ""));

                    if (Stock_Add_BA < 0)
                    {
                        popupNotifier1.TitleText = "انجام نشد";
                        popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                        popupNotifier1.Popup();

                        Form_Load();

                        return;
                    }

                    string Remove_CH_Checks = RCC.Action(Person_Id, Cmb_Check_Payment.Text);

                    string Add_BA = F.Add(Person_Id, "BA", Find_BA.Split(Paths.Split_Char)[1], Stock_Add_BA.ToString());

                    if (Add_BA != "Try" || Remove_CH_Checks != "Try")
                    {
                        popupNotifier1.TitleText = "انجام نشد";
                        popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                        popupNotifier1.Popup();

                        Form_Load();

                        return;
                    }
                }

                popupNotifier2.TitleText = "انجام شد";
                popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                popupNotifier2.Popup();

                Form_Load();
            }

            catch
            {
                try
                {
                    popupNotifier1.TitleText = "انجام نشد";
                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                    popupNotifier1.Popup();

                    Form_Load();
                }
                catch { }
            }
        }

        private void Btn_Apply_Deposit_Click(object sender, EventArgs e)
        {
            try
            {
                Financial F = new Financial();

                string Origin_Stock = F.Stock(Person_Id, "BA", Cmb_Origin_Deposit.Text).Split(Paths.Split_Char)[2];
                string Destination_Stock = F.Stock(Person_Id, "BA", Cmb_Destination_Deposit.Text).Split(Paths.Split_Char)[2];

                if (Origin_Stock == "catch" || Origin_Stock == null || Destination_Stock == "catch" || Destination_Stock == null)
                {
                    popupNotifier1.TitleText = "انجام نشد";
                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                    popupNotifier1.Popup();
                }

                int Stock = Convert.ToInt32(Txt_Price_Deposit.Text.Replace(",", "").Replace(",", ""));

                string Add_Origin = F.Add(Person_Id, "BA", Cmb_Origin_Deposit.Text, (Convert.ToInt32(Origin_Stock) - Stock).ToString());
                string Add_Destination = F.Add(Person_Id, "BA", Cmb_Destination_Deposit.Text, (Convert.ToInt32(Destination_Stock) + Stock).ToString());

                if (Add_Origin == "Try" && Add_Destination == "Try")
                {
                    popupNotifier2.TitleText = "انجام شد";
                    popupNotifier2.ContentText = "عملیات با موفقیت مواجه شد";
                    popupNotifier2.Popup();
                }

                else
                {
                    popupNotifier1.TitleText = "انجام نشد";
                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                    popupNotifier1.Popup();
                }
            }
            catch { }
        }

        private void Btn_Check(object sender, EventArgs e)
        {
            Hide();
            Add_Check AC = new Add_Check(Person_Id, "P");
            AC.ShowDialog();
            Show();

            Form_Load();
        }

        private void Cmb_Check_Payment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Financial F = new Financial();

                ComboBox Cmb = (ComboBox)sender;

                if (Cmb == Cmb_Check_Payment)
                    Txt_Check_Price_Payment.Text = F.Stock(Person_Id, "CH", Cmb_Check_Payment.Text).Split(Paths.Split_Char)[2];

                if (Cmb == Cmb_Account_Side_Payment)
                    Txt_Check_Price_Payment.Text = F.Stock(Person_Id, "AC", Cmb.Text).Split(Paths.Split_Char)[2];
            }
            catch { }
        }

        private string Find_Work(ComboBox Cmb, RadTextBox Txt)
        {
            try
            {
                if (Txt == null)
                {
                    if (Cmb == Cmb_Cash_Payment)
                        return "CD";

                    if (Cmb == Cmb_Bank_Account_Payment)
                        return "BA";

                    if (Cmb == Cmb_Check_Payment)
                        return "CH";

                    if (Cmb == Cmb_Cash_Cmb_Recive)
                        return "CD";

                    if (Cmb == Cmb_Bank_Account_Recive)
                        return "BA";

                    if (Cmb == Cmb_Origin_Deposit)
                        return "BA";

                    if (Cmb == Cmb_Destination_Deposit)
                        return "BA";
                }
                else
                {
                    if (Txt == Txt_Cash_Price_Payment)
                        return "CD";

                    if (Txt == Txt_Bank_Account_Price_Payment)
                        return "BA";

                    if (Txt == Txt_Check_Price_Payment)
                        return "CH";

                    if (Txt == Txt_Price_Cash_Desk_Recive)
                        return "CD";

                    if (Txt == Txt_Price_Bank_Account_Recive)
                        return "BA";
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        private void Load_Price_Payment(ComboBox Cmb, RadTextBox Txt, RadTextBox Txt_Price, string Work)
        {
            try
            {
                string Text = Cmb.Text;

                Financial F = new Financial();

                int Stock = Convert.ToInt32(F.Stock(Person_Id, Work, Text).Split(Paths.Split_Char)[2]);

                Price = 0;

                if (Txt_Price.Text == "")
                    Txt_Price.Text = "0";

                if (Convert.ToInt32(Txt_Price.Text) != Price)
                {
                    int Price_For_Value = Convert.ToInt32(Txt_Price.Text) - Price;

                    Txt.Text = "";

                    if (Stock >= Price_For_Value)
                    {
                        Txt.Text = Price_For_Value.ToString();
                    }

                    else
                    {
                        Txt.Text = Stock.ToString();
                    }
                }
                else
                {
                    Txt.Text = Stock.ToString();
                }

                if (Txt_Price.Text == "0")
                    Txt_Price.Text = "";
            }
            catch { }
        }

        private void Txt_Price_Text_Changed(object sender)
        {
            RadTextBox Txt = (RadTextBox)sender;

            if (Txt == Txt_Price_Deposit)
            {
                Text_Cahnged(Cmb_Origin_Deposit, Txt, "BA");

                return;
            }

            ComboBox Cmb = Find_Cmb_Payment(Txt);

            Text_Cahnged(Cmb, Txt, Find_Work(Cmb, Txt));
        }

        private void Txt_Cash_Price_Payment_TextChanged(object sender, EventArgs e)
        {
            Txt_Price_Text_Changed(sender);
            Separate_Texts.Separatea(sender);
        }

        private ComboBox Find_Cmb_Payment(RadTextBox Txt)
        {
            try
            {
                if (Txt == Txt_Cash_Price_Payment)
                    return Cmb_Cash_Payment;

                if (Txt == Txt_Bank_Account_Price_Payment)
                    return Cmb_Bank_Account_Payment;

                if (Txt == Txt_Check_Price_Payment)
                    return Cmb_Check_Payment;

                if (Txt == Txt_Price_Cash_Desk_Recive)
                    return Cmb_Cash_Cmb_Recive;

                if (Txt == Txt_Price_Bank_Account_Recive)
                    return Cmb_Bank_Account_Recive;

                return null;
            }
            catch
            {
                return null;
            }
        }

        private void Text_Cahnged(ComboBox Cmb, RadTextBox Txt, string Work)
        {
            try
            {
                if (Cmb.Text != "")
                {
                    Financial F = new Financial();

                    int Stock = Convert.ToInt32(F.Stock(Person_Id, Work, Cmb.Text).Split(Paths.Split_Char)[2]);

                    if (Convert.ToInt32(Txt.Text) >= Stock)
                    {
                        if (Txt.Text != Stock.ToString() || Convert.ToInt32(Txt.Text) > Stock)
                        {
                            if (Txt.Name.Contains("Recive"))
                                Load_Price_Payment(Cmb, Txt, Txt_Price_Recive, Find_Work(Cmb, null));

                            else
                                Load_Price_Payment(Cmb, Txt, Txt_Price_Payment, Find_Work(Cmb, null));

                            popupNotifier1.Delay = 1000;

                            popupNotifier1.TitleText = "خطا";
                            popupNotifier1.ContentText = "مبلغ وارد شده بالاتر از موجودی صندوق است";
                            popupNotifier1.Popup();

                            popupNotifier1.Delay = 3000;
                        }
                    }
                }
            }
            catch { }
        }

        private void Btn_Apply_Recive_Click(object sender, EventArgs e)
        {
            try
            {
                Price = 0;

                Load_Price_Recive();

                if (Price != Convert.ToInt32(Txt_Price_Recive.Text.Replace(",", "").Replace(",", "")))
                {
                    popupNotifier1.TitleText = "خطا";
                    popupNotifier1.ContentText = "موجودی حساب پرداختی با مبلغ پرداختی مطابقت ندارد";
                    popupNotifier1.Popup();

                    return;
                }

                Financial F = new Financial();

                string Find_AS = F.Stock(Person_Id, "AS", Cmb_Account_Side_Recive.Text);

                switch (Find_AS)
                {
                    case null:

                        popupNotifier1.TitleText = "خطا";
                        popupNotifier1.ContentText = "طرف حسابی با این نام در سیستم وجود ندارد";
                        popupNotifier1.Popup();

                        Form_Load();

                        return;

                    case "Negative":

                        popupNotifier1.TitleText = "خطا";
                        popupNotifier1.ContentText = "موجودی حساب پرداختی با مبلغ پرداختی مطابقت ندارد";
                        popupNotifier1.Popup();

                        Form_Load();

                        return;

                    case "catch":

                        popupNotifier1.TitleText = "خطا";
                        popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                        popupNotifier1.Popup();

                        Form_Load();

                        return;
                }

                string Result_Add_AS = F.Add(Person_Id, "AS", Cmb_Account_Side_Recive.Text, (Convert.ToInt32(Find_AS.Split(Paths.Split_Char)[2]) - Convert.ToInt32(Txt_Price_Recive.Text.Replace(",", "").Replace(",", ""))).ToString());

                switch (Result_Add_AS)
                {
                    case "Negative":

                        popupNotifier1.TitleText = "خطا";
                        popupNotifier1.ContentText = "موجودی طرف حساب کمتر از مبلغ پرداختی است";
                        popupNotifier1.Popup();

                        Form_Load();

                        return;

                    case "catch":

                        popupNotifier1.TitleText = "خطا";
                        popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                        popupNotifier1.Popup();

                        Form_Load();

                        return;
                }

                if (Txt_Price_Cash_Desk_Recive.Text.Replace(",", "").Replace(",", "").Replace(",", "") != "")
                {
                    string Find_CD = F.Stock(Person_Id, "CD", Cmb_Cash_Cmb_Recive.Text);

                    switch (Find_CD)
                    {
                        case null:

                            popupNotifier1.TitleText = "خطا";
                            popupNotifier1.ContentText = "صندوقی با این نام وجود ندارد";
                            popupNotifier1.Popup();

                            Form_Load();

                            return;

                        case "catch":

                            popupNotifier1.TitleText = "خطا";
                            popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                            popupNotifier1.Popup();

                            Form_Load();

                            return;
                    }

                    string Result_Add_CD = F.Add(Person_Id, "CD", Cmb_Cash_Cmb_Recive.Text, ((Convert.ToInt32(Find_CD.Split(Paths.Split_Char)[2]) + Convert.ToInt32(Txt_Price_Cash_Desk_Recive.Text.Replace(",", "").Replace(",", "").Replace(",", "")))).ToString());

                    if (Result_Add_CD != "Try")
                    {
                        popupNotifier1.TitleText = "خطا";
                        popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                        popupNotifier1.Popup();

                        Form_Load();

                        return;
                    }
                }

                if (Txt_Price_Bank_Account_Recive.Text.Replace(",", "").Replace(",", "") != "")
                {
                    string Find_BA = F.Stock(Person_Id, "BA", Cmb_Bank_Account_Recive.Text);

                    if (Find_BA == "catch" || Find_BA == null)
                    {
                        popupNotifier1.TitleText = "خطا";
                        popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                        popupNotifier1.Popup();

                        Form_Load();

                        return;
                    }

                    string Add_BA = F.Add(Person_Id, "BA", Cmb_Bank_Account_Recive.Text, (Convert.ToInt32(Find_BA.Split(Paths.Split_Char)[2]) + Convert.ToInt32(Txt_Price_Bank_Account_Recive.Text.Replace(",", "").Replace(",", ""))).ToString());

                    if (Add_BA != "Try")
                    {
                        popupNotifier1.TitleText = "خطا";
                        popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                        popupNotifier1.Popup();

                        Form_Load();

                        return;
                    }
                }

                popupNotifier2.TitleText = "انجام شد";
                popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                popupNotifier2.Popup();

                Form_Load();
            }

            catch
            {
                try
                {
                    popupNotifier1.TitleText = "خطا";
                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                    popupNotifier1.Popup();
                }
                catch { }
            }
        }

        private void Cmb_Origin_Deposit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Load_Cmb_Bank_Account(Cmb_Destination_Deposit);
                Cmb_Destination_Deposit.Items.RemoveAt(Cmb_Origin_Deposit.SelectedIndex);
                Cmb_Destination_Deposit.Text = "";
                Txt_Price_Deposit.Text = "";
            }
            catch { }
        }

        private void Cmb_Account_Side_Payment_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Cmb_Check((ComboBox)sender);
        }

        private void Txt_Price_Payment_TextChanged(object sender, EventArgs e)
        {
            Separate_Texts.Separatea(sender);
        }

        private void Txt_Price_Recive_TextChanged(object sender, EventArgs e)
        {
            Separate_Texts.Separatea(sender);
        }

        private void Txt_Price_Cash_Desk_Recive_TextChanged(object sender, EventArgs e)
        {
            Separate_Texts.Separatea(sender);
        }

        private void Txt_Price_Bank_Account_Recive_TextChanged(object sender, EventArgs e)
        {
            Separate_Texts.Separatea(sender);
        }

        private void Txt_Check_Price_Payment_TextChanged(object sender, EventArgs e)
        {
            Separate_Texts.Separatea(sender);
        }
    }
}