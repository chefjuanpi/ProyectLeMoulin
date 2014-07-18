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



namespace ProyectLeMoulin.Controllers
{

    public class EpicerieController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCategories()
        {
            CoeurContainer db = new CoeurContainer();

            var category = (from c in db.Categories
                            select new
                            {
                                CategoryID = c.CategoryId,
                                CategoryName = c.CategoryName,
                                Description = c.Description
                            }).Single();
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProduits(int cat)
        {
            CoeurContainer db = new CoeurContainer();
            var produit = 0;
            //var produit = (from p in db.Products
            //               where p.CategoryProducts
            //               select new
            //               {
            //                   ProductID = p.ProductID,
            //                   ProductName = p.ProductName,
            //                   Description = p.Description,
            //                   TVQ = p.TVQ,
            //                   TPS = p.TPS,
            //                   Available = p.Available
            //               }).ToList();
            return Json(produit, JsonRequestBehavior.AllowGet);
        }
    }
}