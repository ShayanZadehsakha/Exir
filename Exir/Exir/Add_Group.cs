using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exir
{
    class Add_Group : Paths
    {
        public string Name_Group;
        public string Code;

        string Result = "Try";
        bool check_Equal = false;

        public Add_Group() { }
        public string Add_Group_Action(string name_group, string code)
        {
            try
            {
                Name_Group = name_group;
                Code = code;

                string[] Data = File.ReadAllLines(Group_txt(Code));

                if (Data != null)
                {
                    List<Add_Group> AG_Data = new List<Add_Group>();

                    foreach (string Find in Data)
                    {
                        Add_Group AG = new Add_Group();

                        AG.Name_Group = Find.Split('/')[0];
                        AG.Code = code;

                        AG_Data.Add(AG);
                    }

                    foreach (Add_Group Check_Equal in AG_Data)
                    {
                        if (Equals(Check_Equal))
                            check_Equal = true;
                    }

                    if (!check_Equal)
                    {
                        Result = Add();
                    }
                    else
                        Result = "Repaet";
                }
                else
                    Result = Add();

                return Result;
            }
            catch
            {
                return "catch";
            }
            }

            string Add()
            {
                try
                {
                    File.AppendAllText(Group_txt(Code), Name_Group+"\n");
                    return "Try";
                }
                catch
                {
                    return "catch";
                }
            }

        public override bool Equals(object obj)
        {
            Add_Group AG = (Add_Group)obj;

            if (AG.Name_Group == Name_Group)
            {
                return true;
            }
            return false;
        }
    }
}
