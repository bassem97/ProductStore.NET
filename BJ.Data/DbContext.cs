﻿using ClassLibrary1;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;
using PorductStore.NET.Models;

namespace Data;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext()
        {
           // Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<Biological> Biologicals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Client> Clients { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllodcaldb;Initial Catalog=GestionCompteDB;Integrated Security=true");
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=master;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            /* //not easy to maintain so why we need Configuration classes
            modelBuilder.Entity<Provider>().Property((p) => p.Nom).HasMaxLength(20).IsRequired().HasDefaultValue("Username");
            modelBuilder.Entity<Provider>().HasKey(p => p.Id);
            modelBuilder.Entity<Provider>().Ignore(p => p.ConfirmPassword);*/

            modelBuilder.ApplyConfiguration<Provider>(new ProviderConfiguration());
            modelBuilder.ApplyConfiguration<Product>(new ProductConfiguration());
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration<Chemical>(new ChemicalConfiguration());
            //modelBuilder.ApplyConfiguration<Bill>(new BillConfiguration());

            //TPT
            //.Entity<Product>().ToTable("Product");
            //modelBuilder.Entity<Biological>().ToTable("Biological");
            //modelBuilder.Entity<Chemical>().ToTable("Chemical");

            var properties = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties())
            .Where(p => p.ClrType == typeof(string) && p.Name.StartsWith("Label"));
            foreach (var p in properties)
            {
                p.SetColumnName("MyName");
            }


        }

}