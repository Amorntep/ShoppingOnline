//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingOnline.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customers
    {
        public Customers()
        {
            this.Orders = new HashSet<Orders>();
        }
    
        public int CustomerID { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Nullable<int> Status { get; set; }
        public string Password { get; set; }
    
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
