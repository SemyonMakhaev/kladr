using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kladr.Services;
using Moq;
using Domain;
using Kladr.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Kladr.Tests.Services
{
    [TestClass]
    public class RegionsServiceTests
    {
        private RegionsService _regionsService;
        private Mock<IRepository<Region>> _mock;

        [TestInitialize]
        public void RegionsServiceTestsInitialize()
        {
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = 1,
                    Name = "Гватемала",
                    Settlements = new List<Settlement>()
                    {
                        new Settlement()
                        {
                            Id = 1,
                            Name = "Умба-Юмба"
                        }
                    }
                },
                new Region()
                {
                    Id = 2,
                    Name = "Гондурас",
                    Settlements = new List<Settlement>()
                    {
                        new Settlement()
                        {
                            Id = 2,
                            Name = "Нью-Хемшир"
                        }
                    }
                }
            };

            _mock = new Mock<IRepository<Region>>();
            _mock.Setup(m => m.Add(It.IsAny<Region>())).Callback<Region>(regions.Add);
            _mock.Setup(m => m.Count()).Returns(regions.Count);
            _mock.Setup(m => m.Delete(It.IsAny<int>()))
                .Callback<int>(id =>
                {
                    var region = regions.Find(item => item.Id == id);
                    regions.Remove(region);
                });
            _mock.Setup(m => m.GetAll()).Returns(regions.AsQueryable());
            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns<int>(id => regions.Find(item => item.Id == id));
            // TODO
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
