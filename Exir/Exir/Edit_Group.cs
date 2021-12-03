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
    public partial class Edit_Group : Form
    {
        Telerik.WinControls.UI.RadGridView Dgb_Group;
        string Person_Id;

        List<string> Groups = new List<string>();
        List<string> Goods = new List<string>();
        List<Edit_Group_Groups_Txt> Groups_Txt = new List<Edit_Group_Groups_Txt>();

        public Edit_Group(Telerik.WinControls.UI.RadGridView dgb, string person_id, string Text)
        {
            InitializeComponent();

            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            Txt_Group.Text = Text;
            Dgb_Group = dgb;
            Person_Id = person_id;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        void Popup_Catch()
        {
            popupNotifier1.TitleText = "انجام نشد!";
            popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
            popupNotifier1.Popup();
        }
        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            int i = 0;

            foreach (string Find in Dgb_Group.SelectedRows[0].Cells[1].Value.ToString().Split(','))
            {
                Groups.Add(Find);
                Goods.Clear();

                foreach (string Find_Good in File.ReadAllLines(Paths.Groups_txt(Person_Id, Dgb_Group.SelectedRows[0].Cells[1].Value.ToString().Split(',')[i], Dgb_Group.SelectedRows[0].Cells[0].Value.ToString())))
                {
                    Goods.Add(Find_Good.Split(Paths.Split_Char)[0] + Paths.Split_Char + Find_Good.Split(Paths.Split_Char)[1] + Paths.Split_Char + Find_Good.Split(Paths.Split_Char)[2] + Paths.Split_Char + Txt_Group.Text + Paths.Split_Char + Find_Good.Split(Paths.Split_Char)[4]);
                }

                i++;

                Edit_Group_Groups_Txt EGGT = new Edit_Group_Groups_Txt(Find);

                foreach (string Add in Goods)
                {
                    EGGT.Add_Lsit(Add);
                }

                Groups_Txt.Add(EGGT);
            }

            string Result1 = Remove_Group.Remove_Group_Action(Dgb_Group.SelectedRows[0].Cells[0].Value.ToString(), Person_Id);

            Add_Group AG = new Add_Group();
            string Result2 = AG.Add_Group_Action(Txt_Group.Text, Person_Id);

            if (Result1 == "Try" && Result2 == "Try")
            {
                popupNotifier2.TitleText = "انجام شد!";
                popupNotifier2.ContentText = "عملیات با موفقیت انجام شد";
                popupNotifier2.Popup();

                Add_Groups A_GS = new Add_Groups();

                foreach (string Find in Groups)
                {
                    A_GS.Action(Txt_Group.Text, Find, Person_Id, null);
                }

                foreach (Edit_Group_Groups_Txt Write_Groups in Groups_Txt)
                {
                    foreach (string Write in Write_Groups.List_Txt)
                    {
                        if (Write_Groups.Groups_Name == Write.Split(Paths.Split_Char)[4])
                            File.AppendAllText(Paths.Path_Files + Person_Id + "/" + Txt_Group.Text + "_" + Write_Groups.Groups_Name + ".txt", Write + "\n");

                        foreach (Edit_Group_Groups_Txt Write1 in Groups_Txt)
                        {
                            File.Delete(Paths.Path_Files + Person_Id + "/" + Dgb_Group.SelectedRows[0].Cells[0].Value.ToString() + "_" + Write1.Groups_Name + ".txt");
                        }
                    }
                }

                Close();
            }
            else
            {
                if (Result2 != "Repaet")
                    Remove_Group.Remove_Group_Action(Txt_Group.Text, Person_Id);

                Add_Group Ag = new Add_Group();
                Ag.Add_Group_Action(Dgb_Group.SelectedRows[0].Cells[0].Value.ToString(), Person_Id);

                Add_Groups A_GS = new Add_Groups();

                foreach (string Find in Groups)
                {
                    A_GS.Action(Dgb_Group.SelectedRows[0].Cells[0].Value.ToString(), Find, Person_Id, null);
                }

                foreach (Edit_Group_Groups_Txt Write_Groups in Groups_Txt)
                {
                    foreach (string Write in Write_Groups.List_Txt)
                    {
                        File.AppendAllText(Dgb_Group.SelectedRows[0].Cells[0].Value.ToString() + "_" + Write_Groups.Groups_Name + ".txt", Write + "\n");
                    }
                }

                Popup_Catch();
            }
        }

        private void Txt_Group_TextChanged(object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadTextBox Txt = (Telerik.WinControls.UI.RadTextBox)sender;

            if (Txt.Text.Contains("/"))
                Error_Sound();

            Txt.Text = Txt.Text.Replace(Paths.Split_Char.ToString(), "");
        }

        public void Error_Sound()
        {
            SystemSounds.Beep.Play();
        }
    }
}