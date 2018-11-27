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
            return await _infoClient.SetRatingAsync(ratingDto);
        }
    }
}