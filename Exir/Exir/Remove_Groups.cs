using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exir
{
    class Remove_Groups : Paths
    {
        public string Group_Name;
        public string Groups_Name;
        public static string Person_Id;
        static string find = "";
        static bool Exists_Group = false;
        static bool Exists_Groups = false;

        public string Action(string group_name, string groups_name, string person_id)
        {
            try
            {
                Group_Name = group_name;
                Groups_Name = groups_name;
                Person_Id = person_id;

                string[] Data = File.ReadAllLines(Group_txt(person_id));

                File.WriteAllText(Group_txt(person_id), "");

                find = "";
                Exists_Group = false;
                Exists_Groups = false;

                foreach (string Find in Data)
                {
                    if (Find.Split(Split_Char)[0] == Group_Name)
                    {
                        Exists_Group = true;

                        foreach (string Find_Groups in Find.Split(Split_Char))
                        {
                            if (Find_Groups != Groups_Name)
                            {
                                if (find == "")
                                    find += Find_Groups;

                                else
                                    find += Split_Char + Find_Groups;
                            }

                            else
                                Exists_Groups = true;
                        }

                        Append_File(find + "\n");
                    }
                    else
                        Append_File(Find + "\n");
                }

                if (!Exists_Group)
                    return "N_Exists_Group";

                if (!Exists_Groups)
                    return "N_Exists_Groups";

                if (File.Exists(Groups_txt(person_id, groups_name, group_name)))
                {
                    File.Delete(Groups_txt(person_id, groups_name, group_name));
                }    

                return "Try";
            }
            catch
            {
                return "catch";
            }
            void Append_File(string Text)
            {
                File.AppendAllText(Group_txt(person_id), Text);
            }
        }
    }
}