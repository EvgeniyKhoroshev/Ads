using Ads.Contracts.Dto;
using Domain.Entities;
using System.Threading.Tasks;

namespace AppServices.ServiceInterfaces
{
    public interface IInfoService
    {
        Task<AdvertsInfoDto> GetInfo();
    }
}