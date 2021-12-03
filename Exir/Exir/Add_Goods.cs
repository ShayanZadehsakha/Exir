using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Exir
{
    public partial class Add_Goods : Telerik.WinControls.UI.RadTabbedForm
    {
        string Person_Id = "";
        string Path_Group_txt;

        public Add_Goods(string PersonId)
        {
            InitializeComponent();

            Person_Id = PersonId;

            AllowAero = false;
            popupNotifier1.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier1.Size.Height);
            popupNotifier2.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, popupNotifier2.Size.Height);

            Path_Group_txt = Paths.Group_txt(Person_Id);
        }

        void Change_Font(Font font)
        {
            label1.Font = font;
            label2.Font = font;
            label3.Font = font;
            label4.Font = font;
            label5.Font = font;
            Txt_Good.Font = font;
            Txt_Group.Font = font;
            Cmb_Groups_In_Groups.Font = font;
            Txt_Price.Font = font;
        }

        private void Btn_Add_Group_Click(object sender, EventArgs e)
        {
            Add_Group AG = new Add_Group();

            string Result;

            try
            {
                Result = AG.Add_Group_Action(Txt_Group.Text, Person_Id);
            }
            catch
            {
                Result = "catch";
            }

            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "گروه " + " " + Txt_Group.Text + " " + "با موفقیت ثبت شد";
                    popupNotifier2.Popup();

                    break;

                case "Repaet":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "گروهی با نام" + " " + Txt_Group.Text + " " + "در سیستم موجود است";
                    popupNotifier1.Popup();

                    break;

                case "catch":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                    popupNotifier1.Popup();

                    break;
            }
            Txt_Group.Text = "";
            Form_Load();
        }

        private void Add_Goods_Load(object sender, EventArgs e)
        {
            try
            {
                Form_Load();
                Cmb_Group_In_Groups.Text = Dgb_Groups.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch { }
        }

        void Load_Cmb_Group(ComboBox Cmb)
        {
            Cmb.Items.Clear();

            string[] Data = File.ReadAllLines(Path_Group_txt);

            foreach (string Find in Data)
            {
                Cmb.Items.Add(Find.Split(Paths.Split_Char)[0]);
            }
        }
        void Load_Cmb_Groups(ComboBox Cmb, ComboBox Cmb_Group, bool Select)
        {
            Cmb.Items.Clear();

            foreach (string Find in File.ReadAllLines(Paths.Group_txt(Person_Id)))
            {
                if (Cmb_Group.Text == Find.Split(Paths.Split_Char)[0])
                {
                    if (Find.Contains(Paths.Split_Char))
                    {
                        int i = 0;

                        foreach (string Find_Groups in Find.Split(Paths.Split_Char))
                        {
                            i++;

                            if (i != 1)
                                Cmb.Items.Add(Find_Groups);

                            else if (i != 1 && Select)
                                Cmb.Text = Find_Groups;
                        }
                    }
                    else
                    {
                        Cmb.Items.Add("زیرگروهی وجود ندارد");
                        Cmb.Text = "زیرگروهی در سیستم ثبت نشده";
                    }
                }
            }
        }

        void Form_Load()
        {
            try
            {
                if (!File.Exists("C:/Exir/" + Person_Id))
                    Directory.CreateDirectory("C:/Exir/" + Person_Id);

                if (!File.Exists("C:/Exir/" + Person_Id + "/Group.txt"))
                {
                    var a = File.Create("C:/Exir/" + Person_Id + "/Group.txt");
                    a.Close();
                }

                Cmb_Groups.Items.Clear();
                Cmb_Groups.Items.Add("گروهی انتخاب نشده");
                Cmb_Group.Items.Add("گروهی در سیستم ثبت نشده");
                Cmb_Group_In_Groups.Items.Add("گروهی در سیستم ثبت نشده");
                Cmb_Groups_In_Groups.Items.Add("زیرگروهی در سیستم ثبت نشده");
                Load_Goods(Dgb_Good);
                Load_Data(Dgb_Group);
                Load_Data(Dgb_Groups);
                Load_Cmb_Group(Cmb_Group);
                Load_Cmb_Group(Cmb_Group_In_Groups);
                Load_Cmb_Group(Txt_Group);
                Load_Cmb_Good(Txt_Good);

                Txt_Group.Text = "گروه";
                Txt_Good.Text = "";
                Num_Stock.Value = 0;
                Txt_Price.Text= "0";
                Cmb_Group.Text = "";
                Cmb_Groups.Text = "";
                Cmb_Group_In_Groups.Text = "گروه";
                Cmb_Groups_In_Groups.Text = "زیرگروه";
            }
            catch
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "عملیات بارگزاری اطلاعات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        void Load_Cmb_Good(ComboBox Cmb)
        {
            string Group = Cmb_Group.Text;
            string Groups = Cmb_Groups.Text;

            Cmb.Items.Clear();

            string[] Data_Group = File.ReadAllLines(Paths.Group_txt(Person_Id));

            foreach (string Find in Data_Group)
            {
                if (Find.Split(Paths.Split_Char)[0] == Group)
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
                                    Cmb.Items.Add(Find_Good.Split(Paths.Split_Char)[0]);
                                }
                            }
                        }
                    }
                }
            }
        }

        void Load_Data(Telerik.WinControls.UI.RadGridView Dgb)
        {
            Dgb.Rows.Clear();

            string[] Data = File.ReadAllLines(Path_Group_txt);
            string find_Groups = "";

            foreach (string Find in Data)
            {
                int I = 0;

                find_Groups = "";

                foreach (string find in Find.Split(Paths.Split_Char))
                {
                    I++;

                    if (I != 1)
                    {
                        if (I == 2)
                            find_Groups += find;

                        else
                            find_Groups += Paths.Split_Char + find;
                    }
                }

                find_Groups = find_Groups.Replace('/', ',');

                Dgb.Rows.Add(Find.Split(Paths.Split_Char)[0], find_Groups);
            }
        }
        void Load_Goods(Telerik.WinControls.UI.RadGridView Dgb)
        {
            Dgb.Rows.Clear();
            string[] Add_In_Dgb = new string[3];

            string[] Data = File.ReadAllLines(Path_Group_txt);

            string find_Groups = "";
            string find_Good = "";

            if (Data.Count() != 0)
            {
                foreach (string Find_Group in Data)
                {
                    if (Find_Group.Contains(Paths.Split_Char))
                    {
                        Add_In_Dgb[0] = Find_Group.Split(Paths.Split_Char)[0];

                        int I = 0;

                        foreach (string Find_Groups in Find_Group.Split(Paths.Split_Char))
                        {
                            I++;

                            if (I != 1)
                            {
                                find_Groups = Find_Groups;

                                Add_In_Dgb[1] += find_Groups;

                                bool Exists_Good;
                                Exists_Good = false;

                                string[] Good_Data = File.ReadAllLines(Paths.Path_Files + Paths.Split_Char + Person_Id + Paths.Split_Char + Add_In_Dgb[0] + '_' + find_Groups + ".txt");

                                if (Good_Data != null)
                                {
                                    foreach (string Find_Good in Good_Data)
                                    {
                                        Exists_Good = true;
                                        find_Good += Find_Good.Split(Paths.Split_Char)[0];

                                        Add_In_Dgb[2] = find_Good;

                                        Dgb.Rows.Add(Add_In_Dgb[0], Add_In_Dgb[1], Add_In_Dgb[2]);

                                        find_Good = "";
                                        Add_In_Dgb[2] = "";
                                    }
                                }

                                if (!Exists_Good)
                                    Dgb.Rows.Add(Add_In_Dgb[0], Add_In_Dgb[1], "");


                                Add_In_Dgb[1] = "";
                            }
                        }
                    }
                    else
                        Dgb.Rows.Add(Find_Group, "", "");
                }
            }
        }

        private void Btn_Remove_Group_Click(object sender, EventArgs e)
        {
            Remove_Group_Button_Action();
        }

        void Remove_Group_Button_Action()
        {
            Remove_Group RG = new Remove_Group();
            string Result = Remove_Group.Remove_Group_Action(Txt_Group.Text, Person_Id);

            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "گروه" + " " + Txt_Group.Text + " " + "با موفقیت حذف شد";
                    popupNotifier2.Popup();

                    break;

                case "N_Exists":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "گروهی با نام" + " " + Txt_Group.Text + " " + "در سیستم وجود ندارد";
                    popupNotifier1.Popup();

                    break;

                case "catch":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                    popupNotifier1.Popup();

                    break;
            }

            Txt_Group.Text = "";
            Form_Load();
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            Edit_Group_Button_Action();
        }

        void Edit_Group_Button_Action()
        {
            Edit_Group EG = new Edit_Group(Dgb_Group, Person_Id, Txt_Group.Text);
            EG.ShowDialog();

            Txt_Group.Text = "";
            Form_Load();
        }

        private void Btn_Add_Groups_Click(object sender, EventArgs e)
        {
            try
            {
                Add_Groups AG = new Add_Groups();
                Poppup(AG.Action(Cmb_Group_In_Groups.Text.ToString(), Cmb_Groups_In_Groups.Text.ToString(), Person_Id, null));
            }
            catch
            {
                try
                {
                    Poppup("catch");
                }
                catch { }
            }
            Form_Load();
            Cmb_Group_In_Groups.Text = Dgb_Groups.SelectedRows[0].Cells[0].Value.ToString();
        }

        void Poppup(string Result)
        {
            switch (Result)
            {
                case "Try":

                    popupNotifier2.TitleText = "انجام شد!";
                    popupNotifier2.ContentText = "زیرگروه" + " " + Cmb_Groups_In_Groups.Text + " " + "با موفقیت اضافه شد";
                    popupNotifier2.Popup();

                    break;

                case "N_Exists":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "گروهی با نام" + " " + Cmb_Group_In_Groups.SelectedText + " " + "در سیستم وجود ندارد";
                    popupNotifier1.Popup();

                    break;

                case "catch":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                    popupNotifier1.Popup();

                    break;

                case "Exists":

                    popupNotifier1.TitleText = "انجام نشد!";
                    popupNotifier1.ContentText = "زیرگروهی با نام" + " " + Cmb_Groups_In_Groups.Text + " " + "در گروه مورد نظر وجود دارد";
                    popupNotifier1.Popup();

                    break;
            }
            Cmb_Groups_In_Groups.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Remove_Groups_Button_Action();
        }

        void Remove_Groups_Button_Action()
        {
            try
            {
                Remove_Groups RG = new Remove_Groups();
                string Result = RG.Action(Cmb_Group_In_Groups.Text, Cmb_Groups_In_Groups.Text, Person_Id);

                switch (Result)
                {
                    case "Try":

                        popupNotifier2.TitleText = "انجام شد!";
                        popupNotifier2.ContentText = "زیرگروه" + " " + Cmb_Groups_In_Groups.Text + " " + "با موفقیت حذف  شد";
                        popupNotifier2.Popup();

                        break;

                    case "catch":

                        popupNotifier1.TitleText = "انجام نشد!";
                        popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                        popupNotifier1.Popup();

                        break;

                    case "N_Exists_Group":

                        popupNotifier1.TitleText = "انجام نشد!";
                        popupNotifier1.ContentText = "گروهی با نام " + Cmb_Group_In_Groups.Text + " در سیستم ذخیره نشده";
                        popupNotifier1.Popup();

                        break;

                    case "N_Exists_Groups":

                        popupNotifier1.TitleText = "انجام نشد!";
                        popupNotifier1.ContentText = "زیرگروهی با نام " + Cmb_Groups_In_Groups.Text + " در سیستم ذخیره نشده";
                        popupNotifier1.Popup();

                        break;
                }
            }
            catch { }

            Form_Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Edit_Groups_Button_Action();
        }

        void Edit_Groups_Button_Action()
        {
            Edit_Groups EG = new Edit_Groups(Cmb_Group_In_Groups.Text, Cmb_Groups_In_Groups.Text, Person_Id);
            EG.ShowDialog();

            Form_Load();
        }

        private void Cmb_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Groups(Cmb_Groups, Cmb_Group.Text);
        }

        void Load_Groups(ComboBox Cmb, string Group)
        {
            try
            {
                Cmb.Items.Clear();
                foreach (string Find in File.ReadAllLines(Paths.Group_txt(Person_Id)))
                {
                    if (Find.Split(Paths.Split_Char)[0] == Group)
                    {
                        int i = 0;

                        foreach (string Find1 in Find.Split(Paths.Split_Char))
                        {
                            i++;

                            if (i != 1)
                            {
                                Cmb.Items.Add(Find1);
                            }
                        }
                    }
                }
            }
            catch
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "عملیات بارگزاری اطلاعات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Add_Good AG = new Add_Good();
                string Result = AG.Action(Person_Id, Txt_Good.Text, Cmb_Group.Text, Cmb_Groups.Text, Txt_Price.Text.Replace(",", ""), Num_Stock.Value.ToString());

                switch (Result)
                {
                    case "Try":

                        popupNotifier2.TitleText = "انجام شد!";
                        popupNotifier2.ContentText = "کالا" + " " + Txt_Good.Text + " " + "با موفقیت اضافه شد";
                        popupNotifier2.Popup();

                        break;

                    case "catch":

                        popupNotifier1.TitleText = "انجام نشد!";
                        popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                        popupNotifier1.Popup();

                        break;

                    case "N_Exists_Group":

                        popupNotifier1.TitleText = "انجام نشد!";
                        popupNotifier1.ContentText = "گروهی با این نام در سیستم وجود ندارد";
                        popupNotifier1.Popup();

                        break;

                    case "N_Exists_Groups":

                        popupNotifier1.TitleText = "انجام نشد!";
                        popupNotifier1.ContentText = "زیرگروهی با این نام در سیستم وجود ندارد";
                        popupNotifier1.Popup();

                        break;

                    case "Equals":

                        popupNotifier1.TitleText = "انجام نشد!";
                        popupNotifier1.ContentText = "کالایی با این نام در سیستم ثبت شده";
                        popupNotifier1.Popup();

                        break;
                }
            }
            catch { }

            Form_Load();
            Load_Infos_In_Good();
        }

        void Load_Infos_In_Good()
        {
            Cmb_Group.Text = "";
            Cmb_Groups.Text = "";
            Cmb_Group.Items.Clear();
            Cmb_Groups.Items.Clear();
            Txt_Good.Text = "";
            Num_Stock.Value = 0;
            Txt_Price.Text = "";

            Cmb_Group.Text = Dgb_Good.CurrentRow.Cells[0].Value.ToString();
            Cmb_Groups.Text = Dgb_Good.CurrentRow.Cells[1].Value.ToString();
            Cmb_Group.Items.Add(Dgb_Good.CurrentRow.Cells[0].Value.ToString());
            Txt_Good.Text = Dgb_Good.CurrentRow.Cells[2].Value.ToString();

            Load_Cmb_Group(Cmb_Group);
            Load_Cmb_Groups(Cmb_Groups, Cmb_Group, true);
            Load_Cmb_Good(Txt_Good);


            foreach (string Find in File.ReadAllLines(Paths.Groups_txt(Person_Id, Dgb_Good.CurrentRow.Cells[1].Value.ToString(), Dgb_Good.CurrentRow.Cells[0].Value.ToString())))
            {
                if (Find.Split(Paths.Split_Char)[0] == Dgb_Good.CurrentRow.Cells[2].Value.ToString())
                {
                    Num_Stock.Value = Convert.ToDecimal(Find.Split(Paths.Split_Char)[1]);
                    Txt_Price.Text = Find.Split(Paths.Split_Char)[2];
                }
            }
        }

        private void Dgb_Good_Click(object sender, EventArgs e)
        {
            try
            {
                Load_Infos_In_Good();
            }
            catch
            {
                popupNotifier1.TitleText = "خطا";
                popupNotifier1.ContentText = "عملیات بارگزاری اطلاعات با مشکل مواجه شد";
                popupNotifier1.Popup();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Edit_Good_Button_Action();
        }

        void Edit_Good_Button_Action()
        {
            try
            {
                string[] Data_Group = File.ReadAllLines(Paths.Group_txt(Person_Id));

                bool Exists_Group = false;
                bool Exists_Groups = false;
                bool Exists_Good = false;

                foreach (string Find in Data_Group)
                {
                    if (Find.Split(Paths.Split_Char)[0] == Cmb_Group.Text)
                    {
                        Exists_Group = true;

                        int i = 0;

                        foreach (string Find_Groups in Find.Split(Paths.Split_Char))
                        {
                            i++;

                            if (i != 1)
                            {
                                if (Find_Groups == Cmb_Groups.Text)
                                {
                                    Exists_Groups = true;
                                }
                            }
                        }
                    }
                }

                foreach (string Find_Good in File.ReadAllLines(Paths.Groups_txt(Person_Id, Cmb_Groups.Text, Cmb_Group.Text)))
                {
                    if (Find_Good.Split(Paths.Split_Char)[0] == Txt_Good.Text)
                        Exists_Good = true;
                }

                if (!Exists_Group)
                {
                    popupNotifier1.TitleText = "خطا";
                    popupNotifier1.ContentText = "گروهی با این نام در سیستم وجود ندارد";
                    popupNotifier1.Popup();
                }

                if (!Exists_Groups)
                {
                    popupNotifier1.TitleText = "خطا";
                    popupNotifier1.ContentText = "زیرگروهی با این نام در سیستم وجود ندارد";
                    popupNotifier1.Popup();
                }

                if (!Exists_Good)
                {
                    popupNotifier1.TitleText = "خطا";
                    popupNotifier1.ContentText = "کالایی با این اطلاعات در سیستم وجود ندارد";
                    popupNotifier1.Popup();
                }

                if (Exists_Good && Exists_Group && Exists_Groups)
                {
                    Edit_Good EG = new Edit_Good(Txt_Good.Text, Num_Stock.Value.ToString(), Txt_Price.Text.Replace(",", ""), Cmb_Group.Text, Cmb_Groups.Text, Person_Id, Cmb_Group, Cmb_Groups, Txt_Good);
                    EG.ShowDialog();
                }

                Form_Load();
                Load_Infos_In_Good();

            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Remove_Good_Button_Action();
        }

        void Remove_Good_Button_Action()
        {
            try
            {
                Remove_Good RG = new Remove_Good();
                string Result = RG.Action(Person_Id, Cmb_Group.Text, Cmb_Groups.Text, Txt_Good.Text, Txt_Price.Text.Replace(",", ""), Num_Stock.Value.ToString());

                switch (Result)
                {
                    case "Try":

                        popupNotifier2.TitleText = "انجام شد!";
                        popupNotifier2.ContentText = "کالا" + " " + Txt_Good.Text + " " + "با موفقیت حذف شد";
                        popupNotifier2.Popup();

                        break;

                    case "N_Exists":

                    case "Equals":

                        popupNotifier1.TitleText = "انجام نشد!";
                        popupNotifier1.ContentText = "کالایی با این نام در سیستم ثبت نشده";
                        popupNotifier1.Popup();

                        break;

                    case "catch":

                        popupNotifier1.TitleText = "انجام نشد!";
                        popupNotifier1.ContentText = "عملیات با مشکل مواجه شد";
                        popupNotifier1.Popup();

                        break;
                }
            }
            catch { }

            Form_Load();
            Load_Infos_In_Good();
        }

        private void Dgb_Group_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Txt_Group.Text = Dgb_Group.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch { }
        }

        public void Error_Sound()
        {
            SystemSounds.Beep.Play();
        }

        void Anty_Slash(object obj)
        {
            Telerik.WinControls.UI.RadTextBox Txt = (Telerik.WinControls.UI.RadTextBox)obj;

            if (Txt.Text.Contains("/"))
                Error_Sound();

            Txt.Text = Txt.Text.Replace(Paths.Split_Char.ToString(), "");
        }

        void Anty_Slash_Cmb(object obj)
        {
            ComboBox Cmb = (ComboBox)obj;

            if (Cmb.Text.Contains("/"))
                Error_Sound();

            Cmb.Text = Cmb.Text.Replace(Paths.Split_Char.ToString(), "");
        }

        private void Txt_Price_TextChanged(object sender, EventArgs e)
        {
            Separate_Texts.Separatea(sender);
        }

        private void Cmb_Group_In_Groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Cmb_Groups(Cmb_Groups_In_Groups, Cmb_Group_In_Groups, false);
        }

        private void Dgb_Groups_Click(object sender, EventArgs e)
        {
            if (Dgb_Groups.SelectedRows.Count != 0)
            {
                Cmb_Group_In_Groups.Text = Dgb_Groups.SelectedRows[0].Cells[0].Value.ToString();
                Cmb_Groups_In_Groups.Text = Dgb_Groups.SelectedRows[0].Cells[1].Value.ToString().Split(',')[0];
            }
        }

        private void Anty_slash(object sender, EventArgs e)
        {
            Anty_Slash_Cmb(sender);
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove_Good_Button_Action();
        }

        private void تغییرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_Good_Button_Action();
        }

        private void تغییرToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Edit_Groups_Button_Action();
        }

        private void حذفToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Remove_Groups_Button_Action();
        }

        private void حذفToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Remove_Group_Button_Action();
        }

        private void تغییرToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Edit_Group_Button_Action();
        }

        private void Dgb_Groups_ValueChanged(object sender, EventArgs e)
        {
            Dgb_Groups_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}