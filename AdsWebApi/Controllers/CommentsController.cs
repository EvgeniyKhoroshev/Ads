using System.Collections.Generic;
using System.Threading.Tasks;
using Ads.CoreService.AppServices.ServiceInterfaces;
using Ads.CoreService.Contracts.Dto;
using AppServices.ServiceInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AdsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        readonly ICommentsService _commentsService;
        readonly IPostRatingService _postRatingService;
        public CommentsController(ICommentsService commentsService,
                                  IPostRatingService postRatingService)
        {
            _postRatingService = postRatingService;
            _commentsService = commentsService;
        }

        [HttpGet]
        public IList<CommentDto> Get()
        {
            return _commentsService.GetAll();
        }

        [HttpGet("advertcomments/{advertId:int?}")]
        public async Task<IList<CommentDto>> GetAdvertComments(int? advertId)
        {
            var comments = await _commentsService.GetAdvertCommentsAsync(advertId.Value);
            return comments;
        }

        [EnableCors("allow")]
        [HttpPost("saveorupdate")]
        public async Task<CommentDto> PostSaveOrUpdate([FromBody] CommentDto value)
        {
            return await _commentsService.SaveOrUpdateAsync(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _commentsService.Delete(id);
        }


    }
}