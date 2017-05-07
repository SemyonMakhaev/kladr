using Domain;
using Kladr.Core.Repositories;
using Kladr.Core.Services;
using Kladr.Services;
using Ninject;
using Ninject.Web.Common;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Kladr
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            base.OnApplicationStarted();
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IRepository<Region>>().To<Repository<Region>>();
            kernel.Bind<IRepository<Settlement>>().To<Repository<Settlement>>();
            kernel.Bind<IRepository<Street>>().To<Repository<Street>>();
            kernel.Bind<IRepository<House>>().To<Repository<House>>();
            kernel.Bind<IRepository<Flat>>().To<Repository<Flat>>();
            kernel.Bind<IRegionsService>().To<RegionsService>();
            kernel.Bind<ISettlementsService>().To<SettlementsService>();
            kernel.Bind<IStreetsService>().To<StreetsService>();
            kernel.Bind<IHousesService>().To<HousesService>();
            kernel.Bind<IFlatsService>().To<FlatsService>();
            return kernel;
        }
    }
}
