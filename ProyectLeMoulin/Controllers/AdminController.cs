using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;

namespace IdentitySample.Controllers
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

        public ActionResult Notice()
        {
            ViewBag.Message = "creer une notice";

            return View();
        }
        
        public virtual ActionResult Photos()
        {
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Files/MyFolder"));
            // Enumerating all 1st level directories of a given root folder (MyFolder in this case) and retrieving the folders names.
            var folders = di.GetDirectories().ToList().Select(d => d.Name);

            return View(folders);
        }

     
        public virtual ActionResult Files(string subFolder)
        {        // FileViewModel contains the root MyFolder and the selected subfolder if any
            FileViewModel model = new FileViewModel() { Folder = "MyFolder", SubFolder = subFolder };

            return View(model);
        }


    }
}