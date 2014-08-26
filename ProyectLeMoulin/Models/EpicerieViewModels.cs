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
    }

    public class Commande
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public int WeekId { get; set; }
        public bool Commande_Payee { get; set; }
    }

    public class Detail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int WeekId { get; set; }
        public int Quantite { get; set; }
        public decimal UnitPrice { get; set; }

    }
}