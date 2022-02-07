namespace ClassLibrary1;

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
}