using System.Collections.Generic;
using System.Threading.Tasks;
using Ads.Contracts.Dto;
using AppServices.ServiceInterfaces;
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
        [HttpPost("/api/[controller]/saveorupdate")]
        public async Task<int> PostSaveOrUpdate([FromBody] CommentDto value)
        {
            return await _commentsService.SaveOrUpdate(value);
        }

    }
}