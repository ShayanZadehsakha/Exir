using System.Collections.Generic;
using System.IO;

namespace Exir
{
    class Remove_Check : Paths
    {
        public string Action(string Person_Id, string Name)
        {
            try
            {
                bool Exists = false;

                string[] Data = File.ReadAllLines(Checks_Txt(Person_Id));
                List<string> New_Data = new List<string>();

                foreach (string Find in Data)
                {
                    if (Find.Split(Split_Char)[0] == Name)
                        Exists = true;

                    else
                        New_Data.Add(Find + "\n");
                }

                if (!Exists)
                    return "N_Exists";

                File.WriteAllText(Checks_Txt(Person_Id), "");

                foreach (string Find in New_Data)
                {
                    File.AppendAllText(Checks_Txt(Person_Id), Find);
                }

                Financial F = new Financial();

                return F.Remove(Person_Id, "CH", Name, F.Stock(Person_Id, "CH", Name).Split(Split_Char)[2]);
            }
            catch
            {
                return "catch";
            }
        }
    }
}