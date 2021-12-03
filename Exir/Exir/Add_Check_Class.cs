using System;
using System.IO;

namespace Exir
{
    class Add_Check_Class : Paths
    {
        public string Action(string Person_Id, string Name, string Date_Issuance, string Bank_Name, string Bank_Account, string Date_Expiration, string Check_Number, string Price_In_Number, string Price_In_String, string Account_Side, bool Recived_Check)
        {
            try
            {
                bool Exists = false;

                string[] Data = File.ReadAllLines(Checks_Txt(Person_Id));
                string[] Data_Bank_Accounts = File.ReadAllLines(Bank_Account_User_txt(Person_Id));

                foreach (string Find in Data_Bank_Accounts)
                {
                    if (Find.Split(Split_Char)[0] == Bank_Account)
                        Exists = true;
                }

                if (!Exists)
                    return "N_Exists";

                foreach (string Find in Data)
                {
                    if (Find.Split(Split_Char)[0] == Name)
                        return "Exists";
                }

                Financial F = new Financial();

                string Result_Stock = F.Stock(Person_Id, "BA", Bank_Account);

                if (Result_Stock != "catch" && Result_Stock != null)
                {
                    if (Convert.ToInt32(Price_In_Number) > Convert.ToInt32(Result_Stock.Split(Split_Char)[2]))
                        return "LP";
                }

                string PR_Check = "P";

                if (Recived_Check)
                    PR_Check = "R";

                string Text = Name + Split_Char + Date_Issuance + Split_Char + Date_Expiration + Split_Char + Bank_Name + Split_Char + Bank_Account + Split_Char + Check_Number + Split_Char + Price_In_Number + Split_Char + Price_In_String + Split_Char + Account_Side + Split_Char + PR_Check + "\n";
                File.AppendAllText(Checks_Txt(Person_Id), Text);

                Properties.Settings.Default.Check_Financial = Name;

                return F.Add(Person_Id, "CH", Name, Price_In_Number.ToString());
            }
            catch
            {
                return "catch";
            }
        }
    }
}