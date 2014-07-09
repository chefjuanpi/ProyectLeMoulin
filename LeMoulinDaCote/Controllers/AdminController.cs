using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeMoulinDaCote.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Configuration()
        {
            ViewBag.Message = "Configuration de base";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Pages()
        {
            ViewBag.Message = "Edition des pages du site";

            return View();
        }

        public ActionResult Evenements()
        {
            ViewBag.Message = "creer une nouvelle page";

            return View();
        }
    }
}