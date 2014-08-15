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
                              photos = e.PrincipalPhotoEvenement,
                              titre = e.TitleEvenement,
                              dateStart = e.DateStart,
                              dateEnd = e.DateEnd
                          }).ToList();
            string t = "";
            for (int i = 0; i < photos.Count; i++)
            {
                t += "<div data-img='../tinyfilemanager.net/resources/files/" + photos[i].photos +
                    "' >" +
                    "<div><div class='cubobajatexto'></div> <a class='fotorama__select' href='/Home/Evenement?id=" + photos[i].titre + "'>" +
                    "<div class='alert alert-info' style=' background:#464646; background-color: rgba(91, 192, 222, 0.5);' ><div class='row'><h2>" + photos[i].titre + "</h1></div><div class='row'><h2>de " +
                    photos[i].dateStart.ToLongDateString() + " au " + photos[i].dateEnd.ToLongDateString() + "</h2></div></a></div></div></div>";


            }
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
