using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exir
{
    class Add_Salary : Paths
    {
        public string Action(string Person_Id, string Name)
        {
            try
            {
                if (!File.Exists(Salary_txt(Person_Id)))
                {
                    var a = File.Create(Salary_txt(Person_Id));
                    a.Close();
                }

                string[] Data = File.ReadAllLines(Salary_txt(Person_Id));

                foreach (string Find in Data)
                {
                    if (Find == Name)
                        return "Exists";
                }

                File.AppendAllText(Salary_txt(Person_Id), Name + "\n");

                Financial F = new Financial();
                string Result_Add = F.Add(Person_Id, "SR", Name, "0");

                return Result_Add;
            }
            catch
            {
                try
                {
                    Financial F = new Financial();

                    F.Remove(Person_Id, "SR", Name, "0");

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