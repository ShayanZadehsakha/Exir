using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exir
{
    class Add_Good : Paths
    {
        public string Good_Name;
        public string Group_Name;
        public string Groups_Name;
        public string Price;
        public string Stock;

        public string Action(string person_id, string good_name, string group_name, string groups_name, string price, string stock)
        {
            try
            {
                Good_Name = good_name;
                Group_Name = group_name;
                Groups_Name = groups_name;
                Price = price;
                Stock = stock;

                Add_Good AG = new Add_Good();
                bool Exists_Groups = false;
                bool Exists_Group = false;

                foreach (string Find_Group in File.ReadAllLines(Group_txt(person_id)))
                {
                    if (Find_Group.Split(Split_Char)[0] == group_name)
                    {
                        Exists_Group = true;

                        int i;
                        i = 0;

                        foreach (string Find_Groups in Find_Group.Split(Split_Char))
                        {
                            i++;

                            if (i != 1 && Find_Groups == groups_name)
                                Exists_Groups = true;
                        }
                    }
                }

                if (!Exists_Groups)
                    return "N_Exists_Groups";

                if (!Exists_Group)
                    return "N_Exists_Group";

                foreach (string Find in File.ReadAllLines(Groups_txt(person_id, groups_name, group_name)))
                {
                    AG.Good_Name = Find.Split(Split_Char)[0];

                    if (Equals(AG))
                        return "Equals";
                }

                string Good_Append = good_name + Split_Char + stock + Split_Char + price + Split_Char + group_name + Split_Char + groups_name + "\n";

                File.AppendAllText(Groups_txt(person_id, groups_name, group_name), Good_Append);

                return "Try";
            }
            catch
            {
                return "catch";
            }
        }
        public override bool Equals(object obj)
        {
            Add_Good AG = (Add_Good)obj;

            if (Good_Name == AG.Good_Name)
                return true;

            return false;
        }
    }
}
