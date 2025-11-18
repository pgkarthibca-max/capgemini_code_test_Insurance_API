using App.Data;
using App.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.UOW
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly PremiumDbContext _context;
        private readonly ConcurrentDictionary<Type, object> _repos = new ConcurrentDictionary<Type, object>();

        public EfUnitOfWork(PremiumDbContext context)
        {
            _context = context;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            return (IRepository<T>)_repos.GetOrAdd(typeof(T), (t) => new EfRepository<T>(_context));
        }

        public int SaveChanges() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}