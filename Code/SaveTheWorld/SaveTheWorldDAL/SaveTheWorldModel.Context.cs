﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SaveTheWorldEntities : DbContext
    {
        public SaveTheWorldEntities()
            : base("name=SaveTheWorldEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<auser> auser { get; set; }
        public virtual DbSet<bankAccount> bankAccount { get; set; }
        public virtual DbSet<category> category { get; set; }
        public virtual DbSet<disaster> disaster { get; set; }
        public virtual DbSet<invoice> invoice { get; set; }
        public virtual DbSet<orderLine> orderLine { get; set; }
        public virtual DbSet<product> product { get; set; }
        public virtual DbSet<productPropertyValues> productPropertyValues { get; set; }
        public virtual DbSet<property> property { get; set; }
        public virtual DbSet<propertyValues> propertyValues { get; set; }
        public virtual DbSet<subscription> subscription { get; set; }
        public virtual DbSet<tbOrder> tbOrder { get; set; }
        public virtual DbSet<typeOfSubscription> typeOfSubscription { get; set; }
    }
}
