using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exir
{
    class Add_Bank_Account_Side : Paths
    {
        public string Action(string Person_Id, string Name_Account_Side, string Name_Bank_Account)
        {
            try
            {
                if (!File.Exists(Account_Side_Bank_txt(Person_Id, Name_Account_Side)))
                {
                    var a = File.Create(Account_Side_Bank_txt(Person_Id, Name_Account_Side));
                    a.Close();
                }

                string[] Data_Account_Side = File.ReadAllLines(Account_Side_txt(Person_Id));

                bool Exists_Account_Side = false;

                foreach (string Find in Data_Account_Side)
                {
                    if (Find.Split(Split_Char)[0] == Name_Account_Side)
                        Exists_Account_Side = true;
                }

                if (!Exists_Account_Side && Data_Account_Side.Count() != 0)
                    return "N_Exists";

                string[] Data_BA = File.ReadAllLines(Bank_Account_txt(Person_Id));

                bool Exists_BA = false;
                string Text = "";

                foreach (string Find in Data_BA)
                {
                    if (Find.Split(Split_Char)[0] == Name_Bank_Account)
                    {
                        Exists_BA = true;
                        Text = Find + "\n";
                    }
                }

                if (!Exists_BA)
                    return "N_Exists_BA";

                string[] Data = File.ReadAllLines(Account_Side_Bank_txt(Person_Id, Name_Account_Side));

                foreach (string Find in Data)
                {
                    if (Find.Split(Split_Char)[0] == Name_Bank_Account)
                        return "Exists";
                }

                File.AppendAllText(Account_Side_Bank_txt(Person_Id, Name_Account_Side), Text);

                return "Try";
            }
            catch
            {
                return "catch";
            }
        }
    }
}
