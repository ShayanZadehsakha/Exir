using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exir
{
    class Remove_Group : Paths
    {
        static string Person_Id;
        static string Result = "Try";

        static bool Exists_Group = false;

        public static string Remove_Group_Action(string name_group, string person_id)
        {
            Person_Id = person_id;

            if (!File.Exists(Group_txt(person_id)))
            {
                var a = File.Create(Group_txt(person_id));
                a.Close();
            }

            string[] Data = File.ReadAllLines(Group_txt(person_id));
            List<string> New_Data = new List<string>();

            if (Data.Count() != 0)
            {
                foreach (string Find in Data)
                {
                    if (Find.Contains(Split_Char))
                    {
                        if (Find.Split(Split_Char)[0] != name_group)
                        {
                            New_Data.Add(Find);
                        }
                        else
                        {
                            Exists_Group = false;
                        }
                    }
                    else
                    {
                        if (Find != name_group)
                        {
                            New_Data.Add(Find);
                        }
                        else
                        {
                            Exists_Group = false;
                        }
                    }
                }
            }
            else
            {
                Exists_Group = true;
            }

            if (Exists_Group)
            {
                Result = "N_Exists";
            }
            else
            {
                Result = Add_Group(New_Data);
            }

            return Result;
        }

        static string Add_Group(List<string> New_Data)
        {
            try
            {
                File.WriteAllText(Group_txt(Person_Id), "");

                foreach (string Add in New_Data)
                {
                    File.AppendAllText(Group_txt(Person_Id), Add + "\n");
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