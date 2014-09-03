using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentitySample.Models
{
    //
    /// <summary>
    /// Modèle de chaque produit
    /// </summary>
    public class listProducts
    {
        public int qty { get; set; }
        public int PID { get; set; }
    }

    public class test1234
    {
        //
        /// <summary>
        /// Modèle de la semaine, contient l'identifiant de la semmaine et la liste des produits
        /// </summary>
        public List<listProducts> obj { get; set; }
        public int week { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public DateTime Recup { get; set; }

    }

}