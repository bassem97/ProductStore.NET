using ClassLibrary1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

public class ChemicalConfiguration : IEntityTypeConfiguration<Chemical>
{
    public void Configure(EntityTypeBuilder<Chemical> builder)
    {
        //throw new NotImplementedException();
        builder.OwnsOne(c => c.StreetAddress, p =>
        {
            // p.Property(p => p.City).HasColumnName("MyCity").HasMaxLength(50).IsRequired();
            // p.Property(p => p.StreetAdress).HasColumnName("MyAdress").HasMaxLength(50).IsRequired();
        });
    }
}