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
        public AdvertsController (IAdvertService advertService, IInfoService infoService)
        {
            _infoService = infoService;
            _infoService.GetInfo();
            _advertService = advertService;
        }
        readonly IAdvertService _advertService;
        readonly IInfoService _infoService;
        // GET api/values
        [HttpGet]
        public async Task<IList<AdvertDto>> Get()
        {
            AdvertsInfoDto info =  await _infoService.GetInfo();
            return await _advertService.GetAllWithoutIncludes();
        }
        [HttpGet("{add}")]
        public async Task<AdvertsInfoDto> Get(string add)
        {
            AdvertsInfoDto info = await _infoService.GetInfo();
            return info;
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
