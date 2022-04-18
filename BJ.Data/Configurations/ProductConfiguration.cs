using BJ.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BJ.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(p => p.Providers).WithMany(pr => pr.Products).UsingEntity(p => p.ToTable("Providings"));
            //builder.HasDiscriminator<int>("Type").HasValue<Product>(0).HasValue<ChemicalProduct>(1).HasValue<BiologicalProduct>(2);

            builder.HasMany(p => p.Clients).WithMany(cl => cl.Products).UsingEntity<Facture>(f => f.HasOne(f => f.Client)
            .WithMany(f => f.Factures).HasForeignKey(f => f.ClientFK),
            f => f.HasOne(f => f.Product).WithMany(f => f.Factures).HasForeignKey(f => f.ProductFK),
            f => f.HasKey(f => new { f.ProductFK, f.ClientFK, f.DateAchat })
            );



        }
    }
}
