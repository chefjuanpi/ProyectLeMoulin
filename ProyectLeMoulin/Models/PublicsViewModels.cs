using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentitySample.Models
{
    public class EvemPhoto
    {
        public string photos { get; set; }

        public string titre { get; set; }

        public DateTime dateStart { get; set; }

        public DateTime dateEnd { get; set; }
    }

    public class evDisplay
    {
        public string title { get; set; }

        public string start { get; set; }

        public string end { get; set; }

        public string url { get; set; }

        public string description { get; set; }

        public string backgroundColor { get; set; }

        public string photo { get; set; }

    }

    class t
    {
        public DateTime date { get; set; }

        public DateTime datefin { get; set; }

        public string type { get; set; }

        public TimeSpan heureStart { get; set; }

        public TimeSpan heurefin { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string photo { get; set; }
    }

    class titreTextNouvelle
    {
        public string titre { get; set; }

        public string text { get; set; }
    }

}