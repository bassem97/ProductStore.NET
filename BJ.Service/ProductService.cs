using BJ.Data;
using BJ.Domain;
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
        public ProductService(IUnitofwork utwk) : base (utwk)
        {
        }
        public void DeleteOldProducts()
        {
            GetMany(p => (DateTime.Now - p.DateProd).TotalDays > 365).ToList().ForEach(e =>
            {
                Delete(e);
            });
            Commit();
        }

        public IList<Product> MostExpensive()
        {
            return GetMany().OrderByDescending(p => p.Price).Take(5).ToList();
        }

        public double UnavailableProductsPercentage()
        {
            return (GetMany(p => p.Quantity == 0).Count() / (double)GetMany().Count()) * 100;
        }
    }
}
