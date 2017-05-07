using Domain;

namespace Kladr.Core.Services
{
    public interface IFlatsService : IService<Flat>
    {
        Flat GetByNumber(string number);
    }
}
