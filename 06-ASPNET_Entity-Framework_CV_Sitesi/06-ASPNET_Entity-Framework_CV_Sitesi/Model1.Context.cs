﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _06_CvEntityProje
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Dbo_CvEntityEntities : DbContext
    {
        public Dbo_CvEntityEntities()
            : base("name=Dbo_CvEntityEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBLADRES> TBLADRES { get; set; }
        public virtual DbSet<TBLCALISMALARIM> TBLCALISMALARIM { get; set; }
        public virtual DbSet<TBLHAKKIMDA> TBLHAKKIMDA { get; set; }
        public virtual DbSet<TBLILETISIM> TBLILETISIM { get; set; }
        public virtual DbSet<TBLYETENEKLER> TBLYETENEKLER { get; set; }
    }
}
