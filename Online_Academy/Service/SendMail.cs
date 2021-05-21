using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Online_Academy.Service
{
    public class SendMail
    {
        public string sendMail(string mail)
        {
            //email của dự án
            string email = "nhomltweb@gmail.com";
            string password = "123456789a@";
            //tao code xac nhan
            string ranCod = RandomString(10, false);

            var loginInfo = new NetworkCredential(email, password);
            var msg = new MailMessage();
            var smtpClient = new SmtpClient("smtp.gmail.com", 25);


            msg.From = new MailAddress(email);
            msg.To.Add(mail);
            msg.Subject = "Hello";
            msg.Body = "Your verify code is: " + ranCod;
            msg.IsBodyHtml = true;


            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);

            return ranCod;
        }
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder sb = new StringBuilder();
            char c;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(rand.Next(65, 87)));
                sb.Append(c);
            }
            if (lowerCase)
            {
                return sb.ToString().ToLower();
            }
            return sb.ToString();
        }
    }
}