using Microsoft.AspNetCore.Mvc;
using PetHealth.Dtos;

namespace PetHealth.Services.Abstracts
{
    public interface IProdutosServices
    {
        Task<ActionResult> CadastrarProduto([FromBody]ProdutoDto produtoDto);
        Task<ActionResult> ConsultarProduto(long idProduto);
    }
}
