using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using System.Threading.Tasks;
using ProyectLeMoulin.Models;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PhotoEvement()
        {
            CoeurContainer db = new CoeurContainer();
            var photos = (from e in db.Evenements
                          where e.DateStart >= DateTime.Now & e.Poublier == true
                          orderby e.DateStart
                          select new
                          {
                              photos = e.PrincipalPhotoEvenement
                          }).ToList();
            string t = "";
            for (int i = 0; i < photos.Count; i++)
            {
                t += "<img href='../tinyfilemanager.net/resources/files/" + photos[i].photos + 
                    "'" + "src='../tinyfilemanager.net/resources/thumbs/" + photos[i].photos + 
                    "'>";
            }
            t += "";
            int o = 0;
            return Content(t);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GroupedAchats()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
