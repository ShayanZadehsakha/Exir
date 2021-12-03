using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Exir
{
    public class Login
    {
        public string User_Name;
        public string Pass;
        public bool Verfication_Code;
        public List<string> Data;

        public bool Check_For_Login()
        {
            try
            {
                foreach (string Find in Data)
                {
                    if (User_Name == Find.Split('/')[0] && FormsAuthentication.HashPasswordForStoringInConfigFile(Pass, "MD5") == Find.Split('/')[1] && Verfication_Code)
                        return true;

                    if (!Directory.Exists("C:/Exir/" + Find.Split('/')[4]))
                        Directory.CreateDirectory("C:/Exir/" + Find.Split('/')[4]);

                    if (!File.Exists("C:/Exir/" + Find.Split('/')[4] + "/Group.txt"))
                    {
                        var a = File.Create("C:/Exir/" + Find.Split('/')[4] + "/Group.txt");
                        a.Close();
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}