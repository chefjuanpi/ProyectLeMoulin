using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectLeMoulin.Controllers
{
    class Panier
    {
        public int ProductID { get; set; }

        public string Produits { get; set; }

        public decimal Price { get; set; }

        public int Qantity { get; set; }

        public bool TVQ { get; set; }

        public bool TPS { get; set; }

        public decimal Total { get; set; }

        public decimal Quebec { get; set; }

        public decimal Canada { get; set; }
    }
}
