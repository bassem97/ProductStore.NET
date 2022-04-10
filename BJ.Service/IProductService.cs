using BJ.domaine;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace BJ.Service
{
    public interface IProductService : IService<Product>
    {
        public IList<Product> FindMost5ExpensiveProds();
        public double UnavailableProductsPercentage();
        public IList<Product> GetProdsByClient(Client client)
        public void DeleteOldProducts();
    }
}
