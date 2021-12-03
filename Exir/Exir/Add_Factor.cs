using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Exir
{
    class Add_Factor : Paths
    {
        public string Buy_Action(string Person_Id, string Account_Side, string Number_Factor, string Date, DataGridView DGB, string Cash_Desk, string Cash_Desk_Price, string Bank_Account, string Bank_Account_Price, string Check, string Check_Price)
        {
            try
            {
                List<Factor_Infos> Data_Factors = new List<Factor_Infos>();
                List<string> New_Data = new List<string>();

                if (Cash_Desk_Price == "")
                    Cash_Desk_Price = "0";

                if (Bank_Account_Price == "")
                    Bank_Account_Price = "0";

                if (Check_Price == "")
                    Check_Price = "0";

                File.WriteAllText(Factor_Buy_txt(Person_Id, Account_Side), "");

                foreach (DataGridViewRow Find in DGB.Rows)
                {
                    if (Find.Cells[0].Value != null)
                    {
                        Factor_Infos FI = new Factor_Infos();

                        if (DGB.Name == "Dgb_Factors_Management")
                        {
                            FI.Group = Find.Cells[1].Value.ToString();
                            FI.Groups = Find.Cells[2].Value.ToString();
                            FI.Good = Find.Cells[3].Value.ToString();
                            FI.Stock = Find.Cells[4].Value.ToString();
                            
                            Data_Factors.Add(FI);

                            File.AppendAllText(Factor_Buy_txt(Person_Id, Account_Side), Find.Cells[1].Value.ToString() + Split_Char + Find.Cells[2].Value.ToString() + Split_Char + Find.Cells[3].Value.ToString() + Split_Char + Find.Cells[4].Value.ToString() + Split_Char + Find.Cells[5].Value.ToString() + Split_Char + Find.Cells[6].Value.ToString() + Split_Char + Date + Split_Char + Number_Factor + Split_Char + Cash_Desk + Split_Char + Cash_Desk_Price + Split_Char + Bank_Account + Split_Char + Bank_Account_Price + Split_Char + Check + Split_Char + Check_Price + "\n");
                        }
                        else
                        {
                            FI.Group = Find.Cells[0].Value.ToString();
                            FI.Groups = Find.Cells[1].Value.ToString();
                            FI.Good = Find.Cells[2].Value.ToString();
                            FI.Stock = Find.Cells[3].Value.ToString();
                            FI.Per_Unit = Find.Cells[4].Value.ToString();

                            Data_Factors.Add(FI);

                            File.AppendAllText(Factor_Buy_txt(Person_Id, Account_Side), Find.Cells[0].Value.ToString() + Split_Char + Find.Cells[1].Value.ToString() + Split_Char + Find.Cells[2].Value.ToString() + Split_Char + Find.Cells[3].Value.ToString() + Split_Char + Find.Cells[4].Value.ToString() + Split_Char + Find.Cells[5].Value.ToString() + Split_Char + Date + Split_Char + Number_Factor + Split_Char + Cash_Desk + Split_Char + Cash_Desk_Price + Split_Char + Bank_Account + Split_Char + Bank_Account_Price + Split_Char + Check + Split_Char + Check_Price + "\n");
                        }
                    }
                }

                foreach (Factor_Infos Find in Data_Factors)
                {
                    foreach (string Find_In_File in File.ReadAllLines(Groups_txt(Person_Id, Find.Groups, Find.Group)))
                    {
                        New_Data.Clear();

                        if (Find_In_File.Split(Split_Char)[0] == Find.Good)
                            New_Data.Add(Find.Good + Split_Char + (Convert.ToInt32(Find_In_File.Split(Split_Char)[1]) + Convert.ToInt32(Find.Stock)).ToString() + Split_Char + Find_In_File.Split(Split_Char)[2] + Split_Char + Find.Group + Split_Char + Find.Groups + "\n");

                        else
                            New_Data.Add(Find_In_File + "\n");

                        File.WriteAllText(Groups_txt(Person_Id, Find.Groups, Find.Group), "");

                        foreach (string Append in New_Data)
                        {
                            File.AppendAllText(Groups_txt(Person_Id, Find.Groups, Find.Group), Append);
                        }
                    }
                }

                return "Try";
            }
            catch
            {
                return "catch";
            }
        }

        public string Sell_Action(string Person_Id, string Account_Side, string Number_Factor, string Date, DataGridView DGB, string Cash_Desk, string Cash_Desk_Price, string Bank_Account, string Bank_Account_Price, string Check, string Check_Price)
        {
            try
            {
                if (Cash_Desk_Price == "")
                    Cash_Desk_Price = "0";

                if (Bank_Account_Price == "")
                    Bank_Account_Price = "0";

                if (Check_Price == "")
                    Check_Price = "0";

                List<Factor_Infos> Data_Factors = new List<Factor_Infos>();
                List<string> New_Data = new List<string>();

                foreach (DataGridViewRow Find in DGB.Rows)
                {
                    if (Find.Cells[0].Value != null)
                    {
                        Factor_Infos FI = new Factor_Infos();

                        FI.Group = Find.Cells[0].Value.ToString();
                        FI.Groups = Find.Cells[1].Value.ToString();
                        FI.Good = Find.Cells[2].Value.ToString();
                        FI.Stock = Find.Cells[3].Value.ToString();
                        FI.Per_Unit = Find.Cells[4].Value.ToString();

                        Data_Factors.Add(FI);

                        File.AppendAllText(Factor_Sell_txt(Person_Id, Account_Side), Find.Cells[0].Value.ToString() + Split_Char + Find.Cells[1].Value.ToString() + Split_Char + Find.Cells[2].Value.ToString() + Split_Char + Find.Cells[3].Value.ToString() + Split_Char + Find.Cells[4].Value.ToString() + Split_Char + Find.Cells[5].Value.ToString() + Split_Char + Date + Split_Char + Number_Factor + Split_Char + Cash_Desk + Split_Char + Cash_Desk_Price + Split_Char + Bank_Account + Split_Char + Bank_Account_Price + Split_Char + Check + Split_Char + Check_Price + "\n");
                    }
                }

                foreach (Factor_Infos Find in Data_Factors)
                {
                    foreach (string Find_In_File in File.ReadAllLines(Groups_txt(Person_Id, Find.Groups, Find.Group)))
                    {
                        if (Find_In_File.Split(Split_Char)[0] == Find.Good)
                            New_Data.Add(Find.Good + Split_Char + (Convert.ToInt32(Find_In_File.Split(Split_Char)[1]) - Convert.ToInt32(Find.Stock)).ToString() + Split_Char + Find_In_File.Split(Split_Char)[2] + Split_Char + Find.Group + Split_Char + Find.Groups + "\n");

                        else
                            New_Data.Add(Find_In_File + "\n");

                        File.WriteAllText(Groups_txt(Person_Id, Find.Groups, Find.Group), "");

                        foreach (string Append in New_Data)
                        {
                            File.AppendAllText(Groups_txt(Person_Id, Find.Groups, Find.Group), Append);
                        }
                    }
                }

                return "Try";
            }
            catch
            {
                return "catch";
            }
        }

        public string RFP_Action(string Person_Id, string Account_Side, string Number_Factor, string Date, DataGridView DGB, string Cash_Desk, string Cash_Desk_Price, string Bank_Account, string Bank_Account_Price, string Check, string Check_Price)
        {
            try
            {
                Cash_Desk_Price.Replace("", "0");
                Bank_Account_Price.Replace("", "0");
                Check_Price.Replace("", "0");

                List<Factor_Infos> Data_Factors = new List<Factor_Infos>();
                List<string> New_Data = new List<string>();

                foreach (DataGridViewRow Find in DGB.Rows)
                {
                    if (Find.Cells[0].Value != null)
                    {
                        Factor_Infos FI = new Factor_Infos();

                        FI.Group = Find.Cells[0].Value.ToString();
                        FI.Groups = Find.Cells[1].Value.ToString();
                        FI.Good = Find.Cells[2].Value.ToString();
                        FI.Stock = Find.Cells[3].Value.ToString();
                        FI.Per_Unit = Find.Cells[4].Value.ToString();

                        Data_Factors.Add(FI);

                        File.AppendAllText(Factor_RFP_txt(Person_Id, Account_Side), Find.Cells[0].Value.ToString() + Split_Char + Find.Cells[1].Value.ToString() + Split_Char + Find.Cells[2].Value.ToString() + Split_Char + Find.Cells[3].Value.ToString() + Split_Char + Find.Cells[4].Value.ToString() + Split_Char + Find.Cells[5].Value.ToString() + Split_Char + Date + Split_Char + Number_Factor + Split_Char + Cash_Desk + Split_Char + Cash_Desk_Price + Split_Char + Bank_Account + Split_Char + Bank_Account_Price + Split_Char + Check + Split_Char + Check_Price + "\n");
                    }
                }

                foreach (Factor_Infos Find in Data_Factors)
                {
                    foreach (string Find_In_File in File.ReadAllLines(Groups_txt(Person_Id, Find.Groups, Find.Group)))
                    {
                        if (Find_In_File.Split(Split_Char)[0] == Find.Good)
                            New_Data.Add(Find.Good + Split_Char + (Convert.ToInt32(Find_In_File.Split(Split_Char)[1]) - Convert.ToInt32(Find.Stock)).ToString() + Split_Char + Find_In_File.Split(Split_Char)[2] + Split_Char + Find.Group + Split_Char + Find.Groups + "\n");

                        else
                            New_Data.Add(Find_In_File + "\n");

                        File.WriteAllText(Groups_txt(Person_Id, Find.Groups, Find.Group), "");

                        foreach (string Append in New_Data)
                        {
                            File.AppendAllText(Groups_txt(Person_Id, Find.Groups, Find.Group), Append);
                        }
                    }
                }

                return "Try";
            }
            catch
            {
                return "catch";
            }
        }

        public string ROS_Action(string Person_Id, string Account_Side, string Number_Factor, string Date, DataGridView DGB, string Cash_Desk, string Cash_Desk_Price, string Bank_Account, string Bank_Account_Price, string Check, string Check_Price)
        {
            try
            {
                Cash_Desk_Price.Replace("", "0");
                Bank_Account_Price.Replace("", "0");
                Check_Price.Replace("", "0");

                List<Factor_Infos> Data_Factors = new List<Factor_Infos>();
                List<string> New_Data = new List<string>();

                foreach (DataGridViewRow Find in DGB.Rows)
                {
                    if (Find.Cells[0].Value != null)
                    {
                        Factor_Infos FI = new Factor_Infos();

                        FI.Group = Find.Cells[0].Value.ToString();
                        FI.Groups = Find.Cells[1].Value.ToString();
                        FI.Good = Find.Cells[2].Value.ToString();
                        FI.Stock = Find.Cells[3].Value.ToString();
                        FI.Per_Unit = Find.Cells[4].Value.ToString();

                        Data_Factors.Add(FI);

                        File.AppendAllText(Factor_ROS_txt(Person_Id, Account_Side), Find.Cells[0].Value.ToString() + Split_Char + Find.Cells[1].Value.ToString() + Split_Char + Find.Cells[2].Value.ToString() + Split_Char + Find.Cells[3].Value.ToString() + Split_Char + Find.Cells[4].Value.ToString() + Split_Char + Find.Cells[5].Value.ToString() + Split_Char + Date + Split_Char + Number_Factor + Split_Char + Cash_Desk + Split_Char + Cash_Desk_Price + Split_Char + Bank_Account + Split_Char + Bank_Account_Price + Split_Char + Check + Split_Char + Check_Price + "\n");
                    }
                }

                foreach (Factor_Infos Find in Data_Factors)
                {
                    foreach (string Find_In_File in File.ReadAllLines(Groups_txt(Person_Id, Find.Groups, Find.Group)))
                    {
                        if (Find_In_File.Split(Split_Char)[0] == Find.Good)
                            New_Data.Add(Find.Good + Split_Char + (Convert.ToInt32(Find_In_File.Split(Split_Char)[1]) + Convert.ToInt32(Find.Stock)).ToString() + Split_Char + Find_In_File.Split(Split_Char)[2] + Split_Char + Find.Group + Split_Char + Find.Groups + "\n");

                        else
                            New_Data.Add(Find_In_File + "\n");

                        File.WriteAllText(Groups_txt(Person_Id, Find.Groups, Find.Group), "");

                        foreach (string Append in New_Data)
                        {
                            File.AppendAllText(Groups_txt(Person_Id, Find.Groups, Find.Group), Append);
                        }
                    }
                }

                return "Try";
            }
            catch
            {
                return "catch";
            }
        }
    }
}