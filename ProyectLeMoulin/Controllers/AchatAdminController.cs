using IdentitySample.Models;
using ProyectLeMoulin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectLeMoulin.Controllers
{
    public class AchatAdminController : Controller
    {
        //
        // GET: /AchatAdmin/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewOrder()
        {
            ViewBag.message = "Pour faire une nouvelle commande";
            return View();
        }

        public ActionResult Products()
        {
            ViewBag.message = "Administration des produits";
            return View();
        }

        public ActionResult Suppliers()
        {
            ViewBag.message = "Administration des fournisseurs";
            return View();
        }

        public ActionResult OldOrders()
        {
            ViewBag.message = "Pour obtenir les rapports d'anciennes commandes";
            return View();
        }

        public ActionResult MembersOrders()
        {
            ViewBag.message = "Pour sortir les commandes des membres et leurs reçu";
            return View();
        }

        //[HttpPost]
        //[ValidateInput(false)]
        //public async Task<ActionResult> Supplier(SupplierViewModel Supplier)
        //{
        //    CoeurContainer db = new CoeurContainer();
        //    if ( Supplier.SupplierId == null)
        //        {
        //            Nouvelle n = new Nouvelle();
        //            n.NouvelleDate = DateTime.Now;
        //            n.UserId = guid;
        //            n.NouvelleTitle = notice.Nouvelletitre;
        //            n.NouvelleText = notice.NouvelleText;
        //            n.NouvellePrincipalPhoto = notice.NouvellePhotoPrincipal;
        //            n.Publier = notice.NouvellePublier;
                    

        //            db.Nouvelles.Add(n);
        //            await db.SaveChangesAsync();                 
        //        }
        //        else
        //        {
        //            int x = Convert.ToInt16(notice.NouvelleId);
        //            var modifnotice = (from n in db.Nouvelles
        //                               where n.NouvelleId == x
        //                               select n).Single();
        //            modifnotice.UserId = guid;
        //            modifnotice.NouvelleTitle = notice.Nouvelletitre;
        //            modifnotice.NouvelleText = notice.NouvelleText;
        //            modifnotice.NouvellePrincipalPhoto = notice.NouvellePhotoPrincipal;
        //            modifnotice.Publier = notice.NouvellePublier;
        //            await db.SaveChangesAsync();
        //        }
        //    return View();
        //}

        //public JsonResult getNouvelles()
        //{
        //    CoeurContainer db = new CoeurContainer();
        //    var nouvelles = (from n in db.Nouvelles
        //                     orderby n.NouvelleDate
        //                     select new
        //                     {
        //                         id = n.NouvelleId,
        //                         Titre = n.NouvelleTitle
        //                     });
        //    return Json(nouvelles, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult getNDetails(int NouvelleId)
        //{
        //    CoeurContainer db = new CoeurContainer();
        //    var nouvelle = (from n in db.Nouvelles
        //                    where n.NouvelleId == NouvelleId
        //                     select new
        //                     {
        //                         id = n.NouvelleId,
        //                         Titre = n.NouvelleTitle,
        //                         page = n.NouvelleText,
        //                         image = n.NouvellePrincipalPhoto,
        //                         publier = n.Publier
        //                     }).Single();
        //    return Json(nouvelle, JsonRequestBehavior.AllowGet);        
        //}

        //public async Task<ActionResult> delNews(int nID)
        //{
        //    CoeurContainer db = new CoeurContainer();
        //    var delnotice = (from n in db.Nouvelles
        //                     where n.NouvelleId == nID
        //                       select n).Single();
        //    if(delnotice != null)
        //    { 
        //        db.Nouvelles.Remove(delnotice);
        //        await db.SaveChangesAsync();
        //    }
        //    return Redirect("/Admin/Notice");
        //}

    }
}
