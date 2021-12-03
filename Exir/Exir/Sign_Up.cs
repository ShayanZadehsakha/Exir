using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Security;

namespace Exir
{
    public class Sign_Up
    {
        public string User_Name;
        public string Pass;
        public string Email;
        public List<string> Data;
        public string Path;

        public string Su()
        {
            string Text_In_File = User_Name + '/' + FormsAuthentication.HashPasswordForStoringInConfigFile(Pass, "MD5") + '/' + Email;

            if (Data.Count != 0)
            {
                foreach (string Find in Data)
                {
                    try
                    {
                        if (Find.Split('/')[0] != User_Name || Find.Split('/')[2] != Email)
                        {
                            int Person_Id = Convert.ToInt32("1000" + Data.Count.ToString());
                            Person_Id++;
                            File.AppendAllText(Path, Text_In_File + '/' + Pass.Length.ToString() + '/' + Person_Id.ToString() + "\n");
                            Directory.CreateDirectory("C:/Exir/" + Person_Id.ToString());
                            Create_Files(Person_Id);
                            return "Try";
                        }
                        else
                        {
                            return "Repaet";
                        }
                    }
                    catch 
                    {
                        return "catch";
                    }
                }
            }
            else if (Data.Count == 0)
            {
                int Person_Id = 10001;
                File.AppendAllText(Path, Text_In_File + '/' + Pass.Length.ToString() + "/" + Person_Id.ToString() + "\n");
                Directory.CreateDirectory("C:/Exir/" + Person_Id.ToString());
                Create_Files(Person_Id);
                return "Try";
            }
            return "catch";
        }
        void Create_Files(int Person_Id)
        {
            File.AppendAllText("C:/Exir/" + Person_Id.ToString() + "/Selected_Profile.txt", "1");
            Properties.Resources.profile.Save("C:/Exir/" + Person_Id.ToString() + "/Profile1.png");
            File.AppendAllText("C:/Exir/" + Person_Id.ToString() + "/Font0.txt", "IRRoya/Bold");
            File.AppendAllText("C:/Exir/" + Person_Id.ToString() + "/Font1.txt", "Lalezar/Regular");
        }
    }
}