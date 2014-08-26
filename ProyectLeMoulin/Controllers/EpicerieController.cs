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

    public class EpicerieController : Controller
    
    {
        public ActionResult Index()
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
        public JsonResult GetCategories()
        {
            EpicerieEntities db = new EpicerieEntities();
            var category = (from c in db.Categories
                            select new
                            {
                                CategoryID      =   c.CategoryId,
                                CategoryName    =   c.CategoryName,
                                Description     =   c.Description
                            }).ToList();
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Récupérer les produits selon la catégorie choisie
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public JsonResult GetProduits(int cat)
        {
            EpicerieEntities db = new EpicerieEntities();
                        
                int weekID = (from    w in db.Weeks
                              orderby w.WeekId descending
                              select  w.WeekId
                              ).FirstOrDefault();

                var produit =   (from   w               in      db.Weeks
                                 join   wp              in      db.WeekProduct
                                 on     w.WeekId        equals  wp.WeekId
                                 join   p               in      db.Products
                                 on     wp.ProductId    equals  p.ProductId
                                 join   cp              in      db.CategoryProduct
                                 on     p.ProductId     equals  cp.ProductId
                                 where  cp.CategoryId   == cat
                                 &&     w.WeekId        == weekID
                                 select new
                                 {
                                     WeeK           =   weekID,
                                     ProductID      =   p.ProductId,
                                     ProductName    =   p.ProductName,
                                     Format         =   wp.Format,
                                     Price          =   wp.UnitPrice
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
        public async Task<ActionResult> Index(List<listProducts> panier, test1234 cart)
        {
            EpicerieEntities db = new EpicerieEntities();

            int WEEK = int.Parse(cart.week);
            
            var week = db.Weeks.SingleOrDefault(w => w.WeekId == WEEK).WeekId;
            string utilisateur = User.Identity.Name;
            string guid1 = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;



            string guid = "estive";
            //Créer un Order et enregistrer l'Order dans la BD
            Orders NewOrders = new Orders();

            NewOrders.UserId            =   guid;
            NewOrders.WeekId            =   week;
            NewOrders.Commande_Payee    =   false;
            db.Orders.Add(NewOrders);

            await db.SaveChangesAsync();

            //Sortir le OrderID pour créer la Order Detail
            int comID = (from o in db.Orders
                            where
                            o.UserId            ==  NewOrders.UserId &
                            o.WeekId            ==  NewOrders.WeekId &
                            o.Commande_Payee    ==  NewOrders.Commande_Payee
                            select o.OrderId).Single();
            NewOrders.OrderId = comID;

            //Créer et enregistrer l'OrderDetail dans la BD
            foreach (var item in panier)
            {
                var price = db.WeekProduct.SingleOrDefault(p => p.ProductId == item.PID).UnitPrice;

                OrderDetails NewOdersDetails    =   new OrderDetails();
                NewOdersDetails.ProductId       =   item.PID;
                NewOdersDetails.Orders          =   NewOrders;
                NewOdersDetails.Quantite        =   item.qty;
                NewOdersDetails.UnitPrice       =   price;
                NewOdersDetails.WeekId          =   (int)NewOrders.WeekId;
            }
            await db.SaveChangesAsync();

            ViewBag.Steeve = "ton panier";
            return View();

        }

        //Afficher le message de l'administrateur du groupe D'achats
        //public JsonResult Afficher_Message()
        //{
                
        //}

    }
}