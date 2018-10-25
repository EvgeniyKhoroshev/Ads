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
    public class AuthorizationController : ControllerBase
    {
        public AuthorizationController(IUserService userService, IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        // GET api/values
        //[HttpGet]
        //public IList<AdvertDto> Get()
        //{
        //    return _userService.GetAll_ToIndex();
        //}
        //// GET api/values/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<AdvertDto>> Get(int id)
        //{
        //    return await _userService.Get(id);
        //}
        //// GET api/values/5
        ////[EnableCors("allow")]
        //[HttpGet("/api/[controller]/{id}/advertcomments")]
        //public IList<CommentDto> GetUserAdvertsComments(int id)
        //{
        //    var result = _userService.GetAdvertComments(id);
        //    return result;
        //}
        //POST api/values
        [HttpPost("/api/[controller]/create")]
        public async Task TaskCreateUser([FromBody] CreateUserDto value)
        {
            await _userService.CreateUserAsync(value);
        }

        [HttpPost("token")]
        public string Token()
        {
            return _authenticationService.GetToken();
        }
        [HttpPost("/api/[controller]/signin")]
        public async Task<IActionResult> SignIn([FromBody] UserLoginDto value)
        {
            
            var s = await _authenticationService.JWTSignInAsync(value);
            return Ok(s);
        }
        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    _userService.Delete(id);
        //}

        //[HttpPost("filter")]
        //public AdvertDto[] GetFiltered([FromBody]FilterDto filter)
        //{
        //    return _userService.GetFiltred(filter);
        //}

    }
}
