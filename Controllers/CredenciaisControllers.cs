using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.HttpRequests;


namespace Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CredenciaisControllers : ControllerBase
    {
        private readonly PetHealthDbContext database;
        public CredenciaisControllers(PetHealthDbContext contexto)
        {
            database = contexto;
        }

        [HttpPost("autenticarusuario")]
        public void AutenticarUsuario(CredencialRequest credencial) {

        }

        [HttpPost("registrar")]
        public void Registrar([FromBody] UsuarioRequest usuario) {

        }
    }
}
   



