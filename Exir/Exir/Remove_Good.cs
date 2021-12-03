using System.IO;

namespace Exir
{
    class Remove_Good : Paths
    {
        public string Action(string Person_Id, string Group_Name, string Groups_name, string Good_Name, string Price, string Stock)
        {
            try
            {
                bool Exists = File.Exists(Groups_txt(Person_Id, Groups_name, Group_Name));

                if (!Exists)
                    return "N_Exists";

                else
                    File.Delete(Groups_txt(Person_Id, Groups_name, Group_Name));

                return "Try";
            }
            catch
            {
                return "catch";
            }
        }
    }
}