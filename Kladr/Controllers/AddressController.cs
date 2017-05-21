using Kladr.Core.Services;
using System.Linq;
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
            var regions = _regionsService.GetAll().Select(region => region.Name);
            return Json(regions, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRegionSettlements(string regionName)
        {
            var settlements = _settlementsService.GetAll()
                .Where(settlement => settlement.RegionName == regionName)
                .Select(settlement => settlement.Name)
                .ToList();
            return Json(settlements, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSettlementStreets(string regionName, string settlementName)
        {
            var streets = _streetsService.GetAll()
                .Where(street => street.SettlementName == settlementName &&
                            street.RegionName == regionName)
                .Select(street => street.Name)
                .ToList();
            return Json(streets, JsonRequestBehavior.AllowGet);
        }

        public string GetIndex(string houseNumber, string streetName, string settlementName, string regionName)
        {
            var index = "";
            if (houseNumber == "undefined")
            {
                if (streetName == "undefined")
                {
                    if (settlementName == "undefined")
                    {
                        if (regionName != "undefined")
                        {
                            var obj = _regionsService.GetAll()
                                .FirstOrDefault(region => region.Name == regionName);
                            if (obj != null) index = obj.Index;
                        }
                    }
                    else
                    {
                        var obj = _settlementsService.GetAll()
                            .FirstOrDefault(settlement => settlement.Name == settlementName &&
                                        settlement.RegionName == regionName);
                        if (obj != null) index = obj.Index;
                    }
                }
                else
                {
                    var obj = _streetsService.GetAll()
                        .FirstOrDefault(street => street.Name == streetName &&
                                    street.SettlementName == settlementName &&
                                    street.RegionName == regionName);
                    if (obj != null) index = obj.Index;
                }
            }
            else
            {
                var obj = _housesService.GetAll()
                    .FirstOrDefault(house => house.Number == houseNumber &&
                            house.StreetName == streetName &&
                            house.SettlementName == settlementName &&
                            house.RegionName == regionName);
                if (obj != null) index = obj.Index;
            }
            return index;
        }
    }
}