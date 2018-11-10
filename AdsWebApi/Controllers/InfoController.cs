using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Enabling cors for getting response directly from the UI
    [EnableCors("allow")]
    public class InfoController : ControllerBase
    {
        readonly IInfoService _infoService;
        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }
        [HttpGet("{id:int}/{regionId:int?}")]
        public async Task<object[]> GetInfo(int id, int? regionId)
        {
            switch(id)
            {
                // Getting categories
                case 1:
                    return await _infoService.GetCategoriesAsync();
                // Getting cities with optional regionId, if regionId!=null then returns
                // cities belongs to the <regionId> region
                case 2:
                    return await _infoService.GetCitiesAsync(regionId);
                // Getting advert statuses
                case 3:
                    return await _infoService.GetStatusesAsync();
                // Getting advert types
                case 4:
                    return await _infoService.GetTypesAsync();
                // Getting regions
                case 5:
                    return await _infoService.GetRegionsAsync();
                default:
                    return null;
            }
        }

        [HttpGet]
        public async Task<AdvertsInfoDto> Get()
        {
            return await _infoService.GetInfoAsync();
        }

    }

}