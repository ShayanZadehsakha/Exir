using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exir
{
    class Add_Groups : Paths
    {
        public string Group_Name;
        public string Groups_Name;
        public string Person_Id;
        public string find = "";

        public string Action(string group_name, string groups_name, string person_id, List<string> data_in_groups_txt)
        {
            string Result = "catch";

            try
            {
                Group_Name = group_name;
                Groups_Name = groups_name;
                Person_Id = person_id;

                string[] Data = File.ReadAllLines(Group_txt(person_id));
                List<string> New_Data = new List<string>();

                foreach (string Find in Data)
                {
                    if (Find.Contains(Split_Char))
                    {
                        if (Find.Split(Split_Char)[0] == group_name)
                        {
                            find = Find;
                            New_Data.Add("");
                        }

                        else
                            New_Data.Add(Find);
                    }
                    else
                    {
                        if (Find == group_name)
                        {
                            find = Find;
                            New_Data.Add("");
                        }

                        else
                            New_Data.Add(Find);
                    }
                }

                bool First = false;

                if (find == "")
                    Result = "N_Exists";

                else if (!find.Contains(Split_Char))
                {
                    find += Split_Char;
                    First = true;
                }

                bool Equal = false;

                foreach (string Item in find.Split(Split_Char))
                {
                    Add_Groups Ag = new Add_Groups();

                    Ag.Groups_Name = Item;

                    if (Equals(Ag))
                        Equal = true;
                }

                if (Equal)
                    return "Exists";

                if (First)
                    find += groups_name;

                else
                    find += Split_Char + groups_name;

                File.WriteAllText(Group_txt(person_id), "");

                foreach (string Add_New_Data in New_Data)
                {
                    if (Add_New_Data == "")
                        Append_File(find);

                    else
                        Append_File(Add_New_Data);
                }

                if (data_in_groups_txt != null)
                {
                    foreach (string Add_In_File in data_in_groups_txt)
                    {
                        File.AppendAllText(Groups_txt(person_id, groups_name, group_name), Add_In_File);
                    }
                }
                else
                    File.AppendAllText(Groups_txt(person_id, groups_name, group_name), "");

                Result = "Try";
            }
            catch
            {
                Result = "catch";
            }
            return Result;

            void Append_File(string Append_Text)
            {
                File.AppendAllText(Group_txt(Person_Id), Append_Text + "\n");
            }
        }
        public override bool Equals(object obj)
        {
            Add_Groups AG = (Add_Groups)obj;

            if (Groups_Name == AG.Groups_Name)
                return true;

            return false;
        }
    }
}