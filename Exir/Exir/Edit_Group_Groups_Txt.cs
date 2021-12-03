using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exir
{
    class Edit_Group_Groups_Txt
    {
        public string Groups_Name;
        public List<string> List_Txt = new List<string>();

        public Edit_Group_Groups_Txt(string groups_name)
        {
            Groups_Name = groups_name;
        }

        public void Add_Lsit(string List_Find)
        {
            List_Txt.Add(List_Find);
        }
    }
}