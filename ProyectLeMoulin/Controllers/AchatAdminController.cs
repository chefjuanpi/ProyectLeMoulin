using EpicerieModel.Models;
using IdentitySample.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    [Authorize(Roles = "Administrateur")]
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
        /// <param name="WeekProduct">Model à utiliser</param>
        /// <returns>Une vue</returns>
        [HttpPost]
        public ActionResult Index(WeekProductViewModel WeekProduct)
        {
            EpicerieEntities db = new EpicerieEntities();

            int x = Convert.ToInt16(WeekProduct.ProductId);
            var Week = (from w in db.Weeks
                        orderby w.WeekId descending
                        select w.WeekId).First();

            if ((from wp in db.WeekProduct
                 where wp.ProductId == x 
                 where wp.WeekId == Week 
                 select wp).Count() == 0)
            {
                WeekProduct wp = new WeekProduct();

                wp.WeekId = Week;
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
                var modifWeekProduct = (from wp in db.WeekProduct
                                 where wp.ProductId == x
                                 where wp.WeekId == Week
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

            ViewBag.Title = "Liste des produits";
            ViewBag.message = "Administration de la liste d'achat";
            return View();
        }

        /// <summary>
        /// Permet de récupérer les WeekProducts de la semaine courrante
        /// </summary>
        /// <param name="Id">Id du produit voulu</param>
        /// <returns></returns>
        public JsonResult getWeekProducts(int Id)
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
                                where c.CategoryId == Id
                                select new
                                {
                                    CategoryId = cp.CategoryId,
                                    SupplierId = s.SupplierId,
                                    ProductId = wp.ProductId,
                                    ProductName = p.ProductName,
                                    SupplierName = s.SupplierName,
                                    UnitPrice = wp.UnitPrice,
                                    Format = wp.Format,
                                    Quantity = wp.Quantity
                                }).ToList();

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

            var Week = (from w in db.Weeks
                        orderby w.WeekId descending
                        select w.WeekId).First();

            var weekProduct = ( from wp in db.WeekProduct
                                where wp.ProductId == ProductId
                                where wp.WeekId == Week
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

            var Week = (from w in db.Weeks
                        orderby w.WeekId descending
                        select w.WeekId).First();

            var delWeekProduct = (from wp in db.WeekProduct
                                  where wp.ProductId == nID
                                  where wp.WeekId == Week
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
            ViewBag.message = "Affiche la commande à faire cette semaine";
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
        /// S'exécute au "Post" de la page Products
        /// Enregistre les Ajouts et Modifications
        /// </summary>
        /// <param name="Product">Model à utiliser</param>
        /// <returns>Une vue</returns>
        [HttpPost]
        public ActionResult Products(ProductViewModel product)
        {
            EpicerieEntities db = new EpicerieEntities();
            if (product.ProductId == null)
            {
                Products p = new Products();
                p.ProductName = product.ProductName;
                p.Description = product.Description;
                p.TVQ = product.TVQ;
                p.TPS = product.TPS;

                db.Products.Add(p);
                db.SaveChanges();
            }
            else
            {
                int x = Convert.ToInt16(product.ProductId);
                var modifProduct = (from p in db.Products
                                    where p.ProductId == x
                                    select p).Single();
                modifProduct.ProductName = product.ProductName;
                modifProduct.Description = product.Description;
                modifProduct.TVQ = product.TVQ;
                modifProduct.TPS = product.TPS;

                db.SaveChanges();
            }

            getProducts();

            ViewBag.Title = "Produits";
            ViewBag.message = "Administration des produits";
            return View();
        }

        /// <summary>
        /// Permet d'obtenir l'ID et le Nom des Products
        /// </summary>
        /// <returns>Json contenant les Products</returns>
        public JsonResult getProducts()
        {
            EpicerieEntities db = new EpicerieEntities();
            var products = (from p in db.Products
                            orderby p.ProductName
                            select new
                            {
                                id = p.ProductId,
                                nom = p.ProductName
                            }).ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Permet d'otenir les informations sur un product
        /// </summary>
        /// <param name="ProductId">ID du product</param>
        /// <returns>Json contenant les informations</returns>
        public JsonResult getProductDetails(int ProductId)
        {
            EpicerieEntities db = new EpicerieEntities();
            var product = (from p in db.Products
                           where p.ProductId == ProductId
                           select new
                           {
                               id = p.ProductId,
                               Nom = p.ProductName,
                               description = p.Description,
                               TVQ = p.TVQ,
                               TPS = p.TPS,
                           }).Single();
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Permet d'effacer un produit de la BD
        /// </summary>
        /// <param name="nID">ID du produit</param>
        /// <returns>Retourne à la selection</returns>
        public ActionResult delProduct(int nID)
        {
            EpicerieEntities db = new EpicerieEntities();
            var delproduct = (from p in db.Products
                              where p.ProductId == nID
                              select p).Single();
            if (delproduct != null)
            {
                db.Products.Remove(delproduct);
                db.SaveChanges();
            }
            return Redirect("/AchatAdmin/Categories");
        }

        /// <summary>
        /// Permet d'ouvrir la vue pour Categories
        /// </summary>
        /// <returns>Une vue avec titre et message</returns>
        public ActionResult Categories()
        {
            ViewBag.Title = "Categories";
            ViewBag.message = "Administration des catégories";
            return View();
        }

        /// <summary>
        /// S'exécute au "Post" de la page Categories
        /// Enregistre les Ajouts et Modifications
        /// </summary>
        /// <param name="Category">Model à utiliser</param>
        /// <returns>Une vue</returns>
        [HttpPost]
        public ActionResult Categories(CategoryViewModel category)
        {
            EpicerieEntities db = new EpicerieEntities();
            if (category.CategoryId == null)
            {
                Categories c = new Categories();
                c.CategoryName = category.CategoryName;
                c.Description = category.Description;


                db.Categories.Add(c);
                db.SaveChanges();
            }
            else
            {
                int x = Convert.ToInt16(category.CategoryId);
                var modifCategory = (from c in db.Categories
                                     where c.CategoryId == x
                                     select c).Single();
                modifCategory.CategoryName = category.CategoryName;
                modifCategory.Description = category.Description;

                db.SaveChanges();
            }

            getCategories();

            ViewBag.Title = "Categories";
            ViewBag.message = "Administration des catégories";
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
        /// Permet d'otenir les informations sur une Categorie
        /// </summary>
        /// <param name="CategoryId">ID du fournisseur</param>
        /// <returns>Json contenant les informations</returns>
        public JsonResult getCategoryDetails(int CategoryId)
        {
            EpicerieEntities db = new EpicerieEntities();
            var category = (from c in db.Categories
                            where c.CategoryId == CategoryId
                            select new
                            {
                                id = c.CategoryId,
                                Nom = c.CategoryName,
                                description = c.Description,
                            }).Single();
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Permet d'effacer une Categorie de la BD
        /// </summary>
        /// <param name="nID">ID de la categorie</param>
        /// <returns>Retourne à la selection</returns>
        public ActionResult delCategory(int nID)
        {
            EpicerieEntities db = new EpicerieEntities();
            var delcategory = (from c in db.Categories
                               where c.CategoryId == nID
                               select c).Single();
            if (delcategory != null)
            {
                db.Categories.Remove(delcategory);
                db.SaveChanges();
            }
            return Redirect("/AchatAdmin/Categories");
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

            ViewBag.Title = "Fournisseurs";
            ViewBag.message = "Administration des fournisseurs";
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
                             }).ToList();
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
            ViewBag.Title = "Anciennes commandes";
            ViewBag.message = "Pour obtenir les rapports d'anciennes commandes";
            return View();
        }

        /// <summary>
        /// Permet d'ouvrir la vue pour MembersOrders
        /// </summary>
        /// <returns>Une vue avec titre et message</returns>
        public ActionResult MembersOrders()
        {
            ViewBag.Title = "Factures des membres";
            ViewBag.message = "Pour sortir les commandes des membres et leurs reçu";
            return View();
        }

        /// <summary>
        /// Permet d'ouvrir la vue pour Taxes
        /// </summary>
        /// <returns>Une vue avec titre et message</returns>
        public ActionResult Taxes()
        {
            ViewBag.Title = "Admnistration des Taxes";
            ViewBag.message = "Permet de modifier les taxes au besoin";
            return View();
        }
    }
}