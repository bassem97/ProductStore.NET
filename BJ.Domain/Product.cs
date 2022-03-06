using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PorductStore.NET.Models;

namespace ClassLibrary1;

[Table("Product")]
public class Product : Concept
{
    public int? ProductId { get; set; }
    
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }
    
    [Required(ErrorMessage ="Label is required")]
    [MaxLength(50, ErrorMessage ="Maxlength 50")] 
    [StringLength(25, ErrorMessage = "Maxlength 25")] 
    public string?  Label { get; set; }
    
    [DataType(DataType.Currency)]
    [Range(0,int.MaxValue)]
    public double? Price { get; set; }
    public int? Quantity { get; set; }
    
    [Display(Name ="Production Date"),DataType(DataType.DateTime)]
    public DateTime DateProd { get; set; }
    public Category Category { get; set; }
    
    public int? CategoryId { get; set; }
    
    public string Image { get; set; }
    
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