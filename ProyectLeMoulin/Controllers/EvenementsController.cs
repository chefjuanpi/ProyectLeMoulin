using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class EvenementsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getEvements(System.DateTime start, System.DateTime end, double ti = 0)
        {
            CoeurContainer db = new CoeurContainer();
            var calendar = (from e in db.Evenements
                            where e.DateStart >= start & e.Poublier == true
                            select new t
                            {
                                date = e.DateStart,
                                datefin = e.DateEnd,
                                heureStart = (TimeSpan)e.HourStart,
                                heurefin = (TimeSpan)e.HourEnd,
                                title = e.TitleEvenement,
                                description = e.Text,
                                photo = e.PrincipalPhotoEvenement
                            }).ToList();

            calendar.RemoveAll(e => e.date > end);

            List<evDisplay> eve = new List<evDisplay>();
            for (int x = 0; x < calendar.Count(); x++)
            {
                int i = calendar.Count();
                calendar[x].description = Nohtml(calendar[x].description) + " ...";

                string m = (calendar[x].date.Month > 9) ? calendar[x].date.Month.ToString() : "0" + calendar[x].date.Month;
                string j = (calendar[x].date.Day > 9) ? calendar[x].date.Day.ToString() : "0" + calendar[x].date.Day;
                string h = (calendar[x].heureStart.Hours > 9) ? calendar[x].heureStart.Hours.ToString() : "0" + calendar[x].heureStart.Hours;
                string min = (calendar[x].heureStart.Minutes > 9) ? calendar[x].heureStart.Minutes.ToString() : "0" + calendar[x].heureStart.Minutes;

                string mf = (calendar[x].datefin.Month > 9) ? calendar[x].datefin.Month.ToString() : "0" + calendar[x].datefin.Month;
                string jf = (calendar[x].datefin.Day > 9) ? calendar[x].datefin.Day.ToString() : "0" + calendar[x].datefin.Day;
                string hf = (calendar[x].heurefin.Hours > 9) ? calendar[x].heurefin.Hours.ToString() : "0" + calendar[x].heurefin.Hours;
                string minf = (calendar[x].heurefin.Minutes > 9) ? calendar[x].heurefin.Minutes.ToString() : "0" + calendar[x].heurefin.Minutes;

                evDisplay temp = new evDisplay
                {
                    title = calendar[x].title,
                    start = calendar[x].date.Year + "-" + m + "-" + j + "T" + h + ":" + min + ":" + "00",
                    end = calendar[x].datefin.Year + "-" + mf + "-" + jf + "T" + hf + ":" + minf + ":" + "00",
                    url = "/Evenements/Details?nom='" + calendar[x].title + "'",
                    description = calendar[x].description,
                    backgroundColor = "red"
                };

                eve.Add(temp);
            }
            return Json(eve, JsonRequestBehavior.AllowGet);
        }

        private string Nohtml(string tiny)
        {
            int y;
            string temp = "";
            for (y = 0; y < tiny.Count() - 1; )
            {
                if (tiny.IndexOf("<", y) > -1)
                {
                    int start = tiny.IndexOf("<", y);
                    y = tiny.IndexOf(">", start) + 1;
                    start = tiny.IndexOf("<", y);
                    if ((start - y) > 0)
                    {
                        string yupi = tiny.Substring(y, (start - y)).Trim();
                        if (tiny.Substring(y, (start - y)) != "\r\n")
                        {
                            if (tiny.Substring(y, (start - y)).Trim() != "&nbsp;")
                            {
                                temp += " " + tiny.Substring(y, (start - y));
                                if (temp.Count() > 200)
                                {
                                    temp = temp.Substring(0, 199);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return temp;
        }

        public ActionResult Details(string nom)
        {
            return View();
        }
    }
}