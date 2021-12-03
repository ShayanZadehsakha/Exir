using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exir
{
    class Remove_Account_Side : Paths
    {
        List<string> Data = new List<string>();
        List<string> Data_Address = new List<string>();
        List<string> Data_Description = new List<string>();

        public string Action(string person_id, string name, string code, string home_phone, string email, string mobile_phone, string address, string description)
        {
            try
            {
                List<string> New_Data = new List<string>();

                Data = File.ReadAllLines(Account_Side_txt(person_id)).ToList();
                Data_Address = File.ReadAllLines(Address_Account_Side_txt(person_id, name)).ToList();
                Data_Description = File.ReadAllLines(Description_Account_Side_txt(person_id, name)).ToList();

                bool Exists = false;

                foreach (string Find in Data)
                {
                    if (Find.Split(Split_Char)[0] == name)
                    {
                        Exists = true;
                    }
                    else
                        New_Data.Add(Find + "\n");
                }

                if (!Exists)
                {
                    return "N_Exists";
                }

                File.WriteAllText(Account_Side_txt(person_id), "");

                foreach (string Find in New_Data)
                {
                    File.AppendAllText(Account_Side_txt(person_id), Find);
                }

                File.Delete(Address_Account_Side_txt(person_id, name));
                File.Delete(Description_Account_Side_txt(person_id, name));

                Financial F = new Financial();
                string Stock = F.Stock(person_id, "AS", name).Split(Split_Char)[2];

                string Result_Remove = F.Remove(person_id, "AS", name, Stock);

                return Result_Remove;
            }
            catch
            {
                try
                {
                    File.WriteAllText(Account_Side_txt(person_id), "");

                    foreach (string Find in Data)
                    {
                        File.AppendAllText(Account_Side_txt(person_id), Find);
                    }

                    foreach (string Find in Data_Address)
                    {
                        File.AppendAllText(Address_Account_Side_txt(person_id, name), Find);
                    }

                    foreach (string Find in Data_Description)
                    {
                        File.AppendAllText(Description_Account_Side_txt(person_id, name), Find);
                    }

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