using Ads.CoreService.AppServices.ServiceInterfaces;
using Ads.CoreService.Contracts.Dto;
using AppServices.ServiceInterfaces;
using Authentication.Contracts.CookieAuthentication;
using Authentication.Contracts.JwtAuthentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("CurrentUserRates/{advertId:int}")]
        public async Task<IActionResult> GetCurrentUserRatesAsync(int advertId)
        {
            int userId = GetCurrentUserId().Value;
            return Ok(await _ratingService.GetCurrentUserRatesAsync(userId, advertId));
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
                    return await _infoService.GetCitiesByRegionIdAsync(regionId);
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
        [HttpGet("City/{id:int}")]
        public async Task<CityDto> GetCityByIdAsync(int id)
        {
            return await _infoService.GetCityByIdAsync(id);
        }
        [HttpGet("GetPostRatingValue/{postId:int}")]
        public async Task<ActionResult> GetPostRatingValue(int postId)
        {
            int value = await _ratingService.GetPostRatingAsync(postId);
            return Ok($"{value}");
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("SetRating")]
        public async Task<bool> SetPostRatingAsync([FromBody]RatingDto ratingDto)
        {
            return await _ratingService.SetRatingToPostAsync(ratingDto);
        }
        [HttpGet]
        public async Task<AdvertsInfoDto> Get()
        {
            return await _infoService.GetInfoAsync();
        }
        private int? GetCurrentUserId()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return null;
            int UserId = Convert.ToInt32(
                HttpContext.User.Claims.FirstOrDefault(t => t.Type == JwtCustomClaimNames.UserId).Value);
            return UserId;
        }
    }

}