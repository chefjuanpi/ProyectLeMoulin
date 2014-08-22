using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Generateur de la page de Accueil
        /// </summary>
        /// <returns>return les plusieurs components de la page</returns>
        public ActionResult Index()
        {
            CoeurContainer db = new CoeurContainer();
            //obtienne de la bd les dernier 5 evenemets avec sont informstion de base, et les envoi dans ViewBag.photos
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

            //obtienne de la bd le contenu principal de la page
            ViewBag.Accueil = (from s in db.Sections
                                   from p in s.Pages
                                   where p.MenuName == "Accueil" & s.Nom == "AccueilContenu"
                                   select s.Contenu).Single();

            //obtienne de la bd le code des plug-ins sociales
            ViewBag.Gauche = (from s in db.Sections
                              from p in s.Pages
                              where p.MenuName == "Accueil" & s.Nom == "AccueilGauche"
                              select s.Contenu).Single();
             
            return View();
        }

        /// <summary>
        /// function JSON pour recouperer les dernieres 5 nouvelles
        /// </summary>
        /// <returns>return list de nouvelles</returns>
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

        /// <summary>
        /// function qui permet retirer le code html, de string retourné de la bd, cette champ a été fait avec tinyMCE
        /// </summary>
        /// <param name="tiny">texte a retirer le html</param>
        /// <returns>un string avec les premiers 200 characteres du parametre string</returns>
        private string Nohtml(string tiny)
        {
            int y;
            string temp = "";
            for (y = 0; y < tiny.Count() - 1; )
            {
                int start = tiny.IndexOf("<", y);
                y = (start == 0 || y !=0  ) ? tiny.IndexOf(">", start) + 1 : y;
                start = tiny.IndexOf("<", y);
                if ((start - y) > 0)
                {
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
                y = (y == 0) ? tiny.IndexOf(">", start) + 1 : y;
            }

            return temp;
        }

        /// <summary>
        /// action Result de generation de la page Pages
        /// </summary>
        /// <param name="pname">receive le nom de la page a rechercher</param>
        /// <returns>two viewBags avec l'information necesaire pour creer la page</returns>
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