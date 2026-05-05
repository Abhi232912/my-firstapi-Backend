using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Model;
using MyFirstWebApi.Services;

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        public readonly IEmployeeService _empserv;

        public AuthController(IEmployeeService empserv)
        {
            _empserv = empserv;
        }

        [HttpPost("login")]

        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var token = _empserv.Login(loginDto);
            
            if(token == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(new { Token = token });
        }
    }
}
