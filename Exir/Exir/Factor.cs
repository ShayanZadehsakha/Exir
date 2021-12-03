using CEWorld.Convert;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Exir
{
    public partial class Factor : RadTabbedForm
    {
        string Person_Id = "";
        string Result = "";
        string Cmb_Text = "";
        string Type_Factor_For_Managment = "";

        int Count_CellValueChanged = 0;
        int Count_CellValueChanged_Management = 0;
        int Count_CellValueChanged_RFP = 0;
        int Price = 0;
        int Count_Change_Size_Columns = 0;

        public Factor(string person_id)
        {
            InitializeComponent();
            Person_Id = person_id;

            Change_Size_Columns();
            Change_Size_Management_Columns();

            AllowAero = false;
            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            radTabbedFormControlTab5.Size = new Size(800, 611);

            Size = new Size(815, 596);
            AllowAero = false;

            Form_Load();
        }

        private void Change_Size_Columns()
        {
            if (Count_Change_Size_Columns > 5)
            {
                Count_Change_Size_Columns = 0;
                return;
            }

            Dgb_Factors_Buy.Columns[Count_Change_Size_Columns].Width = Size.Width / 5;
            Dgb_Factors_Sell.Columns[Count_Change_Size_Columns].Width = Size.Width / 5;
            Dgb_Factors_ROS.Columns[Count_Change_Size_Columns].Width = Size.Width / 5;
            Dgb_Factors_RFP.Columns[Count_Change_Size_Columns].Width = Size.Width / 5;

            Count_Change_Size_Columns++;

            Change_Size_Columns();
        }

        private void Change_Size_Management_Columns()
        {
            if (Count_Change_Size_Columns > 6)
            {
                Count_Change_Size_Columns = 0;
                return;
            }

            Dgb_Factor_Management.Columns[Count_Change_Size_Columns].Width = Size.Width / 6;

            Count_Change_Size_Columns++;

            Change_Size_Management_Columns();
        }

        private void Form_Load()
        {
            string[] Data_Account_Sides = File.ReadAllLines(Paths.Account_Side_txt(Person_Id));

            foreach (string Find in Data_Account_Sides)
            {
                if (!File.Exists(Paths.Factor_Buy_txt(Person_Id, Find.Split(Paths.Split_Char)[0])))
                {
                    var a = File.Create(Paths.Factor_Buy_txt(Person_Id, Find.Split(Paths.Split_Char)[0]));
                    a.Close();
                }

                Cmb_Account_Side_Buy.Items.Add(Find.Split(Paths.Split_Char)[0]);
                Cmb_Account_Side_Sell.Items.Add(Find.Split(Paths.Split_Char)[0]);
                Cmb_Account_Side_RFP.Items.Add(Find.Split(Paths.Split_Char)[0]);
                Cmb_Account_Side_ROS.Items.Add(Find.Split(Paths.Split_Char)[0]);
                Cmb_Account_Side_Management.Items.Add(Find.Split(Paths.Split_Char)[0]);
            }

            Load_Cmb_In_Dgb(Cmb_In_Dgb_Bye);
            Load_Cmb_In_Dgb(Cmb_In_Dgb_Sell);
            Load_Cmb_In_Dgb(Cmb_In_Dgb_RFP);
            Load_Cmb_In_Dgb(Cmb_In_Dgb_ROS);
        }

        private void Load_Cmb_Managment()
        {
            try
            {
                if (Cmb_Account_Side_Management.Text != "")
                {
                    if (Chk_Buy_Management.Checked)
                    {
                        string[] Data = File.ReadAllLines(Paths.Factor_Buy_txt(Person_Id, Cmb_Account_Side_Management.Text));

                        foreach (string Find in Data)
                        {
                            Check_Exists_Cmb("خرید - " + Find.Split(Paths.Split_Char)[7]);
                        }
                    }

                    if (Chk_Sell_Management.Checked)
                    {
                        string[] Data = File.ReadAllLines(Paths.Factor_Sell_txt(Person_Id, Cmb_Account_Side_Management.Text));

                        foreach (string Find in Data)
                        {
                            Check_Exists_Cmb("فروش - " + Find.Split(Paths.Split_Char)[7]);
                        }
                    }

                    if (Chk_RFP_Management.Checked)
                    {
                        string[] Data = File.ReadAllLines(Paths.Factor_RFP_txt(Person_Id, Cmb_Account_Side_Management.Text));

                        foreach (string Find in Data)
                        {
                            Check_Exists_Cmb("برگشت از خرید - " + Find.Split(Paths.Split_Char)[7]);
                        }
                    }

                    if (Chk_Ros_Management.Checked)
                    {
                        string[] Data = File.ReadAllLines(Paths.Factor_ROS_txt(Person_Id, Cmb_Account_Side_Management.Text));

                        foreach (string Find in Data)
                        {
                            Check_Exists_Cmb("برگشت از فروش - " + Find.Split(Paths.Split_Char)[7]);
                        }
                    }
                }

                if (Cmb_Factor_Number_Management.Items.Count == 0)
                    Cmb_Factor_Number_Management.Items.Add("فاکتوری وجود ندارد");

                else if (Cmb_Factor_Number_Management.Items.Contains("فاکتوری وجود ندارد"))
                    Cmb_Factor_Number_Management.Items.Remove("فاکتوری وجود ندارد");
            }
            catch { }
        }

        private void Check_Exists_Cmb(string Item_Text)
        {
            if (!Cmb_Factor_Number_Management.Items.Contains(Item_Text))
                Cmb_Factor_Number_Management.Items.Add(Item_Text);
        }

        private void Load_Dgb_Managment(string Find)
        {
            Dgb_Factor_Management.Rows.Add(Cmb_Factor_Number_Management.Text.Split('-')[0], Find.Split(Paths.Split_Char)[0], Find.Split(Paths.Split_Char)[1], Find.Split(Paths.Split_Char)[2], Find.Split(Paths.Split_Char)[3], Find.Split(Paths.Split_Char)[4], Find.Split(Paths.Split_Char)[5]);

            Txt_Year_Management.Text = Find.Split(Paths.Split_Char)[6].Split('_')[0];
            Txt_Month_Management.Text = Find.Split(Paths.Split_Char)[6].Split('_')[1];
            Txt_Day_Management.Text = Find.Split(Paths.Split_Char)[6].Split('_')[2];

            Txt_Price_Management.Text = (Convert.ToInt32(Txt_Price_Management.Text) + Convert.ToInt32(Find.Split(Paths.Split_Char)[5])).ToString();
        }

        private void Load_Cmb_In_Dgb(DataGridViewComboBoxColumn Cmb)
        {
            string[] Data_Goods = File.ReadAllLines(Paths.Group_txt(Person_Id));

            foreach (string Find in Data_Goods)
            {
                int i = 0;

                foreach (string Find1 in Find.Split(Paths.Split_Char))
                {
                    i++;

                    if (i != 1)
                    {
                        foreach (string Find2 in File.ReadAllLines(Paths.Groups_txt(Person_Id, Find1, Find.Split(Paths.Split_Char)[0])))
                        {
                            Cmb.Items.Add(Find2.Split(Paths.Split_Char)[0]);
                        }
                    }
                }
            }

            if (Cmb.Items.Count == 0)
            {
                Cmb.Items.Add("کالایی ثبت نشده");
            }
        }

        private void Dgb_Factors_Buy_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView Dgb = (DataGridView)sender;

                Count_CellValueChanged++;

                bool Find_Groups = false;

                if (Count_CellValueChanged > 12)
                {
                    if (!Find_Groups)
                    {
                        if (Dgb.CurrentRow.Cells[2].Value != null)
                        {
                            string[] Data = File.ReadAllLines(Paths.Group_txt(Person_Id));

                            foreach (string Find in Data)
                            {
                                if (!Find_Groups)
                                {
                                    int i = 0;

                                    foreach (string Find1 in Find.Split(Paths.Split_Char))
                                    {
                                        if (!Find_Groups)
                                        {
                                            i++;

                                            if (i != 1)
                                            {
                                                foreach (string Find2 in File.ReadAllLines(Paths.Groups_txt(Person_Id, Find1, Find.Split(Paths.Split_Char)[0])))
                                                {
                                                    if (!Find_Groups)
                                                    {
                                                        if (Find2.Split(Paths.Split_Char)[0] == Dgb.CurrentRow.Cells[2].Value.ToString())
                                                        {
                                                            Dgb.CurrentRow.Cells[1].Value = Find1;
                                                            Dgb.CurrentRow.Cells[0].Value = Find.Split(Paths.Split_Char)[0];

                                                            Dgb.CurrentRow.Cells[4].Value = Find2.Split(Paths.Split_Char)[2];

                                                            if (Dgb.CurrentRow.Cells[3].Value != null && Convert.ToInt32(Dgb.CurrentRow.Cells[3].Value.ToString()) > Convert.ToInt32(Find2.Split(Paths.Split_Char)[1]) && Dgb != Dgb_Factors_Buy && Dgb != Dgb_Factors_RFP)
                                                            {
                                                                Dgb.CurrentRow.Cells[3].Value = Find2.Split(Paths.Split_Char)[1];

                                                                Popup_Alarm_Action("خطا !", "موجودی وارد شده بیشتر از موجودی کالا است");
                                                            }

                                                            else if (Dgb.CurrentRow.Cells[3].Value == null || Dgb.CurrentRow.Cells[3].Value.ToString() == "")
                                                                Dgb.CurrentRow.Cells[3].Value = "1";

                                                            Find_Groups = true;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            Cmb_Text = Dgb.CurrentRow.Cells[2].Value.ToString();
                        }
                    }

                    if (Dgb.CurrentRow.Cells[3].Value != null && Dgb.CurrentRow.Cells[4].Value != null)
                    {
                        int Number = 0;
                        int Per_Unit = 0;

                        Number = Convert.ToInt32(Dgb.CurrentRow.Cells[3].Value.ToString());
                        Per_Unit = Convert.ToInt32(Dgb.CurrentRow.Cells[4].Value.ToString());

                        Price = Number * Per_Unit;

                        Dgb.CurrentRow.Cells[5].Value = Price.ToString();
                    }

                    Price = 0;

                    for (int i = 0; i < Dgb.Rows.Count; i++)
                    {
                        if (Dgb.Rows[i].Cells[5].Value != null)
                        {
                            Price += Convert.ToInt32(Dgb.Rows[i].Cells[5].Value.ToString());
                        }
                    }

                    if (Dgb == Dgb_Factors_Buy)
                        Txt_Price_Buy.Text = Price.ToString();

                    else if (Dgb == Dgb_Factors_Sell)
                        Txt_Price_Sell.Text = Price.ToString();

                    else if (Dgb == Dgb_Factors_RFP)
                        Txt_Price_RFP.Text = Price.ToString();

                    else
                        Txt_Price_ROS.Text = Price.ToString();
                }
            }

            catch { }
        }

        bool Check_Factor_Number(object sender)
        {
            try
            {
                Button Button = (Button)sender;
                RadTextBox Txt = Txt_Factor_Number_Buy;

                switch (Button.Name.Split('_')[2])
                {
                    case "Sell":

                        Txt = Txt_Factor_Number_Sell;

                        break;

                    case "ROS":

                        Txt = Txt_Factor_Number_ROS;

                        break;

                    case "RFP":

                        Txt = Txt_Factor_Number_RFP;

                        break;
                }

                List<string> Data = new List<string>();

                switch (Txt.Name.Split('_')[3])
                {
                    case "Buy":

                        Data = File.ReadAllLines(Paths.Factor_Buy_txt(Person_Id, Cmb_Account_Side_Buy.Text)).ToList();

                        break;

                    case "Sell":

                        Data = File.ReadAllLines(Paths.Factor_Sell_txt(Person_Id, Cmb_Account_Side_Sell.Text)).ToList();

                        break;

                    case "RFP":

                        Data = File.ReadAllLines(Paths.Factor_RFP_txt(Person_Id, Cmb_Account_Side_RFP.Text)).ToList();

                        break;

                    case "ROS":

                        Data = File.ReadAllLines(Paths.Factor_ROS_txt(Person_Id, Cmb_Account_Side_ROS.Text)).ToList();

                        break;

                    case "Management":

                        switch (Cmb_Factor_Number_Management.Text.Split(Paths.Split_Char)[1])
                        {
                            case "خرید":

                                Data = File.ReadAllLines(Paths.Factor_Buy_txt(Person_Id, Cmb_Account_Side_Buy.Text)).ToList();

                                break;

                            case "فروش":

                                Data = File.ReadAllLines(Paths.Factor_Sell_txt(Person_Id, Cmb_Account_Side_Buy.Text)).ToList();

                                break;

                            case "برگشت از خرید":

                                Data = File.ReadAllLines(Paths.Factor_RFP_txt(Person_Id, Cmb_Account_Side_Buy.Text)).ToList();

                                break;

                            case "برگشت از فروش":

                                Data = File.ReadAllLines(Paths.Factor_ROS_txt(Person_Id, Cmb_Account_Side_Buy.Text)).ToList();

                                break;
                        }
                        break;
                }

                foreach (string Find in Data)
                {
                    if (Find.Split(Paths.Split_Char)[7] == Txt.Text)
                    {
                        Popup_Alarm_Action("خطا !", "فاکتوری با این شماره وجود دارد");

                        return false;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private RadTextBox Get_Txt_Factor_Number(Button Btn)
        {
            try
            {
                if (Btn == Btn_Apply_Buy)
                    return Txt_Factor_Number_Buy;

                else if (Btn == Btn_Apply_Sell)
                    return Txt_Factor_Number_Sell;

                else if (Btn == Btn_Apply_RFP)
                    return Txt_Factor_Number_RFP;

                else
                    return Txt_Factor_Number_ROS;
            }
            catch
            {
                return null;
            }
        }

        private RadTextBox Get_Txt_Price(Button Btn)
        {
            try
            {
                if (Btn == Btn_Apply_Buy)
                    return Txt_Price_Buy;

                else if (Btn == Btn_Apply_Sell)
                    return Txt_Price_Sell;

                else if (Btn == Btn_Apply_RFP)
                    return Txt_Price_RFP;

                return Txt_Price_ROS;
            }
            catch
            {
                return null;
            }
        }

        private DataGridView Get_Dgb(Button Btn)
        {
            try
            {
                if (Btn == Btn_Apply_Buy)
                    return Dgb_Factors_Buy;

                else if (Btn == Btn_Apply_Sell)
                    return Dgb_Factors_Sell;

                else if (Btn == Btn_Apply_RFP)
                    return Dgb_Factors_RFP;

                return Dgb_Factors_ROS;
            }
            catch
            {
                return null;
            }
        }

        private string Get_Date(Button Btn)
        {
            if (Btn == Btn_Apply_Buy)
                return Txt_Year_Buy.Text + "_" + Txt_Month_Buy.Text + "_" + Txt_Day_Buy.Text;

            else if (Btn == Btn_Apply_Sell)
                return Txt_Year_Sell.Text + "_" + Txt_Month_Sell.Text + "_" + Txt_Day_Sell.Text;

            else if (Btn == Btn_Apply_Sell)
                return Txt_Year_RFP.Text + "_" + Txt_Month_RFP.Text + "_" + Txt_Day_RFP.Text;

            else if (Btn == Btn_Apply_ROS)
                return Txt_Year_ROS.Text + "_" + Txt_Month_ROS.Text + "_" + Txt_Day_ROS.Text;

            return Txt_Year_Management.Text + "_" + Txt_Month_Management.Text + "_" + Txt_Day_Management.Text;
        }

        private void Btn_Apply_Buy_Click(object sender, EventArgs e)
        {
            try
            {
                Button Btn = (Button)sender;

                if (!Check_Factor_Number(sender))
                    return;

                DataGridView Dgb = new DataGridView();

                switch (Btn.Name.Split('_')[2])
                {
                    case "Buy":

                        Dgb = Dgb_Factors_Buy;

                        break;

                    case "Sell":

                        Dgb = Dgb_Factors_Sell;

                        break;

                    case "ROS":

                        Dgb = Dgb_Factors_ROS;

                        break;

                    case "RFP":

                        Dgb = Dgb_Factors_RFP;

                        break;
                }

                if (Dgb.RowCount < 1)
                {
                    Popup_Alarm_Action("خطا !", "حداقل باید یک ردیف فاکتور ثبت شود");

                    return;
                }

                if (Get_Txt_Factor_Number(Btn).Text == "")
                {
                    Popup_Alarm_Action("خطا !", "لطفا شماره فاکتور را وارد کنید");

                    return;
                }

                if (Get_Date(Btn).Split('_')[0] == "" || Get_Date(Btn).Split('_')[1] == "" || Get_Date(Btn).Split('_')[2] == "")
                {
                    Popup_Alarm_Action("خطا !", "لطفا تاریخ را وارد کنید");

                    return;
                }

                if (Get_Cmb(Btn).Text == "")
                {
                    Popup_Alarm_Action("خطا !", "لطفا طرف حساب را وارد کنید");

                    return;
                }

                bool Exists_Account_Side = false;

                string[] Data = File.ReadAllLines(Paths.Account_Side_txt(Person_Id));

                foreach (string Find in Data)
                {
                    if (Find.Split(Paths.Split_Char)[0] == Get_Cmb(Btn).Text)
                        Exists_Account_Side = true;
                }

                if (!Exists_Account_Side)
                {
                    Popup_Alarm_Action("خطا !", "طرف حسابی با این نام در سیستم وجود ندارد");

                    return;
                }

                Payment_Factor PF = new Payment_Factor(Person_Id, Get_Txt_Factor_Number(Btn).Text, Get_Txt_Price(Btn).Text, Get_Cmb(Btn).Text, Get_Date(Btn), Get_Dgb(Btn), Btn.Name.Split('_')[2]);

                PF.ShowDialog();

                if (PF.DialogResult != DialogResult.Cancel)
                    Close();
            }
            catch
            {
                Popup_Alarm_Action("خطا !", "عملیات با مشکل مواجه شد");
            }
        }

        public void Error_Sound()
        {
            SystemSounds.Beep.Play();
        }

        private void Txt_Price_Bye_TextChanged(object sender, EventArgs e)
        {
            Convert_To_String_Price(sender, Lbl_Price_In_String_Buy);
                Separate_Texts.Separatea(sender);
        }

        private void Convert_To_String_Price(object sender, Label Lbl)
        {
            try
            {
                RadTextBox Txt = (RadTextBox)sender;

                if (Lbl.Text.Length <= 70)
                    Lbl.Text = NumberToWord.PersianConvertNumberToWord(Txt.Text);

                else
                {
                    string Price_In_String = NumberToWord.PersianConvertNumberToWord(Txt.Text);

                    Lbl.Text = "";

                    for (int i = 0; i < 70; i++)
                    {
                        Lbl.Text += Price_In_String[i];
                    }

                    Lbl.Text += " ...";
                }
            }
            catch { }
        }

        private void Convert_To_String_Price_Management(object sender, Label Lbl)
        {
            try
            {
                RadTextBox Txt = (RadTextBox)sender;

                if (Lbl.Text.Length <= 70)
                    Lbl.Text = NumberToWord.PersianConvertNumberToWord(Txt.Text);

                else
                {
                    string Price_In_String = NumberToWord.PersianConvertNumberToWord(Txt.Text);

                    Lbl.Text = "";

                    for (int i = 0; i < 70; i++)
                    {
                        Lbl.Text += Price_In_String[i];
                    }

                    Lbl.Text += " ...";
                }
            }
            catch (Exception m) { }
        }

        private RadTextBox Get_Txt(RadTextBox Txt)
        {
            try
            {
                if (Txt == Txt_Day_Buy)
                    return Txt_Month_Buy;

                else if (Txt == Txt_Month_Buy)
                    return Txt_Day_Buy;

                else if (Txt == Txt_Day_Sell)
                    return Txt_Month_Sell;

                else if (Txt == Txt_Month_Sell)
                    return Txt_Day_Sell;

                else if (Txt == Txt_Day_RFP)
                    return Txt_Month_RFP;

                else if (Txt == Txt_Month_RFP)
                    return Txt_Day_RFP;

                else if (Txt == Txt_Day_ROS)
                    return Txt_Month_ROS;

                else if (Txt == Txt_Month_ROS)
                    return Txt_Day_ROS;

                else if (Txt == Txt_Day_Management)
                    return Txt_Month_Management;

                return Txt_Day_Management;
            }
            catch
            {
                return null;
            }
        }

        private ComboBox Get_Cmb(Button Btn)
        {
            try
            {
                if (Btn == Btn_Apply_Buy)
                    return Cmb_Account_Side_Buy;

                else if (Btn == Btn_Apply_Sell)
                    return Cmb_Account_Side_Sell;

                else if (Btn == Btn_Apply_RFP)
                    return Cmb_Account_Side_RFP;

                else
                    return Cmb_Account_Side_ROS;
            }
            catch
            {
                return null;
            }
        }

        private void Txt_Day_Buy_TextChanged(object sender, EventArgs e)
        {
            Txt_Day_Text_Changed(sender);
        }

        private void Txt_Day_Text_Changed(object sender)
        {
            try
            {
                RadTextBox Txt = (RadTextBox)sender;

                if (Get_Txt(Txt).Text != "" && Txt.Text != "")
                {
                    if (Convert.ToInt32(Get_Txt(Txt).Text) <= 6 && Convert.ToInt32(Txt.Text) > 31)
                    {
                        Txt.Text = "31";

                        Error_Sound();
                    }
                    else if (Convert.ToInt32(Get_Txt(Txt).Text) > 6 && Convert.ToInt32(Txt.Text) > 30)
                    {
                        Txt.Text = "30";

                        Error_Sound();
                    }
                }

                if (Txt.TextLength == Txt.MaxLength)
                {
                    Get_Txt(Txt).Select();
                }
            }
            catch { }
        }

        private void Txt_Month_Buy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                RadTextBox Txt = (RadTextBox)sender;

                Txt_Day_Text_Changed(Get_Txt(Txt));

                if (Txt.Text != "" && Convert.ToInt32(Txt.Text) > 12)
                {
                    Txt.Text = "12";

                    Error_Sound();
                }

                if (Txt.TextLength == Txt.MaxLength)
                {
                    if (Txt == Txt_Month_Buy)
                        Txt_Year_Buy.Select();

                    else if (Txt == Txt_Month_Sell)
                        Txt_Year_Sell.Select();

                    else if (Txt == Txt_Month_RFP)
                        Txt_Year_RFP.Select();

                    else if (Txt == Txt_Month_ROS)
                        Txt_Year_ROS.Select();

                    else
                        Txt_Year_Management.Select();
                }

                if (Get_Txt(Txt).Text == "31" && Convert.ToInt32(Txt.Text) > 6)
                {
                    Get_Txt(Txt).Text = "30";
                }
            }
            catch { }
        }

        private void Txt_Price_Sell_TextChanged(object sender, EventArgs e)
        {
            Convert_To_String_Price(sender, Lbl_Price_In_String_Sell);
                Separate_Texts.Separatea(sender);
        }

        private void Txt_Price_RFP_TextChanged(object sender, EventArgs e)
        {
            Convert_To_String_Price(sender, Lbl_Price_In_String_RFP);
                Separate_Texts.Separatea(sender);
        }

        private void Txt_Price_ROS_TextChanged(object sender, EventArgs e)
        {
            Convert_To_String_Price(sender, Lbl_Price_In_String_ROS);
                Separate_Texts.Separatea(sender);
        }

        private void Chk_All_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            Chk_Sell_Management.Checked = Chk_All_Management.Checked;
            Chk_Buy_Management.Checked = Chk_All_Management.Checked;
            Chk_RFP_Management.Checked = Chk_All_Management.Checked;
            Chk_Ros_Management.Checked = Chk_All_Management.Checked;

            Load_Cmb_Managment();
        }

        private void Chk_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            RadCheckBox Chk = (RadCheckBox)sender;

            if (!Chk.Checked && Chk_All_Management.Checked)
            {
                Chk_All_Management.Checked = false;

                if (Chk != Chk_Buy_Management)
                    Chk_Buy_Management.Checked = true;

                if (Chk != Chk_Sell_Management)
                    Chk_Sell_Management.Checked = true;

                if (Chk != Chk_RFP_Management)
                    Chk_RFP_Management.Checked = true;

                if (Chk != Chk_Ros_Management)
                    Chk_Ros_Management.Checked = true;
            }

            else if (!Chk_All_Management.Checked && Chk_Buy_Management.Checked && Chk_Sell_Management.Checked && Chk_Ros_Management.Checked && Chk_RFP_Management.Checked)
                Chk_All_Management.Checked = true;

            Load_Cmb_Managment();
        }

        private string Get_Void_Of_Paths()
        {
            switch (Cmb_Factor_Number_Management.Text.Split('-')[0])
            {
                case "خرید ":

                    Type_Factor_For_Managment = "Buy";
                    return Paths.Factor_Buy_txt(Person_Id, Cmb_Account_Side_Management.Text);

                case "فروش ":

                    Type_Factor_For_Managment = "Sell";
                    return Paths.Factor_Sell_txt(Person_Id, Cmb_Account_Side_Management.Text);

                case "برگشت از خرید ":

                    Type_Factor_For_Managment = "RFP";
                    return Paths.Factor_RFP_txt(Person_Id, Cmb_Account_Side_Management.Text);

                case " برگشت از فروش ":

                    Type_Factor_For_Managment = "ROS";
                    return Paths.Factor_ROS_txt(Person_Id, Cmb_Account_Side_Management.Text);
            }

            return null;
        }

        private void Cmb_Factor_Number_Management_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] Data = File.ReadAllLines(Get_Void_Of_Paths());

                Txt_Price_Management.Text = "0";
                Dgb_Factor_Management.Rows.Clear();

                foreach (string Find in Data)
                {
                    if (Find.Split(Paths.Split_Char)[7] == Cmb_Factor_Number_Management.Text.Split('-')[1].Replace(" ", ""))
                        Load_Dgb_Managment(Find);
                }
            }
            catch
            {
                Popup_Alarm_Action("خطا !", "عملیات بارگزاری اطلاعات با مشکل مواجه شد");
            }
        }

        private void Cmb_Account_Side_Management_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Cmb_Managment();
        }

        private void Dgb_Factors_Management_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                DataGridView Dgb = (DataGridView)sender;

                object Value = Dgb.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (!((DataGridViewComboBoxColumn)Dgb.Columns[e.ColumnIndex]).Items.Contains(Value))
                {
                    ((DataGridViewComboBoxColumn)Dgb.Columns[e.ColumnIndex]).Items.Add(Value);
                    e.ThrowException = false;
                }
            }
        }

        private void Dgb_Factors_Management_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Count_CellValueChanged_Management++;

                if (Count_CellValueChanged_Management > 7)
                {
                    if (Dgb_Factor_Management.CurrentRow != null)
                    {
                        Txt_Price_Management.Text = "0";

                        for (int i = 0; i < Dgb_Factor_Management.RowCount - 1; i++)
                        {
                            int Number = Convert.ToInt32(Dgb_Factor_Management.Rows[i].Cells[4].Value.ToString());
                            int Per_Unit = Convert.ToInt32(Dgb_Factor_Management.Rows[i].Cells[5].Value.ToString());

                            int Price = Number * Per_Unit;

                            Txt_Price_Management.Text = (Convert.ToInt32(Txt_Price_Management.Text) + Price).ToString();

                            Dgb_Factor_Management.Rows[i].Cells[6].Value = Price.ToString();
                        }

                        string[] Data = File.ReadAllLines(Paths.Group_txt(Person_Id));

                        foreach (string Find in Data)
                        {
                            int i = 0;

                            foreach (string Find1 in Find.Split(Paths.Split_Char))
                            {
                                i++;

                                if (i != 1)
                                {
                                    foreach (string Find2 in File.ReadAllLines(Paths.Groups_txt(Person_Id, Find1, Find.Split(Paths.Split_Char)[0])))
                                    {
                                        if (Find2.Split(Paths.Split_Char)[0] == Dgb_Factor_Management.CurrentRow.Cells[3].Value.ToString())
                                        {
                                            Dgb_Factor_Management.CurrentRow.Cells[2].Value = Find1;
                                            Dgb_Factor_Management.CurrentRow.Cells[1].Value = Find.Split(Paths.Split_Char)[0];

                                            if (Dgb_Factor_Management.CurrentRow.Cells[4].Value != null && Convert.ToInt32(Dgb_Factor_Management.CurrentRow.Cells[4].Value.ToString()) > Convert.ToInt32(Find2.Split(Paths.Split_Char)[1]))
                                                Dgb_Factor_Management.CurrentRow.Cells[4].Value = Find2.Split(Paths.Split_Char)[1];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void Btn_Remove_Management_Click(object sender, EventArgs e)
        {
            Custom_MessageBox CM = new Custom_MessageBox(Cmb_Factor_Number_Management.Text.Split('-')[1].Replace(" ", ""));
            CM.ShowDialog();

            if (CM.DialogResult == DialogResult.OK)
            {
                Remove_Factor RF = new Remove_Factor();
                string Result = RF.Action(Cmb_Factor_Number_Management.Text, Person_Id, Cmb_Account_Side_Management.Text);

                if (Result == "عملیات با موفقیت انجام شد")
                    Popup_Success_Action("انجام شد", Result);

                else if (Result == "عملیات با مشکل مواجه شد")
                    Popup_Alarm_Action("انجام نشد", Result);

                else
                    Popup_Alarm_Action("خطا !", Result);

                Load_Default_Management_Tab_Elements();

                Form_Load();
            }
        }

        void Load_Default_Management_Tab_Elements()
        {
            Dgb_Factor_Management.Rows.Clear();

            Cmb_Factor_Number_Management.Text = "";
            Cmb_Factor_Number_Management.Items.Clear();

            Cmb_Account_Side_Management.Text = "";
            Cmb_Account_Side_Management.Items.Clear();

            Txt_Price_Management.Text = "";
            Lbl_Price_In_String_Management.Text = "";

            Txt_Day_Management.Text = "";
            Txt_Month_Management.Text = "";
            Txt_Year_Management.Text = "";

            Chk_All_Management.Checked = false;
            Chk_Buy_Management.Checked = false;
            Chk_Sell_Management.Checked = false;
            Chk_RFP_Management.Checked = false;
            Chk_RFP_Management.Checked = false;
        }

        private void Poppup_For_Actions()
        {
            if (Result != "Try")
            {
                Popup_Alarm_Action("خطا !", "عملیات با مشکل مواجه شد");
            }
        }

        private void Poppup_For_Actions_End_Void()
        {
            if (Result != "Try")
            {
                Popup_Alarm_Action("خطا !", "عملیات با مشکل مواجه شد");
            }
            else
            {
                Popup_Alarm_Action("انجام نشد !", "عملیات با مشکل مواجه شد");
            }
        }

        private void Txt_Price_Management_TextChanged(object sender, EventArgs e)
        {
            Convert_To_String_Price_Management(sender, Lbl_Price_In_String_Management);
                Separate_Texts.Separatea(sender);
        }

        private void حذفسطرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dgb_Factor_Management.SelectedRows != null)
                {
                    Dgb_Factor_Management.Rows.RemoveAt(Dgb_Factor_Management.CurrentRow.Index);
                }
            }
            catch (Exception m)
            {
                string Error_For_New_Row = "System.InvalidOperationException: Uncommitted new row cannot be deleted.\r\n   at System.Windows.Forms.DataGridViewRowCollection.RemoveAt(Int32 index)\r\n   at Exir.Factor.حذفسطرToolStripMenuItem_Click(Object sender, EventArgs e) in E:\\Exir\\Exir\\Factor.cs:line 1321";

                if (m.ToString() == Error_For_New_Row)
                {
                    Popup_Alarm_Action("خطا !", "سطر انتخاب شده تا زمانی که خالی باشد در فاکتور ثبت نمی شود");
                }

                else
                {
                    Popup_Alarm_Action("خطا !", "عملیات با مشکل مواجه شد");
                }
            }
        }

        private void Popup_Alarm_Action(string Title_Text, string Content_Text)
        {
            popupNotifier1.TitleText = " " + Title_Text;
            popupNotifier1.ContentText = Content_Text;
            popupNotifier1.Popup();
        }

        private void Popup_Success_Action(string Title_Text, string Content_Text)
        {
            popupNotifier2.TitleText = " " + Title_Text;
            popupNotifier2.ContentText = Content_Text;
            popupNotifier2.Popup();
        }

        private void Dgb_Factors_RFP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Count_CellValueChanged_RFP++;

                if (Count_CellValueChanged_RFP > 12)
                {
                    string Path_Files = "";

                    DataGridView Dgb = (DataGridView)sender;

                    switch (Dgb.Name)
                    {
                        case ("Dgb_Factors_RFP"):

                            if (Cmb_Account_Side_RFP.Text == "")
                            {
                                Popup_Alarm_Action("خطا !", "لطفا طرف حساب را وارد کنید");
                                return;
                            }

                            else
                                Path_Files = Paths.Factor_Buy_txt(Person_Id, Cmb_Account_Side_RFP.Text);

                            break;

                        case "Dgb_Factors_ROS":

                            if (Cmb_Account_Side_ROS.Text == "")
                            {
                                Popup_Alarm_Action("خطا !", "لطفا طرف حساب را وارد کنید");
                                return;
                            }

                            else
                                Path_Files = Paths.Factor_Sell_txt(Person_Id, Cmb_Account_Side_ROS.Text);

                            break;
                    }

                    string[] Data = File.ReadAllLines(Path_Files);
                    int Index_Columns = Dgb.SelectedCells[0].ColumnIndex;

                    foreach (string Find in Data)
                    {
                        if (Dgb.Rows[Dgb.CurrentRow.Index].Cells[Index_Columns].Value.ToString() == Find.Split(Paths.Split_Char)[Index_Columns])
                        {
                            Dgb.Rows[Dgb.CurrentRow.Index].Cells[2].Value = Find.Split(Paths.Split_Char)[2];
                            Dgb.Rows[Dgb.CurrentRow.Index].Cells[3].Tag = Find.Split(Paths.Split_Char)[3];
                            Dgb.Rows[Dgb.CurrentRow.Index].Cells[4].Value = Find.Split(Paths.Split_Char)[4];
                        }
                    }

                    string Tag = Dgb.Rows[Dgb.CurrentRow.Index].Cells[3].Tag.ToString();

                    if (Dgb.Rows[Dgb.CurrentRow.Index].Cells[3].Value != null && Tag != "" && Tag != null && Convert.ToInt32(Tag) < Convert.ToInt32(Dgb.Rows[Dgb.CurrentRow.Index].Cells[3].Value.ToString()))
                    {
                        Dgb.Rows[Dgb.CurrentRow.Index].Cells[3].Value = Tag;
                        Popup_Alarm_Action("خطا !", "تعداد وارد شده بیشتر از تعداد در فاکتور است");
                    }

                    else
                    {
                        Dgb.Rows[Dgb.CurrentRow.Index].Cells[3].Value = "1";
                    }

                    Txt_Price_RFP.Text = "0";

                    for (int i = 0; i < Dgb.RowCount - 1; i++)
                    {
                        int Stock = Convert.ToInt32(Dgb.Rows[i].Cells[3].Value.ToString());
                        int Per_Unit = Convert.ToInt32(Dgb.Rows[i].Cells[4].Value.ToString());
                        int Price = Stock * Per_Unit;

                        Dgb.Rows[i].Cells[5].Value = Price.ToString();
                        Txt_Price_RFP.Text = (Convert.ToInt32(Txt_Price_RFP.Text) + Price).ToString();

                        try
                        {
                            decimal result;

                            if (Dgb.Rows[i].Cells[5].Value == null || !decimal.TryParse(Dgb.Rows[i].Cells[5].Value.ToString(), out result) || Dgb.Rows[i].Cells[5].Value.ToString() == "" || Dgb.Rows[i].Cells[5].Value.ToString() == "0")
                                return;

                            decimal price;

                            price = decimal.Parse(Dgb.Rows[i].Cells[5].Value.ToString(), System.Globalization.NumberStyles.Currency);

                            Dgb.Rows[i].Cells[5].Value = price.ToString("#,#");
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }

        private void Cmb_Account_Side_RFP_SelectedIndexChanged(object sender, EventArgs e)
        {
            Write_New_Factor_Number_Action(sender);

            DataGridView Dgb = Dgb_Factors_RFP;
            string Path_Files = "";

            if ((ComboBox)sender == Cmb_Account_Side_ROS)
                Dgb = Dgb_Factors_ROS;

            if (Dgb == Dgb_Factors_ROS)
                Path_Files = Paths.Factor_Sell_txt(Person_Id, Cmb_Account_Side_ROS.Text);

            else
                Path_Files = Paths.Factor_Buy_txt(Person_Id, Cmb_Account_Side_RFP.Text);

            string[] Data = File.ReadAllLines(Path_Files);

            for (int i = 0; i < Dgb.RowCount; i++)
            {
                ((DataGridViewComboBoxCell)Dgb.Rows[i].Cells[2]).Items.Clear();
                ((DataGridViewComboBoxCell)Dgb.Rows[i].Cells[4]).Items.Clear();

                foreach (string Find in Data)
                {
                    ((DataGridViewComboBoxCell)Dgb.Rows[i].Cells[2]).Items.Add(Find.Split(Paths.Split_Char)[2]);
                    ((DataGridViewComboBoxCell)Dgb.Rows[i].Cells[4]).Items.Add(Find.Split(Paths.Split_Char)[4]);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dgb_Factors_Buy.SelectedRows != null)
                {
                    Dgb_Factors_Buy.Rows.RemoveAt(Dgb_Factors_Buy.CurrentRow.Index);
                }
            }
            catch (Exception m)
            {
                string Error_For_New_Row = "System.InvalidOperationException: Uncommitted new row cannot be deleted.\r\n   at System.Windows.Forms.DataGridViewRowCollection.RemoveAt(Int32 index)\r\n   at Exir.Factor.حذفسطرToolStripMenuItem_Click(Object sender, EventArgs e) in E:\\Exir\\Exir\\Factor.cs:line 1321";

                if (m.ToString() == Error_For_New_Row)
                {
                    Popup_Alarm_Action("خطا !", "سطر انتخاب شده تا زمانی که خالی باشد در فاکتور ثبت نمی شود");
                }

                else
                {
                    Popup_Alarm_Action("خطا !", "عملیات با مشکل مواجه شد");
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dgb_Factors_Sell.SelectedRows != null)
                {
                    Dgb_Factors_Sell.Rows.RemoveAt(Dgb_Factors_Sell.CurrentRow.Index);
                }
            }
            catch (Exception m)
            {
                string Error_For_New_Row = "System.InvalidOperationException: Uncommitted new row cannot be deleted.\r\n   at System.Windows.Forms.DataGridViewRowCollection.RemoveAt(Int32 index)\r\n   at Exir.Factor.حذفسطرToolStripMenuItem_Click(Object sender, EventArgs e) in E:\\Exir\\Exir\\Factor.cs:line 1321";

                if (m.ToString() == Error_For_New_Row)
                {
                    Popup_Alarm_Action("خطا !", "سطر انتخاب شده تا زمانی که خالی باشد در فاکتور ثبت نمی شود");
                }

                else
                {
                    Popup_Alarm_Action("خطا !", "عملیات با مشکل مواجه شد");
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dgb_Factors_RFP.SelectedRows != null)
                {
                    Dgb_Factors_RFP.Rows.RemoveAt(Dgb_Factors_RFP.CurrentRow.Index);
                }
            }
            catch (Exception m)
            {
                string Error_For_New_Row = "System.InvalidOperationException: Uncommitted new row cannot be deleted.\r\n   at System.Windows.Forms.DataGridViewRowCollection.RemoveAt(Int32 index)\r\n   at Exir.Factor.حذفسطرToolStripMenuItem_Click(Object sender, EventArgs e) in E:\\Exir\\Exir\\Factor.cs:line 1321";

                if (m.ToString() == Error_For_New_Row)
                {
                    Popup_Alarm_Action("خطا !", "سطر انتخاب شده تا زمانی که خالی باشد در فاکتور ثبت نمی شود");
                }

                else
                {
                    Popup_Alarm_Action("خطا !", "عملیات با مشکل مواجه شد");
                }
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dgb_Factors_ROS.SelectedRows != null)
                {
                    Dgb_Factors_ROS.Rows.RemoveAt(Dgb_Factors_ROS.CurrentRow.Index);
                }
            }
            catch (Exception m)
            {
                string Error_For_New_Row = "System.InvalidOperationException: Uncommitted new row cannot be deleted.\r\n   at System.Windows.Forms.DataGridViewRowCollection.RemoveAt(Int32 index)\r\n   at Exir.Factor.حذفسطرToolStripMenuItem_Click(Object sender, EventArgs e) in E:\\Exir\\Exir\\Factor.cs:line 1321";

                if (m.ToString() == Error_For_New_Row)
                {
                    Popup_Alarm_Action("خطا !", "سطر انتخاب شده تا زمانی که خالی باشد در فاکتور ثبت نمی شود");
                }

                else
                {
                    Popup_Alarm_Action("خطا !", "عملیات با مشکل مواجه شد");
                }
            }
        }

        void Write_New_Factor_Number_Action(object sender)
        {
            ComboBox Cmb = (ComboBox)sender;
            RadTextBox Txt = new RadTextBox();

            List<string> Data = new List<string>();

            switch (Cmb.Name.Split('_')[3])
            {
                case "Buy":

                    Data = File.ReadAllLines(Paths.Factor_Buy_txt(Person_Id, Cmb.Text)).ToList();
                    Txt = Txt_Factor_Number_Buy;

                    break;

                case "Sell":

                    Data = File.ReadAllLines(Paths.Factor_Sell_txt(Person_Id, Cmb.Text)).ToList();
                    Txt = Txt_Factor_Number_Sell;

                    break;

                case "ROS":

                    Data = File.ReadAllLines(Paths.Factor_ROS_txt(Person_Id, Cmb.Text)).ToList();
                    Txt = Txt_Factor_Number_ROS;

                    break;

                case "RFP":

                    Data = File.ReadAllLines(Paths.Factor_RFP_txt(Person_Id, Cmb.Text)).ToList();
                    Txt = Txt_Factor_Number_RFP;

                    break;
            }

            int New_Factor_Number = 1;

        Check_Exists_Factor_Number:

            foreach (string Find in Data)
            {
                if (Find.Split(Paths.Split_Char)[7] == New_Factor_Number.ToString())
                {
                    Data.Remove(Find);

                    New_Factor_Number++;
                    goto Check_Exists_Factor_Number;
                }
            }

            Txt.Text = New_Factor_Number.ToString();
        }

        private void Write_New_Factor_Number(object sender, EventArgs e)
        {
            Write_New_Factor_Number_Action(sender);
        }

        private void radTabbedFormControlTab1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            Dgb_Factor_Management.Print();
        }
    }
}