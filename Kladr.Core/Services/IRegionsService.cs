using Domain;

namespace Kladr.Core.Services
{
    public interface IRegionsService : IService<Region>
    {
        Region GetByName(string name);
    }
}
