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
    
    public void getMyType()
    {
        Console.WriteLine("This is a product");
    }
}