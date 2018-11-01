using Ads.Contracts.Dto;
using Ads.Contracts.Dto.Filters;
using Ads.CoreService.Contracts.Dto.Filters;
using Ads.Shared.Contracts;
using AppServices.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        public AdvertsController (IAdvertService advertService)
        {
            _advertService = advertService;
        }
        readonly IAdvertService _advertService;
        //// GET api/values
        //[HttpGet]
        //public IList<AdvertDto> Get()
        //{
        //    return _advertService.GetAll_ToIndex();
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<AdvertDto>> Get(int id)
        {
            return await _advertService.GetAsync(id);
        }
        // GET api/values/5
        //[EnableCors("allow")]
        [HttpGet("/api/[controller]/{id}/advertcomments")]
        public IList<CommentDto> GetAdvertComments(int id)
        {
            var result = _advertService.GetAdvertComments(id);
            return result;
        }
        // POST api/values
        [HttpPost("/api/[controller]/saveorupdate")]
        public async Task<AdvertDto> PostSaveOrUpdate(AdvertDto value)
        {
            return await _advertService.SaveOrUpdateAsync(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _advertService.Delete(id);
        }
        [HttpPost("filter")]
        public PagedCollection<AdvertDto> GetFiltered([FromBody]AdvertFilterDto filter)
        {
            return _advertService.GetFilteredAsync(filter);

        }


    }
}
