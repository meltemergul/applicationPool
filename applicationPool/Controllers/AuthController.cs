using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using applicationPool.Models;
using applicationPool.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace applicationPool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly TokenService _tokenService;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _tokenService = new TokenService(configuration["Jwt:Key"]);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User login)
        {
            var user = _userService.Authenticate(login.Username, login.Password);

            if (user == null)
                return Unauthorized();

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }

        [HttpGet("login")]
        public IActionResult LoginPage()
        {
            return View("Login");
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User register)
        {
            try
            {
                if (register == null)
                    return BadRequest("Invalid user data.");

                var user = _userService.Register(register);

                if (user == null)
                    return BadRequest("User already exists.");

                return Ok();
            }
            catch (Exception ex)
            {
                // Log exception details here
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("register")]
        public IActionResult RegisterPage()
        {
            return View("Register");
        }
    }
}
