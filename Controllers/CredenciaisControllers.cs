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
       
        // Este é o construtor da classe CredenciaisControllers, que recebe o contexto do banco de dados como parâmetro
        public CredenciaisControllers(PetHealthDbContext contexto)
        {
            database = contexto;
        }

        // Rota "api/CredenciaisControllers/autenticarusuario"
        // Ele autentica um usuário com base nas credenciais fornecidas no objeto CredencialRequest
        [HttpPost("autenticarusuario")]
        public void AutenticarUsuario(CredencialRequest credencial) {

        }

        // Rota "api/CredenciaisControllers/registrar"
        // Ele registra um novo usuário com base no objeto UsuarioRequest fornecido no corpo da requisição
        [HttpPost("registrar")]
        public void Registrar([FromBody] UsuarioRequest usuario) {

        }
    }
}
   



