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
    
    public partial class Weeks
    {
        public Weeks()
        {
            this.WeekProduct = new HashSet<WeekProduct>();
            this.Orders = new HashSet<Orders>();
        }
    
        public int WeekId { get; set; }
        public Nullable<System.DateTime> Date_Debut { get; set; }
        public Nullable<System.DateTime> Date_Fin { get; set; }
        public Nullable<System.DateTime> Date_Recuperation { get; set; }
    
        public virtual ICollection<WeekProduct> WeekProduct { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
