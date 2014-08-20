﻿using IdentitySample.Models;
using System;
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
                    "' data-thumb='../tinyfilemanager.net/resources/thumbs/" + photos[i].photos +
                    "' ><div><div class='cubobajatexto'></div> <a class='fotorama__select' href='/Home/Evenement?id=" + photos[i].titre + "'>" +
                    "<div class='alert alert-info' style=' background:#464646; background-color: rgba(91, 192, 222, 0.5);' ><div class='row'><h2>"
                    + photos[i].titre + "</h1></div><div class='row'><h2>de " + photos[i].dateStart.ToLongDateString() + " au " +
                    photos[i].dateEnd.ToLongDateString() + "</h2></div></a></div></div></div>";
            }
            ViewBag.Photos = t;

            ViewBag.Accueil = (from s in db.Sections
                                   from p in s.Pages
                                   where p.MenuName == "Accueil" & s.Nom == "AccueilContenu"
                                   select s.Contenu).Single();

            var x = (from s in db.Sections
                              from p in s.Pages
                              where p.MenuName == "Accueil" & s.Nom == "AccueilGauche"
                              select s.Contenu).Single();
            ViewBag.Gauche = "<h2>Suivez-Nous</h2>" + x;
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

        public ActionResult Calendar()
        {
            ViewBag.Message = "Calendrier des évenements.";

            return View();
        }

        public ActionResult testcalendar()
        {
            ViewBag.Message = "Calendrier des évenements.";

            return View();
        }

        public JsonResult events123()
        {
            CoeurContainer db = new CoeurContainer();
            var calendar = (from e in db.Evenements
                           select new evDisplay
                           {
                               date = e.DateStart,
                               datefin = e.DateEnd,
                               type = "evenement",
                               heureStart = (TimeSpan)e.HourStart,
                               heurefin = (TimeSpan)e.HourEnd,
                               title = e.TitleEvenement,
                               description = e.Text,
                               url = "/Home/evenement?nom='"+e.TitleEvenement +"'"
                           }).ToList();

            for (int x = 0; x < calendar.Count(); x++)
            {
                int i = calendar.Count();
                calendar[x].description = Nohtml(calendar[x].description) + " ...";
                if(calendar[x].date != calendar[x].datefin)
                {
                    for (int ini = calendar[x].date.Day; ini < calendar[x].datefin.Day; ini++)
                    {
                        evDisplay temp = new evDisplay
                        {
                            date = calendar[x].date.AddDays(1),
                            datefin = calendar[x].datefin,
                            type = "evenement",
                            heureStart = calendar[x].heureStart,
                            heurefin = calendar[x].heurefin,
                            title = "Continuation de : " + calendar[x].title,
                            description = calendar[x].description,
                            url = calendar[x].url
                        };
                        calendar.Add(temp);
                    }
                }
            }
            return Json(calendar, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GroupedAchats()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
