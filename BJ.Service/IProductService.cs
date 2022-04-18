using BJ.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace BJ.Service
{
    public interface IProductService : IService<Product>
    {
        public IList<Product> MostExpensive();
        public double UnavailableProductsPercentage();

        public void DeleteOldProducts();
    }
}
