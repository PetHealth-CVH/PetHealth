using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosControllers : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Produtos> SolicitarProdutos()
        {
                List<Produtos> produtos = new List<Produtos>
            {
                new() {
                    Id = Guid.NewGuid(),
                    NomeProduto = "Vermífugo Vermivet Composto 600mg para cães",
                    Descricao = "Vermifugo para tratamento e controle de verminoses para cães",
                    Preco = 9.90,
                    Quantidade = 100
                }
            };
            return produtos;
        } 
    }
}

