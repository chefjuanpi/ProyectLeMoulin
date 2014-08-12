﻿using System.Globalization;
using ProyectLeMoulin.Models;
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

namespace ProyectLeMoulin.Controllers
{

    public class EpicerieController : Controller
    {

        public decimal Total = 0;
        public decimal TotTaxe = 0;
        public decimal GrandTot = 0;
        public decimal Quebec = 0;
        public decimal Canada = 0;

        public ActionResult Index()
        {

            return View();

        }

        //Récupérer les catégories de produits
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

        //Récupérer les produits selon la catégorie choisie
        //public JsonResult GetProduits(int cat)
        //{
        //    EpicerieEntities db = new EpicerieEntities();
        //    if (cat == db.Categories.CategoryId)
        //    {

        //        var produit = (from w in db.Week
        //                       join p in db.Products
        //                       on w.ProductId equals p.ProductId
        //                       join cp in db.CategoryProduct
        //                       on p.ProductId equals cp.ProductId
        //                       where cp.CategoryId == cat
        //                       select new
        //                       {
        //                           ProductID = p.ProductId,
        //                           ProductName = p.ProductName,
        //                           TVQ = p.TVQ,
        //                           TPS = p.TPS,
        //                           Price = w.UnitPrice,
        //                           Available = p.Avaibled
        //                       }).ToList();
        //        return Json(produit, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //Remplir le Panier
        //public JsonResult Remplir_Le_Panier(int productId, string produit, int qty, decimal price, bool tvq, bool tps)
        //{
        //    EpicerieEntities db = new EpicerieEntities();
        //    if (produit == db.Products.ProductName)
        //    {
        //        Panier p = new Panier();

        //        p.ProductID = productId;
        //        p.Produits = produit;
        //        p.Qantity = qty;
        //        p.Price = price;
        //        p.TVQ = tvq;
        //        p.TPS = tps;
        //        p.Total = 0;
        //        p.Quebec = Quebec;
        //        p.Canada = Canada;

        //        Calculer_Prix_Total(p.TVQ, p.TPS, p.Price);

        //        return Json(p, JsonRequestBehavior.AllowGet);
        //    }

        //}

        //public void Calculer_Prix_Total(bool tvq, bool tps, decimal price)
        //{

        //    if (tvq == true && tps == true)
        //    {
        //        Quebec = price * (decimal)0.09975;
        //        Canada = price * (decimal)0.05;
        //        price = price + Quebec + Canada;

        //    }
        //    if (tvq == true && tps == false)
        //    {
        //        Quebec = price * (decimal)0.09975;
        //        Canada = 0;
        //        price = price + Quebec;
        //    }

        //    if (tps == true && tvq == false)
        //    {
        //        Canada = price * (decimal)0.05;
        //        Quebec = 0;
        //        price = price + Canada;
        //    }
        //    if (tvq == false && tps == false)
        //    {
        //        Quebec = 0;
        //        Canada = 0;
        //        return;
        //    }
        //}

        //Afficher le panier d'épicerie
        //public JsonResult Afficherer_Le_Panier()
        //{
        //    Panier p = new Panier();

        //    var panier = p;

        //    return Json(panier, JsonRequestBehavior.AllowGet);
        //}

        //Récupérer le GUID du membre connecté et son role au sein du groupe d'achats
        //public JsonResult Recuperer_Membre()
        //{

        //    EpicerieEntities db   = new EpicerieEntities();
        //    string utilisateur    = User.Identity.Name;
        //    string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;

        //    var membre = (from    m       in      db.AspNetUsers
        //                  join    r       in      db.AspNetUserRoles
        //                  on      m.Id    equals  r.UserId
        //                  where   m.Id    ==      guid
        //                  select new
        //                  {
        //                      MembreID        =   m.Id,
        //                      UserFirstName   =   m.Prenom, 
        //                      UserLastName    =   m.Nom,
        //                      Role            =   r.RoleId
        //                  }).ToList();
        //    return Json(membre, JsonRequestBehavior.AllowGet); 
        //}

        //Afficher le message de l'administrateur du groupe D'achats
        //public JsonResult Afficher_Message()
        //{

        //}

        //Valider la date de l'exercice d'achat en cours
        //public JsonResult Validerer_Date()
        //{
        //    EpicerieEntities db = new EpicerieEntities();

        //    var sem = (from w in db.Week
        //                    select new
        //                    {
        //                        Semaine   =   w.DateSemaine,
        //                    }).ToString;
        //    return Json(sem, JsonRequestBehavior.AllowGet);
        //}

    }
}