using AluraChallenge.Adopet.Authentication.Interfaces;
using AluraChallenge.Adopet.Authentication.Request;
using AluraChallenge.Adopet.Authentication.Response;
using AluraChallenge.Adopet.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AluraChallenge.Adopet.WebAPI.Controllers
{
    [ApiController]
    [Route("api/autenticar")]
    public class AuthenticationController : ControllerBase
    {
        protected readonly IUserServices _userService;

        public AuthenticationController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            var valid = await _userService.ValidateUserAsync(request);
            if (valid)
                return Ok(await _userService.CreateTokenAsync());
            return Unauthorized();
        }
    }
}