using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace StudentManagement.Web.Api_Router
{
    public class EmailBusiness
    {
        public bool PasswordChange(string emailBody, string to)
        {
            var m = new MailMessage()
            {
                Subject = "Password Change",
                Body = emailBody,
                IsBodyHtml = true,
            };
            m.From = new MailAddress("znabi4924@gmail.com", "Student Manager");
            m.To.Add(to);
            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("znabi4924@gmail.com", "Djdjegdo786"); // Enter seders User name and password       
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(m);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
