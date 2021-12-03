using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exir
{
    class Remove_Bank_Account_User : Paths
    {
        public string Action(string Person_Id, string Name_Account, string Name_Bank, string Code, string Sheba, string Card_Holder, string Account_Number, string Card_Number, int Check)
        {
            try
            {
                string[] Data = File.ReadAllLines(Bank_Account_User_txt(Person_Id));
                List<string> New_Data = new List<string>();

                bool Exists = false;

                foreach (string Find in Data)
                {
                    if (Find.Split(Split_Char)[0] == Name_Account)
                        Exists = true;

                    else
                        New_Data.Add(Find);
                }

                if (!Exists)
                    return "N_Exists";

                File.WriteAllText(Bank_Account_User_txt(Person_Id), "");

                foreach (string Find in New_Data)
                {
                    File.AppendAllText(Bank_Account_User_txt(Person_Id), Find + "\n");
                }

                Financial F = new Financial();

                string Find_BA = F.Stock(Person_Id, "BA", Name_Account);

                F.Remove(Person_Id, "BA", Name_Account, Find_BA.Split(Split_Char)[2]);

                return "Try";
            }
            catch
            {
                return "catch";
            }
        }
    }
}
