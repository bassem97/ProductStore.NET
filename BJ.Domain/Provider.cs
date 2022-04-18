using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BJ.Domain
{
    public delegate IList<Product> Find (Product product);
    public class Provider : Concept
    {

       // public Find find { get; set; }
        public static int nb = 0;
        private string password;
        private string confirmPassword;
        public virtual IList<Product> Products { get; set; }
        [Key]
        public int Id { get; set;}
        public string Name { get; set; }

        [DataType(DataType.Password), Required, MinLength(8)]
        public string Password { get { return password; }  
            set
            {
                if (value.Length < 5 || value.Length > 20)
                {
                    System.Console.WriteLine("between 5 and 20");
                }
                else
                {
                    password = value;
                }
            }
        }
        [Required,Compare("Password"),DataType(DataType.Password),NotMapped]
        public string ConfirmPassword { get { return confirmPassword; }
            set { 
                    if (value == Password)
                    {
                        confirmPassword = value;
                    }
                    else
                    {
                        System.Console.WriteLine("must be identical");
                    }
            } 
        }
        [EmailAddress,Required]
        public string Email { get; set; }
        public bool IsApproved { get; set; }

        public Provider()
        {
            nb++;
            Products = new List<Product>();
        }

        public override string ToString()
        {
            return Id + " " + Name + " ";
        }

        public bool login (string name, string password)
        {
            return (Name == name && this.password == password);
        }

        public bool login(string name, string password,string email)
        {
            return (Name == name && this.password == password && email == Email);
        }

        public bool loginFusion(string name, string password, string? email = null)
        {
            if (email != null)
            {
                return (Name == name && this.password == password && email == Email);
            }
            else
            {
                return (Name == name && this.password == password);
            }
        }

        public static void setIsApproved(Provider provider)
        {
            provider.IsApproved = provider.Password == provider.ConfirmPassword;            
        }

        public static void setIsApproved(string confirmPassword, string password, out bool isApproved)
        {
            isApproved = confirmPassword == password;
        }

        public override void GetDetails()
        {
            foreach(var product in Products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        public IEnumerable<Product> GetProducts(string filterType, string filterValue)
        {
            foreach(var product in Products)
            {
                if (filterType.ToUpper() == "DESCRIPTION")
                {
                    if (filterValue == product.Description)
                    {
                        yield return product;
                    }
                }
                switch (filterType.ToUpper())
                {
                    case "DESCRIPTION":
                        if (filterValue == product.Description)
                        {
                            yield return product;

                        }
                        break;
                    case "DATEPROD":
                        DateTime.TryParse(filterValue, out var dateTime);
                        if(dateTime == product.DateProd)
                        {
                            yield return product;
                        }
                        break;
                    case "PRICE":
                        Double.TryParse(filterValue, out var price);
                        if (price == product.Price)
                        {
                            yield return product;
                        }
                        break;
                }
            }
        }
    }
}
