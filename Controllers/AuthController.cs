using Microsoft.AspNetCore.Mvc;
using apiApp.Interfaces;
using apiApp.DTOs;

namespace apiApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // [HttpPost("register")]
        // public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterDto userRegisterDto)
        // {
        //     var result = await _authService.RegisterAsync(userRegisterDto);
        //     if (!result.Success)
        //     {
        //         return BadRequest(result.Message);
        //     }
        //     return Ok(result);
        // }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto user)
        {
            string token = _authService.Login(user);
            if (token == null)
            {
                return Unauthorized("Invalid credentials");
            }
            return Ok(new { Token = token });
        }
    }
}

