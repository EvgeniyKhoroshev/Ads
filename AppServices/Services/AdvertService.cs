using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;

namespace AppServices.Services
{
    public class AdvertService : Base.BaseService<AdvertDto, int> , IAdvertService
    {
        public override AdvertDto Get(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
