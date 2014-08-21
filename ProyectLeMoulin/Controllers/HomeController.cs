using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CoeurContainer db = new CoeurContainer();
            var photos = (from e in db.Evenements
                          where e.Poublier == true
                          orderby e.DateStart
                          select new EvemPhoto
                          {
                              photos = e.PrincipalPhotoEvenement,
                              titre = e.TitleEvenement,
                              dateStart = e.DateStart,
                              dateEnd = e.DateEnd
                          }).Take(5).ToList();
            ViewBag.photos = photos;

            ViewBag.Accueil = (from s in db.Sections
                                   from p in s.Pages
                                   where p.MenuName == "Accueil" & s.Nom == "AccueilContenu"
                                   select s.Contenu).Single();

            ViewBag.Gauche = (from s in db.Sections
                              from p in s.Pages
                              where p.MenuName == "Accueil" & s.Nom == "AccueilGauche"
                              select s.Contenu).Single();
             
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
                nouvelles[x].text = Nohtml(nouvelles[x].text) + " ...";
            }

            return Json(nouvelles, JsonRequestBehavior.AllowGet);
        }

        private string Nohtml(string tiny)
        {
            int y;
            string temp = "";
            for (y = 0; y < tiny.Count() - 1; )
            {
                if (tiny.IndexOf("<", y) > -1)
                {
                    int start = tiny.IndexOf("<", y);
                    y = tiny.IndexOf(">", start) + 1;
                    start = tiny.IndexOf("<", y);
                    if ((start - y) > 0)
                    {
                        string yupi = tiny.Substring(y, (start - y)).Trim();
                        if (tiny.Substring(y, (start - y)) != "\r\n")
                        {
                            if (tiny.Substring(y, (start - y)).Trim() != "&nbsp;")
                            {
                                temp += " " + tiny.Substring(y, (start - y));
                                if (temp.Count() > 200)
                                {
                                    temp = temp.Substring(0, 199);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return temp;
        }

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
