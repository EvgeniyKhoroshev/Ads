using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ads.CoreService.Contracts.Dto;
using Ads.MVCClientApplication.Components.ApiClients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ads.MVCClientApplication.Controllers
{
    public class RatingController : Controller
    {
        readonly IApiInfoClient _infoClient;
        public RatingController(IApiInfoClient infoClient)
        {
            _infoClient = infoClient;
        }
        [HttpPost("setrating")]
        public async Task<ActionResult> SetRatingAsync([FromBody] RatingDto ratingDto)
        {
            var isRated = await _infoClient.SetRatingAsync(ratingDto);
            if (isRated)
                return Ok();
            else
                return Unauthorized();
        }
        [HttpGet("CurrentUserRates/{advertId:int}")]
        public async Task<ActionResult> GetCurrentUserRatesAsync(int advertId)
        {
            var rates = await _infoClient.GetCurrentUserRatesAsync(advertId);
            if (rates != null)
                return Ok(rates);
            else
                return Unauthorized();
        }
    }
}