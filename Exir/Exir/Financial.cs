using System;
using System.Collections.Generic;
using System.IO;

namespace Exir
{
    class Financial : Paths
    {
        public string Stock(string Person_Id, string Work, string Name)
        {
            try
            {
                if (!File.Exists(Stock_txt(Person_Id)))
                {
                    var a = File.Create(Stock_txt(Person_Id));
                    a.Close();
                }

                string[] Data = File.ReadAllLines(Stock_txt(Person_Id));

                foreach (string Find in Data)
                {
                    if (Find.Split(Split_Char)[0] == Work && Find.Split(Split_Char)[1] == Name)
                    {
                        return Find;
                    }
                }

                return null;
            }
            catch
            {
                return "catch";
            }
        }

        public string Remove(string Person_Id, string Work, string Name, string Stock)
        {
            try
            {
                if (!File.Exists(Stock_txt(Person_Id)))
                {
                    var a = File.Create(Stock_txt(Person_Id));
                    a.Close();
                }
                string[] Data = File.ReadAllLines(Stock_txt(Person_Id));
                List<string> New_Data = new List<string>();

                bool Exists = false;

                foreach (string Find in Data)
                {
                    if (Find.Split(Split_Char)[0] == Work && Find.Split(Split_Char)[1] == Name)
                    {
                        Exists = true;
                    }
                    else
                        New_Data.Add(Find + "\n");
                }

                if (!Exists)
                    return "N_Exists";

                File.WriteAllText(Stock_txt(Person_Id), "");

                foreach (string Find in New_Data)
                {
                    File.AppendAllText(Stock_txt(Person_Id), Find);
                }

                return "Try";
            }
            catch
            {
                return "catch";
            }
        }

        public string Add(string Person_Id, string Work, string Name, string Stock)
        {
            try
            {
                if (!File.Exists(Stock_txt(Person_Id)))
                {
                    var a = File.Create(Stock_txt(Person_Id));
                    a.Close();
                }

                if (Convert.ToInt32(Stock) < 0)
                    return "Negative";

                string[] Data = File.ReadAllLines(Stock_txt(Person_Id));
                List<string> New_Data = new List<string>();

                foreach (string Find in Data)
                {
                    string Text = Find.Split(Split_Char)[0] + Split_Char + Find.Split(Split_Char)[1];

                    if (Text != Work + Split_Char + Name)
                        New_Data.Add(Find + "\n");
                }

                New_Data.Add(Work + Split_Char + Name + Split_Char + Stock + "\n");

                File.WriteAllText(Stock_txt(Person_Id), "");

                foreach (string Find in New_Data)
                {
                    File.AppendAllText(Stock_txt(Person_Id), Find);
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