using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exir
{
    class Add_Bank_Account_User : Paths
    {
        public string Action(string Person_Id, string Name_Account, string Name_Bank, string Code, string Sheba, string Card_Holder, string Account_Number, string Card_Number, int Check)
        {
            try
            {
                string[] Data = File.ReadAllLines(Bank_Account_User_txt(Person_Id));

                foreach (string Find in Data)
                {
                    if (Find.Split(Split_Char)[0] == Name_Account)
                        return "Exists";
                }

                string Text = Name_Account + Split_Char + Name_Bank + Split_Char + Code + Split_Char + Sheba + Split_Char + Card_Holder + Split_Char + Account_Number + Split_Char + Card_Number + Split_Char + Check + "\n";
                File.AppendAllText(Bank_Account_User_txt(Person_Id), Text);

                Financial F = new Financial();
                string Result_Add = F.Add(Person_Id, "BA", Name_Account, "0");

                return Result_Add;
            }
            catch
            {
                try
                {
                    Financial F = new Financial();
                    F.Remove(Person_Id, "BA", Name_Account, "0");

                    return "catch";
                }
                catch
                {
                    return "catch";
                }
            }
        }
    }
}
