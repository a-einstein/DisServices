﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RCS.DIS.DataServices
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DbcOverzicht> DbcOverzichts { get; set; }
        public virtual DbSet<DbcProfiel> DbcProfiels { get; set; }
        public virtual DbSet<Diagnose> Diagnoses { get; set; }
        public virtual DbSet<Specialisme> Specialismes { get; set; }
        public virtual DbSet<Zorgactiviteit> Zorgactiviteits { get; set; }
        public virtual DbSet<Zorgproduct> Zorgproducts { get; set; }
        public virtual DbSet<Zorgprofielklasse> Zorgprofielklasses { get; set; }
    }
}