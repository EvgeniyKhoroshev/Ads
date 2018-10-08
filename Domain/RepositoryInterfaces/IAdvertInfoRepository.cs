using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IAdvertInfoRepository : Base.IRepositoryBase<AdvertsInfo, int>
    {
        new Task<AdvertsInfo> GetInfo();
    }
}
