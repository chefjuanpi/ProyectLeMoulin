//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectLeMoulin
{
    using System;
    using System.Collections.Generic;
    
    public partial class Week
    {
        public Week()
        {
            this.OrderDetails = new HashSet<OrderDetails>();
        }
    
        public System.DateTime DateSemaine { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Format { get; set; }
    
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual Products Products { get; set; }
        public virtual Suppliers Suppliers { get; set; }
    }
}
