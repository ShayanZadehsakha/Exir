using System.Collections.Generic;
using System.IO;

namespace Exir
{
    class Add_Account_Side : Paths
    {
        public string Action(string person_id, string name, string code, string home_phone, string email, string mobile_phone, string address, string description, string Bool_Byer, string Bool_Seller, string Bool_Intermediary)
        {
            try
            {
                string[] Data = File.ReadAllLines(Account_Side_txt(person_id));

                foreach (string Find in Data)
                {
                    if (Find.Split(Split_Char)[0] == name && Find.Split(Split_Char)[1] == code)
                    {
                        return "Exists";
                    }
                }

                string Text = name + Split_Char + code + Split_Char + home_phone + Split_Char + email + Split_Char + mobile_phone + Split_Char + Bool_Byer + Split_Char + Bool_Seller + Split_Char + Bool_Intermediary;

                File.AppendAllText(Account_Side_txt(person_id), Text + "\n");
                File.AppendAllText(Address_Account_Side_txt(person_id, name), address);
                File.AppendAllText(Description_Account_Side_txt(person_id, name), description);

                Financial F = new Financial();
                F.Add(person_id, "AS", name, "0");

                var a = File.Create(Account_Side_Bank_txt(person_id, name));
                a.Close();

                return "Try";
            }
            catch
            {
                try
                {
                    string[] Data = File.ReadAllLines(Account_Side_txt(person_id));

                    Financial F = new Financial();

                    F.Remove(person_id, "AS", name, "0");

                    List<string> New_Data = new List<string>();

                    bool Exist = false;

                    foreach (string Find in Data)
                    {
                        if (Find.Split(Split_Char)[0] != name)
                        {
                            New_Data.Add(Find + "\n");
                        }
                        else
                            Exist = true;
                    }

                    if (Exist)
                    {
                        File.WriteAllText(Account_Side_txt(person_id), "");

                        foreach (string item in New_Data)
                        {
                            File.AppendAllText(Account_Side_txt(person_id), item);
                        }

                        var a = File.Create(Bank_Account_txt(person_id));
                        a.Close();
                    }

                    return "catch";
                }
                catch
                {
                    try
                    {
                        List<string> New_Data = new List<string>();
                        string[] Data = File.ReadAllLines(Account_Side_txt(person_id));

                        bool Try_Account_Side = false;

                        foreach (string Find in Data)
                        {
                            if (Find.Split(Split_Char)[0] == name)
                            {
                                Try_Account_Side = true;
                            }
                            else
                                New_Data.Add(Find + "\n");
                        }

                        File.WriteAllText(Account_Side_txt(person_id), "");

                        if (Try_Account_Side)
                        {
                            foreach (string item in New_Data)
                            {
                                File.AppendAllText(Account_Side_txt(person_id), item);
                            }
                        }

                        if (File.Exists(Bank_Account_txt(person_id)))
                            File.Delete(Bank_Account_txt(person_id));

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
}
