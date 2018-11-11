using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.AppServices.JwtAuthentication;
using Authentication.Contracts.Basic;
using Authentication.Contracts.JwtAuthentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdsWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JwtAuthenticationController : ControllerBase
    {
        private readonly IJwtAuthenticationService _authenticationService;

        public JwtAuthenticationController(IJwtAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]
        public async Task<ActionResult<JwtAuthenticationToken>> Authenticate(BasicAuthenticationRequest request)
        {
            if (request == null)
                return BadRequest();

            var result = await _authenticationService.AuthenticateAsync(request);
            if (!result.IsSucceed)
                return BadRequest(result.Errors);

            return Ok(result.Token);
        }
    }
}