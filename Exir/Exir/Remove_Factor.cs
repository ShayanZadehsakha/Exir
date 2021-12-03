using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exir
{
    class Remove_Factor : Paths
    {
        List<string> Data_Groups, New_Data, Data = new List<string>();

        string Factor_Number = "";
        string Factor_Type = "";

        public string Action(string Cmb_Text, string Person_Id, string Account_Side)
        {
            try
            {
                List<string> Data_Stock_Backup, Data_Factor_Backup = new List<string>();
                List<Class_List_Groups_Backup> Data_Groups_Backup = new List<Class_List_Groups_Backup>();

                Data_Stock_Backup = File.ReadAllLines(Stock_txt(Person_Id)).ToList();

                Factor_Number = Cmb_Text.Split('-')[1].Replace(" ", "");
                Factor_Type = Cmb_Text.Split('-')[0].Replace(" ", "");

                switch (Factor_Type)
                {
                    case "خرید":

                        Data = File.ReadAllLines(Factor_Buy_txt(Person_Id, Account_Side)).ToList();

                        if (Data.Count == 0)
                            return "catch";

                        Data_Stock_Backup = File.ReadAllLines(Stock_txt(Person_Id)).ToList();

                        Data_Factor_Backup = File.ReadAllLines(Factor_Buy_txt(Person_Id, Account_Side)).ToList();

                        foreach (string Find in Data_Factor_Backup)
                        {
                            Class_List_Groups_Backup CLGB = new Class_List_Groups_Backup();

                            CLGB.Data = File.ReadAllLines(Groups_txt(Person_Id, Find.Split(Split_Char)[1], Find.Split(Split_Char)[0])).ToList();
                            CLGB.Path = Groups_txt(Person_Id, Find.Split(Split_Char)[1], Find.Split(Split_Char)[0]);
                            Data_Groups_Backup.Add(CLGB);
                        }

                        string Result = Get_Result(Cmb_Text, Person_Id, Account_Side);

                        if (Result == "catch")
                            return "عملیات با مشکل مواجه شد";

                        else if (Result == "Try")
                            return "عملیات با موفقیت انجام شد";

                        else
                        {
                            File.WriteAllText(Factor_Buy_txt(Person_Id, Account_Side), "");

                            foreach (string Find in Data_Factor_Backup)
                            {
                                File.AppendAllText(Factor_Buy_txt(Person_Id, Account_Side), Find + "\n");
                            }

                            File.WriteAllText(Stock_txt(Person_Id), "");

                            foreach (string Find in Data_Stock_Backup)
                            {
                                File.AppendAllText(Stock_txt(Person_Id), Find + "\n");
                            }

                            foreach (Class_List_Groups_Backup Find in Data_Groups_Backup)
                            {
                                File.WriteAllText(Find.Path, "");

                                foreach (string Find2 in Find.Data)
                                {
                                    File.AppendAllText(Find.Path, Find + "\n");
                                }
                            }

                            return Result;
                        }

                        break;

                    case "فروش":

                        Data = File.ReadAllLines(Factor_Sell_txt(Person_Id, Account_Side)).ToList();
                        //  Factor_Type = Factor_Sell_txt(Person_Id, Account_Side);

                        break;

                    case "برگشت از خرید":

                        Data = File.ReadAllLines(Factor_RFP_txt(Person_Id, Account_Side)).ToList();
                        //  Factor_Type = Factor_RFP_txt(Person_Id, Account_Side);

                        break;

                    case "برگشت از فروش":

                        Data = File.ReadAllLines(Factor_ROS_txt(Person_Id, Account_Side)).ToList();
                        // Factor_Type = Factor_ROS_txt(Person_Id, Account_Side);

                        break;
                }
            }
            catch
            {
                return "catch";
            }

            return "catch";
        }

        private string Get_Result(string Cmb_Text, string Person_Id, string Account_Side)
        {
            List<string> Data = new List<string>();

            string Stock_Result = "";
            int Stock = 0;

            string Add_Result = "";

            Financial F = new Financial();

            switch (Factor_Type)
            {
                case "خرید":

                    Data = File.ReadAllLines(Factor_Buy_txt(Person_Id, Account_Side)).ToList();

                    if (Data.Count == 0)
                        return "catch";

                    foreach (string Find in Data)
                    {
                        if (Find.Split(Split_Char)[8] != "")
                        {
                            Stock_Result = F.Stock(Person_Id, "CD", Find.Split(Split_Char)[8]);

                            if (Stock_Result == null)
                                return "صندوق " + Find.Split(Split_Char)[1] + " در سیستم وجود ندارد";

                            else if (Stock_Result == "catch")
                                return Stock_Result;

                            Stock = int.Parse(Stock_Result.Split(Split_Char)[2]);

                            Add_Result = F.Add(Person_Id, "CD", Find.Split(Split_Char)[8], (Stock + int.Parse(Find.Split(Split_Char)[9])).ToString());

                            if (Add_Result == "catch")
                                return Add_Result;

                            else if (Add_Result == "Negative")
                                return "مانده صندوق " + Find.Split(Split_Char)[1] + " کمتر از فاکتور است";
                        }

                        if (Find.Split(Split_Char)[10] != "")
                        {
                            Stock_Result = F.Stock(Person_Id, "BA", Find.Split(Split_Char)[10]);

                            if (Stock_Result == "catch")
                                return Stock_Result;

                            else if (Stock_Result == null)
                                return "حساب بانکی " + Find.Split(Split_Char)[1] + " در سیستم وجود ندارد";

                            Stock = int.Parse(Stock_Result);

                            Add_Result = F.Add(Person_Id, "BA", Find.Split(Split_Char)[10], (Stock + int.Parse(Find.Split(Split_Char)[10])).ToString());

                            if (Add_Result == "catch")
                                return Add_Result;

                            else if (Add_Result == "Negative")
                                return "مانده حساب بانکی " + Find.Split(Split_Char)[1] + " کمتر از فاکتور است";
                        }

                        if (Find.Split(Split_Char)[12] != "")
                        {
                            Stock_Result = F.Stock(Person_Id, "CH", Find.Split(Split_Char)[12]);

                            if (Stock_Result == "catch")
                                return Stock_Result;

                            else if (Stock_Result == null)
                                return "چک " + Find.Split(Split_Char)[12] + " در سیستم وجود ندارد";

                            Stock = int.Parse(Stock_Result.Split(Split_Char)[2]);

                            Add_Result = F.Add(Person_Id, "CH", Find.Split(Split_Char)[12], (Stock + int.Parse(Find.Split(Split_Char)[13])).ToString());

                            if (Add_Result == "catch")
                                return Add_Result;

                            else if (Add_Result == "Negative")
                                return "مانده چک " + Find.Split(Split_Char)[12] + " کمتر از فاکتور است";
                        }

                        Data_Groups = File.ReadAllLines(Groups_txt(Person_Id, Find.Split(Split_Char)[1], Find.Split(Split_Char)[0])).ToList();
                        List<string> New_Data_Group = new List<string>();

                        foreach (string Find2 in Data_Groups)
                        {
                            if (Find.Split(Split_Char)[2] == Find2.Split(Split_Char)[0])
                                if (int.Parse(Find2.Split(Split_Char)[1]) - int.Parse(Find.Split(Split_Char)[3]) > 0)
                                    New_Data_Group.Add(Find2.Split(Split_Char)[0] + Split_Char + (int.Parse(Find2.Split(Split_Char)[1]) - int.Parse(Find.Split(Split_Char)[3])).ToString() + Split_Char + Find2.Split(Split_Char)[2] + Split_Char + Find2.Split(Split_Char)[3] + Split_Char + Find2.Split(Split_Char)[4]);

                                else
                                    return "موجودی کالا " + Find.Split(Split_Char)[0] + "کمتر از موجودی فاکتور است ";
                        }

                        File.WriteAllText(Groups_txt(Person_Id, Find.Split(Split_Char)[1], Find.Split(Split_Char)[0]), "");

                        foreach (string Find2 in New_Data_Group)
                        {
                            File.AppendAllText(Groups_txt(Person_Id, Find.Split(Split_Char)[1], Find.Split(Split_Char)[0]), Find2 + "\n");
                        }

                        if (Find.Split(Split_Char)[7] != Factor_Number)
                        {
                            New_Data.Add(Find);
                        }
                    }

                    File.WriteAllText(Factor_Buy_txt(Person_Id, Account_Side), "");

                    if (New_Data != null)
                        foreach (string Find in New_Data)
                        {
                            File.AppendAllText(Factor_Buy_txt(Person_Id, Account_Side), Find);
                        }

                    break;

                case "فروش":

                    Data = File.ReadAllLines(Factor_Sell_txt(Person_Id, Account_Side)).ToList();
                    //  Factor_Type = Factor_Sell_txt(Person_Id, Account_Side);

                    break;

                case "برگشت از خرید":

                    Data = File.ReadAllLines(Factor_RFP_txt(Person_Id, Account_Side)).ToList();
                    //  Factor_Type = Factor_RFP_txt(Person_Id, Account_Side);

                    break;

                case "برگشت از فروش":

                    Data = File.ReadAllLines(Factor_ROS_txt(Person_Id, Account_Side)).ToList();
                    // Factor_Type = Factor_ROS_txt(Person_Id, Account_Side);

                    break;
            }

            return "Try";
        }
    }
}