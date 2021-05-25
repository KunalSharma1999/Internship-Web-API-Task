using Employee_Directory.Contracts;
using Employee_Directory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public ApplicationUserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<object> Register(ApplicationUserModel model){
            var result = await _authenticationService.Register(model);
            return result;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            string token = await _authenticationService.Login(model);
            if (token != null)
            {
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "Username or password is incorrect." });
            }
        }
    }
}
