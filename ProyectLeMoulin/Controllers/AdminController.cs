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

        public JsonResult delNews(int nID)
        {
            CoeurContainer db = new CoeurContainer();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var nouvelle = 1;

            return Json(nouvelle, JsonRequestBehavior.AllowGet); 
        }


        public ActionResult Photos()
        {
            ViewBag.Message = "Gestion du photos du site";

            return View();
        }

    }
}