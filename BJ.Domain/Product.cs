using PorductStore.NET.Models;

namespace ClassLibrary1;

public class Product : Concept
{
    public int? ProductId { get; set; }
    public string? Description { get; set; }
    public string?  Label { get; set; }
    public double? Price { get; set; }
    public int? Quantity { get; set; }
    public DateTime DateProd { get; set; }
    public Category Category { get; set; }
    
    public IList<Provider> Providers { get; set; }

    public Product(string? description, string? label, double? price, DateTime dateProd)
    {
        Description = description;
        Label = label;
        Price = price;
        DateProd = dateProd;
        ProductId++;

    }

    public Product()
    {
    }

    public void getMyType()
    {
        Console.WriteLine("This is a product");
    }

    public override void GetDetails()
    {
        Console.WriteLine("Description"+Description+" Product ID : "+ProductId);
    }

    public override string ToString()
    {
        return $"{nameof(ProductId)}: {ProductId} ,  {nameof(Description)}: {Description}, {nameof(Label)}: {Label},{nameof(DateProd)}: {DateProd} ";

    }
}