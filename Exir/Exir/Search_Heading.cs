using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Exir
{
    public partial class Search_Heading : RadForm
    {
        string Person_Id = "";

        Color Color_Btn = Color.FromArgb(255, 232, 207);
        Color Color_Btn2 = Color.FromArgb(227, 93, 59);

        public Search_Heading(string person_id)
        {
            InitializeComponent();

            Person_Id = person_id;

            Size = new Size(808, 391);

            Change_Focus_Border_Color();

            Btn_Total_Account_Click(Btn_Total_Account, null);
        }

        private void Load()
        {
            try
            {
                string[] Data = File.ReadAllLines(Paths.Heading_Total_Account_Txt(Person_Id));
                string[] Data_Code = File.ReadAllLines(Paths.Heading_Code(Person_Id));

                Dgb_Tot.Rows.Clear();
                Dgb_Def.Rows.Clear();
                Dgb_Det.Rows.Clear();

                foreach (string Find in Data_Code)
                {
                    if (Find.Split(Paths.Split_Char)[0] == "Tot" && Find.Split(Paths.Split_Char)[1].Contains(Txt_Name.Text) && Find.Split(Paths.Split_Char)[2].Contains(Txt_Code.Text))
                    {
                        Dgb_Tot.Rows.Add(Find.Split(Paths.Split_Char)[1], Find.Split(Paths.Split_Char)[2]);
                    }
                }

                foreach (string Find in Data)
                {
                    int i = 0;

                    foreach (string Find_Def in Find.Split(Paths.Split_Char))
                    {
                        i++;

                        if (i != 1)
                        {
                            foreach (string Find_Code in Data_Code)
                            {
                                if (Find_Code.Split(Paths.Split_Char)[0] == "Def" && Find_Code.Split(Paths.Split_Char)[1] == Find.Split(Paths.Split_Char)[0] && Find_Code.Split(Paths.Split_Char)[2] == Find_Def && Find_Code.Split(Paths.Split_Char)[2].Contains(Txt_Name_Def.Text) && Find_Code.Split(Paths.Split_Char)[3].Contains(Txt_Code_Def.Text))
                                {
                                    string Code_Tot = "";

                                    foreach (string Find_Code_Tot in Data_Code)
                                    {
                                        if (Find_Code_Tot.Split(Paths.Split_Char)[0] == "Tot" && Find_Code_Tot.Split(Paths.Split_Char)[1] == Find.Split(Paths.Split_Char)[0])
                                        {
                                            Code_Tot = Find_Code_Tot.Split(Paths.Split_Char)[2];
                                        }
                                    }

                                    Dgb_Def.Rows.Add(Find.Split(Paths.Split_Char)[0], Find_Def, Code_Tot + '/' + Find_Code.Split(Paths.Split_Char)[3]);
                                }
                            }
                        }
                    }
                }

                foreach (string Find in Data)
                {
                    int i = 0;

                    foreach (string Find_Def in Find.Split(Paths.Split_Char))
                    {
                        i++;

                        if (i != 1)
                        {
                            foreach (string Find_Code in Data_Code)
                            {
                                if (Find_Code.Split(Paths.Split_Char)[0] == "Det" && Find_Code.Split(Paths.Split_Char)[1] == Find.Split(Paths.Split_Char)[0] && Find_Code.Split(Paths.Split_Char)[2] == Find_Def && Find_Code.Split(Paths.Split_Char)[3].Contains(Txt_Name_Det.Text) && Find_Code.Split(Paths.Split_Char)[4].Contains(Txt_Code_Det.Text))
                                {
                                    string Code_Tot = "";
                                    string Code_Def = "";

                                    foreach (string Find_Code_Tot in Data_Code)
                                    {
                                        if (Find_Code_Tot.Split(Paths.Split_Char)[0] == "Tot" && Find_Code_Tot.Split(Paths.Split_Char)[1] == Find.Split(Paths.Split_Char)[0])
                                        {
                                            Code_Tot = Find_Code_Tot.Split(Paths.Split_Char)[2];
                                        }
                                    }

                                    foreach (string Find_Code_Def in Data_Code)
                                    {
                                        if (Find_Code_Def.Split(Paths.Split_Char)[0] == "Def" && Find_Code_Def.Split(Paths.Split_Char)[1] == Find.Split(Paths.Split_Char)[0] && Find_Code_Def.Split(Paths.Split_Char)[2] == Find_Def)
                                        {
                                            Code_Def = Find_Code_Def.Split(Paths.Split_Char)[3];
                                        }
                                    }

                                    Dgb_Det.Rows.Add(Find.Split(Paths.Split_Char)[0], Find_Def, Find_Code.Split(Paths.Split_Char)[3], Code_Tot + '/' + Code_Def + '/' + Find_Code.Split(Paths.Split_Char)[4]);
                                }
                            }
                        }
                    }
                }
            }

            catch { }
        }

        private void Change_Focus_Border_Color()
        {
            Txt_Name.TextBoxElement.FocusBorderColor = Color.FromArgb(30, 46, 175);
            Txt_Code.TextBoxElement.FocusBorderColor = Color.FromArgb(30, 46, 175);
            Txt_Name_Def.TextBoxElement.FocusBorderColor = Color.FromArgb(30, 46, 175);
            Txt_Code_Def.TextBoxElement.FocusBorderColor = Color.FromArgb(30, 46, 175);
            Txt_Name_Det.TextBoxElement.FocusBorderColor = Color.FromArgb(30, 46, 175);
            Txt_Code_Det.TextBoxElement.FocusBorderColor = Color.FromArgb(30, 46, 175);
        }

        private void Btn_Total_Account_Click(object sender, EventArgs e)
        {
            RadButton Btn = (RadButton)sender;

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

            Open_Panel();
        }

        private void Open_Panel()
        {
            if (Btn_Total_Account.BackColor == Color_Btn)
            {
                Pnl_Def.Hide();
                Pnl_Det.Hide();
                Pnl_Tot.Show();
                Pnl_Tot.Dock = DockStyle.Left;
            }

            else if (Btn_Definite_Account.BackColor == Color_Btn)
            {
                Pnl_Tot.Hide();
                Pnl_Det.Hide();
                Pnl_Def.Show();
                Pnl_Def.Dock = DockStyle.Left;
            }

            else
            {
                Pnl_Tot.Hide();
                Pnl_Def.Hide();
                Pnl_Det.Show();
                Pnl_Det.Dock = DockStyle.Left;
            }

            Load();
        }

        private void Labels_Click(object sender, EventArgs e)
        {
            Label Lbl = (Label)sender;

            if (Lbl == Lbl_Total_Account)
                Btn_Total_Account_Click(Btn_Total_Account, null);

            else if (Lbl == Lbl_Detailed_Account)
                Btn_Total_Account_Click(Btn_Detailed_Account, null);

            else
                Btn_Total_Account_Click(Btn_Definite_Account, null);
        }

        private void Txts_Text_Changed(object sender, EventArgs e)
        {
            Load();
        }

        private void Dgbs_MouseMove(object sender, MouseEventArgs e)
        {
            RadGridView Dgb = (RadGridView)sender;

            if (Dgb.RowCount != 0)
                Dgb.Cursor = Cursors.Cross;

            else
                Dgb.Cursor = Cursors.Default;
        }

        private void Dgb_Tot_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                Properties.Settings.Default.Selected_Heading_Type = "Tot";
                Properties.Settings.Default.Selected_Heading_Name = Dgb_Tot.CurrentRow.Cells[0].Value.ToString();
                Properties.Settings.Default.Selected_Heading_Code = Dgb_Tot.CurrentRow.Cells[1].Value.ToString();

                DialogResult = DialogResult.OK;
                Close();
            }

            catch { }
        }

        private void Dgb_Det_CellClick(object sender, GridViewCellEventArgs e)
        {
            Properties.Settings.Default.Selected_Heading_Type = "Det";
            Properties.Settings.Default.Selected_Heading_Name = Dgb_Det.CurrentRow.Cells[2].Value.ToString();
            Properties.Settings.Default.Selected_Heading_Code = Dgb_Det.CurrentRow.Cells[3].Value.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Dgb_Def_CellClick(object sender, GridViewCellEventArgs e)
        {
            Properties.Settings.Default.Selected_Heading_Type = "Def";
            Properties.Settings.Default.Selected_Heading_Name = Dgb_Def.CurrentRow.Cells[1].Value.ToString();
            Properties.Settings.Default.Selected_Heading_Code = Dgb_Def.CurrentRow.Cells[2].Value.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}