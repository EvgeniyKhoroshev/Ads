﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AdsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        ICommentsService _commentsService;
        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }
        [HttpGet]
        public IList<CommentDto> Get()
        {
            return _commentsService.GetAll();
        }
        [HttpGet("advertcomments")]
        public IList<CommentDto> GetAdvertComments(int? advertId)
        {
            return _commentsService.GetAllAdvertComments(advertId.Value);
        }
        [EnableCors("allow")]
        [HttpPost("saveorupdate")]
        public async Task<CommentDto> PostSaveOrUpdate([FromBody] CommentDto value)
        {
            return await _commentsService.SaveOrUpdate(value);
        }

    }
}