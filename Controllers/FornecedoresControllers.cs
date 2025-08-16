using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contexts;
using Models;
using Models.HttpRequests;
using Models.HttpResponse;
using PetHealth.Services.Abstracts;
using PetHealth.Dtos;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedoresServices _fornecedorServices;

        public FornecedoresController(IFornecedoresServices fornecedoresServices)
        {
            _fornecedorServices = fornecedoresServices;
        }

        // POST: api/fornecedores
        [HttpPost]
        public async Task<ActionResult> Cadastrar(FornecedorDto fornecedorDto)
        {
            return await _fornecedorServices.Cadastrar(fornecedorDto);
        }

        // GET: api/fornecedores/{idFornecedor}
        [HttpGet("{idFornecedor}")]
        public async Task<ActionResult> ObterPelaId(long idFornecedor)
        {
            return await _fornecedorServices.ObterPelaId(idFornecedor);
        }
    }
}