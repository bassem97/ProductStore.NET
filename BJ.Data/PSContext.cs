using BJ.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BJ.Data.Configurations;

namespace BJ.Data
{
    public class PSContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ChemicalProduct> ChemicalProducts { get; set; }
        public DbSet<BiologicalProduct> BiologicalProducts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Facture> Factures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"data source=(localdb)\MSSQLlocalDB; Initial catalog=ProductStore; Integrated Security = True;").UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ChemicalConfiguration());
            //modelBuilder.ApplyConfiguration(new FactureConfiguration());
            /* modelBuilder.Entity<Product>().ToTable("Product");
              modelBuilder.Entity<ChemicalProduct>().ToTable("ChemicalProduct");
              modelBuilder.Entity<BiologicalProduct>().ToTable("BiologicalProduct");*/
            var properties = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties())
                .Where(p => p.ClrType == typeof(string) && p.Name.StartsWith("Name"));
            foreach (var item in properties)
            {
                item.SetColumnName("Category_name");
            }
        }
    }
}
