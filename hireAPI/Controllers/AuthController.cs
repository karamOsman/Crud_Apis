using hireAPI.Models;
using hireAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace hireAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService= authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }
            var result =await _authService.RegisterAsync(registerModel);

            if(!result.isAuthenticated)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);


            //return Ok(new { token= result.Token,expiresOn=result.ExpireOn});

        }
        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel tokenRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.GetTokenAsync(tokenRequest);

            if (!result.isAuthenticated)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel addRoleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.AddRoleAsync(addRoleModel);

            if (!string.IsNullOrEmpty(result))
            {
                return BadRequest(result);
            }
            return Ok(addRoleModel);
        }
    }
}
