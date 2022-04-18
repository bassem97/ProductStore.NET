using System;
using System.Collections.Generic;
using System.Text;

namespace BJ.Data.Infrastructure
{
    public class Unitofwork : IUnitofwork
    {
        private IDatabaseFactory DBF ;
        public Unitofwork(IDatabaseFactory DBF)
        {
            this.DBF = DBF;
        }
        
        public void Commit()
        {
            DBF.Context.SaveChanges();
        }

        public void Dispose()
        {
            DBF.Dispose();
        }

        public IRepositoryBase<T> GetRepository<T>() where T : class
        {
            return new RepositoryBase<T>(DBF);
        }
    }
}
