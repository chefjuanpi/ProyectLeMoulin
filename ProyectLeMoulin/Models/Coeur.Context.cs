﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IdentitySample.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CoeurContainer : DbContext
    {
        public CoeurContainer()
            : base("name=CoeurContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Nouvelle> Nouvelles { get; set; }
        public DbSet<NouvellesPicture> NouvellesPictures { get; set; }
        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}
