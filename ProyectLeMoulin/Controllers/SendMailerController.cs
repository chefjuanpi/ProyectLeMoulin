using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;

namespace SendMail.Controllers
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
        public ViewResult Index(MailModel obj)
        {
            if (ModelState.IsValid)
            {
                
                MailMessage mail = new MailMessage();

                mail.To.Add(obj.to);
                mail.From = new MailAddress(obj.from);
                mail.Subject = obj.Subject;
                string Body = obj.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("ton@sand.wich", "ummm");// Enter seders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}