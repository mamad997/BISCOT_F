﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace biscotDATAaccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class biscotir_dbEntities1 : DbContext
    {
        public biscotir_dbEntities1()
            : base("name=biscotir_dbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cartbl> Cartbls { get; set; }
        public virtual DbSet<Drivertbl> Drivertbls { get; set; }
        public virtual DbSet<Triptbl> Triptbls { get; set; }
        public virtual DbSet<usertbl> usertbls { get; set; }
        public virtual DbSet<View_report> View_report { get; set; }
        public virtual DbSet<View_car> View_car { get; set; }
    }
}