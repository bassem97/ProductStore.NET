using BJ.Data;
using BJ.domaine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BJ.Data.Infrastructure;
using ServicePattern;

namespace BJ.Service
{
    public class ProductService : Service<Product>, IProductService
    {
        public void DeleteOldProducts()
        {
            GetMany(p => (DateTime.Now - p.DateProd).TotalDays > 365).ToList().ForEach(e =>
            {
                Delete(e);
            });
            Commit();
        }

        public IList<Product> FindMost5ExpensiveProds()
        {
            return GetMany().OrderByDescending(p => p.Price).Take(5).ToList();
        }

        public IList<Product> GetProdsByClient(Client client)
        {
            return GetMany(product =>  product.Clients.Contains(client);
        }

        public double UnavailableProductsPercentage()
        {
            return (GetMany(p => p.Quantity == 0).Count() / (double)GetMany().Count()) * 100;
        }
    }
}
