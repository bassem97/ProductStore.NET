namespace ClassLibrary1;

public class Bill
{
    public DateTime Date { set; get; }

    public double Price { set; get; }

    public virtual Client Client { set; get; }

    // [ForeignKey("Client")]
    public int ClientFk { set; get; }

    // [ForeignKey("Product")]
    public int ProductFk { set; get; }

    public virtual Product Product { get; set; }
}