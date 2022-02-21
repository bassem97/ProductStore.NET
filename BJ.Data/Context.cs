using ClassLibrary1;
using Microsoft.EntityFrameworkCore;
using PorductStore.NET.Models;

namespace Data;

public class Context : DbContext
{
     DbSet<Product> Products { get; set; }
     DbSet<Provider> Providers { get; set; }
     DbSet<Chemical> Chemicals { get; set; }
     DbSet<Biological> Biologicals { get; set; }
     DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"data source = (localdb)\MSSQLlocalDB;initial catalog=ProductStore;Integrated Security = True;");
        base.OnConfiguring(optionsBuilder);
    }
    
}