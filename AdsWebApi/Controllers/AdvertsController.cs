using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;
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
        IAdvertService _advertService;
        // GET api/values
        [HttpGet]
        public async Task<IList<AdvertDto>> Get()
        {
            return await _advertService.GetAllWithoutIncludes();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdvertDto>> Get(int id)
        {
            return await _advertService.GetWithIncludes(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] AdvertDto value)
        {
            _advertService.SaveOrUpdate(value);
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
        }
    }
}
