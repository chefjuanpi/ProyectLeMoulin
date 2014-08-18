using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using System.Threading.Tasks;
using ProyectLeMoulin.Models;
using ProyectLeMoulin.Controllers;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
                    "' ><div><div class='cubobajatexto'></div> <a class='fotorama__select' href='/Home/Evenement?id=" + photos[i].titre + "'>" +
                    "<div class='alert alert-info' style=' background:#464646; background-color: rgba(91, 192, 222, 0.5);' ><div class='row'><h2>"
                    + photos[i].titre + "</h1></div><div class='row'><h2>de " + photos[i].dateStart.ToLongDateString() + " au " +
                    photos[i].dateEnd.ToLongDateString() + "</h2></div></a></div></div></div>";
            }
            ViewBag.Photos = t;

            return View();
        }

        public JsonResult getNews()
        {
            CoeurContainer db = new CoeurContainer();
            var nouvelles = (from n in db.Nouvelles
                             where n.Publier == true
                             orderby n.NouvelleDate
                             select new titreTextNouvelle
                             {
                                 titre = n.NouvelleTitle,
                                 text = n.NouvelleText
                             }).Take(5).ToList();

            for (int x = 0; x < nouvelles.Count(); x++)
            {
                int i = nouvelles.Count();
                int y;
                string temp = "";

                for (y = 0; y < nouvelles[x].text.Count() - 1; )
                {
                    if (nouvelles[x].text.IndexOf("<", y) > -1)
                    {
                        int start = nouvelles[x].text.IndexOf("<", y);
                        y = nouvelles[x].text.IndexOf(">", start) + 1;
                        start = nouvelles[x].text.IndexOf("<", y);
                        if ((start - y) > 0)
                        {
                            string yupi = nouvelles[x].text.Substring(y, (start - y)).Trim();
                            if (nouvelles[x].text.Substring(y, (start - y)) != "\r\n") 
                            {    
                                if (nouvelles[x].text.Substring(y, (start - y)).Trim() != "&nbsp;")
                                {
                                    temp += " " + nouvelles[x].text.Substring(y, (start - y));
                                    if (temp.Count() > 150)
                                    {
                                        temp = temp.Substring(0, 149);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                nouvelles[x].text = temp + " ...";
            }

            return Json(nouvelles, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult PhotoEvement()
        //{
        //    CoeurContainer db = new CoeurContainer();
        //    var photos = (from e in db.Evenements
        //                  where e.DateStart >= DateTime.Now & e.Poublier == true
        //                  orderby e.DateStart
        //                  select new
        //                  {
        //                      photos = e.PrincipalPhotoEvenement,
        //                      titre = e.TitleEvenement,
        //                      dateStart = e.DateStart,
        //                      dateEnd = e.DateEnd
        //                  }).ToList();
        //    string t = "";
        //    for (int i = 0; i < photos.Count; i++)
        //    {
        //        t += "<div data-img='../tinyfilemanager.net/resources/files/" + photos[i].photos +
        //            "' ><div><div class='cubobajatexto'></div> <a class='fotorama__select' href='/Home/Evenement?id=" + photos[i].titre + "'>" +
        //            "<div class='alert alert-info' style=' background:#464646; background-color: rgba(91, 192, 222, 0.5);' ><div class='row'><h2>" 
        //            + photos[i].titre + "</h1></div><div class='row'><h2>de " + photos[i].dateStart.ToLongDateString() + " au " + 
        //            photos[i].dateEnd.ToLongDateString() + "</h2></div></a></div></div></div>";
        //    }
        //    return Content(t);
        //}


        public ActionResult Pages(string pname)
        {
            CoeurContainer db = new CoeurContainer();
            var page = (from p in db.Pages
                        where p.Poublier == true & p.MenuName == pname
                        select p).FirstOrDefault();
            if (page == null) return Redirect("/");
            ViewBag.Title = page.Title;
            ViewBag.contenu = page.Text;
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
