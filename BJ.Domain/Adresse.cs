using Microsoft.EntityFrameworkCore;

namespace BJ.Domain
{
    [Owned]
    public class Adresse
    {
        public string City { get; set; }
        public string StreetAdress { get; set; }
    }
}