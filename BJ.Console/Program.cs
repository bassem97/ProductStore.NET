using BJ.Data;
using BJ.Domain;
using System;
using System.Collections.Generic;
using TB.Service;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using BJ.Service;
using BJ.Data.Infrastructure;

namespace MAConsole
{
    
    class Program
    {
        
        public static IList<Product> findmain(Product product)
        {
            Console.WriteLine("test delegate");
            return null;
        }
        public static List<Product> findp(string c, List<Product> liste)
        {
            List<Product> listp = new List<Product>();
            foreach (var item in liste)
            {
                if (item.Label.StartsWith(c))
                {
                    listp.Add(item);
                }
            }
            return listp;
        }
        static void Main(string[] args)
        {


            /*int[] tab = new int[10];
            int[,] mat = new int[2,3];
            int[,,] matCube = new int[2,3,3];
            int[][] tab2 = new int[10][];*/
            Provider p = new Provider();
            p.Id = 1;
            p.Name = "med";
            p.Email = "med@email";
            p.Password = "aaaiii";
            p.ConfirmPassword = "aaaiii";
           /* System.Console.WriteLine(p.Password);
            System.Console.WriteLine(p.Id);
            System.Console.WriteLine(p.ToString());
            System.Console.WriteLine(p.login("med", "aaaiii"));

            System.Console.WriteLine(p.login("med", "aaaiii", "med@email"));
            System.Console.WriteLine(p.loginFusion("med", "aaaiii", "med@email"));
            System.Console.WriteLine(p.loginFusion("med", "aaaiii"));
            Provider p2 = new Provider();
            p2.Password = "aaaaa";
            System.Console.WriteLine(Provider.nb);
            Provider.setIsApproved(p);
            Provider.setIsApproved(p2);
            System.Console.WriteLine(p.IsApproved);
            System.Console.WriteLine(p2.IsApproved);

            bool isapp;
            Provider.setIsApproved(p.ConfirmPassword, p.Password, out isapp);
            System.Console.WriteLine(isapp);
            Provider.setIsApproved(p2.ConfirmPassword, p2.Password, out isapp);
            System.Console.WriteLine(isapp);*/

            Product pr = new Product();
            ChemicalProduct cp = new ChemicalProduct();
            BiologicalProduct bp = new BiologicalProduct();
            pr.GetMyType();
            cp.GetMyType();
            bp.GetMyType();


            Product pr2 = new Product();
            Product cp2 = new ChemicalProduct();
            Product bp2 = new BiologicalProduct();

            pr2.GetMyType();
            cp2.GetMyType();
            bp2.GetMyType();


            pr2.GetMyType2();
            cp2.GetMyType2();
            bp2.GetMyType2();
            pr.GetDetails();
            cp.GetDetails();
            bp.GetDetails();

            cp2.Price = 33.5;

            /*string product = ""; 
            var product2 = "";
            double price;
            var price2 = 0d;
            int? number = null;

            InputProduct(ref product);
            InputPrice(out price);
            Display(product, price,20);


            InputProduct(ref product2);
            InputPrice(out price2);
            Display(product2, price2);*/
            p.Products.Add(pr);
            cp2.ProductId = 1;
            cp2.Price = 33.5;
            p.Products.Add(cp2);
            double x = 33.5;

            
            foreach (var product in p.GetProducts("PRICE", x.ToString()))
            {
                Console.WriteLine("pppppppp " + product);
            }


           /* p.find = findmain;
            p.find(pr2);
            p.find = delegate (Product product)
            {
                Console.WriteLine("test delegate fonction anonyme");
                return null;
            };
            p.find(pr);

            p.find = (Product p) =>
            {
                Console.WriteLine("test delegate lambda");
                return null;
            };
            p.find(pr);
            */




            Category cat = new Category()
            {
                Name = "cat1"
            };
            Category cat2 = new Category()
            {
                Name = "cat2"
            };


            Product pp = new Product()
            {
               // ProductId = 1,
                Label = "prodPP",
                Description = "description",
                Quantity = 12,
                Category = cat2,
                Price = 10,

            };

            List<Product> lp = new List<Product>()
            {
                new Product()
                {
                     //ProductId = 2,
                     Description = "description1",
                     Label = "prod",
                     Quantity = 12,
                     Category = cat,
                     Price = 10,
                },
                pp
            };
            

             ProductManage pm = new ProductManage();
             pm.Products = lp;
             //pm.FindProduct = findp;
             //pm.FindProduct("p", lp);
            // pm.ProductList("p",findp);
             List<Product> listpr = pm.ProductList("p", (string c, List<Product> list) =>
             {
                 List<Product> listp = new List<Product>();
                 foreach (var item in list)
                 {
                     if (item.Label.StartsWith(c))
                     {
                         listp.Add(item);
                     }
                 }
                 return listp;
             });

            foreach (var item in listpr)
            {
                Console.WriteLine("aaaaaaaaaaaa" + item.ToString());
            }
           

            pm.ScanProduct = (categ) =>
            {
                foreach (var p in pm.Products)
                {
                    if (p.Category.Name.Equals(categ))
                    {
                        Console.WriteLine("les produits de la categorie " + categ + " : "+ p.ToString());
                    }
                }
            };
            pm.ScanProduct("cat2");


           
            foreach (var item in pm.Filter("description", "description1"))
            {
                Console.WriteLine("test filter " + item.ToString());
            }

            pm.UpperName();
            foreach (var item in pm.Products)
            {
                Console.WriteLine(item.Label);

            }
            Console.WriteLine(pm.InCategory("cat1"));

            PSContext context = new PSContext();
            /*context.Products.Add(pp);
            context.SaveChanges();*/
            foreach (var item in context.Products.ToList())
            {
                Console.WriteLine("Label : " + item.Label);
                Console.WriteLine("Category : " + item.Category.Name);
            }


            Console.WriteLine("Injection de dépendances");

            var serviceCollection = new ServiceCollection();           

            serviceCollection.AddSingleton<IProductService, ProductService>();
            serviceCollection.AddSingleton<IUnitofwork, Unitofwork>();
            serviceCollection.AddSingleton<IDatabaseFactory, DatabaseFactory>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var productService = serviceProvider.GetService<IProductService>();

            productService.GetMany().ToList().ForEach(e =>
            {
                Console.WriteLine(e);
            });


        }

        //------------------END MAIN----------- 
        public static void InputProduct(ref string product)
        {
            while (product == "")
            {
                Console.WriteLine("Nom du produit :");
                product = Console.ReadLine();
            }
        }

        public static void InputPrice(out double price)
        {
            price = 0;
            while (price <= 0)
            {
                try
                {
                    Console.WriteLine("Prix du produit :");
                    price = Double.Parse(Console.ReadLine());

                    if (price < 0)
                    {
                        Console.WriteLine("prix positive");
                    }
                }
                catch
                {
                    Console.WriteLine("price  has to int");
                }

            }
        }

        public static void Display(string product, double price, int quantitiy = 0)
        {
            Console.WriteLine("Product : " + product);
            Console.WriteLine("Price : " + price);
            Console.WriteLine("qt : " + quantitiy);
        }


    }
}
