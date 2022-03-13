using ClassLibrary1;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

public class BillConfiguration
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.HasKey(b => new { b.ClientFk, b.ProductFk, b.Date });
        builder.HasOne(b => b.Product).WithMany(b => b.Bills).HasForeignKey(b => b.ProductFk);
        builder.HasOne(b => b.Client).WithMany(b => b.Bills).HasForeignKey(b => b.ClientFk);
        //builder.HasMany(b => b.Product).WithMany(b => b.Client).UsingEntity(p => p.ToTable());

    }
}