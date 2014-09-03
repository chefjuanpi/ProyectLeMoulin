using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;

namespace IdentitySample.Controllers
{
    [RequireHttps]
    public class NouvellesController : Controller
    {
        // GET: Nouvelles envoi la liste des nouvelles
        public ActionResult Index()
        {
            CoeurContainer db = new CoeurContainer();
            var a = (from n in db.Nouvelles
                     select new newslistViewModel
                     {
                         id = n.NouvelleId,
                         titre = n.NouvelleTitle,
                         date = n.NouvelleDate
                     }).ToList();
            ViewBag.message = "Liste de tous les nouvelles poublies dans le site web";
            return View(a);
        }

        /// <summary>
        /// function qui permet voir la page de un nouvelle en speciaux
        /// </summary>
        /// <param name="title">prend le titre de la nouvelle por la recherche</param>
        /// <returns>la information de la nouvelle correcte</returns>
        public ActionResult Details(string title)
        {
            CoeurContainer db = new CoeurContainer();
            string t = title.Replace('_', ' ');
            var news = (from n in db.Nouvelles
                        where n.Publier == true & n.NouvelleTitle == t
                        select n).SingleOrDefault();
            if (news == null)
            {
                ViewBag.errorMessage = "Le lien démandé marche pas, SVP vous devez aller a la page d'accueil pour continuer ";
                return View("Error");
            }

            var ID = news.UserId;
            var user = (from n in db.AspNetUsers
                        where n.Id == ID
                        select n).SingleOrDefault();
            ViewBag.author = user.Prenom + " " + user.Nom;
            ViewBag.news = news;

            return View();
        }
    }
}