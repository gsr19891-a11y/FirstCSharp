using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace ATM.Services
{
    public class EmailService
    {

        public static void SendEmail(string to, string subject, string body)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("giorgiplays2pro@gmail.com", "jykh phlk swav axhr");


            MailMessage message = new MailMessage();

            message.From = new MailAddress("gsr19891@gmail.com");

            message.To.Add(to);
            //message.To.Add("gsr19891@gmail.com");

            message.Subject = subject;
            message.Body = body;


            smtp.Send(message);

        }











    }
}
