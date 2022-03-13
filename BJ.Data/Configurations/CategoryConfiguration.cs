using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1;
using PorductStore.NET.Models;

namespace Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //builder.ToTable("Category");
            builder.HasKey(c => c.CategoryId);
            builder.Property((c) => c.Name).HasMaxLength(50).IsRequired();
            builder.HasMany<Product>(c=>c.Products).WithOne(p=>p.category).HasForeignKey(p=>p.CategoryId);
        }
    }
}
