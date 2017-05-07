using Domain;

namespace Kladr.Core.Services
{
    public interface IStreetsService : IService<Street>
    {
        Street GetByName(string name);
    }
}
