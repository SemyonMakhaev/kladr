﻿using Kladr.Domain;
using Kladr.Core.Repositories;
using Kladr.Core.Services;
using System.Linq;

namespace Kladr.Services
{
    public class SettlementsService : ISettlementsService
    {
        private readonly IRepository<Settlement> _repository;

        public SettlementsService(IRepository<Settlement> repository)
        {
            _repository = repository;
        }

        public void Add(Settlement entity)
        {
            _repository.Add(entity);
        }

        public int Count()
        {
            return _repository.Count();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IQueryable<Settlement> GetAll()
        {
            return _repository.GetAll()
                .OrderBy(settlement => settlement.Name);
        }

        public Settlement GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Settlement settlement)
        {
            _repository.SaveOrUpdate(settlement);
        }
    }
}
