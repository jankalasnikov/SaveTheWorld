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
    
    public partial class subscription
    {
        public int id { get; set; }
        public Nullable<int> typeOfSubscriptionId { get; set; }
        public double amount { get; set; }
        public System.DateTime startDate { get; set; }
    
        public virtual typeOfSubscription typeOfSubscription { get; set; }
    }
}
