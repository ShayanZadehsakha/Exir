using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exir
{
    class Add_Bank_Accounts : Paths
    {
        public string Action(string Person_Id, string Name_Account_Side, string Bank_Name, string Name, string Account_Number, string Sheba, string Card_Number, string Holder_Card_Name)
        {
            try
            {
                string[] Data_Acount_Sides = File.ReadAllLines(Account_Side_txt(Person_Id));
                bool Exists_Account_Side = false;

                foreach (string Find in Data_Acount_Sides)
                {
                    if (Find.Split(Split_Char)[0] == Name_Account_Side)
                    {
                        Exists_Account_Side = true;
                    }
                }

                if (!Exists_Account_Side)
                    return "N_Exists";

                string Text = Name + Split_Char + Bank_Name + Split_Char + Account_Number + Split_Char + Sheba + Split_Char + Card_Number + Split_Char + Holder_Card_Name + "\n";

                if (!File.Exists(Bank_Account_txt(Person_Id)))
                {
                    var a = File.Create(Bank_Account_txt(Person_Id));
                    a.Close();
                }

                string[] Data = File.ReadAllLines(Account_Side_Bank_txt(Person_Id,Name_Account_Side));

                foreach (string Find in Data)
                {
                    if (Find + "\n" == Text)
                    {
                        return "Exists";
                    }
                }

                File.AppendAllText(Bank_Account_txt(Person_Id), Text);

                Financial F = new Financial();

                string Result_F = F.Add(Person_Id, "BA", Name, "0");

                return Result_F;
            }
            catch
            {
                return "catch";
            }
        }
    }
}
