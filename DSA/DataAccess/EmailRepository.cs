using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace DataAccess
{
    public class EmailRepository : ConnectionClass
    {
        public void SendEmail(string destinationaddress,string body)
        {
            try
            {

                MailMessage NewUserWelcome = new MailMessage();




                NewUserWelcome.Body = body;
                NewUserWelcome.Subject = "Appointment Status Update";

                NewUserWelcome.From = new System.Net.Mail.MailAddress("noreply@thegreatsupermarket.com");


                //List<string> adminEmails = new UsersBL().getUserEmailsByRole(1);
                //foreach (string e in adminEmails)
                //{
                //    orderEmail.To.Add(new MailAddress(e));
                //}
                NewUserWelcome.To.Add(new MailAddress(destinationaddress));
                NewUserWelcome.To.Add(new MailAddress("garyrizzo92@gmail.com"));

                System.Net.Mail.SmtpClient Smtp = new SmtpClient("smtp.gmail.com");

                //Smtp.Host = "smtp.gmail.com"; // for example gmail smtp server
                Smtp.Port = 587;
                Smtp.Credentials = new System.Net.NetworkCredential("garyrizzo92@gmail.com", "Abc123!!");
                Smtp.EnableSsl = true;
                Smtp.Send(NewUserWelcome);
            }
            catch (Exception eX)
            {
                throw new Exception(eX.ToString(), eX);
            }
        }
    }
}
