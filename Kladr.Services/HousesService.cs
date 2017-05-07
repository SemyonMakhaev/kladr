using Kladr.Core.Services;
using System.Collections.Generic;
using System.Linq;
using Kladr.Core.Repositories;
using Domain;

namespace Kladr.Services
{
    public class HousesService : IHousesService
    {
        private readonly IRepository<House> _repository;

        public HousesService(IRepository<House> repository)
        {
            _repository = repository;
        }

        public void Add(House house)
        {
            _repository.Add(house);
        }

        public int Count()
        {
            return _repository.Count();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IList<House> GetAll()
        {
            return _repository.GetAll()
                .OrderBy(house => house.Number)
                .ToList();
        }

        public House GetById(int id)
        {
            return _repository.GetById(id);
        }

        public House GetByNumber(string number)
        {
            return _repository.GetAll()
                .FirstOrDefault(house => house.Number == number);
        }

        public void Update(House house)
        {
            _repository.SaveOrUpdate(house);
        }
    }
}
