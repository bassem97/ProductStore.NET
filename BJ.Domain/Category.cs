using ClassLibrary1;

namespace PorductStore.NET.Models;

public class Category : Concept
{
    public Category(int? productId, string name)
    {
        ProductId = productId;
        Name = name;
        Products = new List<Product>();
    }

    public Category(int? productId)
    {
        ProductId = productId;
        Products = new List<Product>();
    }

    public int? ProductId { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; }

}