using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //builder.ToTable("Product");
            builder.HasOne(p => p.category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.SetNull); //.Cascade
            builder.HasDiscriminator<int>("type").HasValue<Product>(0).HasValue<Biological>(1).HasValue<Chemical>(2);
            builder.HasMany(p => p.Clients).WithMany(p => p.Products)
                .UsingEntity<Bill>(
                    b=>b.HasOne(b=>b.Client).WithMany(b=>b.Bills).HasForeignKey(b=>b.ClientFk),
                    b=>b.HasOne(b=>b.Product).WithMany(b=>b.Bills).HasForeignKey(b => b.ProductFk),
                    b=>b.HasKey(b=> new { b.ProductFk,b.ClientFk,b.Date })
                );
            
        }
    }
}