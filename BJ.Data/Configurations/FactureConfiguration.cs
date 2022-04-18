using BJ.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BJ.Data.Configurations
{
    public class FactureConfiguration : IEntityTypeConfiguration<Facture>
    {
        public void Configure(EntityTypeBuilder<Facture> builder)
        {
           /* builder.HasKey(f => new { f.ClientFK, f.ProductFK, f.DateAchat });
            builder.HasOne(f => f.Product).WithMany(f => f.Factures).HasForeignKey(f => f.ProductFK);
            builder.HasOne(f => f.Client).WithMany(f => f.Factures).HasForeignKey(f => f.ClientFK);*/

        }
    }
}
