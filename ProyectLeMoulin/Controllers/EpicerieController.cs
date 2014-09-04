using System.Globalization;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Collections.Generic;

namespace IdentitySample.Controllers
{
    [RequireHttps]
    [Authorize(Roles = "Membre groupe d'achats")]
    public class EpicerieController : Controller
    {
        /// <summary>
        /// Fait le lien avec la page index
        /// Récupérer les dates de la période d'achat et de récupération
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            EpicerieEntities db = new EpicerieEntities();

            var week = (from w in db.Weeks
                        orderby w.WeekId descending
                        select new test1234
                        {
                            Debut = (DateTime)w.Date_Debut,
                            Fin = (DateTime)w.Date_Fin,
                            Recup = (DateTime)w.Date_Recuperation
                        }).Take(1).ToList();

            ViewBag.Period = week;

            return View();
        }
        
        /// <summary>
        /// Fait le lien avec la page Facture
        /// </summary>
        /// <returns></returns>
        public ActionResult Facture()
        {
            return View();
        }

        /// <summary>
        /// Afficher le message de l'administrateur du groupe D'achats
        /// </summary>
        //public JsonResult Afficher_Message()
        //{

        //}

        /// <summary>
        /// Récupérer les catégories de produits
        /// </summary>
        /// <returns></returns>
        public JsonResult GetWeek()
        {
            EpicerieEntities db = new EpicerieEntities();

            var week = (from w in db.Weeks
                        orderby w.WeekId descending
                        select new
                        {
                            w.WeekId
                        }).FirstOrDefault();


            return Json(week, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetPeriod()
        {
            EpicerieEntities db = new EpicerieEntities();

            var week = (from w in db.Weeks
                        orderby w.WeekId descending
                        select new
                        {
                            Debut = w.Date_Debut,
                            Fin = w.Date_Fin,
                            Recup = w.Date_Recuperation
                        }).FirstOrDefault();

            return Json(week, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Fait la validation de la semaine pour savoir si le membre
        /// peut passer une commande
        /// </summary>
        /// <returns></returns>
        //public JsonResult ValiderWeek()
        //{
        //    EpicerieEntities db = new EpicerieEntities();

        //    bool valide = false;
        //    var week = (from w in db.Weeks orderby w.WeekId descending select w.WeekId).FirstOrDefault();
        //    var fin = (from w in db.Weeks
        //               where w.WeekId == week
        //               select w.Date_Fin).SingleOrDefault();

        //    if (DateTime.Today <= (DateTime)fin)
        //        valide = true;
        //    return Json(valide, JsonRequestBehavior.AllowGet);
        //}

        /// <summary>
        /// Récupérer La catégorie sélectionnée
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCategories()
        {
            EpicerieEntities db = new EpicerieEntities();
            var category = (from c in db.Categories
                            select new
                            {
                                CategoryID = c.CategoryId,
                                CategoryName = c.CategoryName,
                                Description = c.Description
                            }).ToList();
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Récupérer les produits selon la catégorie choisie
        /// </summary>
        /// <param name="cat">Id de la catégorie sélectionnée</param>
        /// <returns></returns>
        public JsonResult GetProduits(int cat)
        {
            EpicerieEntities db = new EpicerieEntities();

            int weekID = (from w in db.Weeks
                          orderby w.WeekId descending
                          select w.WeekId
                            ).FirstOrDefault();

            int category = (from c in db.Categories
                            where c.CategoryId == cat
                            select c.CategoryId
                            ).FirstOrDefault();

            var produit = (from w in db.Weeks
                           join wp in db.WeekProduct
                           on w.WeekId equals wp.WeekId
                           join p in db.Products
                           on wp.ProductId equals p.ProductId
                           join cp in db.CategoryProduct
                           on p.ProductId equals cp.ProductId
                           where cp.CategoryId == category
                           && w.WeekId == weekID
                           select new
                           {
                               WeeK = weekID,
                               ProductID = p.ProductId,
                               ProductName = p.ProductName,
                               Format = wp.Format,
                               Price = wp.UnitPrice
                           }).ToList();
            return Json(produit, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Garder ou modifier la bd en async sans affecter la vitesse de l'utilisateur
        /// </summary>
        /// <param name="panier">Liste des produits commandées</param>
        /// <param name="cart">ID de la semaine d'exercice en cours</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Index(test1234 cart)
        {
            EpicerieEntities db = new EpicerieEntities();


            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;

            //Créer et enregistrer l'Order dans la BD
            Orders NewOrders = new Orders();

            NewOrders.UserId = guid;
            NewOrders.WeekId = cart.week;
            NewOrders.Commande_Payee = false;

            //Créer et enregistrer l'OrderDetail dans la BD
            foreach (var item in cart.obj)
            {
                var price = db.WeekProduct.SingleOrDefault(p => p.ProductId == item.PID && p.WeekId == cart.week).UnitPrice;

                OrderDetails NewOdersDetails = new OrderDetails();
                NewOdersDetails.ProductId = item.PID;
                NewOdersDetails.Quantite = item.qty;
                NewOdersDetails.UnitPrice = price;
                NewOdersDetails.WeekId = cart.week;
                NewOrders.OrderDetails.Add(NewOdersDetails);
            }


            db.Orders.Add(NewOrders);

            await db.SaveChangesAsync();

            //ViewBag.Steeve = "ton panier";
            //}
            //else
            //{
            //    ViewBag.Steeve = "erreur";
            //}
            //}

            return Redirect("/Epicerie/Facture");

        }
        //----------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Récupères les informations du membre pour afficher
        /// </summary>
        /// <param name="OID">OrderID sélectionné</param>
        /// <returns></returns>
        public JsonResult GetMembre(int OID)
        {
            EpicerieEntities db = new EpicerieEntities();

            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;

            var order = (from o in db.Orders
                         join a in db.AspNetUsers
                         on o.UserId equals a.Id
                         join w in db.Weeks
                         on o.WeekId equals w.WeekId
                         where o.UserId == guid
                         && o.OrderId == OID
                         orderby o.OrderId descending
                         select new
                         {
                             Membre = a.Prenom + " " + a.Nom,
                             OrderID = o.OrderId,
                             Fin = w.Date_Fin
                         }).ToList();

            var week = (from w in db.Weeks
                        join o in db.Orders
                        on w.WeekId equals o.WeekId
                        where o.WeekId == OID
                        orderby w.WeekId descending
                        select new test1234
                        {
                            Fin = (DateTime)w.Date_Fin,
                            Recup = (DateTime)w.Date_Recuperation
                        }).ToList();

            ViewBag.GetMembre = week;

            return Json(order, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Récupérer le OrderId de la facture à afficher
        /// </summary>
        /// <returns></returns>
        public JsonResult GetOrder()
        {
            EpicerieEntities db = new EpicerieEntities();

            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;

            var order = (from o in db.Orders
                         where o.UserId == guid
                         orderby o.OrderId descending
                         select new
                         {
                             OrderID = o.OrderId
                         }).ToList();
            return Json(order, JsonRequestBehavior.AllowGet);
        }

       

        /// <summary>
        /// Récupérer le détail de la facture sélectionnée
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public JsonResult GetDetails(int OID)
        {        
            EpicerieEntities db = new EpicerieEntities();
        
            //if (OID != null)
            //{



                var bill = (from c in db.Categories
                            join cp in db.CategoryProduct
                            on c.CategoryId equals cp.CategoryId
                            join p in db.Products
                            on cp.ProductId equals p.ProductId
                            join wp in db.WeekProduct
                            on p.ProductId equals wp.ProductId
                            join od in db.OrderDetails
                            on wp.ProductId equals od.ProductId into xs
                            from y in xs.Where(od => od.OrderId == OID)
                            orderby cp.CategoryId
                            select new
                            {
                                Produit = p.ProductName,
                                ProductID = y.ProductId,
                                Format = wp.Format,
                                Quantite = y.Quantite,
                                Prix = y.UnitPrice,
                                SousTotal = y.Quantite * y.UnitPrice
                            }).ToList();
                return Json(bill, JsonRequestBehavior.AllowGet);
        }
    }
}