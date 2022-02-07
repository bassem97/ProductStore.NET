using ClassLibrary1;

namespace PorductStore.NET.Models;

public class Category : Concept
{
    public Category(int? productId, string name)
    {
        ProductId = productId;
        Name = name;
    }
    public Category(int? productId)
    {
        ProductId = productId;
    }
    public int? ProductId { get; set; }
    public string Name { get; set; }
    public IList<Product> Products { get; set; }
    public override void GetDetails()
    {
        
        throw new NotImplementedException();
    }
}