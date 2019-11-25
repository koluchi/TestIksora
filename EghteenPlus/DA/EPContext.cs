using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EghteenPlus.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EghteenPlus.DA
{
    public class EPContext: DbContext
    {
        public EPContext(): base("EPContext")
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(e => e.Number).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}