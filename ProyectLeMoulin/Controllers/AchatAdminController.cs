using EpicerieModel.Models;
using IdentitySample.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    //[Authorize(Roles = "Admin groupe d'achats")]
    public class AchatAdminController : Controller
    {
        /// <summary>
        /// Permet d'ouvrir la vue pour Index
        /// Index contient la page qui permet de gêrée la liste d'achats
        /// </summary>
        /// <returns>Une vue avec titre et message</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Liste des produits";
            ViewBag.message = "Administration de la liste d'achat";
            return View();
        }

        /// <summary>
        /// S'exécute au "Post" de la page Index
        /// Enregistre les Ajouts et Modifications
        /// </summary>
        /// <param name="Week">Model à utiliser</param>
        /// <returns>Une vue</returns>
        [HttpPost]
        public ActionResult Index(WeekProductViewModel WeekProduct)
        {
            EpicerieEntities db = new EpicerieEntities();
            if (WeekProduct.ProductId == null)
            {
                WeekProduct wp = new WeekProduct();

                wp.WeekId = WeekProduct.WeekId;
                wp.ProductId = WeekProduct.ProductId;
                wp.SupplierId = WeekProduct.SupplierId;
                wp.UnitPrice = WeekProduct.UnitPrice;
                wp.Quantity = WeekProduct.Quantity;
                wp.Format = WeekProduct.Format;

                db.WeekProduct.Add(wp);
                db.SaveChanges();
            }
            else
            {
                int x = Convert.ToInt16(WeekProduct.ProductId);

                var modifWeekProduct = (from wp in db.WeekProduct
                                 where wp.ProductId == x
                                 where wp.WeekId == (from w in db.Weeks
                                                     orderby w.WeekId descending
                                                     select w.WeekId).First()
                                 select wp).Single();

                modifWeekProduct.ProductId = WeekProduct.ProductId;
                modifWeekProduct.SupplierId = WeekProduct.SupplierId;
                modifWeekProduct.UnitPrice = WeekProduct.UnitPrice;
                modifWeekProduct.Quantity = WeekProduct.Quantity;
                modifWeekProduct.Format = WeekProduct.Format;

                db.SaveChanges();
            }
            getSuppliers();
            getCategories();
            return View();
        }

        public JsonResult getWeekProducts(int Id, string type)
        {
            EpicerieEntities db = new EpicerieEntities();

            int weekbd = (from w in db.Weeks
                          orderby w.WeekId descending
                          select w.WeekId).First();

            var WeekProducts = (from wp in db.WeekProduct
                                join p in db.Products
                                on wp.ProductId equals p.ProductId
                                join cp in db.CategoryProduct
                                on p.ProductId equals cp.ProductId
                                join c in db.Categories
                                on cp.CategoryId equals c.CategoryId
                                join s in db.Suppliers
                                on wp.SupplierId equals s.SupplierId
                                orderby p.ProductName
                                where wp.WeekId == weekbd
                                select new
                                {
                                    CategoryId = c.CategoryId,
                                    SupplierId = s.SupplierId,
                                    ProductId = wp.ProductId,
                                    ProductName = p.ProductName,
                                    SupplierName = c.CategoryName,
                                    UnitPrice = wp.UnitPrice,
                                    Format = wp.Format,
                                    Quantity = wp.Quantity
                                });

            if (type == "cat")
            {
                WeekProducts.Where(c => c.CategoryId == Id);
            }
            else if (type == "sup")
            {
                WeekProducts.Where(s => s.SupplierId == Id);
            }

            WeekProducts.ToList();

            return Json(WeekProducts, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Permet d'otenir les informations sur le produit spécifié
        /// pour la semaine courrante.
        /// </summary>
        /// <param name="ProductId">ID du fournisseur</param>
        /// <returns>Json contenant les informations</returns>
        public JsonResult getWeekProductDetails(int ProductId)
        {
            EpicerieEntities db = new EpicerieEntities();
            var weekProduct = (from wp in db.WeekProduct
                               where wp.ProductId == ProductId
                               where wp.WeekId == (from w in db.Weeks
                                                   orderby w.WeekId descending
                                                   select w.WeekId).First()
                            select new
                            {
                                week = wp.WeekId,
                                Product = wp.ProductId,
                                Supplier = wp.SupplierId,
                                UnitPrice = wp.UnitPrice,
                                Format = wp.Format,
                                Qty = wp.Quantity
                            }).Single();

            return Json(weekProduct, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Permet d'effacer un WeekProduct de la BD
        /// </summary>
        /// <param name="nID">ID du produit</param>
        /// <returns>Retourne à la selection</returns>
        public ActionResult delWeekProduct(int nID)
        {
            EpicerieEntities db = new EpicerieEntities();
            var delWeekProduct = (from wp in db.WeekProduct
                                  where wp.ProductId == nID
                                  where wp.WeekId == (from w in db.Weeks
                                                      orderby w.WeekId descending
                                                      select w.WeekId).First()
                                  select wp).Single();
            if (delWeekProduct != null)
            {
                db.WeekProduct.Remove(delWeekProduct); 
                db.SaveChanges();
            }
            return Redirect("/AchatAdmin/Index");
        }

        /// <summary>
        /// Permet d'ouvrir la vue pour NewOrder
        /// </summary>
        /// <returns>Une vue avec titre et message</returns>
        public ActionResult NewOrder()
        {
            ViewBag.Title = "Nouvelle Commande";
            ViewBag.message = "Affiche la nouvelle commande";
            return View();
        }

        /// <summary>
        /// Permet d'ouvrir la vue pour Products
        /// </summary>
        /// <returns>Une vue avec titre et message</returns>
        public ActionResult Products()
        {
            ViewBag.Title = "Produits";
            ViewBag.message = "Administration des produits";
            return View();
        }

        /// <summary>
        /// Permet d'obtenir l'ID et le Nom des Categories
        /// </summary>
        /// <returns>Json contenant les Suppliers</returns>
        public JsonResult getCategories()
        {
            EpicerieEntities db = new EpicerieEntities();
            var categories = (from c in db.Categories
                             orderby c.CategoryName
                             select new
                             {
                                 id = c.CategoryId,
                                 nom = c.CategoryName
                             });
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Permet d'ouvrir la vue pour Suppliers
        /// </summary>
        /// <returns>Une vue avec titre et message</returns>
        public ActionResult Suppliers()
        {
            ViewBag.Title = "Fournisseurs";
            ViewBag.message = "Administration des fournisseurs";
            return View();
        }

        /// <summary>
        /// S'exécute au "Post" de la page Suppliers
        /// Enregistre les Ajouts et Modifications
        /// </summary>
        /// <param name="Supplier">Model à utiliser</param>
        /// <returns>Une vue</returns>
        [HttpPost]
        public ActionResult Suppliers(SupplierViewModel Supplier)
        {
            EpicerieEntities db = new EpicerieEntities();
            if (Supplier.SupplierId == null)
            {
                Suppliers s = new Suppliers();
                s.SupplierName = Supplier.SupplierName;
                s.ContactName = Supplier.SupplierContactName;
                s.Adress = Supplier.SupplierAdress;
                s.E_Mail = Supplier.SupplierMail;
                s.Phone = Supplier.SupplierPhone;
                s.Fax = Supplier.SupplierFax;
                s.PostalCode = Supplier.SupplierPostalCode;
                s.Ville = Supplier.SupplierCity;

                db.Suppliers.Add(s);
                db.SaveChanges();
            }
            else
            {
                int x = Convert.ToInt16(Supplier.SupplierId);
                var modifsupplier = (from s in db.Suppliers
                                     where s.SupplierId == x
                                     select s).Single();
                modifsupplier.SupplierName = Supplier.SupplierName;
                modifsupplier.ContactName = Supplier.SupplierContactName;
                modifsupplier.Adress = Supplier.SupplierAdress;
                modifsupplier.E_Mail = Supplier.SupplierMail;
                modifsupplier.Phone = Supplier.SupplierPhone;
                modifsupplier.Fax = Supplier.SupplierFax;
                modifsupplier.PostalCode = Supplier.SupplierPostalCode;
                modifsupplier.Ville = Supplier.SupplierCity;
                db.SaveChanges();
            }
            getSuppliers();
            return View();
        }

        /// <summary>
        /// Permet d'obtenir l'ID et le Nom des fournisseurs
        /// </summary>
        /// <returns>Json contenant les Suppliers</returns>
        public JsonResult getSuppliers()
        {
            EpicerieEntities db = new EpicerieEntities();
            var suppliers = (from s in db.Suppliers
                             orderby s.SupplierName
                             select new
                             {
                                 id = s.SupplierId,
                                 nom = s.SupplierName
                             });
            return Json(suppliers, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Permet d'otenir les informations sur un fournisseur
        /// </summary>
        /// <param name="SupplierId">ID du fournisseur</param>
        /// <returns>Json contenant les informations</returns>
        public JsonResult getSupplierDetails(int SupplierId)
        {
            EpicerieEntities db = new EpicerieEntities();
            var supplier = (from s in db.Suppliers
                            where s.SupplierId == SupplierId
                            select new
                            {
                                id = s.SupplierId,
                                Nom = s.SupplierName,
                                contact = s.ContactName,
                                adresse = s.Adress,
                                mail = s.E_Mail,
                                phone = s.Phone,
                                fax = s.Fax,
                                codepostal = s.PostalCode,
                                ville = s.Ville,
                            }).Single();
            return Json(supplier, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Permet d'effacer un fournisseur de la BD
        /// </summary>
        /// <param name="nID">ID du fournisseur</param>
        /// <returns>Retourne à la selection</returns>
        public ActionResult delSupplier(int nID)
        {
            EpicerieEntities db = new EpicerieEntities();
            var delsupplier = (from s in db.Suppliers
                               where s.SupplierId == nID
                               select s).Single();
            if (delsupplier != null)
            {
                db.Suppliers.Remove(delsupplier);
                db.SaveChanges();
            }
            return Redirect("/AchatAdmin/Suppliers");
        }


        /// <summary>
        /// Permet d'ouvrir la vue pour OldOrders
        /// </summary>
        /// <returns>Une vue avec titre et message</returns>
        public ActionResult OldOrders()
        {
            ViewBag.Title = "Fournisseurs";
            ViewBag.message = "Pour obtenir les rapports d'anciennes commandes";
            return View();
        }

        /// <summary>
        /// Permet d'ouvrir la vue pour MembersOrders
        /// </summary>
        /// <returns>Une vue avec titre et message</returns>
        public ActionResult MembersOrders()
        {
            ViewBag.Title = "Commandes des membres";
            ViewBag.message = "Pour sortir les commandes des membres et leurs reçu";
            return View();
        }

    }
}
