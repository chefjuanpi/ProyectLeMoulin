using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    [RequireHttps]
    public class EvenementsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// function json qui permete recouperer de la bd les evenements dans un cicle presice de temp
        /// la comunication ce fait directement sur full calendar et ces donnes apres sont evoyes a le
        /// template handelbar pour le preview des pages
        /// </summary>
        /// <param name="start">date de commence du cicle</param>
        /// <param name="end">date de fin</param>
        /// <param name="ti">parametre optionel necesarie pour le plug in ful calendar</param>
        /// <returns>l'ensemble des evenemets durant un periode precise</returns>
        public JsonResult getEvements(System.DateTime start, System.DateTime end, double ti = 0)
        {
            CoeurContainer db = new CoeurContainer();
            //obtenir les evenements de un date superior ou égal à start
            var calendar = (from e in db.Evenements
                            where e.DateStart >= start & e.Poublier == true
                            select new t
                            {
                                date = e.DateStart,
                                datefin = e.DateEnd,
                                heureStart = (TimeSpan)e.HourStart,
                                heurefin = (TimeSpan)e.HourEnd,
                                title = e.TitleEvenement,
                                description = e.Text,
                                photo = e.PrincipalPhotoEvenement
                            }).ToList();

            //retire les evenement avec le date superior a le valeur de end
            calendar.RemoveAll(e => e.date > end);

            List<evDisplay> eve = new List<evDisplay>();

            //instancier un controleur pour utiliser la fonction NOHTML
            HomeController nohtml = new HomeController();

            //change le format des donnes au format desire et ajoute certain information.
            for (int x = 0; x < calendar.Count(); x++)
            {
                int i = calendar.Count();
                calendar[x].description = nohtml.Nohtml(calendar[x].description) + " ...";

                string s = String.Format("{0:yyyy-MM-dd}", calendar[x].date);
                s += "T";
                s += calendar[x].heureStart.ToString();

                string e = String.Format("{0:yyyy-MM-dd}", calendar[x].datefin);
                e += "T";
                e += calendar[x].heurefin.ToString();

                evDisplay temp = new evDisplay
                {
                    title = calendar[x].title,
                    start = s,
                    end = e,
                    url = "/Evenements/Details?nom=" + calendar[x].title,
                    description = calendar[x].description,
                    photo = calendar[x].photo,
                    backgroundColor = "#009d28"
                };

                eve.Add(temp);
            }
            return Json(eve, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// control de la view qui affiche les details d'un evenement
        /// </summary>
        /// <param name="nom">string </param>
        /// <returns>si le nom corresponde a un evenement existant retourne a la view les donnes 
        /// correspondant sinon retourne une page vide</returns>
        public ActionResult Details(string nom)
        {
            CoeurContainer db = new CoeurContainer();
            Evenement ev = (from e in db.Evenements
                            where e.Poublier == true & e.TitleEvenement == nom
                            select e).SingleOrDefault();
           ViewBag.evenement = (ev != null) ? ev: null;

            
            return View();
        }
    }
}