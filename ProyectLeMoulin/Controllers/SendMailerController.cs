using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using System.Configuration;
using System.Threading.Tasks;

namespace IdentitySample.Controllers
{
    public class SendMailerController : Controller
    {
       public static bool sendMailer(MailMessage mail)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                (ConfigurationManager.AppSettings["mailAccount"],
                ConfigurationManager.AppSettings["mailPassword"]);// Enter seders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}