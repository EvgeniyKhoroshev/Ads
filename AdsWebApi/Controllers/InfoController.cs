using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        readonly IInfoService _infoService;
        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }
        [HttpGet("{id}")]
        [EnableCors("allow")]
        public async Task<object[]> GetInfo(int id)
        {
            switch(id)
            {
                case 1:
                    return await _infoService.GetCategoriesAsync();
                case 2:
                    return await _infoService.GetCitiesAsync();
                case 3:
                    return await _infoService.GetStatusesAsync();
                case 4:
                    return await _infoService.GetTypesAsync();
                case 5:
                    return await _infoService.GetRegionsAsync();
                default:
                    return null;
            }
        }

        [HttpGet]
        [EnableCors("allow")]
        public async Task<AdvertsInfoDto> Get()
        {
            return await _infoService.GetInfoAsync();
        }

    }

}