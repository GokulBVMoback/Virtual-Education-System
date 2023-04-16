using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace BLL.EmailTemplate
{
    public class EmailTemplate
    {

        public static bool SendEmail(string toEmail , string emailBody , string subject)
        {
            try
            {
				MailMessage mail = new MailMessage();
				SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

				mail.From = new MailAddress("abc@gmail.com");
				mail.To.Add(toEmail);
				mail.Subject = "Test Mail";
				mail.Body = emailBody;

				SmtpServer.Port = 587;
				SmtpServer.Credentials = new System.Net.NetworkCredential("abc@gmail.com", "Password@10");
				SmtpServer.EnableSsl = true;

				SmtpServer.Send(mail);
				return true;
			}
            catch(Exception ex)
            {
                return false;

            }
        }

        
        // Email for Student registration
        public static bool StudentRegistrationEmail (string userEmail, string emailbody)
        {
            //url = "";
            try
            {
                SmtpClient client = new SmtpClient
                { // Host = "smtpout.secureserver.net",
                    Host = "smtp.gmail.com",
                    Port = 587,
                    UseDefaultCredentials = false,
                    EnableSsl = true


                };



				MailMessage mail = new MailMessage();
				SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

				mail.From = new MailAddress("abc@gmail.com");
				mail.To.Add(userEmail);
				mail.Body = emailbody;

				SmtpServer.Port = 587;
				const string fromAddress = "abc@gmail.com";
				const string subject = "Verfication Email";
				string body = emailbody;
				var msg = new MailMessage(fromAddress, userEmail, subject, body) { IsBodyHtml = true };
				SmtpServer.Credentials = new System.Net.NetworkCredential("abc@gmail.com", "Password@10");
				SmtpServer.EnableSsl = true;

				SmtpServer.Send(msg);
				


				//NetworkCredential credentials = new NetworkCredential("abc@gmail.com", "Password@10");
                //client.UseDefaultCredentials = false;
                //client.Credentials = credentials;
                //const string fromAddress = "abc@gmail.com";
                //const string subject = "Verfication Email";
                //string body = emailbody;
                //var msg = new MailMessage(fromAddress, userEmail, subject, body) { IsBodyHtml = true };
                //msg.To.Add(userEmail);
                //client.Send(msg);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
