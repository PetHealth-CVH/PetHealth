using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.HttpResponse;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresControllers : ControllerBase
    {
        // Rota "api/FornecedoresControllers/{id}"
        // Ele retorna um objeto FornecedorResponse, que representa as informações de um fornecedor
        private readonly PetHealthDbContext _contexto;

        public FornecedoresControllers(PetHealthDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet("{idFornecedor}")]
        public async Task<ActionResult<FornecedorResponse>> ObterProdutoPelaId(Guid id)
        {
            try
            {
                var Fornecedor = await _contexto.Fornecedor
                                .FirstOrDefaultAsync(tb_fornecedores => tb_fornecedores.id == id);

                if (Fornecedor == null)
                {
                    return NotFound();
                }

                new FornecedorResponse
                {
                    Id = Fornecedor.id,
                    Razao = Fornecedor.Razao,
                    CNPJ = Fornecedor.CNPJ,
                    Telefone = Fornecedor.Telefone,
                    Email = Fornecedor.Email
                };

                return Ok(Fornecedor);
            }
            catch (Exception)
            {
                return StatusCode(500, "Não foi possível realizar a consulta.");
            }
        }
    }
}