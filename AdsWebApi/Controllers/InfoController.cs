﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        readonly IInfoService _infoService;
        AdvertsInfoDto _advertsInfoDto;
        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
            _advertsInfoDto = _infoService.GetInfo().Result;
        }
        [HttpGet]
        [EnableCors("allow")]
        public AdvertsInfoDto Get()
        {
            return _advertsInfoDto;
        }

    }

}