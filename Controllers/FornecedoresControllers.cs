using Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.HttpRequests;
using Models.HttpResponse;
using System;
using System.Threading.Tasks;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresControllers : ControllerBase
    {
        private readonly PetHealthDbContext _contexto;

        public FornecedoresControllers(PetHealthDbContext contexto)
        {
            _contexto = contexto;
        }
        // Rota api/FornecedoresControllers/RegistrarFornecedor
        [HttpPost("RegistrarFornecedor")]
        public async Task<ActionResult<FornecedorResponse>> RegistrarFornecedor(FornecedorRequest fornecedorRequest)
        {
            try
            {
                var novoFornecedor = new Fornecedor
                {
                    id = Guid.NewGuid(),
                    Razao = fornecedorRequest.Razao,
                    CNPJ = fornecedorRequest.CNPJ,
                    Telefone = fornecedorRequest.Telefone,
                    Email = fornecedorRequest.Email
                };

                _contexto.Fornecedor.Add(novoFornecedor);
                await _contexto.SaveChangesAsync();

                var fornecedorResponse = new FornecedorResponse
                {
                    Id = novoFornecedor.id,
                    Razao = novoFornecedor.Razao,
                    CNPJ = novoFornecedor.CNPJ,
                    Telefone = novoFornecedor.Telefone,
                    Email = novoFornecedor.Email
                };

                return CreatedAtAction(nameof(ObterProdutoPelaId), new { idFornecedor = fornecedorResponse.Id }, fornecedorResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao tentar registrar o fornecedor.");
            }
        }

        // Rota api/FornecedoresControllers/{idFornecedor}
        [HttpGet("{idFornecedor}")]
        public async Task<ActionResult<FornecedorResponse>> ObterProdutoPelaId(Guid idFornecedor)
        {
            try
            {
                var fornecedor = await _contexto.Fornecedor
                                .FirstOrDefaultAsync(f => f.id == idFornecedor);

                if (fornecedor == null)
                {
                    return NotFound();
                }

                var fornecedorResponse = new FornecedorResponse
                {
                    Id = fornecedor.id,
                    Razao = fornecedor.Razao,
                    CNPJ = fornecedor.CNPJ,
                    Telefone = fornecedor.Telefone,
                    Email = fornecedor.Email
                };

                return Ok(fornecedorResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, "Não foi possível realizar a consulta.");
            }
        }
    }
}