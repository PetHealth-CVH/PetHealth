using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Contexts;
using Models;
using Models.HttpRequests;
using Models.HttpResponse;

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
        
        // POST: api/produtos
        [HttpPost]
        public ActionResult Cadastrar([FromBody] ProdutoRequest cadastro)
        {
            try
            {
                var produto = new Produto
                {
                    Nome = cadastro.Nome,
                    Descricao = cadastro.Descricao,
                };

                if (cadastro.IdFornecedor != null)
                {
                    produto.FornecedorId = (Guid)cadastro.IdFornecedor;
                }

                _contexto.Produtos.Add(produto);
                _contexto.SaveChanges();

                cadastro.Id = produto.Id;

                return StatusCode(201, new { idProduto = cadastro.Id });
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }
        
        // GET: api/produtos/{idProduto}
        [HttpGet("{idProduto}")]
        public ActionResult<ProdutosResponse> ObterPelaId(Guid idProduto)
        {
            try
            {
                var produto = _contexto.Produtos
                                .FirstOrDefault(tb_produtos => tb_produtos.Id == idProduto);

                if (produto == null)
                {
                    return NotFound();
                }

                return Ok(produto);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: api/produtos/
        [HttpGet]
        public ActionResult<IEnumerable<ProdutosResponse>> ObterLista()
        {
            try
            {
                var produtos = _contexto.Produtos.ToList();

                return Ok(produtos);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }
    }
}

