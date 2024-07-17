using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.HttpRequests;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosControllers : ControllerBase
    {
         [HttpGet("{id}")]
        public void EnderecoId(Guid id) 
        {

        }
        [HttpPost]
        public void Registrar([FromBody] Endereco enderecos)
        {

        }
        [HttpPut("{id}")]
        public void AtualizarEnderecoId(Guid id)
        {

        }
        [HttpDelete("{id}")]
        public void DeletarEnderecoId(Guid id)
        {
            
        }
    }
}
