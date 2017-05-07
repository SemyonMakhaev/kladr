using Kladr.Core.Services;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Kladr.Core.Repositories;

namespace Kladr.Services
{
    public class StreetsService : IStreetsService
    {
        private readonly IRepository<Street> _repository;

        public StreetsService(IRepository<Street> repository)
        {
            _repository = repository;
        }

        public void Add(Street street)
        {
            _repository.Add(street);
        }

        public int Count()
        {
            return _repository.Count();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IList<Street> GetAll()
        {
            return _repository.GetAll()
                .OrderBy(street => street.Name)
                .ToList();
        }

        public Street GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Street GetByName(string name)
        {
            return _repository.GetAll()
                .FirstOrDefault(street => street.Name == name);
        }

        public void Update(Street street)
        {
            _repository.SaveOrUpdate(street);
        }
    }
}
