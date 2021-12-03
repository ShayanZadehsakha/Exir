using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exir
{
    class Add_Account_Side_SBI : Paths
    {
        public string Action(string Person_Id, string Account_Side, int Seller, int Byer, int Intermediary)
        {
            try
            {
                bool Exists_Account_Side = false;

                string[] Data = File.ReadAllLines(Account_Side_txt(Person_Id));
                List<string> New_Data = new List<string>();

                foreach (string Find in Data)
                {
                    if (Find.Split(Split_Char)[0] == Account_Side)
                    {
                        Exists_Account_Side = true;

                        string Text = Find.Split(Split_Char)[0] + Split_Char + Find.Split(Split_Char)[1] + Split_Char + Find.Split(Split_Char)[2] + Split_Char + Find.Split(Split_Char)[3] + Split_Char + Find.Split(Split_Char)[4] + Split_Char + Seller.ToString() + Split_Char + Byer.ToString() + Split_Char + Intermediary.ToString();

                        New_Data.Add(Text + "\n");
                    }

                    else
                        New_Data.Add(Find + "\n");
                }

                if (!Exists_Account_Side)
                    return "N_Exists";

                File.WriteAllText(Account_Side_txt(Person_Id), "");

                foreach (string Find in New_Data)
                {
                    File.AppendAllText(Account_Side_txt(Person_Id), Find);
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
