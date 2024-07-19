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
        // Rota "api/EnderecosControllers/{id}"
        // Ele retorna as informações de um endereço com base no ID fornecido
         [HttpGet("{id}")]
        public void EnderecoId(Guid id) 
        {

        }

        // Rota "api/EnderecosControllers"
        // Ele cria um novo endereço com base no objeto Enderecos fornecido no corpo da requisição
        [HttpPost]
        public void Registrar([FromBody] Endereco enderecos)
        {

        }

        // Rota "api/EnderecosControllers/{id}"
        // Ele atualiza as informações de um endereço com base no ID fornecido
        [HttpPut("{id}")]
        public void AtualizarEnderecoId(Guid id)
        {

        }
        
        // Rota "api/EnderecosControllers/{id}"
        // Ele exclui um endereço com base no ID fornecido
        [HttpDelete("{id}")]
        public void DeletarEnderecoId(Guid id)
        {
            
        }
    }
}
