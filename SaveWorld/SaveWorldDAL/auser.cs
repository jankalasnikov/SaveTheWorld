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
    
    public partial class auser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public auser()
        {
            this.tbOrder = new HashSet<tbOrder>();
            this.subscription = new HashSet<subscription>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public int typeOfUser { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phoneno { get; set; }
        public Nullable<int> accountId { get; set; }
        public byte[] rowVersion { get; set; }
        public string salt { get; set; }
    
        public virtual bankAccount bankAccount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbOrder> tbOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<subscription> subscription { get; set; }
    }
}
