using EpicerieModel.Models;
using ProyectLeMoulin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectLeMoulin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AchatAdminController : Controller
    {
        //
        // GET: /AchatAdmin/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewOrder()
        {
            ViewBag.message = "Pour faire une nouvelle commande";
            return View();
        }

        public ActionResult Products()
        {
            ViewBag.message = "Administration des produits";
            return View();
        }

        public ActionResult Suppliers()
        {
            ViewBag.message = "Administration des fournisseurs";
            return View();
        }

        public ActionResult OldOrders()
        {
            ViewBag.message = "Pour obtenir les rapports d'anciennes commandes";
            return View();
        }

        public ActionResult MembersOrders()
        {
            ViewBag.message = "Pour sortir les commandes des membres et leurs reçu";
            return View();
        }

        [HttpPost]
        public ActionResult Suppliers(SupplierViewModel Supplier)
        {
            ViewBag.Title = "Fournisseurs";
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

    }
}
