using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using System.Threading.Tasks;
using ProyectLeMoulin.Models;

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
            ViewBag.Message = "Edition des pages du site";

            return View();
        }

        public ActionResult Evenements()
        {
            ViewBag.Message = "creer une nouvelle page";

            return View();
        }

        //
        // POST: //enregistrer Evenement nouveles et modifié
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Evenements(EvenementsViewModel Evenement)
        {
            CoeurContainer db = new CoeurContainer();
            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;
            if (Evenement.EvenementId == null)
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
                int x = Convert.ToInt16(Evenement.EvenementId);
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
        [ValidateInput(false)]
        public async Task<ActionResult> Notice(NouvellesViewModel notice)
        {
            CoeurContainer db = new CoeurContainer();
            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;
            if (notice.NouvelleId == null)
                {
                    Nouvelle n = new Nouvelle();
                    n.NouvelleDate = DateTime.Now;
                    n.UserId = guid;
                    n.NouvelleTitle = notice.Nouvelletitre;
                    n.NouvelleText = notice.NouvelleText;
                    n.NouvellePrincipalPhoto = notice.NouvellePhotoPrincipal;
                    n.Publier = notice.NouvellePublier;
                    

                    db.Nouvelles.Add(n);
                    await db.SaveChangesAsync();                 
                }
                else
                {
                    int x = Convert.ToInt16(notice.NouvelleId);
                    var modifnotice = (from n in db.Nouvelles
                                       where n.NouvelleId == x
                                       select n).Single();
                    modifnotice.UserId = guid;
                    modifnotice.NouvelleTitle = notice.Nouvelletitre;
                    modifnotice.NouvelleText = notice.NouvelleText;
                    modifnotice.NouvellePrincipalPhoto = notice.NouvellePhotoPrincipal;
                    modifnotice.Publier = notice.NouvellePublier;
                    await db.SaveChangesAsync();
                }
            return View();
        }

        public JsonResult getNouvelles()
        {
            CoeurContainer db = new CoeurContainer();
            var nouvelles = (from n in db.Nouvelles
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


        public ActionResult Photos()
        {
            ViewBag.Message = "Gestion du photos du site";

            return View();
        }

    }
}