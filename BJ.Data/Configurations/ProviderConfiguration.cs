using BJ.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BJ.Data.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Fournisseur");
            builder.Property(p => p.Name).HasColumnName("UserName").HasMaxLength(20).IsRequired().HasDefaultValue("UserName");
            builder.HasKey(p => p.Id);
            builder.Ignore(p => p.ConfirmPassword);
        }
    }
}
