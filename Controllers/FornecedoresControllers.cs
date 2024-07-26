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
    public class FornecedoresController : ControllerBase
    {
        private readonly PetHealthDbContext _contexto;

        public FornecedoresController(PetHealthDbContext contexto)
        {
            _contexto = contexto;
        }

        // POST: api/fornecedores
        [HttpPost]
        public ActionResult Cadastrar([FromBody] FornecedorRequest cadastro)
        {
            try
            {
                var fornecedor = new Fornecedor
                {
                    Nome = cadastro.Nome,
                    RazaoSocial = cadastro.RazaoSocial,
                    Cnpj = cadastro.Cnpj,
                    Telefone = cadastro.Telefone,
                    Email = cadastro.Email
                };
                _contexto.Fornecedores.Add(fornecedor);
                _contexto.SaveChanges();

                cadastro.Id = fornecedor.Id;

                return StatusCode(201, new { idFornecedor = cadastro.Id });
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: api/fornecedores/
        [HttpGet]
        public ActionResult<IEnumerable<FornecedorResponse>> ObterLista()
        {
            try
            {
                var fornecedores = _contexto.Fornecedores.ToList();

                return Ok(fornecedores);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }
        
        // GET: api/fornecedores/{idProduto}
        [HttpGet("{idFornecedor}")]
        public ActionResult<FornecedorResponse> ObterPelaId(Guid idFornecedor)
        {
            try
            {
                var fornecedor = _contexto.Fornecedores
                                .FirstOrDefault(tb_fornecedores => tb_fornecedores.Id == idFornecedor);

                if (fornecedor == null)
                {
                    return NotFound();
                }

                return Ok(fornecedor);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }
    }
}