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
    
    public partial class CategoryProduct
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string detail { get; set; }
    
        public virtual Categories Categories { get; set; }
        public virtual Products Products { get; set; }
    }
}
