using BJ.domaine;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace BJ.Service
{
    public interface ICategoryService : IService<Category>
    {
        public int NbProduct(Category category);
    }
}
