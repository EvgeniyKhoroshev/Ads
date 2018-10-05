﻿using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController (IAdvertService advertService)
        {
            _advertService = advertService;
        }
        IAdvertService _advertService;
        // GET api/values
        [HttpGet]
        public ActionResult<AdvertDto> Get()
        {
            return _advertService.Get(1);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<AdvertDto> Get(int id)
        {
            return _advertService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
