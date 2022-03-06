using ClassLibrary1;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;
using PorductStore.NET.Models;

namespace Data;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<Chemical> Chemicals { get; set; }

    public DbSet<Biological> Biologicals { get; set; }
    // public DbSet<Category> Categories { get; set; }

    public DbContext()
    {
        Database.EnsureCreated();
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Server=localhost\SQLEXPRESS01;Database=master;Trusted_Connection=True;
        // optionsBuilder.UseSqlServer(@"data source = (localdb)\MSSQLlocalDB;initial catalog=ProductStore;Integrated Security = True;");
        optionsBuilder.UseSqlServer(
            @"data source = (localdb)\MSSQLLocalDB;initial catalog=Productstore;Integrated Security = True;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(product =>
        {
            /* //not easy to maintain so why we need Configuration classes
           modelBuilder.Entity<Provider>().Property((p) => p.Nom).HasMaxLength(20).IsRequired().HasDefaultValue("Username");
           modelBuilder.Entity<Provider>().HasKey(p => p.Id);
           modelBuilder.Entity<Provider>().Ignore(p => p.ConfirmPassword);*/

            modelBuilder.ApplyConfiguration<Provider>(new ProviderConfiguration());
            modelBuilder.ApplyConfiguration<Product>(new ProductConfiguration());
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());

            modelBuilder.Entity<Product>().ToTable("Product");
            // modelBuilder.Entity<Biological>().ToTable("Biological");
            // modelBuilder.Entity<Chemical>().ToTable("Chemical");

        });

    }

}