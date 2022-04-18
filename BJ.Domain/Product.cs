using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BJ.Domain
{
    public class Product : Concept
    {
        public int ProductId { get; set; }

        [Display(Name ="Production date"),DataType(DataType.Date)]
        public DateTime DateProd { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [MaxLength(50,ErrorMessage ="Max 50 char")] //base
        [StringLength(25, ErrorMessage = "length is 25 char")] //interface
        
        public string Label { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public string Image { get; set; }

        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }

        public virtual Category Category { get; set; }
        public int? CategoryId { get; set; }
        public virtual IList<Provider> Providers { get; set; }

        public virtual IList<Facture> Factures { get; set; }
        public virtual IList<Client> Clients { get; set; }
        
        public PackagingType PackagingType { get; set; }

        public override string ToString()
        {
            return "Id : " + ProductId + ", Label : " + Label + ", Price : " + Price;
        }

        public void GetMyType()
        {
            Console.WriteLine("Product");
        }
        public virtual void GetMyType2()
        {
            Console.WriteLine("UNKNOWN");
        }

        public override void GetDetails()
        {
            Console.WriteLine("Description Produit " + ProductId + DateProd + Description + Label + Price);
        }
    }
}
