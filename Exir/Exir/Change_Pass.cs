using System.Collections.Generic;
using System.IO;
using System.Web.Security;

namespace Exir
{
    public class Change_Pass
    {
        public string User_Name;
        public string Email;
        public string New_Pass;
        public List<string> Data;
        public string Path;

        public bool Change()
        {
            try
            {
                string find = "";

                File.WriteAllText(Path, "");

                foreach (string Find in Data)
                {
                    if (Find.Split('/')[0] == User_Name)
                        find = Find;

                    else
                        File.AppendAllText(Path, Find + "\n");
                }

                string Text_In_File = User_Name + '/' + FormsAuthentication.HashPasswordForStoringInConfigFile(New_Pass, "MD5") + '/' + Email;

                File.AppendAllText(Path, Text_In_File + Paths.Split_Char + New_Pass.Length.ToString() + Paths.Split_Char + find.Split(Paths.Split_Char)[4] + "\n");

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}