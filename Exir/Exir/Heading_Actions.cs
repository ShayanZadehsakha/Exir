using System.Collections.Generic;
using System.IO;

namespace Exir
{
    class Heading_Actions : Paths
    {
        public string Add_Total_Account(string Name, string Person_Id, string Type_C, string Type_D, string Code)
        {
            try
            {
                string[] Data = File.ReadAllLines(Heading_Total_Account_Txt(Person_Id));

                foreach (string Find in Data)
                {
                    if (Find.Split(Split_Char)[0] == Name)
                        return "Exists";
                }

                File.AppendAllText(Heading_Total_Account_Type_Txt(Person_Id), Name + Split_Char + Type_C + Split_Char + Type_D + "\n");
                File.AppendAllText(Heading_Total_Account_Txt(Person_Id), Name + "\n");
                File.AppendAllText(Heading_Code(Person_Id), "Tot" + Split_Char + Name + Split_Char + Code + "\n");

                return "Try";
            }

            catch
            {
                return "catch";
            }
        }

        public string Add_Defenite_Account(string Total_Account_Name, string Person_Id, string Defenite_Account_Name, string Code)
        {
            try
            {
                string[] Data = File.ReadAllLines(Heading_Total_Account_Txt(Person_Id));

                List<string> New_Data = new List<string>();

                foreach (string Find in Data)
                {
                    if (Find.Split(Split_Char)[0] == Total_Account_Name)
                    {
                        string New_Text_In_List = Find + Split_Char;

                        foreach (string Find2 in Find.Split(Split_Char))
                        {
                            if (Find2 == Defenite_Account_Name)
                                return "Exists";
                        }

                        New_Text_In_List += Defenite_Account_Name;

                        New_Data.Add(New_Text_In_List);
                    }
                    else
                        New_Data.Add(Find);
                }

                File.WriteAllText(Heading_Total_Account_Txt(Person_Id), "");

                foreach (string Find in New_Data)
                {
                    File.AppendAllText(Heading_Total_Account_Txt(Person_Id), Find + "\n");
                }

                File.AppendAllText(Heading_Code(Person_Id), "Def" + Split_Char + Total_Account_Name + Split_Char + Defenite_Account_Name + Split_Char + Code + "\n");

                return "Try";
            }
            catch
            {
                return "catch";
            }
        }

        public string Add_Account_Detailed(string Name, string Person_Id, string Total_Account, string Defenite_Account, string Code)
        {
            try
            {
                string[] Data = File.ReadAllLines(Heading_Detail_Txt(Person_Id, Total_Account, Defenite_Account));

                foreach (string Find in Data)
                {
                    if (Find == Name)
                        return "Exists";
                }

                File.AppendAllText(Heading_Detail_Txt(Person_Id, Total_Account, Defenite_Account), Name + "\n");
                File.AppendAllText(Heading_Code(Person_Id), "Det" + Split_Char + Total_Account + Split_Char + Defenite_Account + Split_Char + Name + Split_Char + Code + "\n");

                return "Try";
            }

            catch
            {
                return "catch";
            }
        }

        public string Remove_Total_Account(string Name, string Person_Id)
        {
            try
            {
                string[] Data = File.ReadAllLines(Heading_Total_Account_Txt(Person_Id));
                string[] Data_Type = File.ReadAllLines(Heading_Total_Account_Type_Txt(Person_Id));

                File.WriteAllText(Heading_Total_Account_Txt(Person_Id), "");

                foreach (string Find in Data)
                {
                    if (Find.Split(Split_Char)[0] != Name)
                        File.AppendAllText(Heading_Total_Account_Txt(Person_Id), Find + "\n");
                }

                File.WriteAllText(Heading_Total_Account_Type_Txt(Person_Id), "");

                foreach (string Find in Data_Type)
                {
                    if (Find.Split(Split_Char)[0] != Name)
                        File.AppendAllText(Heading_Total_Account_Type_Txt(Person_Id), Find + "\n");
                }
            }

            catch
            {
                return "catch";
            }

            try
            {
                string[] Data_Code = File.ReadAllLines(Heading_Code(Person_Id));

                File.WriteAllText(Heading_Code(Person_Id), "");

                foreach (string Find in Data_Code)
                {
                    if (Find.Split(Split_Char)[1] == Name) { }

                    else
                        File.AppendAllText(Heading_Code(Person_Id), Find + "\n");
                }
            }

            catch { }

            return "Try";
        }

