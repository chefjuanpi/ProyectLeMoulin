using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace IdentitySample.Controllers
{
    [RequireHttps]
    [Authorize(Roles = "Administrateur")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Configuration()
        {
            ViewBag.Message = "Configuration de base";

            return View();
        }

        /// <summary>
        /// function Get pour  recouperer accueil
        /// </summary>
        /// <returns>return de la bd la information enregistre</returns>
        public ActionResult Accueil()
        {
            ViewBag.Title = "Modifier la page d'accueil";
            ViewBag.Message = "Edition de la page accueil";

            CoeurContainer db = new CoeurContainer();

            ViewBag.TinyAccueil = (from s in db.Sections
                               from p in s.Pages
                               where p.MenuName == "Accueil" & s.Nom == "AccueilContenu"
                               select s.Contenu).Single();

            ViewBag.Gauche = (from s in db.Sections
                              from p in s.Pages
                              where p.MenuName == "Accueil" & s.Nom == "AccueilGauche"
                              select s.Contenu).Single();
            return View();
        }

        /// <summary>
        /// Function Post qui permet sousgarder les changemetns fait dans  la page Accueil
        /// </summary>
        /// <param name="page"> reçu le model contenant l'information a modifier</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Accueil(AccueilViewModel page)
        {
            CoeurContainer db = new CoeurContainer();

            var Gauche = (from s in db.Sections
                          from p in s.Pages
                          where p.MenuName == "Accueil" & s.Nom == "AccueilGauche"
                          select s).Single();
            
            var contenu = (from s in db.Sections
                           from p in s.Pages
                           where p.MenuName == "Accueil" & s.Nom == "AccueilContenu"
                           select s).Single();

            Gauche.Contenu = page.Gauche;
            contenu.Contenu = page.Contenu;

            await db.SaveChangesAsync();

            ViewBag.TinyAccueil = page.Contenu;
            ViewBag.Gauche = page.Gauche;
            return View();
        }

        public ActionResult Achats()
        {
            ViewBag.Title = "Modifier la page d'accueil";
            ViewBag.Message = "Edition de la page accueil";

            CoeurContainer db = new CoeurContainer();

            var a  = (from p in db.Pages
                      where p.MenuName == "Groupe d'achats"
                      select p).Single();
            PachatsViewModel m = new PachatsViewModel();
            m.Contenu = a.Text;
            m.Titre = a.Title;
            m.fb = true;
            return View(m);
        }

        /// <summary>
        /// Function Post qui permet sousgarder les changemetns fait dans  la page de presentation du groupe d'achats
        /// </summary>
        /// <param name="page"> reçu le model contenant l'information a modifier</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Achats(PachatsViewModel page)
        {
            CoeurContainer db = new CoeurContainer();

            var gAchats = (from p in db.Pages
                              where p.MenuName == "Groupe d'achats"
                              select p).Single();

            gAchats.Text = page.Contenu;
            gAchats.Title = page.Titre;

            await db.SaveChangesAsync();
            if(page.fb)
            {
                string s = gAchats.Title + "  " + ": Sont des Nouvelles dans le groupe d'achats éntre dans notre site por savoir plus... "
                    + ConfigurationManager.AppSettings["server"] + "Home/GroupedAchats";
                publierFB(s, "/Images/logo.jpg");
            }

            return View();
        }


        public ActionResult Pages()
        {
            ViewBag.Title = "Editeur des Pages";
            ViewBag.Message = "Edition des pages du site";
            ViewBag.ispostBack = false;
            return View();
        }

        /// <summary>
        /// function Post qui permet sousgarder ou modifier les pages du site
        /// </summary>
        /// <param name="page">est le modele</param>
        [HttpPost]
        public async Task<ActionResult> Pages(PagesViewModel page)
        {
            ViewBag.Title = "Editeur des Pages";
            CoeurContainer db = new CoeurContainer();
            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;
            
            //liste de titres de page déjà enregistrées dans la db
            var listTitres = (from a in db.Pages select a.Title).ToList();
            
            //liste des nom de menu déjà enregistres dans la bd
            var listmenus = (from a in db.Pages select a.MenuName).ToList();
            string titre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(page.Titre.ToLower());
            string menu = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(page.MenuName.ToLower());

            if (page.PId == null)
            {
                if (listTitres.Contains(titre))
                {
                    ViewBag.ispostBack = true;
                    ModelState.AddModelError("", "Existe déjà un page avec ce Titre, changer le avant de continuer");
                    return View();
                }
                else
                {
                    if (listmenus.Contains(menu))
                    {
                        ViewBag.ispostBack = true;
                        ModelState.AddModelError("", "Existe déjà un page avec ce Nom de menu, changer le avant de continuer");
                        return View();
                    }
                    else
                    {
                        Page n = new Page();
                        n.MenuName = menu;
                        n.UserId = guid;
                        n.Title = titre;
                        n.Text = page.Contenu;
                        n.Poublier = page.Publier;
                        n.Principal = page.Principal;
                        if (page.Principal == false)
                        {
                            n.SousMenu = page.menuParent;
                        }
                        else
                        {
                            n.SousMenu = null;
                        }
                        db.Pages.Add(n);
                        await db.SaveChangesAsync();
                        if (n.Poublier == true && page.fb == true)
                        {
                            string p = "/Images/logo.jpg";
                            string s = n.Title + "  " + " pour plus d'information sur cette événement, clic dans le lien "
                                + ConfigurationManager.AppSettings["server"] + "Nouvelles/Details?title=" + n.Title.Replace(' ', '_');
                            publierFB(s, p);
                        }
                    }
                }
            }
            else
            {
                int x = Convert.ToInt16(page.PId);

                // actualise la liste titres pour ne prend en consideration dans la recherche le titre actuel
                listTitres = (from a in db.Pages
                              where a.PageID != x
                              select a.Title).ToList();

                //actualise la liste des menus pour ne prend en consideration dans la recherche le menu actuel
                listmenus = (from a in db.Pages where a.PageID != x select a.MenuName).ToList();
                if (listTitres.Contains(titre))
                {
                    ViewBag.ispostBack = true;
                    ModelState.AddModelError("", "Éxiste déjà un page avec ce Titre, changer le avant de continuer");
                    return View();
                }
                else
                {
                    if (listmenus.Contains(menu))
                    {
                        ViewBag.ispostBack = true;
                        ModelState.AddModelError("", "Existe déjà un page avec ce Nom de menu, changer le avant de continuer");
                        return View();
                    }
                    else
                    {
                        var n = (from a in db.Pages
                                 where a.PageID == x
                                 select a).SingleOrDefault();
                        //si éxiste la page fait l'edition
                        if(n !=null)
                        { 
                            n.UserId = guid;
                            n.Title = titre;
                            n.Text = page.Contenu;
                            n.MenuName = menu;
                            n.Poublier = page.Publier;
                            n.Principal = page.Principal;
                            if (page.Principal == false)
                            {
                                n.SousMenu = page.menuParent;
                            }
                            else
                            {
                                n.SousMenu = null;
                            }
                            await db.SaveChangesAsync();
                            if (n.Poublier == true && page.fb == true)
                            {
                                string p = "/Images/logo.jpg";
                                string s = n.Title + "  " + " pour plus d'information sur cette événement, clic dans le lien "
                                                + ConfigurationManager.AppSettings["server"] + "Nouvelles/Details?title=" + n.Title;
                                publierFB(s, p);
                            }
                        }
                    }
                }
            }
            ViewBag.ispostBack = false;
            return View();
        }

        /// <summary>
        /// function Json permet recouperer l'ensemble des pages du site
        /// </summary>
        /// <returns>
        /// return tous le id et titre de tous les pages
        /// </returns>
        public JsonResult getPages()
        {
            CoeurContainer db = new CoeurContainer();
            var nouvelles = (from n in db.Pages
                             where n.PageID > 4
                             select new
                             {
                                 id = n.PageID,
                                 Titre = n.MenuName
                             });
            return Json(nouvelles, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// function json qui permet recouperer la liste de pages qui sont menu principal
        /// </summary>
        public JsonResult getparents()
        {
            CoeurContainer db = new CoeurContainer();
            var nouvelles = (from n in db.Pages
                             where n.Principal == true & n.PageID > 1
                             select new
                             {
                                 id = n.PageID,
                                 Titre = n.MenuName
                             }).ToList();
            return Json(nouvelles, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// funsion json qjui permet recouper le detail de un page
        /// </summary>
        /// <param name="pageId"></param>
        public JsonResult getPDetails(int pageId)
        {
            CoeurContainer db = new CoeurContainer();
            var nouvelle = (from n in db.Pages
                            where n.PageID == pageId
                            select new
                            {
                                id = n.PageID,
                                Titre = n.Title,
                                page = n.Text,
                                publier = n.Poublier,
                                principal = n.Principal,
                                menuparent = n.SousMenu,
                                menuName = n.MenuName
                            }).SingleOrDefault();
            return Json(nouvelle, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// action result qui permet effacer de la bd un page
        /// </summary>
        /// <param name="pID">Id de page a effacer</param>
        /// <returns>return resultat</returns>
        public async Task<ActionResult> delPage(int pID)
        {
            CoeurContainer db = new CoeurContainer();
            var parentsList = (from a in db.Pages select a.SousMenu).ToList();
            if (parentsList.Contains(pID))
            {
                ViewBag.ispostBack = true;
                ModelState.AddModelError("", "Imposible de Effacer, cete page est menu principal pour outres pages, retirer les avent");
                return Redirect("/Admin/Pages");
            }
            else
            { 
                var delpage = (from n in db.Pages
                                    where n.PageID == pID
                                    select n).SingleOrDefault();
                if (delpage != null)
                {
                    db.Pages.Remove(delpage);
                    await db.SaveChangesAsync();
                }
                else
                {
                    ViewBag.ispostBack = true;
                    ModelState.AddModelError("", "Un erreur est produit, la page n'été pas efface !, essai un outre fois");
                    return Redirect("/Admin/Pages");
                }
            }
            ViewBag.ispostBack = false;
            return Redirect("/Admin/Pages");
        }

        public ActionResult Evenements_a_venir()
        {
            ViewBag.Message = "creer une nouvelle page";
            ViewBag.ispostBack = false;
            return View();
        }

        public ActionResult Evenements_Passes()
        {
            ViewBag.Message = "creer une nouvelle page";
            ViewBag.ispostBack = false;
            return View();
        }

        /// <summary>
        /// function Post qui permet sousgarder ou modifier les pages du site
        /// </summary>
        /// <param name="Evenement"> est le modele</param>
        [HttpPost]
        public async Task<ActionResult> Evenements_a_venir(EvenementsViewModel Evenement)
        {
            CoeurContainer db = new CoeurContainer();
            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;

            //lliste des titres de évenements dêjà existants
            var listTitres = (from a in db.Evenements select a.TitleEvenement).ToList();
            string titre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Evenement.Titre.ToLower());
            if (Evenement.PId == null)
            {
                if (listTitres.Contains(titre))
                {
                    ViewBag.ispostBack = true;
                    ModelState.AddModelError("", "Éxiste déjà un Évenement avec ce Titre, changer le avant de continuer");
                    return View();
                }
                else
                {
                    Evenement n = new Evenement();
                    n.UserId = guid;
                    n.TitleEvenement = titre;
                    n.Text = Evenement.Contenu;
                    n.PrincipalPhotoEvenement = Evenement.PhotoPrincipal;
                    n.Poublier = Evenement.Publier;
                    n.DateStart = Evenement.DateStart;
                    n.HourStart = Evenement.HourStart;
                    n.DateEnd = Evenement.DateEnd;
                    n.HourEnd = Evenement.HourEnd;
                    n.PlaceEvenement = Evenement.Lieu;
                    n.AdresseEvenement = Evenement.Adresse;
                    db.Evenements.Add(n);
                    await db.SaveChangesAsync();
                    if (n.Poublier == true && Evenement.fb == true)
                    {
                        string p = (n.PrincipalPhotoEvenement == null) ? "/Images/logo.jpg" : "/tinyfilemanager.net/resources/files/" + n.PrincipalPhotoEvenement;
                        string s = n.TitleEvenement + "  " + " pour plus d'information sur cette événement, clic dans le lien  "
                            + ConfigurationManager.AppSettings["server"] + "Evenements/Details?title=" + n.TitleEvenement;
                        publierFB(s, p );
                    }
                }
            }
            else
            {
                int x = Convert.ToInt16(Evenement.PId);
                listTitres = (from a in db.Evenements
                              where a.EventId != x
                              select a.TitleEvenement).ToList();
                if (listTitres.Contains(titre))
                {

                    ViewBag.ispostBack = true;
                    ModelState.AddModelError("", "Éxiste déjà un autre Événement avec ce Titre, changer le avant de continuer");
                    return View();
                }
                else
                {
                    var n = (from e in db.Evenements
                             where e.EventId == x
                             select e).SingleOrDefault();

                    if(n != null)
                    { 
                        n.UserId = guid;
                        n.TitleEvenement = titre;
                        n.Text = Evenement.Contenu;
                        n.PrincipalPhotoEvenement = Evenement.PhotoPrincipal;
                        n.Poublier = Evenement.Publier;
                        n.DateStart = Evenement.DateStart;
                        n.HourStart = Evenement.HourStart;
                        n.DateEnd = Evenement.DateEnd;
                        n.HourEnd = Evenement.HourEnd;
                        n.PlaceEvenement = Evenement.Lieu;
                        n.AdresseEvenement = Evenement.Adresse;
                        await db.SaveChangesAsync();
                        if (n.Poublier == true && Evenement.fb == true)
                        {
                            string p = (n.PrincipalPhotoEvenement == null) ? "/Images/logo.jpg" : "/tinyfilemanager.net/resources/files/" + n.PrincipalPhotoEvenement;
                            string s = n.TitleEvenement + "  " + " pour plus d'information sur cette événement, clic dans le lien  "
                            + ConfigurationManager.AppSettings["server"] + "Evenements/Details?title=" + n.TitleEvenement;
                            publierFB(s, p);
                        }
                    }
                }
            }
            ViewBag.ispostBack = false;
            return View();
        }

        /// <summary>
        /// function json qui permet recouperer la liste des evenements actuels et futures
        /// </summary>
        /// <returns></returns>
        public JsonResult getEvenements()
        {
            CoeurContainer db = new CoeurContainer();
            var Evenements = (from n in db.Evenements
                              where n.DateEnd >= DateTime.Now || n.DateStart >= DateTime.Now
                              orderby n.DateStart
                             select new
                             {
                                 id = n.EventId,
                                 Titre = n.TitleEvenement
                             });
            return Json(Evenements, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// permet recouperer la liste des évenements passées
        /// </summary>
        /// <returns></returns>
        public JsonResult getEvenementsPasses()
        {
            CoeurContainer db = new CoeurContainer();
            var Evenements = (from n in db.Evenements
                              where n.DateEnd < DateTime.Now || n.DateStart < DateTime.Now
                              orderby n.DateStart
                              select new
                              {
                                  id = n.EventId,
                                  Titre = n.TitleEvenement
                              });
            return Json(Evenements, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// permet recouperer les etails de un evenemet en special
        /// </summary>
        /// <param name="IdEvenement"> id de l'evenement</param>
        /// <returns></returns>
        public JsonResult getEDetails(int IdEvenement)
        {
            CoeurContainer db = new CoeurContainer();
            var evement = (from n in db.Evenements
                           where n.EventId == IdEvenement
                            select new
                            {
                                id = n.EventId,
                                titre = n.TitleEvenement,
                                page = n.Text,
                                image = n.PrincipalPhotoEvenement,
                                publier = n.Poublier,
                                dateStart = n.DateStart,
                                dateEnd = n.DateEnd,
                                hourStart = n.HourStart,
                                hourEnd = n.HourEnd,
                                lieu = n.PlaceEvenement,
                                adresse = n.AdresseEvenement,
                            }).SingleOrDefault();

           
            
            return Json(evement, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// function pour effacer un evenemet
        /// </summary>
        /// <param name="eID">id evenemetn a effacer</param>
        /// <returns></returns>
        public async Task<ActionResult> delEvenement(int eID)
        {
            CoeurContainer db = new CoeurContainer();
            var delevenement = (from n in db.Evenements
                             where n.EventId == eID
                             select n).SingleOrDefault();
            if (delevenement != null)
            {
                db.Evenements.Remove(delevenement);
                await db.SaveChangesAsync();
            }
            ViewBag.ispostBack = false;
            return Redirect("/Admin/Evenements");
        }

        
        //Get: Notices
        public ActionResult Notice()
        {
            ViewBag.Message = "creer une notice";
            ViewBag.ispostBack = false;
            return View();
        }

        /// <summary>
        /// function qui permet sousgarder ou effacer les nouvelles
        /// </summary>
        /// <param name="notice">le modele</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Notice(NouvellesViewModel notice)
        {
            CoeurContainer db = new CoeurContainer();
            
            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;
            // recoupere la liste des titres éxistants
            var listTitres = (from a in db.Nouvelles select a.NouvelleTitle).ToList();
            string titre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(notice.Nouvelletitre.ToLower());
            
            if (notice.PId == null)
            {
                //valide si existe déjà un nouvelle avec le titre du modele
                if (listTitres.Contains(titre))
                {
                    ViewBag.ispostBack = true;
                    ModelState.AddModelError("", "Éxiste déjà un Nouvelle avec cette Titre, changer le avant de continuer");
                    return View();
                }
                else
                {
                    Nouvelle n = new Nouvelle();
                    n.NouvelleDate = DateTime.Now;
                    n.UserId = guid;
                    n.NouvelleTitle = titre;
                    n.NouvelleText = notice.NouvelleText;
                    n.NouvellePrincipalPhoto = notice.NouvellePhotoPrincipal;
                    n.Publier = notice.Publier;
                    db.Nouvelles.Add(n);
                    await db.SaveChangesAsync();
                    if (n.Publier == true && notice.fb == true)
                    {
                        string p = (n.NouvellePrincipalPhoto == null) ? "/Images/logo.jpg" : "/tinyfilemanager.net/resources/files/" + n.NouvellePrincipalPhoto;
                        string s = n.NouvelleTitle + "  " + " pour plus d'information sur cette nouvelle, clic dans le lien  "
                            + ConfigurationManager.AppSettings["server"] + "Nouvelles/Details?title=" + n.NouvelleTitle;
                        publierFB(s, p);
                    }
                }
            }
            else
            {
                int x = Convert.ToInt16(notice.PId);

                //actualise la liste pour ne prend en cosideration le titre actuel
                listTitres = (from a in db.Nouvelles
                              where a.NouvelleId != x
                              select a.NouvelleTitle).ToList();
                if (listTitres.Contains(titre))
                {
                    ViewBag.ispostBack = true;
                    ModelState.AddModelError("", "Éxiste déjà un Nouvelle avec cette Titre, changer le avant de continuer");
                    return View();
                }
                else
                {
                    var n = (from e in db.Nouvelles
                             where e.NouvelleId == x
                             select e).SingleOrDefault();
                    if(n != null)
                    { 
                        n.UserId = guid;
                        n.NouvelleTitle = titre;
                        n.NouvelleText = notice.NouvelleText;
                        n.NouvellePrincipalPhoto = notice.NouvellePhotoPrincipal;
                        n.Publier = notice.Publier;
                        await db.SaveChangesAsync();
                        if (n.Publier == true && notice.fb == true)
                        {
                            string p = (n.NouvellePrincipalPhoto == null) ? "/Images/logo.jpg" : "/tinyfilemanager.net/resources/files/" + n.NouvellePrincipalPhoto;
                            string s = n.NouvelleTitle + "  " + " pour plus d'information sur cette nouvelle, clic dans le lien  "
                                + ConfigurationManager.AppSettings["server"] + "Nouvelles/Details?title=" + n.NouvelleTitle;
                            publierFB(s, p);
                        }
                    }
                }
            }
            ViewBag.ispostBack = false;
            return View();
        }

        /// <summary>
        /// function json qui permet recouperer la liste des nouvelles éxistants
        /// </summary>
        /// <returns></returns>
        public JsonResult getNouvelles()
        {
            CoeurContainer db = new CoeurContainer();
            var nouvelles = (from n in db.Nouvelles
                             orderby n.NouvelleDate
                             select new
                             {
                                 id = n.NouvelleId,
                                 Titre = n.NouvelleTitle
                             });
            return Json(nouvelles, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// function json qui permet recouperer les details d'un nouvelle en particuliere
        /// </summary>
        /// <param name="NouvelleId">identificateur de un nouvelle</param>
        /// <returns></returns>
        public JsonResult getNDetails(int NouvelleId)
        {
            CoeurContainer db = new CoeurContainer();
            var nouvelle = (from n in db.Nouvelles
                            where n.NouvelleId == NouvelleId
                             select new
                             {
                                 id = n.NouvelleId,
                                 Titre = n.NouvelleTitle,
                                 page = n.NouvelleText,
                                 image = n.NouvellePrincipalPhoto,
                                 publier = n.Publier
                             }).SingleOrDefault();
            return Json(nouvelle, JsonRequestBehavior.AllowGet);        
        }

        /// <summary>
        /// function pour effacer les nouvelles
        /// </summary>
        /// <param name="nID"></param>
        /// <returns></returns>
        public async Task<ActionResult> delNews(int nID)
        {
            CoeurContainer db = new CoeurContainer();
            var delnotice = (from n in db.Nouvelles
                             where n.NouvelleId == nID
                               select n).SingleOrDefault();
            if(delnotice != null)
            { 
                db.Nouvelles.Remove(delnotice);
                await db.SaveChangesAsync();
            }
            ViewBag.ispostBack = false;
            return Redirect("/Admin/Notice");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "modifier la page des conntacts.";

            return View();
        }


        /// <summary>
        /// function qui permet envoyer par courriel une publication a une compte de facebbok cible
        /// </summary>
        /// <param name="sujet">sujet du courriel</param>
        /// <param name="photo">path de photo dans le serveur</param>
        /// <param name="resumen">300 charecteres du texte sans code html</param>
        private void publierFB(string sujet, string photo)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(ConfigurationManager.AppSettings["fb"]);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["mailAccount"]);
            mail.Subject = sujet;
            mail.Body = "";
            mail.IsBodyHtml = true;
            mail.Attachments.Add(new Attachment(Server.MapPath(photo)));
            SendMailerController.sendMailer(mail);
        }

    }
}