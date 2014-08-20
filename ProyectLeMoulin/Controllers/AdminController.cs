using IdentitySample.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Pages()
        {
            ViewBag.Title = "Editeur des Pages";
            ViewBag.Message = "Edition des pages du site";

            return View();
        }

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

        // POST: //enregistrer changements dans la pages d'accueil
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

        //
        // POST: //enregistrer Pages
        [HttpPost]
        public async Task<ActionResult> Pages(PagesViewModel page)
        {
            ViewBag.Title = "Editeur des Pages";
            CoeurContainer db = new CoeurContainer();
            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;
            if (page.PId == null)
            {
                Page n = new Page();
                n.MenuName = page.MenuName;
                n.UserId = guid;
                n.Title = page.Titre;
                n.Text = page.Contenu;
                n.Poublier = page.Publier;
                n.Principal = page.Principal;
                if(page.Principal == false)
                {
                    n.SousMenu = page.menuParent;
                }
                else{
                    n.SousMenu = null;
                }
                db.Pages.Add(n);
                await db.SaveChangesAsync();
                int lastId = db.Pages.Max(m => m.PageID);
                int x = 0;
                //continuer apres si marche le reste de la page en public
            }
            else
            {
                int x = Convert.ToInt16(page.PId);
                var modPage = (from n in db.Pages
                                   where n.PageID == x
                                   select n).Single();
                modPage.UserId = guid;
                modPage.Title = page.Titre;
                modPage.Text = page.Contenu;
                modPage.MenuName = page.MenuName;
                modPage.Poublier = page.Publier;
                if (page.Principal == false)
                {
                    modPage.SousMenu = page.menuParent;
                }
                else
                {
                    modPage.SousMenu = null;
                }
                await db.SaveChangesAsync();
            }
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

        public JsonResult getparents()
        {
            CoeurContainer db = new CoeurContainer();
            var nouvelles = (from n in db.Pages
                             where n.Principal == true & n.PageID > 1
                             select new
                             {
                                 id = n.PageID,
                                 Titre = n.MenuName
                             });
            return Json(nouvelles, JsonRequestBehavior.AllowGet);
        }

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
                            }).Single();
            return Json(nouvelle, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> delPage(int pID)
        {
            CoeurContainer db = new CoeurContainer();
            var delpage = (from n in db.Pages
                                where n.PageID == pID
                                select n).Single();
            if (delpage != null)
            {
                db.Pages.Remove(delpage);
                await db.SaveChangesAsync();
            }
            return Redirect("/Admin/Pages");
        }

        public ActionResult Evenements_a_venir()
        {
            ViewBag.Message = "creer une nouvelle page";

            return View();
        }

        public ActionResult Evenements_Passes()
        {
            ViewBag.Message = "creer une nouvelle page";

            return View();
        }

        //
        // POST: //enregistrer nouveles Evenement  et modifié
        [HttpPost]
        public async Task<ActionResult> Evenements_a_venir(EvenementsViewModel Evenement)
        {
            CoeurContainer db = new CoeurContainer();
            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;
            if (Evenement.PId == null)
            {
                Evenement n = new Evenement();
                n.UserId = guid;
                n.TitleEvenement = Evenement.Titre;
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
            }
            else
            {
                int x = Convert.ToInt16(Evenement.PId);
                var modifEvenement = (from n in db.Evenements
                                   where n.EventId == x
                                   select n).Single();

                modifEvenement.UserId = guid;
                modifEvenement.TitleEvenement = Evenement.Titre;
                modifEvenement.Text = Evenement.Contenu;
                modifEvenement.PrincipalPhotoEvenement = Evenement.PhotoPrincipal;
                modifEvenement.Poublier = Evenement.Publier;
                modifEvenement.DateStart = Evenement.DateStart;
                modifEvenement.HourStart = Evenement.HourStart;
                modifEvenement.DateEnd = Evenement.DateEnd;
                modifEvenement.HourEnd = Evenement.HourEnd;
                modifEvenement.PlaceEvenement = Evenement.Lieu;
                modifEvenement.AdresseEvenement = Evenement.Adresse;
                await db.SaveChangesAsync();
            }
            return View();
        }

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
                            }).Single();

           
            
            return Json(evement, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> delEvenement(int eID)
        {
            CoeurContainer db = new CoeurContainer();
            var delevenement = (from n in db.Evenements
                             where n.EventId == eID
                             select n).Single();
            if (delevenement != null)
            {
                db.Evenements.Remove(delevenement);
                await db.SaveChangesAsync();
            }
            return Redirect("/Admin/Evenements");
        }

        
        //Get: Notices
        public ActionResult Notice()
        {
            ViewBag.Message = "creer une notice";

            return View();
        }

        //
        // POST: //enregistrer Notices
        [HttpPost]
        public async Task<ActionResult> Notice(NouvellesViewModel notice)
        {
            CoeurContainer db = new CoeurContainer();
            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;
            if (notice.PId == null)
                {
                    Nouvelle n = new Nouvelle();
                    n.NouvelleDate = DateTime.Now;
                    n.UserId = guid;
                    n.NouvelleTitle = notice.Nouvelletitre;
                    n.NouvelleText = notice.NouvelleText;
                    n.NouvellePrincipalPhoto = notice.NouvellePhotoPrincipal;
                    n.Publier = notice.Publier;
                    

                    db.Nouvelles.Add(n);
                    await db.SaveChangesAsync();                 
                }
                else
                {
                    int x = Convert.ToInt16(notice.PId);
                    var modifnotice = (from n in db.Nouvelles
                                       where n.NouvelleId == x
                                       select n).Single();
                    modifnotice.UserId = guid;
                    modifnotice.NouvelleTitle = notice.Nouvelletitre;
                    modifnotice.NouvelleText = notice.NouvelleText;
                    modifnotice.NouvellePrincipalPhoto = notice.NouvellePhotoPrincipal;
                    modifnotice.Publier = notice.Publier;
                    await db.SaveChangesAsync();
                }
            return View();
        }

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
                             }).Single();
            return Json(nouvelle, JsonRequestBehavior.AllowGet);        
        }

        public async Task<ActionResult> delNews(int nID)
        {
            CoeurContainer db = new CoeurContainer();
            var delnotice = (from n in db.Nouvelles
                             where n.NouvelleId == nID
                               select n).Single();
            if(delnotice != null)
            { 
                db.Nouvelles.Remove(delnotice);
                await db.SaveChangesAsync();
            }
            return Redirect("/Admin/Notice");
        }
    }
}