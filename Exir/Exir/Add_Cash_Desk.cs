using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exir
{
    class Add_Cash_Desk : Paths
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

                foreach (string Find in Data)
                {
                    if (Find == Name)
                        return "Exists";
                }

                File.AppendAllText(Cash_Desk_txt(Person_Id), Name + "\n");

                Financial F = new Financial();
                F.Add(Person_Id, "CD", Name, "0");

                return "Try";
            }
            catch
            {
                try
                {
                    Financial F = new Financial();
                    F.Remove(Person_Id, "CD", Name, "0");

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
