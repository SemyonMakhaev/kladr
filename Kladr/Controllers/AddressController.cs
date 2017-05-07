using Kladr.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kladr.Controllers
{
    public class AddressController : Controller
    {
        private readonly IRegionsService _regionsService;
        private readonly ISettlementsService _settlementsService;
        private readonly IStreetsService _streetsService;
        private readonly IHousesService _housesService;
        private readonly IFlatsService _flatsService;

        public AddressController(IRegionsService regionsService,
            ISettlementsService settlementsService,
            IStreetsService streetsService,
            IHousesService housesService,
            IFlatsService flatsService)
        {
            _regionsService = regionsService;
            _settlementsService = settlementsService;
            _streetsService = streetsService;
            _housesService = housesService;
            _flatsService = flatsService;
        }

        public JsonResult GetRegions()
        {
            return Json(_regionsService.GetAll().Select(region => region.Name));
        }

        public IList<string> GetRegionSettlements(int regionId)
        {
            return _regionsService.GetById(regionId).Settlements
                .Select(settlement => settlement.Name)
                .ToList();
        }

        public IList<string> GetSettlementStreets(int settlementId)
        {
            return _settlementsService.GetById(settlementId).Streets
                .Select(street => street.Name)
                .ToList();
        }

        public IList<string> GetStreetHouses(int streetId)
        {
            return _streetsService.GetById(streetId).Houses
                .Select(house => house.Number)
                .ToList();
        }

        public IList<string> GetHouseFlats(int houseId)
        {
            return _housesService.GetById(houseId).Flats
                .Select(flat => flat.Number)
                .ToList();
        }
    }
}