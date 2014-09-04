using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
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
                          where e.Poublier == true & e.DateStart >= DateTime.Now 
                          orderby e.DateStart
                          select new EvemPhoto
                          {
                              photos = e.PrincipalPhotoEvenement,
                              titre = e.TitleEvenement,
                              dateStart = e.DateStart,
                              dateEnd = e.DateEnd,
                              details =  e.Text
                          }).Take(5).ToList();
            
            if(photos.Count < 5 )
            {
                int i = 5 - photos.Count;
                var p2 = (from e in db.Evenements
                          where e.Poublier == true & e.DateStart < DateTime.Now
                          orderby e.DateStart descending
                          select new EvemPhoto
                          {
                              photos = e.PrincipalPhotoEvenement,
                              titre = e.TitleEvenement,
                              dateStart = e.DateStart,
                              dateEnd = e.DateEnd,
                              details = e.Text
                          }).Take(i).ToList();

                var temp = new List<EvemPhoto>(photos.Count + p2.Count);
                temp.AddRange(photos);
                temp.AddRange(p2);
                photos = temp;
            }

            for (int x = 0; x < photos.Count(); x++)
            {
                photos[x].details = Nohtml(photos[x].details) + " ...";
            }

            ViewBag.photos = photos;

            //obtienne de la bd le contenu principal de la page
            var a = (from s in db.Sections
                     from p in s.Pages
                     where p.MenuName == "Accueil" & s.Nom == "AccueilContenu"
                     select s.Contenu).Single();
            ViewBag.Accueil = a;

            //obtienne de la bd le code des plug-ins sociales
            ViewBag.Gauche = (from s in db.Sections
                              from p in s.Pages
                              where p.MenuName == "Accueil" & s.Nom == "AccueilGauche"
                              select s.Contenu).Single();
            ViewBag.Message = Nohtml(a);
             
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
                                 text = n.NouvelleText,
                                 photo = n.NouvellePrincipalPhoto
                             }).Take(3).ToList();

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
        public static string Nohtml(string tiny)
        {
            int y;
            string temp = "";
            if( tiny != null)
            { 
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
            string x = pname.Replace('_', ' ');
            CoeurContainer db = new CoeurContainer();
            var page = (from p in db.Pages
                        where p.Poublier == true & p.MenuName == x
                        select p).FirstOrDefault();
            
            if (page == null)
            {
                ViewBag.errorMessage = "Le lien démandé marche pas, SVP vous devez aller a la page d'accueil pour continuer ";
                return View("Error");
            }
            ViewBag.Title = page.Title;
            ViewBag.contenu = page.Text;
            ViewBag.Message = Nohtml(page.Text);
            return View();
        }

        public ActionResult Contact()
        {
            CoeurContainer db = new CoeurContainer();
            var b = (from a in db.Pages where a.MenuName == "Contactez-Nous" select a).SingleOrDefault();

            var s = (from a in db.Pages
                     from r in a.Sections
                     where a.MenuName == "Contactez-Nous"
                     select r).ToList();

            foreach (Section r in s)
            {
                switch (r.Nom)
                {
                    case "ville": ViewBag.Cville = r.Contenu; break;
                    case "province": ViewBag.Cprov = r.Contenu; break;
                    case "phone": ViewBag.CPhone = r.Contenu; break;
                    case "email": ViewBag.CEmail = r.Contenu; break;
                    case "codpos": ViewBag.CcodPos = r.Contenu; break;
                }
            }

            ViewBag.Caddresse = b.Title;
            ViewBag.Cmap = b.Text;
            ViewBag.Message = "La page de contact du collective le moulin d'à côté " + ViewBag.addresse + " " + ViewBag.ville +
                " " + ViewBag.prov + " " + ViewBag.codPos + " " + ViewBag.Email + " téléphone : " + ViewBag.Phone;
            return View();
        }

        public ActionResult GroupedAchats()
        {
            CoeurContainer db = new CoeurContainer();
            var page = (from p in db.Pages
                        where p.MenuName == "Groupe d'achats"
                        select p).Single();

            if (page == null)
            {
                ViewBag.errorMessage = "Le lien démandé marche pas, SVP vous devez aller a la page d'accueil pour continuer ";
                return View("Error");
            }
            ViewBag.Title = page.Title;
            ViewBag.contenu = page.Text;
            ViewBag.Message = Nohtml(page.Text);

            return View();
        }

        /// <summary>
        /// FUnction pour envoyer courriel du site web au adminitrateur du site, avec un copie a le courriel de qui avez envoyé le courriel
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult _SendMail(MailModel obj)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.ReplyToList.Add(new MailAddress(obj.to));
                mail.To.Add(ConfigurationManager.AppSettings["mailAccount"]);
                mail.From = new MailAddress(ConfigurationManager.AppSettings["mailAccount"]);
                mail.To.Add(new MailAddress(obj.to));
                mail.Subject = "site web - " + obj.Subject;
                string Body = "Courriel de " + obj.to + " Contenu:  " + obj.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                if (!SendMailerController.sendMailer(mail)) return Json("error", JsonRequestBehavior.AllowGet);
                ViewBag.courriel = "- votre courriel à été envoyé";
                return Json("success", JsonRequestBehavior.AllowGet);  
            }
            return Json("error", JsonRequestBehavior.AllowGet); 
        }
    }
}