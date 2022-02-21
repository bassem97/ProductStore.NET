using ClassLibrary1;
using PorductStore.NET.Models;

namespace Service;

public delegate IList<Product> FindProduct(string lettre, List<Product?> list);
public delegate IList<Product> ScanProducts(string categorie, List<Product?> list);
public class ProductManage
{
    public ProductManage() { }
    public ProductManage(IList<Product?> products)
    {
        Products = products;
    }

    public IList<Product?> Products { get; set; }

    public FindProduct FindProduct { set; get; }
    public ScanProducts ScanProducts { set; get; }
    public IList<Product> FindProductByFirstChar(string l,FindProduct CorpsFunc)
    {

        return CorpsFunc(l,Products.ToList());
             
    }
    public IList<Product> ScanProductByCat(string Cat, ScanProducts CorpsFunc)
    {

        return CorpsFunc(Cat, Products.ToList());

    }

    public IList<Product?> Get5Chemical(double price)
    {
        return Products
            .Where(product => product.Price > price & product.GetType() == typeof(Chemical))
            .Take(5).ToList();
    }
    
    public IList<Product?> GetProductPrice(double price)
    {
        return Products.Where(product => product.Price > price)
            .Skip(5).ToList();
    }
    
    public double GetAveragePrice()
    {
        return Products
            .Select(product => product.Price)
            .Average()!.Value;
    }
    
    public Product GetMaxPrice()
    {
        return Products
            .MaxBy(product => product.Price);
    }
    
    public int GetCountProduct(string city)
    {
        return Products
            .Where(product => product.GetType() == typeof(Chemical))
            .Count(product =>  ((Chemical)product).City.ToUpper().Equals(city.ToUpper()));
    }

    public IList<Product> GetChemicalCity()
    {
        return Products
            .Where(product => product.GetType() == typeof(Chemical))
            .OrderBy(product => ((Chemical)product).City)
            .ToList();
    }
    
    public List<List<Chemical>> GetChemicalGroupByCity()
    {
        return Products
            .OfType<Chemical>()
            .OrderBy(product => product.City)
            .GroupBy(product => product.City)
            .Select(groupe => groupe.ToList())
            .ToList();

        // .Select(groupe => groupe.ToList())
        // .ToList();

    }



}