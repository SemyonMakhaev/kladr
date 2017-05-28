using Kladr.Domain;
using System.Linq;

namespace Kladr.Core.Services
{
    public interface IService<T> where T : Entity
    {
        void Add(T entity);
        void Delete(int id);
        int Count();
        IQueryable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
    }
}
