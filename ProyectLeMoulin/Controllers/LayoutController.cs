using IdentitySample.Models;
using System.Linq;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult Menu()
        {
            CoeurContainer db = new CoeurContainer();
            //function pour recouperer les pages princiales
            var parents = (from p in db.Pages
                         where p.Principal == true & p.PageID > 1 & p.Poublier == true
                         orderby p.PageID
                         select new
                         {
                             idParent = p.PageID,
                             nom = p.MenuName
                         }).ToList();

            var enfants = (from p in db.Pages
                           where p.SousMenu != null & p.Poublier == true
                           orderby p.SousMenu
                           select new
                           {
                               idchild= p.PageID,
                               nom = p.MenuName,
                               parent = p.SousMenu
                           }).ToList();
            string menu = "";

            for (int i = 0; i < parents.Count; i++)
            {
                if (i == 5)
                {
                    menu += "<li class='dropdown-submenu'><a>Outres";
                    menu += "</a><ul class='dropdown-menu' id='menuOutres' >";
                }

                if (enfants.Exists(a => a.parent == parents[i].idParent))
                    {
                        var eMenu = enfants.FindAll(a => a.parent == parents[i].idParent);
                        menu += "<li class='dropdown'><a class='dropdown-toggle' data-toggle='dropdown'>"+parents[i].nom;
                        menu += "<span class='caret'></span></a><ul class='dropdown-menu' role='menu'><li><a ";
                        switch (parents[i].idParent)
                        {
                            case 2 :
                                menu += "href='/Evenements'>" + parents[i].nom + "</a></li>";
                                break;
                            case 3:
                                menu += "href='/Home/GroupedAchats'>" + parents[i].nom + "</a></li>";
                                break;
                            case 4:
                                menu += "href='/Home/Contact'>" + parents[i].nom + "</a></li>";
                                break;
                            default:
                                menu += "href='/home/pages?pname=" + parents[i].nom + "' >" + parents[i].nom + "</a></li>";
                                break;
                        }
                        for(int k = 0; k < eMenu.Count; k++)
                        {
                            menu += "<li><a href='/home/pages?pname=" + eMenu[k].nom + "' >" + eMenu[k].nom + "</a></li>";
                        }
                        menu += "</ul></li>";
                    }
                    else
                    {
                        switch (parents[i].idParent)
                        {
                            case 2:
                                menu += "<li><a href='/Calendar'>" + parents[i].nom + "</a></li>";
                                break;
                            case 3:
                                menu += "<li><a href='/Home/GroupedAchats'>" + parents[i].nom + "</a></li>";
                                break;
                            case 4:
                                menu += "<li><a href='/Home/Contact'>" + parents[i].nom + "</a></li>";
                                break;
                            default :
                                menu += "<li><a href='/home/pages?pname=" + parents[i].nom + "' >" + parents[i].nom + "</a></li>";
                                break;
                        }
                    }
                }
            if (parents.Count > 7)
            {
                menu += "</ul></li>";
            }
            
            return Content(menu);
        }

    }
}