using System;
using System.Windows.Forms;

namespace Exir
{
    public partial class Custom_MessageBox : Telerik.WinControls.UI.RadForm
    {
        public Custom_MessageBox(string Factor_Number)
        {
            InitializeComponent();

            string Text_Lbl = "با این کار فاکتور " + Factor_Number + "پاک می شود و این کار بدون برگشت است";

            Lbl_Messeage.Text = Text_Lbl;
        }

        private void Btn_Remove_Management_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}