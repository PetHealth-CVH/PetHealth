using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresControllers : ControllerBase
    {
        // Rota "api/FornecedoresControllers/{id}"
        // Ele retorna um objeto FornecedorResponse, que representa as informações de um fornecedor
        [HttpGet("{id}")]
        public FornecedorResponse ObterPelaId(Guid id)
        {

        }

        // Rota "api/FornecedoresControllers/{id}"
        // Ele atualiza as informações de um fornecedor com base no ID fornecido
        [HttpPut("{id}")]
        public void AtualizarPelaId(Guid id, [FromBody] FornecedorAtualizarRequest request)
        {

        }
        
        //Não terá opção de remover fornecedor, somente atualizar.
    }
}
