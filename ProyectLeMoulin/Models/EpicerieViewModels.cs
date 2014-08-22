using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentitySample.Models
{
    //ici le model pour chaque produit écrit le propietes a besoin
    public class listProducts
    {
        public int qty { get; set; }
        public int PID { get; set; }
    }

    public class test1234
    {
        //est le modelle pour la semaine, contien le semmaine et la liste des produits
        public List<listProducts> obj { get; set; }
        public string week { get; set; }
    }
}