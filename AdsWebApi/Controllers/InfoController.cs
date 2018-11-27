using Ads.CoreService.AppServices.ServiceInterfaces;
using Ads.CoreService.Contracts.Dto;
using AppServices.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Enabling cors for using API directly from the UI
    [EnableCors("allow")]
    public class InfoController : ControllerBase
    {
        readonly IInfoService _infoService;
        readonly IPostRatingService _ratingService;
        public InfoController(IInfoService infoService,
                              IPostRatingService ratingService)
        {
            _ratingService = ratingService;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("SetRating")]
        public async Task<ActionResult> SetPostRatingAsync([FromBody]RatingDto ratingDto)
        {
            if (await _ratingService.SetRatingToPostAsync(ratingDto))
                return Ok();
            else
                return BadRequest();
        }
        [HttpGet]
        public async Task<AdvertsInfoDto> Get()
        {
            return await _infoService.GetInfoAsync();
        }

    }

}