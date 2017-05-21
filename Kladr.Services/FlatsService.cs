using Kladr.Core.Services;
using Kladr.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using Kladr.Domain;

namespace Kladr.Services
{
    public class FlatsService : IFlatsService
    {
        private readonly IRepository<Flat> _repository;

        public FlatsService(IRepository<Flat> repository)
        {
            _repository = repository;
        }

        public void Add(Flat flat)
        {
            _repository.Add(flat);
        }

        public int Count()
        {
            return _repository.Count();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IList<Flat> GetAll()
        {
            return _repository.GetAll()
                .OrderBy(flat => flat.Number)
                .ToList();
        }

        public Flat GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Flat flat)
        {
            _repository.SaveOrUpdate(flat);
        }
    }
}
