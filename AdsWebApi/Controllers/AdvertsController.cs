using Ads.Contracts.Dto;
using Ads.Contracts.Dto.Filters;
using AppServices.ServiceInterfaces;
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
        // GET api/values
        [HttpGet]
        public IList<AdvertDto> Get()
        {
            return _advertService.GetAll_ToIndex();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdvertDto>> Get(int id)
        {
            return await _advertService.Get(id);
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
        public async Task<int> PostSaveOrUpdate([FromBody] AdvertDto value)
        {
            return await _advertService.SaveOrUpdate(value);
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
        public AdvertDto[] GetFiltered([FromBody]FilterDto filter)
        {
            return _advertService.GetFiltred(filter);
        }

    }
}
