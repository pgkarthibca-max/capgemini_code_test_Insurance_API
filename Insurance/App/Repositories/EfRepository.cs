using App.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace App.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        protected readonly PremiumDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public EfRepository(PremiumDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> Table => _dbSet;

        public T GetById(object id) => _dbSet.Find(id);

        public void Insert(T entity) => _dbSet.Add(entity);

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsEnumerable();
    }
}