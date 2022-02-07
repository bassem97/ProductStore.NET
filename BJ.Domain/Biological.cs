namespace ClassLibrary1;

public class Biological : Product
{
    public string? Hchich { get; set; }
    
    public void getMyType()
    {
        Console.WriteLine("This is a bio product");
    }

    public override string ToString()
    {
        return $"{nameof(Hchich)}: {Hchich}";
    }
    
    public override void GetDetails()
    {
        Console.WriteLine(ToString());
    }
}