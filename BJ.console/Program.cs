// See https://aka.ms/new-console-template for more information

using System.Collections.ObjectModel;
using ClassLibrary1;
using PorductStore.NET.Models;
using BJ.Service;
using Data;


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
        
        public static IList<Product> FindProductFN(string l, List<Product> list)
        {
            return list.Where(product => product.Label.StartsWith(l))
                .ToList();
        }
        public static IList<Product> ScanProductCat(string cat, List<Product> list)
        {
            return list.Where(product => product.category.Name == cat)
                .ToList();
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
                Label = "label1",
                Price = 15,
                DateProd = new DateTime(2019, 12, 12),
                Quantity = 12,
                category = new Category()
                {
                    Name = "Laitiers"
                }
            };

            List<Product?> products = DataTest.Products;
            List<Provider> providers = DataTest.Providers;
            List<Category> categories = DataTest.Categories;
            

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

            // bassem.Find = product =>
            // {
            //     System.Console.WriteLine("this is findName" + product.Price);
            //     return null;
            // };
            // bassem.Find(product);
            ProductManage productManager = new ProductManage();
            
            // 14/02/2022 Session
            

            productManager.Products = products;
            productManager.FindProduct = FindProductFN;
            productManager.ScanProducts = ScanProductCat;
            System.Console.WriteLine("Test Methode FindProduct");
            
            /// Simple list parameter
            productManager.FindProduct("AC", products)
                .ToList()
                .ForEach(product => System.Console.WriteLine(product.Label));
            
            // Passing funciton body to parameter (anonyme methode)
            productManager.FindProductByFirstChar("l",FindProductFN)
                .ToList()
                .ForEach(product => System.Console.WriteLine(product.Label));
           
            // Passing lambda-expression  to parameter
            productManager.FindProductByFirstChar("l", ((letter, list) =>
                {
                    return list.Where(product => product.Label.StartsWith(letter))
                        .ToList();
                }))
                .ToList().ForEach(product => System.Console.WriteLine(product.Label));

            
            // Passing funciton body to parameter (anonyme methode)
            System.Console.WriteLine("ScanProducts test methode");
            productManager.ScanProductByCat("Fruit", ScanProductCat)
                .ToList()
                .ForEach(product => System.Console.WriteLine(product.Label));
            
            System.Console.WriteLine("UpperName test methode");
            productManager.UpperName();
            products.ToList().ForEach(produ => System.Console.WriteLine(produ.Label));
            
            System.Console.WriteLine("InCategory test methode");
            System.Console.WriteLine(productManager.InCategory("Alimentaire"));
            
            // question 13 
            ProviderManage providerManager = new ProviderManage();
            providerManager.Providers = providers;
            
            // Get provider by name
            providerManager.GetProviderByName("SUDMEDICAL").ToList()
                .ForEach(provider => System.Console.WriteLine(provider));
            
            // Get first   provider by name
            System.Console.WriteLine(providerManager.GetFirstProviderByName("SUDMEDICAL"));
           
             
            
            // GEt provider by ID
            System.Console.WriteLine(providerManager.GetProviderById(4));


            // question 14
            //a
            productManager.Get5Chemical(50).ToList()
                .ForEach(product => System.Console.WriteLine(product));
            //b
            productManager.GetProductPrice(50).ToList()
                .ForEach(product => System.Console.WriteLine(product));
            //c
            System.Console.WriteLine(productManager.GetAveragePrice());
            //d
            System.Console.WriteLine(productManager.GetMaxPrice());
            //e
            System.Console.WriteLine(productManager.GetCountProduct("tunis"));
            //f
            productManager.GetChemicalCity().ToList()
                .ForEach(product => System.Console.WriteLine(product));
            // g
            System.Console.WriteLine("groupe by city");
            productManager.GetChemicalGroupByCity().ToList()
                .ForEach(products => System.Console.WriteLine(product));

            DbContext context = new DbContext();
            // context.Database.EnsureCreated();
            context.SaveChanges();
            System.Console.ReadKey();


        }
        
        
        
     



   
      
     }
  
}