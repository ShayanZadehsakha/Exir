using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Exir
{
    public partial class Cash_Desk : RadForm
    {
        string Person_Id = "";
        public Cash_Desk(string person_id)
        {
            InitializeComponent();

            Person_Id = person_id;

            Form_Load();
        }

        void Form_Load()
        {
            try
            {
                if (!File.Exists(Paths.Cash_Desk_txt(Person_Id)))
                {
                    var a = File.Create(Paths.Cash_Desk_txt(Person_Id));
                    a.Close();
                }

                Dgb_Cash_Desk.Rows.Clear();

                string[] Data = File.ReadAllLines(Paths.Cash_Desk_txt(Person_Id));

                if (Data.Count() == 0)
                {
                    Dgb_Cash_Desk.Rows.Add("صندوقی در سیستم ثبت نشده");
                    Txt_Cash_Desk.Text = "";
                }

                foreach (string Find in Data)
                {
                    Dgb_Cash_Desk.Rows.Add(Find);
                }
            }
            catch
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "عملیات بارگزاری اطلاعات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            try
            {
                Add_Cash_Desk ACD = new Add_Cash_Desk();
                string Result = ACD.Action(Person_Id, Txt_Cash_Desk.Text);

                switch (Result)
                {
                    case "Try":

                        popupNotifier2.TitleText = "انجام شد!";
                        popupNotifier2.ContentText = "صندوق" + " " + Txt_Cash_Desk.Text + " " + "با موفقیت اضافه شد";
                        popupNotifier2.Popup();

                        break;

                    case "Exists":

                        popupNotifier1.TitleText = "انجام نشد!";
                        popupNotifier1.ContentText = "صندوقی با این نام در سیستم وجود دارد";
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
            catch
            {
                popupNotifier1.TitleText = "انجام نشد!";
                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        private void Dgb_Cash_Desk_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (Dgb_Cash_Desk.SelectedRows != null)
                    Txt_Cash_Desk.Text = Dgb_Cash_Desk.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "عملیات بارگزاری اطلاعات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                Remove_Cash_Desk RCD = new Remove_Cash_Desk();
                string Result = RCD.Action(Person_Id, Txt_Cash_Desk.Text);

                switch (Result)
                {
                    case "Try":

                        popupNotifier2.TitleText = "انجام شد!";
                        popupNotifier2.ContentText = "صندوق" + " " + Txt_Cash_Desk.Text + " " + "با موفقیت حذف شد";
                        popupNotifier2.Popup();

                        break;

                    case "N_Exists":

                        popupNotifier1.TitleText = "انجام نشد!";
                        popupNotifier1.ContentText = "صندوقی با این نام در سیستم وجود ندارد";
                        popupNotifier1.Popup();

                        break;

                    case "catch":

                        popupNotifier1.TitleText = "انجام نشد!";
                        popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                        popupNotifier1.Popup();

                        break;
                }

                Financial F = new Financial();
                string Find = F.Stock(Person_Id, "CD", Name);
                
                Form_Load();
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