        public string Remove_Defenite_Account(string Total_Account_Name, string Person_Id, string Defenite_Account_Name)
        {
            try
            {
                string[] Data = File.ReadAllLines(Heading_Total_Account_Txt(Person_Id));

                List<string> New_Data = new List<string>();

                foreach (string Find in Data)
                {
                    if (Find.Split(Split_Char).Length > 1 && Find.Split(Split_Char)[0] == Total_Account_Name)
                    {
                        string New_Text_In_List = Find.Split(Split_Char)[0];

                        int i = 0;

                        foreach (string Find2 in Find.Split(Split_Char))
                        {
                            i++;

                            if (Find2 != Defenite_Account_Name && i != 1)
                                New_Text_In_List += Split_Char + Find2;
                        }

                        New_Data.Add(New_Text_In_List);
                    }
                    else
                        New_Data.Add(Find);
                }

                File.WriteAllText(Heading_Total_Account_Txt(Person_Id), "");

                foreach (string Find in New_Data)
                {
                    File.AppendAllText(Heading_Total_Account_Txt(Person_Id), Find + "\n");
                }
            }
            catch
            {
                return "catch";
            }

            try
            {
                string[] Data_Code = File.ReadAllLines(Heading_Code(Person_Id));

                File.WriteAllText(Heading_Code(Person_Id), "");

                foreach (string Find in Data_Code)
                {
                    if (Find.Split(Split_Char)[0] != "Tot" && Find.Split(Split_Char)[1] == Total_Account_Name && Find.Split(Split_Char)[2] == Defenite_Account_Name) { }

                    else
                        File.AppendAllText(Heading_Code(Person_Id), Find + "\n");
                }
            }
            catch { }

            return "Try";
        }

        public string Remove_Detailed_Account(string Total_Account_Name, string Person_Id, string Defenite_Account_Name, string Detailed_Account_Name)
        {
            try
            {
                string[] Data = File.ReadAllLines(Heading_Detail_Txt(Person_Id, Total_Account_Name, Defenite_Account_Name));

                List<string> New_Data = new List<string>();

                foreach (string Find in Data)
                {
                    if (Find != Detailed_Account_Name)
                    {
                        New_Data.Add(Find);
                    }
                }

                File.WriteAllText(Heading_Detail_Txt(Person_Id, Total_Account_Name, Defenite_Account_Name), "");

                foreach (string Find in New_Data)
                {
                    File.AppendAllText(Heading_Detail_Txt(Person_Id, Total_Account_Name, Defenite_Account_Name), Find + "\n");
                }
            }
            catch
            {
                return "catch";
            }

            try
            {
                string[] Data_Code = File.ReadAllLines(Heading_Code(Person_Id));

                File.WriteAllText(Heading_Code(Person_Id), "");

                foreach (string Find in Data_Code)
                {
                    if (Find.Split(Split_Char)[0] == "Det" && Find.Split(Split_Char)[1] == Total_Account_Name && Find.Split(Split_Char)[2] == Defenite_Account_Name && Find.Split(Split_Char)[3] == Detailed_Account_Name) { }

                    else
                        File.AppendAllText(Heading_Code(Person_Id), Find + "\n");
                }
            }

            catch { }

            return "Try";
        }

        public string Edit_Total_Account(string Person_Id, string Past_Name, string New_Name, string Type_C, string Type_D, string Code)
        {
            string Result_Remove = Remove_Total_Account(Past_Name, Person_Id);

            if (Result_Remove == "catch")
                return "R_" + Result_Remove;

            string Result_Add = Add_Total_Account(New_Name, Person_Id, Type_C,Type_D, Code);

            if (Result_Add != "Try")
                return "A_" + Result_Add;

            return "Try_";
        }

        public string Edit_Defenite_Account(string Person_Id, string Past_Total_Account_Name, string Past_Defenite_Name, string New_Defenite_Name, string New_Total_Account_Name, string Code)
        {
            string Result_Remove = Remove_Defenite_Account(Past_Total_Account_Name, Person_Id, Past_Defenite_Name);

            if (Result_Remove == "catch")
                return "R_" + Result_Remove;

            string Result_Add = Add_Defenite_Account(New_Total_Account_Name, Person_Id, New_Defenite_Name, Code);

            if (Result_Add != "Try")
                return "A_" + Result_Add;

            string[] Data = File.ReadAllLines(Heading_Detail_Txt(Person_Id, Past_Total_Account_Name, Past_Defenite_Name));

            foreach (string Find in Data)
            {
                File.AppendAllText(Heading_Detail_Txt(Person_Id, New_Total_Account_Name, New_Defenite_Name), Find + "\n");
            }

            File.Delete(Heading_Detail_Txt(Person_Id, Past_Total_Account_Name, Past_Defenite_Name));

            return "Try_";
        }

        public string Edit_Detailed_Account(string Person_Id, string Past_Total_Account_Name, string Past_Defenite_Name, string New_Defenite_Name, string New_Total_Account_Name, string Past_Detailed_Name, string New_Detailed_Name, string Code)
        {
            string Result_Remove = Remove_Detailed_Account(Past_Total_Account_Name, Person_Id, Past_Defenite_Name, Past_Detailed_Name);

            if (Result_Remove == "catch")
                return "R_" + Result_Remove;

            string Result_Add = Add_Account_Detailed(New_Detailed_Name, Person_Id, New_Total_Account_Name, New_Defenite_Name, Code);

            if (Result_Add != "Try")
                return "A_" + Result_Add;

            return "Try_";
        }
    }
}