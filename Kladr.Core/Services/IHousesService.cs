using Domain;

namespace Kladr.Core.Services
{
    public interface IHousesService : IService<House>
    {
        House GetByNumber(string number);
    }
}
