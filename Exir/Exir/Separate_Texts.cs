using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Exir
{
    class Separate_Texts
    {
        public static void Separatea(object obj)
        {
            List<Check_Text_Changed> CHTCH = new List<Check_Text_Changed>();

            decimal result;

            Check_Text_Changed New_CHTCH = new Check_Text_Changed();

            try
            {
                TextBox Txt = (TextBox)obj;

                if (CHTCH[CHTCH.Count - 1].Name != Txt.Name && CHTCH[CHTCH.Count - 1].Text != Txt.Text)
                {
                    New_CHTCH.Name = Txt.Name;
                    New_CHTCH.Text = Txt.Text;

                    if (!decimal.TryParse(Txt.Text, out result) || Txt.Text == "" || Txt.Text == "0")
                        return;

                    Anty_Slash_Win_Textbox(Txt);

                    decimal price;
                    price = decimal.Parse(Txt.Text, System.Globalization.NumberStyles.Currency);
                    Txt.Text = price.ToString("#,#");
                    Txt.SelectionStart = Txt.Text.Length;
                }
            }

            catch
            {
                try
                {
                    RadTextBox Txt = (RadTextBox)obj;

                    if (CHTCH[CHTCH.Count - 1].Name != Txt.Name && CHTCH[CHTCH.Count - 1].Text != Txt.Text)
                    {
                        New_CHTCH.Name = Txt.Name;
                        New_CHTCH.Text = Txt.Text;

                        if (!decimal.TryParse(Txt.Text, out result) || Txt.Text == "" || Txt.Text == "0")
                            return;

                        Anty_Slash_Radtextbox(Txt);

                        decimal price;
                        price = decimal.Parse(Txt.Text, System.Globalization.NumberStyles.Currency);
                        Txt.Text = price.ToString("#,#");
                        Txt.SelectionStart = Txt.Text.Length;
                    }
                }

                catch { }
            }
        }

        static void Anty_Slash_Radtextbox(RadTextBox Txt)
        {
            if (Txt.Text.Contains("/"))
                SystemSounds.Beep.Play();

            Txt.Text = Txt.Text.Replace(Paths.Split_Char.ToString(), "");
        }

        static void Anty_Slash_Win_Textbox(TextBox Txt)
        {
            if (Txt.Text.Contains("/"))
                SystemSounds.Beep.Play();

            Txt.Text = Txt.Text.Replace(Paths.Split_Char.ToString(), "");
        }
    }
}