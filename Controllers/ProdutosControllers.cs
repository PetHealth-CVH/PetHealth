using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProdutosController : ControllerBase
    {
        private readonly PetHealthDbContext _contexto;

        public ProdutosController(PetHealthDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet("{idProduto}")]
        public async Task<ActionResult<ProdutoResponse>> ObterProdutoPelaId(Guid id)
        {
            try
            {
                var Produtos = await _contexto.Produtos
                                .FirstOrDefaultAsync(tb_produtos => tb_produtos.Id == id);

                if (Produtos == null)
                {
                    return NotFound();
                }

                new ProdutosResponse
                {
                    Id = Produtos.Id,
                    Nome_Produto = Produtos.Nome_Produto,
                    Descricao = Produtos.Descricao,
                    Quantidade = Produtos.Quantidade,
                    Preco = Produtos.Preco
                };

                return Ok(ProdutoResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, "Não foi possível realizar a consulta.");
            }
        }
    }
}

