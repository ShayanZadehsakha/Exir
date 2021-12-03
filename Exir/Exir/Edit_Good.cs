using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exir
{
    public partial class Edit_Good : Form
    {
        public string Person_Id;
        public string Good_Name;
        public string Stock;
        public string Price;
        public string Group;
        public string Groups;

        public Edit_Good(string good_name, string stock, string price, string group, string groups, string person_id, ComboBox cmb_Group, ComboBox cmb_Groups, ComboBox cmb_Good)
        {
            InitializeComponent();

            Cmb_Good.Text = good_name;
            Txt_Price.Text= price;
            Num_Stock.Value = Convert.ToDecimal(stock);
            Cmb_Group.Text = group;
            Cmb_Groups.Text = groups;
            Person_Id = person_id;
            Good_Name = good_name;
            Stock = stock;
            Price = price;
            Group = group;
            Groups = groups;

            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            Load_Data();

            foreach (string Find in cmb_Group.Items)
            {
                Cmb_Group.Items.Add(Find);
            }

            foreach (string Find in cmb_Groups.Items)
            {
                Cmb_Groups.Items.Add(Find);
            }

            foreach (string Find in cmb_Good.Items)
            {
                Cmb_Good.Items.Add(Find);
            }
        }

        void Load_Data()
        {
            string[] Data_Group = File.ReadAllLines(Paths.Group_txt(Person_Id));

            foreach (string Find in Data_Group)
            {
                Cmb_Group.Items.Add(Find.Split(Paths.Split_Char)[0]);
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cmb_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Group = Cmb_Group.Text;

            string[] Data_Group = File.ReadAllLines(Paths.Group_txt(Person_Id));

            foreach (string Find in Data_Group)
            {
                if (Find == Group)
                {
                    int i = 0;

                    foreach (string Find_Groups in Find.Split(Paths.Split_Char))
                    {
                        i++;

                        if (i != 1)
                        {
                            Cmb_Groups.Items.Add(Find_Groups);
                        }
                    }
                }
            }
        }

        private void Cmb_Groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Good();
        }

        void Load_Good()
        {
            string Group = Cmb_Group.Text;
            string Groups = Cmb_Groups.Text;

            string[] Data_Group = File.ReadAllLines(Paths.Group_txt(Person_Id));

            foreach (string Find in Data_Group)
            {
                if (Find == Group)
                {
                    int i = 0;

                    foreach (string Find_Groups in Find.Split(Paths.Split_Char))
                    {
                        i++;

                        if (i != 1)
                        {
                            if (Find_Groups == Groups)
                            {
                                foreach (string Find_Good in File.ReadAllLines(Paths.Groups_txt(Person_Id, Groups, Group)))
                                {
                                    Cmb_Good.Items.Add(Find_Good.Split(Paths.Split_Char)[0]);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Cmb_Good_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Good = Cmb_Good.Text;

            foreach (string Find_Good in File.ReadAllLines(Paths.Groups_txt(Person_Id, Cmb_Groups.Text, Cmb_Group.Text)))
            {
                if (Find_Good.Split(Paths.Split_Char)[0] == Good)
                {
                    Num_Stock.Value = Convert.ToDecimal(Find_Good.Split(Paths.Split_Char)[1]);
                    Txt_Price.Text= Find_Good.Split(Paths.Split_Char)[2];
                }
            }
        }

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            Remove_Good RG = new Remove_Good();
            Add_Good AG = new Add_Good();
     
            string Result_Remove = RG.Action(Person_Id, Group, Groups, Good_Name, Price, Stock);
            string Result_Add = AG.Action(Person_Id, Cmb_Good.Text, Cmb_Group.Text, Cmb_Groups.Text, Txt_Price.Text.Replace(",", ""), Num_Stock.Value.ToString());

            if (Result_Remove == "Try" && Result_Add == "Try")
            {
                popupNotifier2.TitleText = "انجام شد!";
                popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                popupNotifier2.Popup();
            }
            else
            {
                Remove_Good Rg = new Remove_Good();
                Add_Good Ag = new Add_Good();

                if (Result_Add == "Try")
                    Rg.Action(Person_Id, Cmb_Good.Text, Cmb_Group.Text, Cmb_Groups.Text, Txt_Price.Text.Replace(",", ""), Num_Stock.Value.ToString()); ;

                if (Result_Remove == "Try")
                    Ag.Action(Person_Id, Group, Groups, Good_Name, Price, Stock);

                popupNotifier1.TitleText = "انجام نشد!";
                popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
            Close();
        }

        private void Txt_Price_TextChanged(object sender, EventArgs e)
        {
            Separate_Texts.Separatea(sender);
        }

        void Anty_Slash(object obj)
        {
            Telerik.WinControls.UI.RadTextBox Txt = (Telerik.WinControls.UI.RadTextBox)obj;

            if (Txt.Text.Contains("/"))
                Error_Sound();

            Txt.Text = Txt.Text.Replace(Paths.Split_Char.ToString(), "");
        }

        public void Error_Sound()
        {
            SystemSounds.Beep.Play();
        }

        private void Cmb_Good_TextChanged(object sender, EventArgs e)
        {
            ComboBox Cmb = (ComboBox)sender;

            if (Cmb.Text.Contains("/"))
                Error_Sound();

            Cmb.Text = Cmb.Text.Replace(Paths.Split_Char.ToString(), "");
        }
    }
}