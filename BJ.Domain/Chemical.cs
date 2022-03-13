using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1;

// [Table("Chemical")]
[Table("Product")]

public class Chemical : Product
{
    public string? City { get; set; }
    public string? StreetAddress { get; set; }
    public string? LabName { get; set; }

    public void getMyType()
    {
        Console.WriteLine("This is a chemical product");
    }

    public override string ToString()
    {
        return $"{nameof(City)}: {City}, {nameof(StreetAddress)}: {StreetAddress}";
    }
    
    public override void GetDetails()
    {
        Console.WriteLine(ToString());
    }

    public Chemical()
    {
    }

    public Chemical(string? description, string? label, double? price, DateTime dateProd) 
    {
    }
}