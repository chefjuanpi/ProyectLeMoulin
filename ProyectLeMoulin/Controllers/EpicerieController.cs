using System.Globalization;
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
        //public JsonResult GetProduits(string cat);
        //{
        //    EpicerieEntities db = new EpicerieEntities();

        //    var produit = (from w in db.Week
        //                   join p in db.Products
        //                   on w.ProductId equals p.ProductId
        //                   join c in db.Categories
        //                   on cat equals c.CategoryId
        //                   where c.CategoryId == cat
        //                   select new
        //                   {
        //                       ProductID = w.ProductId,
        //                       ProductName = w.Products,
        //                       TVQ = p.TVQ,
        //                       TPS = p.TPS,
        //                       Available = p.Avaibled
        //                   }).ToList();
        //    return Json(produit, JsonRequestBehavior.AllowGet);
        //}

        //Récupérer le GUID du membre connecté et son role au sein du groupe d'achats
        //public JsonResult Recuperer_Membre()
        //{

        //    EpicerieEntities db = new EpicerieEntities();
        //    string utilisateur = User.Identity.Name;
        //    string guid = db.AspNetUsers.Single(m => m.UserName == utilisateur).Id;

        //    var membre = (from m in db.AspNetUsers
        //                  join r in db.AspNetUserRoles
        //                  on m.UserName equals r.AspNetUsers
        //                  where m.Id == guid
        //                  select new
        //                  {
        //                      MembreID          =   m.Id,
        //                      UserFirstName     =   m.Prenom, 
        //                      UserLastName      =   m.Nom,
        //                      Role              =   r.RoleId
        //                  }).ToList();
        //        return Json(membre, JsonRequestBehavior.AllowGet); 
        //    }
        //}
    }
}