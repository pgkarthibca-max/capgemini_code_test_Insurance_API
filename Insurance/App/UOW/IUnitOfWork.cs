using App.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        int SaveChanges();
    }
}