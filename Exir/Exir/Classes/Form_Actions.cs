using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Exir.Classes
{
    static class Form_Actions
    {
        private static Point MouseDownLocation;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRect
                            (
                            int nleft,
                            int nTop,
                            int nRight,
                            int nBatton,
                            int nWidthEllipse,
                            int nHeighEllipse
                            );
        static public void Border_Radius(Form Frm)
        {
            Frm.Region = Region.FromHrgn(CreateRoundRect(0, 0, Frm.Width, Frm.Height, 16, 16));
        }

        static public void DragControl(Form Frm)
        {
            Frm.MouseMove += Frm_MouseMove;

            Frm.MouseDown += Frm_MouseDown;
        }

        private static void Frm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form Frm = (Form)sender;

                Frm.Left = e.X + Frm.Left - MouseDownLocation.X;
                Frm.Top = e.Y + Frm.Top - MouseDownLocation.Y;
            }
        }

        private static void Frm_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
    }
}
