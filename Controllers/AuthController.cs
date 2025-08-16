using Microsoft.AspNetCore.Mvc;
using PetHealth.Dtos;
using PetHealth.Services.Abstracts;

namespace Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        // POST: api/contas/login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] CredencialDTO credencialDTO)
        {
            return await _authServices.Login(credencialDTO);
        }
    }
}
