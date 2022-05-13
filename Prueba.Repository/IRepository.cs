using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Prueba.Repository
{
    public interface IRepository<T> where T : class
    {
         IQueryable<T> GetAll();
         void Add(T entity);

        T GetById(int id);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate);
        IEnumerable<T> IncludesAll(string[] includes);
    }
}