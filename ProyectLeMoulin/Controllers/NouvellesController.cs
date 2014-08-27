using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;

namespace IdentitySample.Controllers
{
    public class NouvellesController : Controller
    {
        // GET: Nouvelles envoi la liste des nouvelles
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// function qui permet voir la page de un nouvelle en speciaux
        /// </summary>
        /// <param name="title">prend le titre de la nouvelle por la recherche</param>
        /// <returns>la information de la nouvelle correcte</returns>
        public ActionResult Details(string title)
        {
            CoeurContainer db = new CoeurContainer();

            var news = (from n in db.Nouvelles
                        where n.Publier == true & n.NouvelleTitle == title
                        select n).SingleOrDefault();
            var ID = news.UserId;
            var user = (from n in db.AspNetUsers
                        where n.Id == ID
                        select n).SingleOrDefault();
            ViewBag.author = user.Prenom + user.Nom;
            ViewBag.news = news;

            return View();
        }
    }
}