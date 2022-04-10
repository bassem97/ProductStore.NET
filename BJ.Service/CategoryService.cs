using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MA.domaine;
using MA.Data;
using ServicePattern;

namespace BJ.Service
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public int NbProduct(Category category)
        {
            return GetById(category.CategoryId).Products.Count();
        }
    }
}
