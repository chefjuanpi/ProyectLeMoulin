//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectLeMoulin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tag
    {
        public Tag()
        {
            this.Nouvelles = new HashSet<Nouvelle>();
        }
    
        public int TagId { get; set; }
        public string Tag1 { get; set; }
    
        public virtual ICollection<Nouvelle> Nouvelles { get; set; }
    }
}
