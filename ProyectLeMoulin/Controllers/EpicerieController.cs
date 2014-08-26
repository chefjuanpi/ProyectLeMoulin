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

            //var category = (from   c in db.Categories
                    //        where  c.CategoryId == cat
                    //        select c.CategoryId
                    //        ).FirstOrDefault();
            //if (category == cat)
            //{
            
                int weekID = (from    w in db.Weeks
                              orderby w.WeekId
                              select  w.WeekId
                              ).FirstOrDefault();

                var produit =   (from w in db.Weeks
                                 join wp in db.WeekProduct
                                 on w.WeekId equals wp.WeekId
                                 join p in db.Products
                                 on wp.ProductId equals p.ProductId
                                 join cp in db.CategoryProduct
                                 on p.ProductId equals cp.ProductId
                                 where cp.CategoryId == cat
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
            //}
            //else {    }
        }

        /// <summary>
        /// Récupérer le GUID du membre connecté et son role au sein du groupe d'achats
        /// </summary>
        //public void Valider_Membre()
        //{
        //    EpicerieEntities db = new EpicerieEntities();

        //    string utilisateur = User.Identity.Name;
        //    string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;

        //    var membre = (from  m in db.AspNetUsers
        //                  join  r in db.AspNetUserRoles
        //                  on    m.Id equals r.UserId
        //                  where m.Id       ==  guid
        //                  &&    r.RoleId   ==  "1fa8e7cb-2dc9-41f5-aecf-a27a60e37423"// ID role Groupe d'achat
        //                  select r.RoleId
        //                 ).Single();
        //}

        //[HttpPost]
        //public async Task<ActionResult> Index(test1234 panier)
        //{
        //    //pour garder ou modifier la bd, async xq sea mas rapido para el utilisateur
        //    EpicerieEntities db = new EpicerieEntities();
            
        //    int i = 0;

        //    foreach (List<listProducts>)
        //   {
        //       var client = from o in db.Orders
        //                    select new listProducts
        //                    {

        //                    };

        //   }

        //    ViewBag.Steeve = "ton panier";
        //    return View();

        //}

        

        //Afficher le message de l'administrateur du groupe D'achats
        //public JsonResult Afficher_Message()
        //{

        //}

    }
}