using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresControllers : ControllerBase
    {
        // Rota "api/FornecedoresControllers/{id}"
        // Ele retorna um objeto FornecedorResponse, que representa as informações de um fornecedor
        private readonly PetHealthDbContext _contexto;

        public FornecedoresControllers (PetHealthDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet("{idFornecedor}")]
        public async Task<ActionResult<FornecedorResponse>> ObterProdutoPelaId(Guid id)
        {
            try
            {
                var Fornecedor = await _contexto.Fornecedor
                                .FirstOrDefaultAsync(tb_fornecedores => tb_fornecedores.Id == id);

                if (Fornecedor == null)
                {
                    return NotFound();
                }

                new FornecedorResponse
                {
                    Id = Fornecedor.Id,
                    Razao = Fornecedor.Razao,
                    CNPJ = Fornecedor.CNPJ,
                    Telefone = Fornecedor.Telefone,
                    Email = Fornecedor.Email
                };

                return Ok(FornecedorResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, "Não foi possível realizar a consulta.");
            }
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
