using ClassLibrary1;

namespace PorductStore.NET.Models;

public class Category : Concept
{
    public Category()
    {
    }

    public Category(int? categoryId, string name)
    {
        CategoryId = categoryId;
        Name = name;
    }
    public Category(int? categoryId)
    {
        CategoryId = categoryId;
    }
    public int? CategoryId { get; set; }
    public string Name { get; set; }
    public IList<Product> Products { get; set; }
    public override void GetDetails()
    {
        
        throw new NotImplementedException();
    }
}