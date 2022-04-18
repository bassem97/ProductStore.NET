using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BJ.Domain;
using BJ.Data;
using ServicePattern;
using BJ.Data.Infrastructure;

namespace BJ.Service
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitofwork utwk) : base(utwk)
        {
        }
        public int NbProduct(Category category)
        {
            return GetById(category.CategoryId).Products.Count();
        }
    }
}
