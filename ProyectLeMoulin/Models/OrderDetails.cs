//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IdentitySample.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public System.DateTime DateSemaine { get; set; }
        public int Quantite { get; set; }
        public decimal UnitPrice { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Week Week { get; set; }
    }
}
