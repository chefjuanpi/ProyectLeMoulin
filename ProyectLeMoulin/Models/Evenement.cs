//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectLeMoulin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Evenement
    {
        public int EventId { get; set; }
        public string TitleEvenement { get; set; }
        public string PrincipalPhotoEvenement { get; set; }
        public string PlaceEvenement { get; set; }
        public string AdresseEvenement { get; set; }
        public System.DateTime DateStart { get; set; }
        public Nullable<System.TimeSpan> HourStart { get; set; }
        public System.DateTime DateEnd { get; set; }
        public Nullable<System.TimeSpan> HourEnd { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public int TypeId { get; set; }
        public Nullable<bool> Poublier { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}