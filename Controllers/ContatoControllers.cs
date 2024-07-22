using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.HttpRequests;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoControllers : ControllerBase
    {
        private readonly PetHealthDbContext _contexto;

        public ContatoControllers(PetHealthDbContext contexto)
        {
            _contexto = contexto;
        }
        // Rota "api/ContatoControllers/AddContato"
        // Ele adiciona um novo contato com base no objeto ContatoRequest fornecido no corpo da requisição
        [HttpPost("AddContato")]

        public void AddContato([FromBody] ContatoRequest contato)
        
        {
            // Aguardando verificação
        }
    }
}
