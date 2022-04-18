using BJ.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BJ.Data.Configurations
{
    public class ChemicalConfiguration : IEntityTypeConfiguration<ChemicalProduct>
    {
        public void Configure(EntityTypeBuilder<ChemicalProduct> builder)
        {
            builder.OwnsOne(cp => cp.Adresse, p => {
                p.Property(p => p.City).HasColumnName("City").HasMaxLength(50).IsRequired();
                p.Property(p => p.StreetAdress).HasColumnName("Address").HasMaxLength(50).IsRequired();
            });
        }
    }
}
