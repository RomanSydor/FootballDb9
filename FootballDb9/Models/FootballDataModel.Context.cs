﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootballDb9.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class lab2dbEntities : DbContext
    {
        public lab2dbEntities()
            : base("name=lab2dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<clubs> clubs { get; set; }
        public DbSet<gameschedule> gameschedule { get; set; }
        public DbSet<players> players { get; set; }
        public DbSet<stadiums> stadiums { get; set; }
    }
}
