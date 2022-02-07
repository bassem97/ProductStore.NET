// See https://aka.ms/new-console-template for more information

using System.Collections.ObjectModel;
using ClassLibrary1;
using PorductStore.NET.Models;

namespace AS.Console{
     public class Program{
        public static void InputProduct(ref string product){
            while (product == ""){
                System.Console.Write("Please type in your product name: ");
                product = System.Console.ReadLine() ?? "";
            }
        }

        public static void InputPrice(out double price){
            price = 0;
            
            while (price <= 0)
            {
                try
                {
                    System.Console.Write("Please type in your product price: ");
                    price = Double.Parse(System.Console.ReadLine());

                    if (price <= 0)
                        System.Console.WriteLine("Price has to be greater than 0.");
                }
                catch
                {
                    System.Console.WriteLine("Product has to be numerical.");
                }

            }
        }

        public static void Output(string product, double price, int qnt = 0){
            System.Console.WriteLine("Product name: " + product);
            System.Console.WriteLine("Product price: " + price);
            
            if(qnt != 0)
                System.Console.WriteLine("Quantity: " + qnt);
        }

        public static void Main(string[] args){
            Provider bassem = new Provider("Bassem","123456","123456","bassem.jadoui@esprit.tn");

            // System.Console.WriteLine(bassem.Login("Bassem", "123456"));
            // System.Console.WriteLine(bassem.Login("Bassem", "123456","bassem.jadoui@esprit.tn"));

    
            bool? isApproved = false;
            Provider.SetIsApproved(bassem, out isApproved);
            // System.Console.WriteLine(product);

        
            // Product product = new Product("description","label",15, new DateTime(2019,12,12));
            Product product = new Product() {
                Description = "description1",
                Label = "label",
                Price = 15,
                DateProd = new DateTime(2019, 12, 12),
                Quantity = 12
            };

            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Description = "description2",
                    Label = "label",
                    Price = 15,
                    DateProd = new DateTime(2019, 12, 12),
                    Quantity = 12

                },
                new() {
                    Description = "description6",
                    Label = "label3",
                }
            };

            // int[,] tab = new int[10,10];
            // int[,,] tab = new int[10,10,10];
            int[][] tab = new int[3][];
           
            

            // Chemical chemicalProduct = new Chemical();
            // Biological biologicalProduct = new Biological();
            
            // product.getMyType();
            // chemicalProduct.getMyType();
            // biologicalProduct.getMyType();
            
            // bassem.Products.Add(product);

            // System.Console.WriteLine(product);
            
            foreach (var product1 in bassem.GetProducts("DATEPROD","12/12/2019"))
            {
                System.Console.WriteLine(product1);
            }

            bassem.Find = product =>
            {
                System.Console.WriteLine("this is findName" + product.Price);
                return null;
            };
            bassem.Find(product);
        }
        // public static IList<Product> FindClient(Product product)
        // {
        //     System.Console.WriteLine("this is findName"+product.Price);
        //     return null;
        // }
    }
}