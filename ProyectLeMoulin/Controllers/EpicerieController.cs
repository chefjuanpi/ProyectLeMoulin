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
        EpicerieEntities db = new EpicerieEntities();
        //public Panier x = new Panier();

        public ActionResult Index()
        {

            return View();

        }

        //[HttpPost]
        //public async Task<ActionResult> Index(test1234 panier)
        //{
        //    //pour garder ou modifier la bd, async xq sea mas rapido para el utilisateur
        //   int i = 0;

        //   for (i = 0; i < Task<ActionResult>.lenght; i++)
        //   {
        //       var client = from o in db.Orders
        //                    select new {
        //                        o.
        //                    }
               
        //   }

        //    ViewBag.Steeve = "ton panier";
        //    return View();

        //}

        
        /// <summary>
        /// Récupérer les catégories de produits
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCategories()
        {
            //EpicerieEntities db = new EpicerieEntities();
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
        /// <param name="cat"></param>
        /// <returns></returns>
        public JsonResult GetProduits(int cat)
        {
            
            //if (cat == db.Categories.CategoryId)
            //{
            
                var produit = (from w in db.Weeks
                               join wp in db.WeekProduct
                               on w.WeekId equals wp.WeekId
                               join p in db.Products
                               on wp.ProductId equals p.ProductId
                               join cp in db.CategoryProduct
                               on p.ProductId equals cp.ProductId
                               where cp.CategoryId == cat
                               select new
                               {
                                   ProductID = p.ProductId,
                                   ProductName = p.ProductName,
                                   Format = wp.Format,
                                   Price = wp.UnitPrice
                               }).ToList();
                return Json(produit, JsonRequestBehavior.AllowGet);
            //}
        }

        /// <summary>
        /// Récupérer le GUID du membre connecté et son role au sein du groupe d'achats
        /// </summary>
       //public JsonResult Recuperer_Membre()
       //{
       //     string utilisateur    = User.Identity.Name;
       //     string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;

       //     var membre = (from    m       in      db.AspNetUsers
       //                   join    r       in      db.AspNetUserRoles
       //                   on      m.Id    equals  r.UserId
       //                   where   m.Id    ==      guid
       //                   select new
       //                   {
       //                       MembreID        =   m.Id,
       //                       UserFirstName   =   m.Prenom, 
       //                       UserLastName    =   m.Nom,
       //                       Role            =   r.RoleId
       //                   }).ToList();
       //     return Json(membre, JsonRequestBehavior.AllowGet); 
       // }

        //Afficher le message de l'administrateur du groupe D'achats
        //public JsonResult Afficher_Message()
        //{

        //}
    }
}