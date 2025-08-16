using Microsoft.AspNetCore.Http;
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

    public class ProdutosControllers : ControllerBase
    {
        private readonly IProdutosServices _produtosServices;

        public ProdutosControllers(IProdutosServices produtosServices)
        {
            _produtosServices = produtosServices;
        }

        // POST: api/produtos
        [HttpPost]
        public async Task<ActionResult> CadastrarProduto([FromBody] ProdutoDto produtoDto)
        {
            return await _produtosServices.CadastrarProduto(produtoDto);
        }

        // GET: api/produtos/{idProduto}
        [HttpGet("{idProduto}")]
        public async Task<ActionResult> ConsultarProduto(long idProduto)
        {
            return await _produtosServices.ConsultarProduto(idProduto);
        }
    }
}

