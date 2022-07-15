using Microsoft.AspNetCore.Identity;
using System;
using System.Net;
using System.Net.Mail;
using WebApplication7.Models;

namespace WebApplication7.BL.Halper
{
    public static class MailHalper
    {
      
          public static string sendMail(MailVM mail)
        {
            try
            {

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                smtp.EnableSsl = true;

                smtp.Credentials = new NetworkCredential("mme61627@gmail.com", "yhydybuutjvefklv");


                smtp.Send("mme61627@gmail.com", mail.Customer,mail.Title ,mail.Massege );
                


                return "Mail Sent Successfully";


                }
            catch (Exception ex)
            {
                return "Mail Faild";
            }
        }
         public static string sendMailResetPassword(string Titele ,string Massage)
        {
            try
            {

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                smtp.EnableSsl = true;

                smtp.Credentials = new NetworkCredential("mme61627@gmail.com", "yhydybuutjvefklv");


                smtp.Send("mme61627@gmail.com", "mme61627@gmail.com",Titele , Massage );
                


                return "Mail Sent Successfully";

              
            }
            catch (Exception ex)
            {
                return "Mail Faild";
            }
        }


       
    }


}

