using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace BJ.Data.Infrastructure
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        IDatabaseFactory DBF;

        DbSet<T> DBSet { get; set; }

        public RepositoryBase(IDatabaseFactory DBF)
            {
                DBSet = DBF.Context.Set<T>();
            }

        public void Add(T entity)
        {
            DBSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DBSet.Remove(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            var query = DBSet.Where(where);
            foreach (var item in query)
            {
                DBSet.Remove(item);
            }
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            var query = DBSet.Where(where);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return DBSet.ToList();
        }

        public T GetById(Object Id)
        {
            return DBSet.Find(Id);
        }

        public T GetById(string Id)
        {
            return DBSet.Find(Id);
        }

        

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null)
        {
            if(where != null)
            {
                return DBSet.Where(where);
                
            }
            else
            {
                return DBSet;
            }
        }

        public void Update(T entity)
        {
            DBSet.Attach(entity);
            DBF.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
