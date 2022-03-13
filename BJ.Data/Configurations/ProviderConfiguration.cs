
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1;

namespace Data.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)        {
            builder.Property((p) => p.UserName).HasMaxLength(20).IsRequired().HasDefaultValue("Username").HasColumnName("Name");
            builder.HasKey(p => p.Id);
            builder.Ignore(p => p.ConfirmPassword);
            builder.ToTable("Provider");
            builder.HasMany(p => p.Products).WithMany(p => p.providers).UsingEntity(p => p.ToTable("Providings"));

        }
    }
}
