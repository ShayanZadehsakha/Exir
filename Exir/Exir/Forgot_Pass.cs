using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Exir
{
    public class Forgot_Pass_Send_Email
    {
        public string User_Name;
        public string Email;
        public List<string> Data;
        public string Path;

        public string Check_Contain_Infos()
        {
            if (Data != null)
            {
                foreach (string Find in Data)
                {
                    if (Find.Split('/')[0] == User_Name && Find.Split('/')[2] == Email)
                    {
                        return User_Name + '/' + Email;
                    }
                }
            }
            return "";
        }

        public string FPSE()
        {
            string Return = Check_Contain_Infos();
            string SE = "";

            if (Return != "")
                SE = Send_Email(Return.Split('/')[1], Return.Split('_')[0], "فراموشی رمز عبور");

            return SE;
        }
        public string Send_Email(string To, string User_Name, string Subject)
        {
            try
            {
                string Random_Code = "";

                Random R = new Random();

                Random_Code += R.Next(0, 9).ToString();
                Random_Code += R.Next(0, 9).ToString();
                Random_Code += R.Next(0, 9).ToString();
                Random_Code += R.Next(0, 9).ToString();
                Random_Code += R.Next(0, 9).ToString();
                Random_Code += R.Next(0, 9).ToString();

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                //نام فرستنده
                mail.From = new MailAddress("infinite.l.o.o.pps@gmail.com");
                //آدرس گیرنده یا گیرندگان
                mail.To.Add(To);
                //عنوان ایمیل
                mail.Subject = Subject;
                //بدنه ایمیل
                mail.Body = "سلام !" + User_Name + " \n . این کد محرمانه برای تغییر رمز عبور است" + Random_Code + "\n\n\n این رمز فقط برای یک دقیقه و سی دقیقه قابل استفاده است";
                //مشخص کرن پورت 
                SmtpServer.Port = 587;
                //username : به جای این کلمه نام کاربری ایمیل خود را قرار دهید
                //password : به جای این کلمه رمز عبور ایمیل خود را قرار دهید
                SmtpServer.Credentials = new System.Net.NetworkCredential("infinite.l.o.o.pps@gmail.com", "Aria.Shayan.Askari");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                return Random_Code + '/' + "T";
            }
            catch
            {
                return "/F";
            }
        }
    }
}