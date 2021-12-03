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
    public partial class Document : RadTabbedForm
    {
        string Person_Id = "";
        public Document(string person_id)
        {
            InitializeComponent();

            Person_Id = person_id;

            AllowAero = false;

            Load_Default();
        }

        private void Load_Default()
        {
            Dgb_Document.Rows.Clear();
            Dgb_Document.Rows.Add();

            Column1.Text = "انتخاب";
            Column1.UseColumnTextForButtonValue = true;


            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            Load_Number();
        }

        private void Load_Number()
        {
            string[] Data = File.ReadAllLines(Paths.Document_Numbers(Person_Id));

            int Num = 0;

            bool Check = false;

            do
            {
                Check = false;

                Num++;

                foreach (string Find in Data)
                {
                    if (int.Parse(Find) == Num)
                    {
                        Check = true;

                        break;
                    }
                }

            } while (Check);

            Num_Number_Document.Value = Num;

            if (Data.Count() != 0)
            {
                Lbl_Last_Number.Text = Data[Data.Count() - 1].ToString();
                Lbl_Last_Number_Report.Text = Data[Data.Count() - 1].ToString();
                Lbl_Last_Number.Visible = true;
                Lbl_Last_Document_Number.Visible = true;
                Lbl_Last_Number_Report.Visible = true;
                Lbl_Title_Report.Visible = true;
            }

            else
            {
                Lbl_Last_Document_Number.Visible = false;
                Lbl_Last_Number.Visible = false;
                Lbl_Last_Number_Report.Visible = false;
                Lbl_Title_Report.Visible = false;
            }
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

        public void Error_Sound()
        {
            SystemSounds.Beep.Play();
        }

        private RadTextBox Get_Txt(RadTextBox Txt)
        {
            try
            {
                if (Txt == Txt_Day_Management)
                    return Txt_Month_Management;

                return Txt_Day_Management;
            }
            catch
            {
                return null;
            }
        }

        private void Btn_Apply_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Txt_Day_Management.Text) || string.IsNullOrEmpty(Txt_Month_Management.Text) || string.IsNullOrEmpty(Txt_Year_Management.Text))
                {
                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "لطفا تاریخ را وارد کنید";
                    popupNotifier1.Popup();

                    return;
                }

                foreach (string Find in File.ReadAllLines(Paths.Document_Numbers(Person_Id)))
                {
                    if (Find == Num_Number_Document.Value.ToString())
                    {
                        popupNotifier1.TitleText = "خطا!";
                        popupNotifier1.ContentText = "سندی با این شماره وجود دارد";
                        popupNotifier1.Popup();

                        return;
                    }
                }

                int Count = 0;

                List<string> Rows = new List<string>();

                for (int i = 0; i < Dgb_Document.RowCount; i++)
                {
                    if (Dgb_Document.Rows[i].Cells[0].Value != null)
                        Count++;

                    if (Dgb_Document.Rows[i].Cells[3].Value != null && Dgb_Document.Rows[i].Cells[4].Value != null)
                    {
                        popupNotifier1.TitleText = "خطا!";
                        popupNotifier1.ContentText = "در هر سطر فقط یکی از مقادیر بدهکار یا بستانکار باید پر شود";
                        popupNotifier1.Popup();

                        return;
                    }

                    if (Dgb_Document.Rows[i].Cells[0].Value != null)
                        Rows.Add(Dgb_Document.Rows[i].Cells[0].Value.ToString());
                }

                if (Count < 2)
                {
                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "حداقل باید دو سطر پر شود";
                    popupNotifier1.Popup();

                    return;
                }

                else if (Count < Dgb_Document.RowCount - 1)
                {
                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "همه سطر ها غیر از سطر آخر باید پر شوند ( برای حذف راست کلیک کنید )";
                    popupNotifier1.Popup();

                    return;
                }

                bool Not_Contain = false;

                foreach (string Find1 in Rows)
                {
                    foreach (string Find2 in Rows)
                    {
                        if (Find2 != Find1)
                            Not_Contain = true;
                    }

                    if (Not_Contain)
                        break;
                }

                if (!Not_Contain)
                {
                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "باید حداقل دو سرفصل مختلف وارد شوند";
                    popupNotifier1.Popup();

                    return;
                }

                int C = 0;
                int D = 0;

                for (int i = 0; i < Dgb_Document.RowCount - 1; i++)
                {
                    int result;

                    if (Dgb_Document.Rows[i].Cells[3].Value == null && Dgb_Document.Rows[i].Cells[4].Value == null)
                    {
                        popupNotifier1.TitleText = "خطا!";
                        popupNotifier1.ContentText = "در هر سطر حداقل یکی از ستون های بدهکار یا بستانکار باید پر شود";
                        popupNotifier1.Popup();

                        return;
                    }

                    if (Dgb_Document.Rows[i].Cells[3].Value != null && !int.TryParse(Dgb_Document.Rows[i].Cells[3].Value.ToString(), out result) || Dgb_Document.Rows[i].Cells[4].Value != null && !int.TryParse(Dgb_Document.Rows[i].Cells[4].Value.ToString(), out result))
                    {
                        popupNotifier1.TitleText = "خطا!";
                        popupNotifier1.ContentText = "مقادیر وارد شده در ستون بدهکار یا بستانکار فقط باید عدد باشد";
                        popupNotifier1.Popup();

                        return;
                    }

                    if (Dgb_Document.Rows[i].Cells[3].Value != null)
                        D += int.Parse(Dgb_Document.Rows[i].Cells[3].Value.ToString());

                    if (Dgb_Document.Rows[i].Cells[4].Value != null)
                        C += int.Parse(Dgb_Document.Rows[i].Cells[4].Value.ToString());

                    switch (Dgb_Document.Rows[i].Cells[5].Value.ToString())
                    {
                        case "Tot":

                            foreach (string Find in File.ReadAllLines(Paths.Heading_Total_Account_Type_Txt(Person_Id)))
                            {
                                if (Find.Split(Paths.Split_Char)[0] == Dgb_Document.Rows[i].Cells[1].Value.ToString())
                                {
                                    if (Dgb_Document.Rows[i].Cells[3].Value != null && !Convert.ToBoolean(Find.Split(Paths.Split_Char)[2]))
                                    {
                                        popupNotifier1.TitleText = "خطا!";
                                        popupNotifier1.ContentText = "حساب کل " + Find.Split(Paths.Split_Char)[0] + " فقط ماهیت بستانکار دارد و نمی تواند مقدار بدهکار دریافت کند";
                                        popupNotifier1.Popup();
                                    }

                                    if (Dgb_Document.Rows[i].Cells[4].Value != null && !Convert.ToBoolean(Find.Split(Paths.Split_Char)[1]))
                                    {
                                        popupNotifier1.TitleText = "خطا!";
                                        popupNotifier1.ContentText = "حساب کل " + Find.Split(Paths.Split_Char)[0] + " فقط ماهیت بدهکار دارد و نمی تواند مقدار بستانکار دریافت کند";
                                        popupNotifier1.Popup();
                                    }
                                }
                            }

                            break;

                        case "Def":

                            foreach (string Find in File.ReadAllLines(Paths.Heading_Code(Person_Id)))
                            {
                                if (Find.Split(Paths.Split_Char)[0] == "Tot" && Find.Split(Paths.Split_Char)[2] == Dgb_Document.Rows[i].Cells[0].Value.ToString().Split('/')[0])
                                {
                                    foreach (string Find_Type in File.ReadAllLines(Paths.Heading_Total_Account_Type_Txt(Person_Id)))
                                    {
                                        if (Find_Type.Split(Paths.Split_Char)[0] == Find.Split(Paths.Split_Char)[1])
                                        {
                                            if (Dgb_Document.Rows[i].Cells[3].Value != null && !Convert.ToBoolean(Find_Type.Split(Paths.Split_Char)[2]))
                                            {
                                                popupNotifier1.TitleText = "خطا!";
                                                popupNotifier1.ContentText = "حساب معین " + Find.Split(Paths.Split_Char)[0] + " فقط ماهیت بستانکار دارد و نمی تواند مقدار بدهکار دریافت کند";
                                                popupNotifier1.Popup();
                                            }

                                            if (Dgb_Document.Rows[i].Cells[4].Value != null && !Convert.ToBoolean(Find.Split(Paths.Split_Char)[1]))
                                            {
                                                popupNotifier1.TitleText = "خطا!";
                                                popupNotifier1.ContentText = "حساب معین " + Find.Split(Paths.Split_Char)[0] + " فقط ماهیت بدهکار دارد و نمی تواند مقدار بستانکار دریافت کند";
                                                popupNotifier1.Popup();
                                            }
                                        }
                                    }
                                }
                            }

                            break;

                        case "Det":

                            foreach (string Find in File.ReadAllLines(Paths.Heading_Code(Person_Id)))
                            {
                                if (Find.Split(Paths.Split_Char)[0] == "Tot" && Find.Split(Paths.Split_Char)[1] == Dgb_Document.Rows[i].Cells[0].Value.ToString().Split('/')[0])
                                {
                                    foreach (string Find_Type in File.ReadAllLines(Paths.Heading_Total_Account_Type_Txt(Person_Id)))
                                    {
                                        if (Find_Type.Split(Paths.Split_Char)[0] == Find.Split(Paths.Split_Char)[1])
                                        {
                                            if (Dgb_Document.Rows[i].Cells[3].Value != null && !Convert.ToBoolean(Find.Split(Paths.Split_Char)[2]))
                                            {
                                                popupNotifier1.TitleText = "خطا!";
                                                popupNotifier1.ContentText = "حساب تفصیلی " + Find.Split(Paths.Split_Char)[0] + " فقط ماهیت بستانکار دارد و نمی تواند مقدار بدهکار دریافت کند";
                                                popupNotifier1.Popup();
                                            }

                                            if (Dgb_Document.Rows[i].Cells[4].Value != null && !Convert.ToBoolean(Find.Split(Paths.Split_Char)[1]))
                                            {
                                                popupNotifier1.TitleText = "خطا!";
                                                popupNotifier1.ContentText = "حساب تفصیلی " + Find.Split(Paths.Split_Char)[0] + " فقط ماهیت بدهکار دارد و نمی تواند مقدار بستانکار دریافت کند";
                                                popupNotifier1.Popup();
                                            }
                                        }
                                    }
                                }
                            }

                            break;
                    }
                }

                if (D != C)
                {
                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "جمع مبلغ بستانکار و بدهکار باید برابر باشد";
                    popupNotifier1.Popup();

                    return;
                }

                for (int i = 0; i < Dgb_Document.RowCount - 1; i++)
                {
                    string Cell2 = "";
                    string Cell3 = "";
                    string Cell4 = "";

                    if (Dgb_Document.Rows[i].Cells[2].Value == null)
                        Cell2 = "";

                    else
                        Cell2 = Dgb_Document.Rows[i].Cells[2].Value.ToString();

                    if (Dgb_Document.Rows[i].Cells[3].Value == null)
                        Cell3 = "";

                    else
                        Cell3 = Dgb_Document.Rows[i].Cells[3].Value.ToString();

                    if (Dgb_Document.Rows[i].Cells[4].Value == null)
                        Cell4 = "";

                    else
                        Cell4 = Dgb_Document.Rows[i].Cells[4].Value.ToString();

                    File.AppendAllText(Paths.Document_txt(Person_Id, Num_Number_Document.Value.ToString()), Num_Number_Document.Value.ToString() + Paths.Split_Char + Txt_Year_Management.Text + Paths.Split_Char + Txt_Month_Management.Text + Paths.Split_Char + Txt_Day_Management.Text + Paths.Split_Char + Dgb_Document.Rows[i].Cells[0].Value.ToString().Replace(Paths.Split_Char, '_') + Paths.Split_Char + Dgb_Document.Rows[i].Cells[1].Value.ToString() + Paths.Split_Char + Cell2 + Paths.Split_Char + Cell3 + Paths.Split_Char + Cell4 + Paths.Split_Char + Dgb_Document.Rows[i].Cells[5].Value.ToString() + "\n");
                }

                File.AppendAllText(Paths.Document_Numbers(Person_Id), Num_Number_Document.Value.ToString() + "\n");

                popupNotifier2.TitleText = "انجام شد";
                popupNotifier2.ContentText = "سند شماره " + Num_Number_Document.Value.ToString() + " با موفقیت ثبت شد";
                popupNotifier2.Popup();

                Load_Default();
            }

            catch { }
        }

        private void حذفسطرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int Count = 0;

                for (int i = 0; i < Dgb_Document.Rows.Count; i++)
                {
                    if (Dgb_Document.Rows[i].Cells[0].Value == null)
                        Count++;
                }

                if (Count < 1 && Dgb_Document.CurrentRow.Cells[0].Value == null)
                {
                    popupNotifier1.TitleText = "خطا!";
                    popupNotifier1.ContentText = "سطر آخر فقط برای راحتی کار است و تاثیری در روند ثبت ندارد";
                    popupNotifier1.Popup();

                    return;
                }

                else
                    Dgb_Document.Rows.Remove(Dgb_Document.CurrentRow);
            }
            catch { }
        }

        private void اضافهکردنسطرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dgb_Document.Rows.Add();
        }

        private void Txt_Day_Management_TextChanged(object sender, EventArgs e)
        {
            Txt_Day_Text_Changed(sender);
        }

        private void Txt_Month_Management_TextChanged(object sender, EventArgs e)
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
                    Txt_Year_Management.Select();
                }

                if (Get_Txt(Txt).Text == "31" && Convert.ToInt32(Txt.Text) > 6)
                {
                    Get_Txt(Txt).Text = "30";
                }
            }
            catch { }
        }

        private void Dgb_Document_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell && e.RowIndex >= 0)
            {
                {
                    Search_Heading SH = new Search_Heading(Person_Id);

                    if (SH.ShowDialog() == DialogResult.OK)
                    {
                        for (int i = 0; i < Dgb_Document.RowCount; i++)
                        {
                            if (Dgb_Document.Rows[i].Cells[1].GetType().ToString() == "System.Windows.Forms.DataGridViewButtonCell")
                            {
                                Dgb_Document.Rows[i].Cells[1] = new DataGridViewTextBoxCell();
                                Dgb_Document.Rows[i].Cells[1].ReadOnly = true;


                                Dgb_Document.Rows[i].Cells[0].Value = Properties.Settings.Default.Selected_Heading_Code;
                                Dgb_Document.Rows[i].Cells[1].Value = Properties.Settings.Default.Selected_Heading_Name;
                                Dgb_Document.Rows[i].Cells[5].Value = Properties.Settings.Default.Selected_Heading_Type;

                                break;
                            }
                        }

                        Dgb_Document.Rows.Add();
                    }
                }
            }

        }

        private void Dgb_Document_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow Row in Dgb_Document.Rows)
            {
                Row.Height = 35;
            }
        }

        private void Num_Document_ValueChanged(object sender, EventArgs e)
        {
            if (Num_Document.Value == 0)
            {
                Num_Document.Value = 1;

                Error_Sound();
            }

            Dgb_Document_Report.Rows.Clear();

            string[] Data_Number = File.ReadAllLines(Paths.Document_Numbers(Person_Id));

            foreach (string Find in Data_Number)
            {
                if (Find == Num_Document.Value.ToString())
                {
                    string[] Data = File.ReadAllLines(Paths.Document_txt(Person_Id, Num_Document.Value.ToString()));

                    foreach (string Add in Data)
                    {
                        Txt_Year_Report.Text = Add.Split(Paths.Split_Char)[1];
                        Txt_Month_Report.Text = Add.Split(Paths.Split_Char)[2];
                        Txt_Day_Report.Text = Add.Split(Paths.Split_Char)[3];

                        Dgb_Document_Report.Rows.Add(Add.Split(Paths.Split_Char)[4].Replace('_', Paths.Split_Char), Add.Split(Paths.Split_Char)[5], Add.Split(Paths.Split_Char)[6], Add.Split(Paths.Split_Char)[7], Add.Split(Paths.Split_Char)[8]);
                    }

                    return;
                }
            }
        }
    }
}