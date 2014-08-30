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
        //
        // GET: /SendMailer/  
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult _SendMail(MailModel obj)
        {
           
            if (ModelState.IsValid)
            {
                
                MailMessage mail = new MailMessage();
                mail.ReplyToList.Add(new MailAddress(obj.from));
                mail.To.Add(obj.to);
                mail.From = new MailAddress(obj.from);
                mail.Subject = obj.Subject;
                string Body = obj.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                sendMailer(mail);
                ViewBag.courriel = "- votre courriel à été envoyé";
                return RedirectToAction(obj.adresse);
            }
            else
            {
                ViewBag.courriel = "- votre courriel à été envoyé";
                return RedirectToAction(obj.adresse);
            }
        }

        public static void sendMailer(MailMessage mail)
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
        }

    }
}