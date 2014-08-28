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
        public JsonResult GetWeek()
        {
            EpicerieEntities db = new EpicerieEntities();

            var week = (from w in db.Weeks
                        select new
                        {
                            Week = w.WeekId,
                            Debut = w.Date_Debut,
                            Fin = w.Date_Fin
                        }).ToList();
            return Json(week, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ValiderWeek()
        {
            EpicerieEntities db = new EpicerieEntities();
            var week = (from w in db.Weeks select w.WeekId);
            string fin = (from f in db.Weeks select f.Date_Fin).ToString();
            bool valide = false;

            //if (DateTime.Today <= DateTime.Parse(fin))
                valide = true;
            
            return Json(valide, JsonRequestBehavior.AllowGet);
        }

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
                                 where  cp.CategoryId   ==  cat
                                 &&     w.WeekId        ==  weekID
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
        public async Task<ActionResult> Index( test1234 cart)
        {
            EpicerieEntities db = new EpicerieEntities();

            int week = (from w in db.Weeks select w.WeekId).LastOrDefault();

            //if (cart.week == weekbd)
            //{ 
            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;

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
                         o.UserId == NewOrders.UserId &
                         o.WeekId == NewOrders.WeekId
                         select o.OrderId).Single();

            //Créer et enregistrer l'OrderDetail dans la BD
            foreach (var item in cart.obj)
            {
                var price = db.WeekProduct.SingleOrDefault(p => p.ProductId == item.PID).UnitPrice;

                OrderDetails NewOdersDetails = new OrderDetails();
                NewOdersDetails.ProductId   =   item.PID;
                NewOdersDetails.OrderId     =   comID;
                NewOdersDetails.Quantite    =   item.qty;
                NewOdersDetails.UnitPrice   =   price;
                NewOdersDetails.WeekId      =   week;
                db.OrderDetails.Add(NewOdersDetails);
            }
            await db.SaveChangesAsync();

            ViewBag.Steeve = "ton panier";
            //}
            //else
            //{
            //    ViewBag.Steeve = "erreur";
            //}

            return View();
        }

        public JsonResult GetOldBill()
        {
            EpicerieEntities db = new EpicerieEntities();

            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;

            var oldbill = (from o in db.Orders
                           join w in db.Weeks
                           on o.WeekId equals w.WeekId
                           where o.UserId == guid
                           select w.Date_Debut).Single();
                               
            return Json(oldbill, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Afficher_Entete_Facture()
        {
            EpicerieEntities db = new EpicerieEntities();

            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;
            int weekbd = (from w in db.Weeks    select w.WeekId).LastOrDefault();

            var bill = (from    u               in      db.AspNetUsers
                        join    o               in      db.Orders
                        on      u.Id            equals  o.UserId
                        join    w               in      db.Weeks
                        on      o.WeekId        equals  w.WeekId
                        where   u.Id            ==      guid 
                        &       w.WeekId        ==      weekbd
                        select new{
                            Usager          =   u.Prenom + " " + u.Nom, 
                            OrderID         =   o.OrderId,
                            Debut           =   w.Date_Debut,
                            Fin             =   w.Date_Fin,
                            DateRecup       =   w.Date_Recuperation,
                            Date            =   DateTime.Today
                            }).ToList();
            return Json(bill, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Afficher_Entete_Facture(int week)
        {
            EpicerieEntities db = new EpicerieEntities();

            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;
            int weekbd = (from w in db.Weeks
                          where w.WeekId == week
                          select w.WeekId
                          ).LastOrDefault();

            var bill = (from u in db.AspNetUsers
                        join o in db.Orders
                        on u.Id equals o.UserId
                        join w in db.Weeks
                        on o.WeekId equals w.WeekId
                        where u.Id == guid
                        & w.WeekId == weekbd
                        select new
                        {
                            Usager      =   u.Prenom + " " + u.Nom,
                            OrderID     =   o.OrderId,
                            Debut       =   w.Date_Debut,
                            Fin         =   w.Date_Fin,
                            DateRecup   =   w.Date_Recuperation
                        }).ToList();
            return Json(bill, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Afficher_Facture(int week)
        {
            EpicerieEntities db = new EpicerieEntities();

            string utilisateur = User.Identity.Name;
            string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;
            int weekbd = (from      w           in  db.Weeks 
                          where     w.WeekId    ==  week 
                          select    w.WeekId
                          ).LastOrDefault();
            
            var bill = (from    o               in      db.Orders
                        join    od              in      db.OrderDetails
                        on      o.OrderId       equals  od.OrderId
                        join    p               in      db.Products
                        on      od.ProductId    equals  p.ProductId
                        join    cp              in      db.CategoryProduct
                        on      p.ProductId     equals  cp.ProductId
                        join    wp              in      db.WeekProduct
                        on      o.WeekId        equals  wp.WeekId
                        where   o.UserId        ==      guid 
                        &       o.WeekId        ==      weekbd
                        orderby cp.CategoryId
                        select new{
                            Nom         =   p.ProductName,
                            Format      =   wp.Format,
                            Quantite    =   od.Quantite,
                            Prix        =   od.UnitPrice,
                            SousTotal   =   od.Quantite * od.UnitPrice
                            //Total       =   sum(od.Quantite * od.UnitPrice)
            }).ToList();
            return Json(bill, JsonRequestBehavior.AllowGet);
        }
    }
}