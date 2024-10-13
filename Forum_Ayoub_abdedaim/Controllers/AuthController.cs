using Microsoft.AspNetCore.Mvc;
using Services.AuthService;
using DAO.Models;
using System.Threading.Tasks;
using Services.UserService;

namespace Forum_Ayoub_abdedaim.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _authService;

        public AuthController(IAuth authService)
        {
            _authService = authService;
        }

        // POST api/auth/signup
        [HttpPost("signup")]
        public async Task<ActionResult<string>> SignUp([FromBody] Utilisateur user, string password)
        {
            var result = await _authService.SignUp(user, password);
            return Ok(result);
        }

        // POST api/auth/signin
        [HttpPost("signin")]
        public async Task<ActionResult<string?>> SignIn([FromBody] string username, string password)
        {
            var result = await _authService.SignIn(username, password);
            if (result == "Invalid username." || result == "Invalid password.")
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }
    }

}
