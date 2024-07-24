using Identity.API.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        //private readonly IJwtTokenGenerator _tokenGenerator;
        //private readonly ILogger<AuthController> _logger;

        //public AuthController
        //    (
        //    ILogger<AuthController> logger,
        //    IJwtTokenGenerator tokenGenerator
        //    )
        //{
        //    _logger = logger;
        //    _tokenGenerator = tokenGenerator;
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginRequest request)
        //{
        //    if (IsValidUser(request.Username, request.Password))
        //    {
        //        var token = _tokenGenerator.GenerateToken(request.Username);
        //        return Ok(new { Token = token });
        //    }
        //    return Unauthorized();
        //}

        //private bool IsValidUser(string username, string password)
        //{
        //    // Validate username and password against your user store
        //    return true; // For demonstration purposes, always return true
        //}

        private readonly IJwtTokenService _jwtTokenService;
        public AuthController(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel user)
        {
            var loginResult = _jwtTokenService.GenerateAuthToken(user);
            return loginResult is null ? Unauthorized() : Ok(loginResult);
        }

    }
}
