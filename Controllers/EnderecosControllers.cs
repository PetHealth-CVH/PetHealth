using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

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
        public void Registrar([FromBody] Enderecos enderecos)
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
