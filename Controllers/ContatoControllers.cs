using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoControllers : ControllerBase
    {
        // Rota "api/ContatoControllers/AddContato"
        // Ele adiciona um novo contato com base no objeto ContatoRequest fornecido no corpo da requisição
        [HttpPost("AddContato")]
        public void AddContato([FromBody] ContatoRequest contato)
        {
            // Aguardando verificação
        }
    }
}
