using System.Collections.Generic;
using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        ICommentsService _advertService;
        public CommentsController(ICommentsService commentsService)
        {
            _advertService = commentsService;
        }
        [HttpGet]
        public IList<CommentDto> Get()
        {
            return _advertService.GetAll();
        }
    }
}