using Kladr.Domain;
using Kladr.Core.Repositories;
using Kladr.Core.Services;
using System.Linq;

namespace Kladr.Services
{
    public class RegionsService : IRegionsService
    {
        private readonly IRepository<Region> _repository;

        public RegionsService(IRepository<Region> repository)
        {
            _repository = repository;
        }

        public void Add(Region region)
        {
            _repository.Add(region);
        }

        public int Count()
        {
            return _repository.Count();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IQueryable<Region> GetAll()
        {
            return _repository.GetAll()
                .OrderBy(region => region.Name);
        }

        public Region GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Region region)
        {
            _repository.SaveOrUpdate(region);
        }
    }
}
