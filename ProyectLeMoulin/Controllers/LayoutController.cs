using ProyectLeMoulin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult Menu()
        {
            CoeurContainer db = new CoeurContainer();
            var pages = (from p in db.Pages
                         where p.PageID > 5
                         select new
                         {
                             nom = p.MenuName,
                             principal = p.Principal,
                             parent = p.SousMenu
                         }).ToList();
            return View();
        }

    }
}