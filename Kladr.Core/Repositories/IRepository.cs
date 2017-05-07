﻿using System.Linq;

namespace Kladr.Core.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(int id);
        int Count();
        IQueryable<T> GetAll();
        T GetById(int id);
        void SaveOrUpdate(T entity);
    }
}
