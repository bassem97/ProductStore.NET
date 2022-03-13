using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1;

// [Table("Biological")]
[Table("Product")]

public class Biological : Product
{
    public string? Herbs { get; set; }
    
    public void getMyType()
    {
        Console.WriteLine("This is a bio product");
    }

    public override string ToString()
    {
        return $"{nameof(Herbs)}: {Herbs}";
    }
    
    public override void GetDetails()
    {
        Console.WriteLine(ToString());
    }

    public Biological()
    {
    }

    public Biological(string? description, string? label, double? price, DateTime dateProd) 
    {
    }
}