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
    
    public partial class Nouvelle
    {
        public Nouvelle()
        {
            this.Comments = new HashSet<Comment>();
            this.NouvellesPictures = new HashSet<NouvellesPicture>();
            this.Tags = new HashSet<Tag>();
        }
    
        public int NouvelleId { get; set; }
        public string NouvelleTitle { get; set; }
        public string NouvellePrincipalPhoto { get; set; }
        public string NouvelleText { get; set; }
        public Nullable<System.DateTime> NouvelleDate { get; set; }
        public string UserId { get; set; }
        public Nullable<bool> Publier { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<NouvellesPicture> NouvellesPictures { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
