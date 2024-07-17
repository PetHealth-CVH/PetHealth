using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresControllers : ControllerBase
    {
        [HttpGet("{id}")]
        public FornecedorResponse ObterPelaId(Guid id)
        {

        }
        [HttpPut("{id}")]
        public void AtualizarPelaId(Guid id, [FromBody] FornecedorAtualizarRequest request)
        {

        }
        //Não terá opção de remover fornecedor, somente atualizar.
    }
}
