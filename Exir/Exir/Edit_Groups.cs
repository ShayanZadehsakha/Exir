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
    public partial class Edit_Groups : Telerik.WinControls.UI.RadForm
    {
        string Group_Name = "";
        string Groups_Name = "";
        string Person_Id = "";
        string Result_Remove = "";
        string Result_Add = "";
        List<string> Good_txt = new List<string>();

        public Edit_Groups(string Name_Group, string Name_Groups, string person_id)
        {
            InitializeComponent();

            Groups_Name = Name_Groups;
            Group_Name = Name_Group;
            Person_Id = person_id;

            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            Load_Cmb();

            Txt_Groups.Text = Name_Groups;
            Cmb_Group_In_Groups.Text = Name_Group;
        }

        void Load_Cmb()
        {
            string[] Data = File.ReadAllLines(Paths.Group_txt(Person_Id));

            foreach (string Find in Data)
            {
                Cmb_Group_In_Groups.Items.Add(Find.Split(Paths.Split_Char)[0]);

                if (Find.Split(Paths.Split_Char)[0] == Group_Name)
                {
                    if (Find.Contains(Paths.Split_Char))
                    {
                        int i = 0;

                        foreach (string Find_Groups in Find.Split(Paths.Split_Char))
                        {
                            i++;

                            if (i != 1)
                                Txt_Groups.Items.Add(Find_Groups);
                        }
                    }
                }
            }
        }

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string Find in File.ReadAllLines(Paths.Groups_txt(Person_Id, Groups_Name, Group_Name)))
                {
                    Good_txt.Add(Find);
                }

                Remove_Groups RG = new Remove_Groups();
                string Result_Remove = RG.Action(Group_Name, Groups_Name, Person_Id);

                Add_Groups AG = new Add_Groups();
                string Result_Add = AG.Action(Cmb_Group_In_Groups.Text, Txt_Groups.Text, Person_Id, null);

                if (Result_Add == "Try" && Result_Remove == "Try")
                {
                    Add_Good Ag = new Add_Good();

                    foreach (string Add_Good in Good_txt)
                    {
                        Ag.Action(Person_Id, Add_Good.Split(Paths.Split_Char)[0], Cmb_Group_In_Groups.Text, Txt_Groups.Text, Add_Good.Split(Paths.Split_Char)[2], Add_Good.Split(Paths.Split_Char)[1]);
                    }

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                    popupNotifier2.Popup();
                }

                else
                {
                    try
                    {
                        popupNotifier1.TitleText = "انجام نشد!";
                        popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                        popupNotifier1.Popup();

                        if (Result_Remove == "Try")
                        {
                            Add_Groups ag = new Add_Groups();
                            ag.Action(Group_Name, Groups_Name, Person_Id, null);

                            Add_Good ag_g = new Add_Good();

                            foreach (string Add_Good in Good_txt)
                            {
                                ag_g.Action(Person_Id, Add_Good.Split(Paths.Split_Char)[0], Add_Good.Split(Paths.Split_Char)[3], Add_Good.Split(Paths.Split_Char)[4], Add_Good.Split(Paths.Split_Char)[2], Add_Good.Split(Paths.Split_Char)[1]);
                            }
                        }

                        if (Result_Add == "Try")
                        {
                            Remove_Groups rg = new Remove_Groups();
                            rg.Action(Group_Name, Groups_Name, Person_Id);
                        }
                    }
                    catch { }
                }
            }
            catch { }

            Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void anty_slash(object sender, EventArgs e)
        {
            ComboBox Cmb = (ComboBox)sender;

            if (Cmb.Text.Contains("/"))
                Error_Sound();

            Cmb.Text = Cmb.Text.Replace(Paths.Split_Char.ToString(), "");
        }

        public void Error_Sound()
        {
            SystemSounds.Beep.Play();
        }
    }
}