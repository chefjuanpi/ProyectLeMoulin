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
    
    public partial class NouvellesPicture
    {
        public int BlogId { get; set; }
        public int PictureId { get; set; }
    
        public virtual Nouvelle Nouvelle { get; set; }
    }
}
