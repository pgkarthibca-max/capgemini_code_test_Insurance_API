using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace App.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Table { get; }
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}