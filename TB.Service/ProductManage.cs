using BJ.Domain;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TB.Service
{
    
    public delegate bool Condition(Product p);
    public delegate List<Product> FindProduct(string c,List<Product>l);
    public delegate void ScanProduct(string cat);
    public class ProductManage
    {
        public Condition Condition { get; set; }
        public FindProduct FindProduct { get; set; }
        public ScanProduct ScanProduct { get; set; }
        public List<Product> Products { get; set; }

        public List<Product> ProductList(string c,FindProduct del)
        {
            return del(c, Products);
        }
       /* public List<Product> ProductList(string c, Func<string, List<Product>, List<Product>> FindProduct)
        {
            return FindProduct(c, Products);
        }*/

        public List<Product> Filter(string filter, string filterv)
        {
            List<Product> listpr = new List<Product>();
            foreach(var p in Products)
            {
                if (filter.ToUpper()  == "DESCRIPTION")
                {
                    if (filterv == p.Description)
                    {
                        listpr.Add(p);
                    }
                }
                if (filter.ToUpper()  == "PRICE")
                {
                    Double.TryParse(filterv, out var price);
                    if (price == p.Price)
                    {
                        listpr.Add(p);
                    }
                }
                if (filter.ToUpper()  == "DATE")
                {
                    DateTime.TryParse(filterv, out var dateTime);
                    if (dateTime == p.DateProd)
                    {
                        listpr.Add(p);
                    }
                }
            }
            return listpr;
        }
        public List<Product> Filter2(Func<Product, bool> c)//Condition c
        {
            List<Product> listpr = new List<Product>();
            foreach (var item in Products)
            {
                if(c(item)== true)
                {
                    listpr.Add(item);
                }
            }
            return listpr;
        }

        public List<ChemicalProduct> Get5Chemical(double price)
        {
            return (from p in Products.OfType<ChemicalProduct>()
                    where p.Price > price
                    select p
                    ).Take(5).ToList();
        }

        public List<Product> GetProductPrice(double price)
        {
            return (from p in Products
                    where p.Price > price
                    select p).Skip(2).ToList();
        }

        public double GetAverage()
        {
            return (Products.Average(p => p.Price));
        }

        public Product GetMaxPrice()
        {
            return (
                Products.OrderByDescending(p => p.Price).First()
                );
        }

        public int GetCountProduct(string city)
        {
            return (
                Products.OfType<ChemicalProduct>().Count(p => p.Adresse.City.Equals(city)));
        }

        public List<ChemicalProduct> GetChemicalCity()
        {
            return (Products.OfType<ChemicalProduct>().OrderBy(p => p.Adresse.City).ToList());
        }

        public List<IGrouping<string,ChemicalProduct>> GetChemicalGroupByCity()
        {
            // return (Products.OfType<ChemicalProduct>().OrderBy(p => p.City).GroupBy(p => p.City).ToList());

            var query = (from p in Products.OfType<ChemicalProduct>()
                    orderby p.Adresse.City
                    group p by p.Adresse.City).ToList();

            foreach (var grp in query)
            {
                Console.WriteLine(grp.Key);
                foreach (var item in grp)
                {
                    Console.WriteLine(item);
                }
            }
            return query;
        }

    }
}
