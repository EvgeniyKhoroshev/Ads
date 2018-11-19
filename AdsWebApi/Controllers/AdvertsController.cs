﻿using Ads.CoreService.Contracts.Dto;
using Ads.CoreService.Contracts.Dto.Filters;
using Ads.Shared.Contracts;
using AppServices.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        public AdvertsController(IAdvertService advertService)
        {
            _advertService = advertService;
        }
        readonly IAdvertService _advertService;
        // GET api/values
        [HttpGet]
        public PagedCollection<AdvertDto> Get()
        {
            return _advertService.GetFilteredAsync(new AdvertFilterDto { });
        }
        [HttpGet("UserAdverts/{userId}")]
        public ActionResult<IList<AdvertDto>> GetUserAdverts(int userId)
        {
            var result = _advertService.GetAdvertsByUserId(userId);
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdvertDto>> Get(int id)
        {
            return await _advertService.GetAsync(id);
        }
        // GET api/values/5
        [HttpGet("/api/[controller]/{id}/advertcomments")]
        public IList<CommentDto> GetAdvertComments(int id)
        {
            var result = _advertService.GetAdvertComments(id);
            return result;
        }
        // POST api/values
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("saveorupdate")]
        public async Task<AdvertDto> PostSaveOrUpdate(AdvertDto value)
        {
            return await _advertService.SaveOrUpdateAsync(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public void Delete(int id)
        {
            _advertService.Delete(id);
        }
        [HttpPost("filter")]
        public PagedCollection<AdvertDto> GetFiltered([FromBody]AdvertFilterDto filter)
        {
            return _advertService.GetFilteredAsync(filter);
            //return _advertService.GetLastAddedAdverts();

        }
        [HttpGet("GetAdvertImages/{advertId}")]
        public ImageDto[] GetAdvertImages(int advertId)
        {

            return null;
        }
    }
}
