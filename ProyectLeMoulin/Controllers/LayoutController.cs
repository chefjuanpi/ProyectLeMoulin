using IdentitySample.Models;
using System.Linq;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    [RequireHttps]
    public class LayoutController : Controller
    {
        /// <summary>
        /// function qui permet créer le contenu du menu de maniere dinamique pour le _Layout du site
        /// </summary>
        /// <returns>le code html du menu</returns>
        public ActionResult Menu()
        {
            CoeurContainer db = new CoeurContainer();
            //variable pour recouperer les pages princiales
            var parents = (from p in db.Pages
                         where p.Principal == true & p.PageID > 1 & p.Poublier == true
                         orderby p.PageID
                         select new
                         {
                             idParent = p.PageID,
                             nom = p.MenuName
                         }).ToList();

            //variable pour recoupere les pages enfants avec le id du parent
            var enfants = (from p in db.Pages
                           where p.SousMenu != null & p.Poublier == true
                           orderby p.SousMenu
                           select new
                           {
                               idchild= p.PageID,
                               nom = p.MenuName,
                               parent = p.SousMenu
                           }).ToList();
            ViewBag.mparent = parents;
            ViewBag.menfants = enfants;
            string menu = "";

            //creation du menu paremetrée
            for (int i = 0; i < parents.Count; i++)
            {
                if (i == 4)
                {
                    menu += "<li class='dropdown-submenu'><a>Autres<span class='caret'></span>";
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
                                menu += "href='/home/pages?pname=" + parents[i].nom.Replace(' ', '_') + "' >" + parents[i].nom + "</a></li>";
                                break;
                        }
                        for(int k = 0; k < eMenu.Count; k++)
                        {
                            menu += "<li><a href='/home/pages?pname=" + eMenu[k].nom.Replace(' ', '_') + "' >" + eMenu[k].nom + "</a></li>";
                        }
                        menu += "</ul></li>";
                    }
                    else
                    {
                        switch (parents[i].idParent)
                        {
                            case 2:
                                menu += "<li><a href='/Evenements'>" + parents[i].nom + "</a></li>";
                                break;
                            case 3:
                                if (User.Identity.IsAuthenticated)
                                {
                                    menu += "<li><a href='/Epicerie'>" + parents[i].nom + "</a></li>";
                                }
                                else
                                {
                                    menu += "<li><a href='/Home/GroupedAchats'>" + parents[i].nom + "</a></li>";
                                }
                                break;
                            case 4:
                                menu += "<li><a href='/Home/Contact'>" + parents[i].nom.Replace(' ', '_') + "</a></li>";
                                break;
                            default :
                                menu += "<li><a href='/home/pages?pname=" + parents[i].nom.Replace(' ', '_') + "' >" + parents[i].nom + "</a></li>";
                                break;
                        }
                    }
                }
            //fermeture extra si le menu include Outres
            if (parents.Count > 4)
            {
                menu += "</ul></li>";
            }
            
            return Content(menu);
        }

    }
}