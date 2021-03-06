using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1;

public class Client
{
    [Key]
    public int Cin { get; set; }

    public DateTime Birthdate { set; get; }

    public string Email { set; get; }

    public string Firstname { set; get; }

    public string Lastname { set; get; }

    public virtual IList<Bill> Bills{ set; get; }
    public virtual IList<Product> Products{ set; get; }
}