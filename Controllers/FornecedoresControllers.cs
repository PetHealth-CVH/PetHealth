using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Contexts;
using Models;
using Models.HttpRequests;

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
    }
}