//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Categories
    {
        public Categories()
        {
            this.CategoryProduct = new HashSet<CategoryProduct>();
        }
    
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<CategoryProduct> CategoryProduct { get; set; }
    }
}
