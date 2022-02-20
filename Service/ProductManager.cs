using ClassLibrary1;
using PorductStore.NET.Models;

namespace Service;

public delegate IList<Product> FindProduct(string lettre, List<Product> list);
public delegate IList<Product> ScanProducts(string categorie, List<Product> list);
public class ProductManage
{
    public ProductManage() { }
    public ProductManage(IList<Product> products)
    {
        Products = products;
    }

    public IList<Product> Products { get; set; }

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

    public IList<Product> Get5Chemical(double price)
    {
        return Products
            .Where(product => product.Price > price & product.GetType() == typeof(Chemical))
            .Take(5).ToList();
    }
    
    public IList<Product> GetProductPrice(double price)
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

   
    
}