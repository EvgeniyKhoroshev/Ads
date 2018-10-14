using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IAdvertInfoRepository<T, Tid>
    {
        Task<AdvertsInfo> GetInfo();
    }
}
