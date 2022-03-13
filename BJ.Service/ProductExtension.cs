using ClassLibrary1;

namespace BJ.Service;

public static class ProductExtension
{
    public static void UpperName(this ProductManage productManager)
    {
        productManager.Products.ToList()
            .ForEach(product => product.Label = product.Label?.ToUpper());
        // foreach (Product product in productManager.Products)
        // {
        //     product.Label = product.Label?.ToUpper();
        // }
    }
    
    public static bool InCategory(this ProductManage productManager, string category)
    {
        return productManager.Products.ToList()
            .Where(product => product.category.Name.ToUpper().Equals(category.ToUpper()))
            .ToList().Count != 0;
    }
}