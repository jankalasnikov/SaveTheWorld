//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SaveWorldDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class orderLine
    {
        public int id { get; set; }
        public Nullable<int> productId { get; set; }
        public double quantity { get; set; }
        public Nullable<int> orderId { get; set; }
    
        public virtual tbOrder tbOrder { get; set; }
        public virtual product product { get; set; }
    }
}
