//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectLeMoulin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Suppliers
    {
        public Suppliers()
        {
            this.Week = new HashSet<Week>();
        }
    
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string Adress { get; set; }
        public string E_Mail { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    
        public virtual ICollection<Week> Week { get; set; }
    }
}