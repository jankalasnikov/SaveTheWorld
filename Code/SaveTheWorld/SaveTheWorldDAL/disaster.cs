//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SaveTheWorldDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class disaster
    {
        public int id { get; set; }
        public string disasterName { get; set; }
        public string description { get; set; }
        public string region { get; set; }
        public Nullable<int> categoryId { get; set; }
        public int priority { get; set; }
        public int victims { get; set; }
        public Nullable<int> accountId { get; set; }
    
        public virtual bankAccount bankAccount { get; set; }
        public virtual category category { get; set; }
    }
}
