using Domain;

namespace Kladr.Core.Services
{
    public interface ISettlementsService : IService<Settlement>
    {
        Settlement GetByName(string name);
    }
}
