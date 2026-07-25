using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Uni.Services
{
    public class EmailService
    {

        public static void SendEmail(string to, string subject, string body)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com" , 587);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("giorgiplays2pro@gmail.com", "rnqq ifez spzt usri");

            MailMessage message = new MailMessage();

            message.From = new MailAddress("giorgiplays2pro@gmail.com");
            message.To.Add(to);
            message.Subject = subject;
            message.Body = body;


            smtp.Send(message);
        }

    }
}

//Smtp
//http
//ftp - file transfer protocol
