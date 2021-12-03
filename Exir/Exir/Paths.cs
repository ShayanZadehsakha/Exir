using System.IO;

namespace Exir
{
    class Paths
    {
        public static void Exists_Files_Without_Input()
        {
            if (!Directory.Exists(App_Directory))
            {
                Directory.CreateDirectory(App_Directory);
            }

            if (!File.Exists(Login_txt))
            {
                var a = File.Create(Login_txt);
                a.Close();
            }
        }

        public static string Login_txt = "C:/Exir/Login.txt";
        public static string Path_Files = "C:/Exir/";
        public static string App_Directory = "C:/Exir";

        public static char Split_Char = '/';

        public static string Font0_txt(string Person_Id)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Font1.txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Font1.txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Font1.txt";
        }


        public static string Group_txt(string Person_Id)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Group.txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Group.txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Group.txt";
        }

        public static string Document_txt(string Person_Id, string Number)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Document_" + Number.ToString() + ".txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Document_" + Number.ToString() + ".txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Document_" + Number.ToString() + ".txt";
        }

        public static string Document_Numbers(string Person_Id)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Document_Numbers.txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Document_Numbers.txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Document_Numbers.txt";
        }

        public static string Heading_Total_Account_Txt(string Person_Id)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Total_Account.txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Total_Account.txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Total_Account.txt";
        }
        public static string Heading_Code(string Person_Id)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Heading_Code.txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Heading_Code.txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Heading_Code.txt";
        }

        public static string Heading_Total_Account_Type_Txt(string Person_Id)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Total_Account_Type.txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Total_Account_Type.txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Total_Account_Type.txt";
        }

        public static string Total_Account_Type_Txt(string Person_Id)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Total_Account_Type.txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Total_Account_Type.txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Total_Account_Type.txt";
        }

        public static string Heading_Detail_Txt(string Person_Id, string Tot_Name, string Def_Name)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/" + Tot_Name + "_" + Def_Name + ".txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/" + Tot_Name + "_" + Def_Name + ".txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/" + Tot_Name + "_" + Def_Name + ".txt";
        }

        public static string Checks_Txt(string Person_Id)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Check.txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Check.txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Check.txt";
        }

        public static string Bank_Account_txt(string Person_Id)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Bank_Account" + ".txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Bank_Account" + ".txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Bank_Account" + ".txt";
        }

        public static string Bank_Account_User_txt(string Person_Id)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Bank_Account_User" + ".txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Bank_Account_User" + ".txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Bank_Account_User" + ".txt";
        }

        public static string Factor_Buy_txt(string Person_Id, string Account_Side)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/" + Account_Side + "_Factor_B" + ".txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/" + Account_Side + "_Factor_B" + ".txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/" + Account_Side + "_Factor_B" + ".txt";
        }

        public static string Factor_RFP_txt(string Person_Id, string Account_Side)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/" + Account_Side + "_Factor_RFP" + ".txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/" + Account_Side + "_Factor_RFP" + ".txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/" + Account_Side + "_Factor_RFP" + ".txt";
        }

        public static string Factor_ROS_txt(string Person_Id, string Account_Side)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/" + Account_Side + "_Factor_ROS" + ".txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/" + Account_Side + "_Factor_ROS" + ".txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/" + Account_Side + "_Factor_ROS" + ".txt";
        }

        public static string Factor_Sell_txt(string Person_Id, string Account_Side)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/" + Account_Side + "_Factor_S" + ".txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/" + Account_Side + "_Factor_S" + ".txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/" + Account_Side + "_Factor_S" + ".txt";
        }

        public static string Cash_Desk_txt(string Person_Id)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Cash_Desk" + ".txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Cash_Desk" + ".txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Cash_Desk" + ".txt";
        }

        public static string Salary_txt(string Person_Id)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Salary" + ".txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Salary" + ".txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Salary" + ".txt";
        }

        public static string Stock_txt(string Person_Id)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Stock" + ".txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Stock" + ".txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Stock" + ".txt";
        }

        public static string Account_Side_Bank_txt(string Person_Id, string Account_Side)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/BA_" + Account_Side + ".txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/BA_" + Account_Side + ".txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/BA_" + Account_Side + ".txt";
        }

        public static string Account_Side_txt(string Person_Id)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Account_Side.txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Account_Side.txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Account_Side.txt";
        }

        public static string Address_Account_Side_txt(string Person_Id, string Account_Side)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/" + Account_Side + "_Address.txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/" + Account_Side + "_Address.txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/" + Account_Side + "_Address.txt";
        }

        public static string Description_Account_Side_txt(string Person_Id, string Account_Side)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/" + Account_Side + "_Description.txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/" + Account_Side + "_Description.txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/" + Account_Side + "_Description.txt";
        }

        public static string Groups_txt(string Person_Id, string Groups, string Group)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/" + Group + "_" + Groups + ".txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/" + Group + "_" + Groups + ".txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/" + Group + "_" + Groups + ".txt";
        }

        public static string Selected_Profile_txt(string Person_Id)
        {
            if (!File.Exists("C:/Exir/" + Person_Id + "/Selected_Profile.txt"))
            {
                var a = File.Create("C:/Exir/" + Person_Id + "/Selected_Profile.txt");
                a.Close();
            }

            return "C:/Exir/" + Person_Id + "/Selected_Profile.txt";
        }

        public static string Fonts_txt(string Num_Font)
        {
            if (!File.Exists("C:/Exir/Font" + Num_Font + ".txt"))
            {
                var a = File.Create("C:/Exir/Font" + Num_Font + ".txt");
                a.Close();
            }

            return "C:/Exir/Font" + Num_Font + ".txt";
        }

        public static string Profile_png(string Person_Id_Profile)
        {
            if (!File.Exists("C:/Exir/Profile" + Person_Id_Profile + ".png"))
            {
                var a = File.Create("C:/Exir/Profile" + Person_Id_Profile + ".png");
                a.Close();
            }

            return "C:/Exir/Profile" + Person_Id_Profile + ".png";
        }
    }
}
