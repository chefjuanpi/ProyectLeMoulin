using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
