using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1;

public class Address
{
    
    [Owned]
    public class Adress
    {
        public string City { get; set; }
        public string StreetAdress { get; set; }
        
    }
}