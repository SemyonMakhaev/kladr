using System.Collections.Generic;
using Domain;

namespace Kladr.Core.Services
{
    public interface IService<T> where T : Entity
    {
        void Add(T entity);
        void Delete(int id);
        int Count();
        IList<T> GetAll();
        T GetById(int id);
        void Update(T entity);
    }
}
