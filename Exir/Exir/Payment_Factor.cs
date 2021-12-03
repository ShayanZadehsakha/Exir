using CEWorld.Convert;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Exir
{
    public partial class Payment_Factor : RadForm
    {
        string Person_Id = "";
        string Account_Side = "";
        string Price = "";
        string Type = "";
        string Date = "";
        string Number_Factor = "";

        bool Check_Stock = true;
        bool Call_Void = false;

        DataGridView Dgb = null;

        public Payment_Factor(string person_id, string number_factor, string price, string account_side, string date, DataGridView dgb, string type)
        {
            InitializeComponent();

            Person_Id = person_id;
            Account_Side = account_side;
            Price = price;
            Type = type;
            Number_Factor = number_factor;
            Date = date;

            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            Dgb = dgb;

            Text = "فاکتور " + Number_Factor;
            Txt_Price.Text= price;

            Form_Load();
        }

        private void Form_Load()
        {
            try
            {
                string[] Data_CD = File.ReadAllLines(Paths.Cash_Desk_txt(Person_Id));
                string[] Data_BA = File.ReadAllLines(Paths.Account_Side_Bank_txt(Person_Id,Account_Side));
                string[] Data_CH = File.ReadAllLines(Paths.Checks_Txt(Person_Id));

                foreach (string Find in Data_CD)
                {
                    Cmb_Cash_Desk.Items.Add(Find.Split(Paths.Split_Char)[0]);
                }

                foreach (string Find in Data_BA)
                {
                    Cmb_Bank_Account.Items.Add(Find.Split(Paths.Split_Char)[0]);
                }

                foreach (string Find in Data_CH)
                {
                    if (Find.Split(Paths.Split_Char)[8] == Account_Side && Find.Split(Paths.Split_Char)[9] == "P")
                        Cmb_Check.Items.Add(Find.Split(Paths.Split_Char)[0]);
                }

                if (Cmb_Cash_Desk.Items.Count == 0)
                    Cmb_Cash_Desk.Items.Add("صندوقی ثبت نشده");

                if (Cmb_Bank_Account.Items.Count == 0)
                    Cmb_Bank_Account.Items.Add("حساب بانکی ثبت نشده");

                if (Cmb_Check.Items.Count == 0)
                    Cmb_Check.Items.Add("چکی برای طرف حساب ثبت نشده");
            }
            catch { }
        }

        private void Txt_Price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Lbl_Price_In_String.Text = NumberToWord.PersianConvertNumberToWord(Txt_Price.Text.Replace(",","").Replace(",", ""));
                Separate_Texts.Separatea(sender);
            }
            catch { }
        }

        private void Txt_Cash_Price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                RadTextBox Txt = (RadTextBox)sender;
                if (Txt.Text == "")
                    Txt.Text = "0";

                Financial F = new Financial();

                int Stock_CD = 0;
                int Stock_BA = 0;
                int Stock_CH = 0;
                int Stock = 0;

                if (Get_Cmb(Txt).Text != Get_Cmb(Txt).Text)
                    Stock = Convert.ToInt32(F.Stock(Person_Id, Get_Work(Txt), Get_Cmb(Txt).Text).Split(Paths.Split_Char)[2]);

                if (Call_Void)
                    if (Convert.ToInt32(Txt.Text.Replace(",","")) > Stock && Type == "Buy" || Type == "ROS")
                    {
                        Txt.Text= Stock.ToString();

                        popupNotifier1.TitleText = "خطا!";
                        popupNotifier1.ContentText = "مبلغ وارد شده بیشتر از موجودی آن است";
                        popupNotifier1.Popup();

                        Check_Stock = false;
                    }

                Stock = 0;
                
                if (Txt_Cash_Price.Text.Replace(",","") != "")
                    Stock_CD = Convert.ToInt32(Txt_Cash_Price.Text.Replace(",",""));
                
                if (Txt_Bank_Account_Price.Text.Replace(",","") != "")
                    Stock_BA = Convert.ToInt32(Txt_Bank_Account_Price.Text.Replace(",",""));

                if (Txt_Check_Price.Text.Replace(",","") != "")
                    Stock_CH = Convert.ToInt32(Txt_Check_Price.Text.Replace(",",""));

                Stock = Convert.ToInt32(Price.Replace(",", "").Replace(",","")) - Stock_CD - Stock_BA - Stock_CH;

                if (Stock < 0)
                {
                    int Negative_Numbers = 0;

                    for (int i = Stock; i < 0; i++)
                    {
                        Negative_Numbers++;
                    }

                    Txt.Text= (Convert.ToInt32(Txt.Text.Replace(",","")) - Negative_Numbers).ToString();

                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "مبلغ وارد شده بیشتر از مبلغ فاکتور است";
                    popupNotifier1.Popup();

                    if (Txt_Cash_Price.Text.Replace(",","") != "")
                        Stock_CD = Convert.ToInt32(Txt_Cash_Price.Text.Replace(",",""));

                    if (Txt_Bank_Account_Price.Text.Replace(",","") != "")
                        Stock_BA = Convert.ToInt32(Txt_Bank_Account_Price.Text.Replace(",",""));

                    if (Txt_Check_Price.Text.Replace(",","") != "")
                        Stock_CH = Convert.ToInt32(Txt_Check_Price.Text.Replace(",",""));

                    Stock = Convert.ToInt32(Price.Replace(",", "")) - Stock_CD - Stock_BA - Stock_CH;
                }
                
                Txt_Price.Text= Stock.ToString();
            }
            catch { }
        
            Separate_Texts.Separatea(sender);
        }

        private ComboBox Get_Cmb(RadTextBox Txt)
        {
            if (Txt == Txt_Cash_Price)
                return Cmb_Cash_Desk;

            else if (Txt == Txt_Bank_Account_Price)
                return Cmb_Bank_Account;

            else
                return Cmb_Check;
        }

        private string Get_Work(RadTextBox Txt)
        {
            if (Txt == Txt_Cash_Price)
                return "CD";

            else if (Txt == Txt_Bank_Account_Price)
                return "BA";

            else
                return "CH";
        }

        private void Btn_Apply_Buy_Click(object sender, EventArgs e)
        {
            try
            {
                int Stock = 0;

                string Stock_F = "";
                string Add = "";

                Check_Stock = true;

                Call_Void = true;

                Txt_Cash_Price_TextChanged(Txt_Bank_Account_Price, null);
                Txt_Cash_Price_TextChanged(Txt_Cash_Price, null);
                Txt_Cash_Price_TextChanged(Txt_Check_Price, null);

                Call_Void = false;

                if (!Check_Stock)
                    return;

                Financial F = new Financial();

                if (Txt_Price.Text.Replace(",","").Replace(",", "") == "0")
                {
                    switch (Type)
                    {
                        case "Buy":

                            Stock_F = F.Stock(Person_Id, "AS", Account_Side).Split(Paths.Split_Char)[2];

                            if (Stock_F == null || Stock_F == "catch")
                            {
                                popupNotifier1.TitleText = "انجام نشد!";
                                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                popupNotifier1.Popup();

                                return;
                            }

                            Stock = Convert.ToInt32(Stock_F);
                            Add = F.Add(Person_Id, "AS", Account_Side, (Stock - Convert.ToInt32(Price.Replace(",", ""))).ToString());

                            if (Add == "Negative" || Add == "catch")
                            {
                                popupNotifier1.TitleText = "انجام نشد!";
                                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                popupNotifier1.Popup();

                                return;
                            }

                            if (Cmb_Cash_Desk.Text != "" && Txt_Cash_Price.Text.Replace(",","") != "")
                            {
                                Stock_F = F.Stock(Person_Id, "CD", Cmb_Cash_Desk.Text).Split(Paths.Split_Char)[2];

                                if (Stock_F == null || Stock_F == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }

                                Stock = Convert.ToInt32(Stock_F) - Convert.ToInt32(Txt_Cash_Price.Text.Replace(",",""));
                                Add = F.Add(Person_Id, "CD", Cmb_Cash_Desk.Text, Stock.ToString());

                                if (Add == "Negative" || Add == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }
                            }

                            if (Cmb_Bank_Account.Text != "" && Txt_Bank_Account_Price.Text.Replace(",","") != "")
                            {
                                Stock_F = F.Stock(Person_Id, "BA", Cmb_Bank_Account.Text).Split(Paths.Split_Char)[2];

                                if (Stock_F == null || Stock_F == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }

                                Stock = Convert.ToInt32(Stock_F) - Convert.ToInt32(Txt_Bank_Account_Price.Text.Replace(",",""));
                                Add = F.Add(Person_Id, "BA", Cmb_Bank_Account.Text, Stock.ToString());

                                if (Add == "Negative" || Add == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }
                            }

                            if (Cmb_Check.Text != "" && Txt_Check_Price.Text.Replace(",","") != "")
                            {
                                Stock_F = F.Stock(Person_Id, "CH", Cmb_Check.Text).Split(Paths.Split_Char)[2];

                                if (Stock_F == null || Stock_F == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }

                                Stock = Convert.ToInt32(Stock_F) - Convert.ToInt32(Txt_Check_Price.Text.Replace(",",""));
                                Add = F.Add(Person_Id, "CH", Name, Stock.ToString());

                                if (Add == "Negative" || Add == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }
                            }

                            Add_Factor AF = new Add_Factor();
                            string Result = AF.Buy_Action(Person_Id, Account_Side, Number_Factor, Date, Dgb, Cmb_Cash_Desk.Text, Txt_Cash_Price.Text.Replace(",",""), Cmb_Bank_Account.Text, Txt_Bank_Account_Price.Text.Replace(",",""), Cmb_Check.Text, Txt_Check_Price.Text.Replace(",",""));

                            if (Result == "catch")
                            {
                                popupNotifier1.TitleText = "انجام نشد!";
                                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                popupNotifier1.Popup();

                                return;
                            }

                            popupNotifier2.TitleText = "انجام شد";
                            popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                            popupNotifier2.Popup();

                            DialogResult = DialogResult.OK;

                            Close();

                            break;

                        case "Sell":

                            Stock_F = F.Stock(Person_Id, "AS", Account_Side).Split(Paths.Split_Char)[2];

                            if (Stock_F == null || Stock_F == "catch")
                            {
                                popupNotifier1.TitleText = "انجام نشد!";
                                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                popupNotifier1.Popup();

                                return;
                            }

                            Stock = Convert.ToInt32(Stock_F);
                        
                            Add = F.Add(Person_Id, "AS", Account_Side, (Stock + Convert.ToInt32(Price.Replace(",", ""))).ToString());

                            if (Add == "Negative" || Add == "catch")
                            {
                                popupNotifier1.TitleText = "انجام نشد!";
                                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                popupNotifier1.Popup();

                                return;
                            }

                            if (Cmb_Cash_Desk.Text != "" && Txt_Cash_Price.Text.Replace(",","") != "")
                            {
                                Stock_F = F.Stock(Person_Id, "CD", Cmb_Cash_Desk.Text).Split(Paths.Split_Char)[2];

                                if (Stock_F == null || Stock_F == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }

                                Stock = Convert.ToInt32(Stock_F) + Convert.ToInt32(Txt_Cash_Price.Text.Replace(",",""));
                                Add = F.Add(Person_Id, "CD", Cmb_Cash_Desk.Text, Stock.ToString());

                                if (Add == "Negative" || Add == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }
                            }

                            if (Cmb_Bank_Account.Text != "" && Txt_Bank_Account_Price.Text.Replace(",","") != "")
                            {
                                Stock_F = F.Stock(Person_Id, "BA", Cmb_Bank_Account.Text).Split(Paths.Split_Char)[2];

                                if (Stock_F == null || Stock_F == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }

                                Stock = Convert.ToInt32(Stock_F) + Convert.ToInt32(Txt_Bank_Account_Price.Text.Replace(",",""));
                                Add = F.Add(Person_Id, "BA", Cmb_Bank_Account.Text, Stock.ToString());

                                if (Add == "Negative" || Add == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }
                            }

                            if (Cmb_Check.Text != "" && Txt_Check_Price.Text.Replace(",","") != "")
                            {
                                Stock_F = F.Stock(Person_Id, "CH", Cmb_Check.Text).Split(Paths.Split_Char)[2];

                                if (Stock_F == null || Stock_F == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }

                                Stock = Convert.ToInt32(Stock_F) + Convert.ToInt32(Txt_Check_Price.Text.Replace(",",""));
                                Add = F.Add(Person_Id, "CH", Name, Stock.ToString());

                                if (Add == "Negative" || Add == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }
                            }

                            Add_Factor AF1 = new Add_Factor();
                            string Result1 = AF1.Sell_Action(Person_Id, Account_Side, Number_Factor, Date, Dgb, Cmb_Cash_Desk.Text, Txt_Cash_Price.Text.Replace(",",""), Cmb_Bank_Account.Text, Txt_Bank_Account_Price.Text.Replace(",",""), Cmb_Check.Text, Txt_Check_Price.Text.Replace(",",""));

                            if (Result1 == "catch")
                            {
                                popupNotifier1.TitleText = "انجام نشد!";
                                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                popupNotifier1.Popup();

                                return;
                            }

                            popupNotifier2.TitleText = "انجام شد";
                            popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                            popupNotifier2.Popup();

                            DialogResult = DialogResult.OK;

                            Close();

                            break;

                        case "RFP":

                            Stock_F = F.Stock(Person_Id, "AS", Account_Side).Split(Paths.Split_Char)[2];

                            if (Stock_F == null || Stock_F == "catch")
                            {
                                popupNotifier1.TitleText = "انجام نشد!";
                                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                popupNotifier1.Popup();

                                return;
                            }

                            Stock = Convert.ToInt32(Stock_F);
                            Add = F.Add(Person_Id, "AS", Account_Side, (Stock - Convert.ToInt32(Price.Replace(",", ""))).ToString());

                            if (Add == "Negative" || Add == "catch")
                            {
                                popupNotifier1.TitleText = "انجام نشد!";
                                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                popupNotifier1.Popup();

                                return;
                            }

                            if (Cmb_Cash_Desk.Text != "" && Txt_Cash_Price.Text.Replace(",","") != "")
                            {
                                Stock_F = F.Stock(Person_Id, "CD", Cmb_Cash_Desk.Text).Split(Paths.Split_Char)[2];

                                if (Stock_F == null || Stock_F == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }

                                Stock = Convert.ToInt32(Stock_F) + Convert.ToInt32(Txt_Cash_Price.Text.Replace(",",""));
                                Add = F.Add(Person_Id, "CD", Cmb_Cash_Desk.Text, Stock.ToString());

                                if (Add == "Negative" || Add == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }
                            }

                            if (Cmb_Bank_Account.Text != "" && Txt_Bank_Account_Price.Text.Replace(",","") != "")
                            {
                                Stock_F = F.Stock(Person_Id, "BA", Cmb_Bank_Account.Text).Split(Paths.Split_Char)[2];

                                if (Stock_F == null || Stock_F == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }

                                Stock = Convert.ToInt32(Stock_F) + Convert.ToInt32(Txt_Bank_Account_Price.Text.Replace(",",""));
                                Add = F.Add(Person_Id, "BA", Cmb_Bank_Account.Text, Stock.ToString());

                                if (Add == "Negative" || Add == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }
                            }

                            if (Cmb_Check.Text != "" && Txt_Check_Price.Text.Replace(",","") != "")
                            {
                                Stock_F = F.Stock(Person_Id, "CH", Cmb_Check.Text).Split(Paths.Split_Char)[2];

                                if (Stock_F == null || Stock_F == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }

                                Stock = Convert.ToInt32(Stock_F) + Convert.ToInt32(Txt_Check_Price.Text.Replace(",",""));
                                Add = F.Add(Person_Id, "CH", Name, Stock.ToString());

                                if (Add == "Negative" || Add == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }
                            }

                            Add_Factor AF2 = new Add_Factor();
                            string Result2 = AF2.RFP_Action(Person_Id, Account_Side, Number_Factor, Date, Dgb, Cmb_Cash_Desk.Text, Txt_Cash_Price.Text.Replace(",",""), Cmb_Bank_Account.Text, Txt_Bank_Account_Price.Text.Replace(",",""), Cmb_Check.Text, Txt_Check_Price.Text.Replace(",",""));

                            if (Result2 == "catch")
                            {
                                popupNotifier1.TitleText = "انجام نشد!";
                                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                popupNotifier1.Popup();

                                return;
                            }

                            popupNotifier2.TitleText = "انجام شد";
                            popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                            popupNotifier2.Popup();

                            DialogResult = DialogResult.OK;

                            Close();

                            break;

                        case "ROS":

                            Stock_F = F.Stock(Person_Id, "AS", Account_Side).Split(Paths.Split_Char)[2];

                            if (Stock_F == null || Stock_F == "catch")
                            {
                                popupNotifier1.TitleText = "انجام نشد!";
                                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                popupNotifier1.Popup();

                                return;
                            }

                            Stock = Convert.ToInt32(Stock_F);
                            Add = F.Add(Person_Id, "AS", Account_Side, (Stock + Convert.ToInt32(Price.Replace(",", ""))).ToString());

                            if (Add == "Negative" || Add == "catch")
                            {
                                popupNotifier1.TitleText = "انجام نشد!";
                                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                popupNotifier1.Popup();

                                return;
                            }

                            if (Cmb_Cash_Desk.Text != "" && Txt_Cash_Price.Text.Replace(",","") != "")
                            {
                                Stock_F = F.Stock(Person_Id, "CD", Cmb_Cash_Desk.Text).Split(Paths.Split_Char)[2];

                                if (Stock_F == null || Stock_F == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }

                                Stock = Convert.ToInt32(Stock_F) - Convert.ToInt32(Txt_Cash_Price.Text.Replace(",",""));
                                Add = F.Add(Person_Id, "CD", Cmb_Cash_Desk.Text, Stock.ToString());

                                if (Add == "Negative" || Add == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }
                            }

                            if (Cmb_Bank_Account.Text != "" && Txt_Bank_Account_Price.Text.Replace(",","") != "")
                            {
                                Stock_F = F.Stock(Person_Id, "BA", Cmb_Bank_Account.Text).Split(Paths.Split_Char)[2];

                                if (Stock_F == null || Stock_F == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }

                                Stock = Convert.ToInt32(Stock_F) - Convert.ToInt32(Txt_Bank_Account_Price.Text.Replace(",",""));
                                Add = F.Add(Person_Id, "BA", Cmb_Bank_Account.Text, Stock.ToString());

                                if (Add == "Negative" || Add == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }
                            }

                            if (Cmb_Check.Text != "" && Txt_Check_Price.Text.Replace(",","") != "")
                            {
                                Stock_F = F.Stock(Person_Id, "CH", Cmb_Check.Text).Split(Paths.Split_Char)[2];

                                if (Stock_F == null || Stock_F == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }

                                Stock = Convert.ToInt32(Stock_F) - Convert.ToInt32(Txt_Check_Price.Text.Replace(",",""));
                                Add = F.Add(Person_Id, "CH", Name, Stock.ToString());

                                if (Add == "Negative" || Add == "catch")
                                {
                                    popupNotifier1.TitleText = "انجام نشد!";
                                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                    popupNotifier1.Popup();

                                    return;
                                }
                            }

                            Add_Factor AF3 = new Add_Factor();
                            string Result3 = AF3.ROS_Action(Person_Id, Account_Side, Number_Factor, Date, Dgb, Cmb_Cash_Desk.Text, Txt_Cash_Price.Text.Replace(",",""), Cmb_Bank_Account.Text, Txt_Bank_Account_Price.Text.Replace(",",""), Cmb_Check.Text, Txt_Check_Price.Text.Replace(",",""));

                            if (Result3 == "catch")
                            {
                                popupNotifier1.TitleText = "انجام نشد!";
                                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                                popupNotifier1.Popup();

                                Close();

                                return;
                            }

                            popupNotifier2.TitleText = "انجام شد";
                            popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                            popupNotifier2.Popup();

                            DialogResult = DialogResult.OK;

                            Close();

                            break;

                        case "Management":

                            try
                            {
                                Payment_Factor_Info.Cash_Desk = Cmb_Cash_Desk.Text;
                                Payment_Factor_Info.Cash_Desk_Price = Txt_Cash_Price.Text.Replace(",","");
                                Payment_Factor_Info.Bank_Account = Cmb_Bank_Account.Text;
                                Payment_Factor_Info.Bank_Account_Price = Txt_Bank_Account_Price.Text.Replace(",","");
                                Payment_Factor_Info.Check = Cmb_Check.Text;
                                Payment_Factor_Info.Check_Price = Txt_Check_Price.Text.Replace(",","");

                                DialogResult = DialogResult.OK;
                            }
                            catch { }

                            Close();

                            break;
                    }
                }
                else
                {
                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "مبلغ پرداختی باید برابر با 0 باشد";
                    popupNotifier1.Popup();

                    Close();
                    DialogResult = DialogResult.Cancel;
                }
            }
            catch
            {
                popupNotifier1.TitleText = "انجام نشد!";
                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                popupNotifier1.Popup();

                Close();
                DialogResult = DialogResult.Cancel;
            }
        }

        private void Payment_Factor_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;

            Close();
        }

        private void Cmb_Check_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Checks_Txt(Person_Id));

                foreach (string Find in Data)
                {
                    if (Find.Split(Paths.Split_Char)[0] == Cmb_Check.Text)
                        Txt_Check_Price.Text = Find.Split(Paths.Split_Char)[6];
                }
            }
            catch { }
        }
    }
}