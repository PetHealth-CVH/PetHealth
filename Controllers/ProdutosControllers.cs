using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosControllers : ControllerBase
    {
        // Rota "api/ProdutosControllers"
        // Ele retorna uma lista de objetos Produtos, cada um representando um produto
        [HttpGet]
        public IEnumerable<Produtos> SolicitarProdutos()
        {
                // Cria uma lista de produtos
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
            // Retorna a lista de produtos
            return produtos;
        } 
    }
}

