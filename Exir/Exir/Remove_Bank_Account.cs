using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exir
{
    class Remove_Bank_Account : Paths
    {
        public string Action(string Person_Id, string Name_Account_Side, string Bank_Name, string Name, string Account_Number, string Sheba, string Card_Number, string Holder_Card_Name)
        {
            try
            {
                string[] Data_Acount_Sides = File.ReadAllLines(Account_Side_txt(Person_Id));

                bool Exists_Account_Side = false;
                bool Exists_Bank_Account = false;

                foreach (string Find in Data_Acount_Sides)
                {
                    if (Find.Split(Split_Char)[0] == Name_Account_Side)
                    {
                        Exists_Account_Side = true;
                    }
                }

                if (!Exists_Account_Side)
                    return "N_Exists_AS";

                string[] Data = File.ReadAllLines(Bank_Account_txt(Person_Id));
                List<string> New_Data = new List<string>();

                string Text = Name + Split_Char + Bank_Name + Split_Char + Account_Number + Split_Char + Sheba + Split_Char + Card_Number + Split_Char + Holder_Card_Name + "\n";

                foreach (string Find in Data)
                {
                    if (Find+"\n" == Text)
                        Exists_Bank_Account = true;

                    else
                        New_Data.Add(Find + "\n");
                }

                if (!Exists_Bank_Account)
                    return "N_Exists_BA";

                File.WriteAllText(Bank_Account_txt(Person_Id), "");

                foreach (string item in New_Data)
                {
                    File.AppendAllText(Bank_Account_txt(Person_Id), item);
                }

                return "Try";
            }
            catch
            {
                return "catch";
            }
        }
    }
}
