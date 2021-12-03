using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exir
{
    class Remove_Cash_Desk : Paths
    {
        public string Action(string Person_Id, string Name)
        {
            try
            {
                if (!File.Exists(Cash_Desk_txt(Person_Id)))
                {
                    var a = File.Create(Cash_Desk_txt(Person_Id));
                    a.Close();
                }

                string[] Data = File.ReadAllLines(Cash_Desk_txt(Person_Id));
                List<string> New_Data = new List<string>();

                bool Exists = false;

                foreach (string Find in Data)
                {
                    if (Find == Name)
                        Exists = true;

                    else
                        New_Data.Add(Find);
                }

                if (!Exists)
                    return "N_Exists";

                File.WriteAllText(Cash_Desk_txt(Person_Id), "");

                foreach (string item in New_Data)
                {
                    File.AppendAllText(Cash_Desk_txt(Person_Id), item + "\n");
                }

                Financial F = new Financial();
                string Find_CD = F.Stock(Person_Id, "CD", Name);

                string Result_Remove = F.Remove(Person_Id, "CD", Name, Find_CD.Split(Split_Char)[2]);

                return Result_Remove;
            }
            catch
            {
                return "catch";
            }
        }
    }
}