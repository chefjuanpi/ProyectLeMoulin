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

namespace IdentitySample.Controllers
{
    
    public class EpicerieController : Controller
    {
        EpicerieEntities db = new EpicerieEntities();
        
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

        //Récupérer les produits selon la catégorie choisie
        public JsonResult GetProduits(int cat)
        {
            
            //if (cat == db.Categories.CategoryId)
            //{
            
                var produit = (from w in db.Week
                               join p in db.Products
                               on w.ProductId equals p.ProductId
                               join cp in db.CategoryProduct
                               on p.ProductId equals cp.ProductId
                               where cp.CategoryId == cat
                               select new
                               {
                                   ProductID = p.ProductId,
                                   ProductName = p.ProductName,
                                   Format = w.Format,
                                   Price = w.UnitPrice
                               }).ToList();
                return Json(produit, JsonRequestBehavior.AllowGet);
            //}
        }

        /// <summary>
        /// Remplir le Panier
        /// </summary>
        /// <param name="prod">ProductID sélectionné</param>
        /// <param name="qty">Quantité choisie</param>
        /// <returns>retourne le contenu du panier</returns>
        //public JsonResult Remplir_Le_Panier(int prod)
        //{
            
            
        //    //if (prod == db.Products.)
        //    //{
        //        var product = (from w in db.Week
        //                       join p in db.Products
        //                       on w.ProductId equals p.ProductId
        //                       join cp in db.CategoryProduct
        //                       on p.ProductId equals cp.ProductId
        //                       where p.ProductId == prod
        //                       join od in db.OrderDetails
        //                       on w.ProductId equals od.ProductId
        //                       join o in db.Orders
        //                       on od.OrderId equals o.OrderId
        //                       select new
        //                       {
        //                            ProductId = w.ProductId,
        //                            ProductName = p.ProductName,
        //                            //Qantity = qty,
        //                            Price = w.UnitPrice,
        //                            CategoryID = cp.CategoryId
        //                       }).ToList();

        //        return Json(product, JsonRequestBehavior.AllowGet);
        //    //}
        //}

        

        /// <summary>
        /// Supprimer un article du panier
        /// </summary>
        /// <param name="prod">ProductId sélectionné</param>
        /// <returns>Contenu du panier après la supression</returns>
        //public ActionResult delArticle(int prod)
        //{
        //    var delsupplier = (from a in Panier
        //                       where a.ProductId == prod
        //                       select new Panier()
        //                       ).ToList();
        //    if (delArticle != null)
        //    {
        //        a.Remove(delArticle);
        //        a.SaveChanges();
        //    }
        //    return Redirect("/Epicerie/Remplir_Le_Panier");
        //}

        //public void Calculer_Prix_Total(bool tvq, bool tps, decimal price)
        //{

        //    if (tvq == true && tps == true)
        //    {
        //        p.Quebec = P.Price * (decimal)0.09975;
        //        p.Canada = P.Price * (decimal)0.05;
        //        p.Total = P.Price + p.Quebec + p.Canada;

        //    }
        //    if (tvq == true && tps == false)
        //    {
        //        p.Quebec = P.Price * (decimal)0.09975;
        //        p.Canada = 0;
        //        p.Total = P.Price + p.Quebec;
        //    }

        //    if (tps == true && tvq == false)
        //    {
        //        P.Canada = price * (decimal)0.05;
        //        P.Quebec = 0;
        //        p.Total = P.Price + p.Canada;
        //    }
        //    if (tvq == false && tps == false)
        //    {
        //        p.Quebec = 0;
        //        p.Canada = 0;
        //        return;
        //    }
        //}

        /// <summary>
        /// Affiche le contenu du panierpour confirmation
        /// </summary>
        //public JsonResult Afficher_Le_Panier()
        //{
        //    Panier p = new Panier();

        //    var panier = p;

        //    return Json(panier, JsonRequestBehavior.AllowGet);
        //}

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