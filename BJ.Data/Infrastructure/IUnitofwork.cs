using System;
using System.Collections.Generic;
using System.Text;

namespace BJ.Data.Infrastructure
{
    public interface IUnitofwork : IDisposable
    {
        public void Commit();
        public IRepositoryBase<T> GetRepository<T>()where T: class;
    }
}
