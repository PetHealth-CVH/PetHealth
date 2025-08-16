using Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.HttpResponse;
using PetHealth.Dtos;
using PetHealth.Services.Abstracts;

namespace PetHealth.Services
{
    public class ProdutosServices : IProdutosServices
    {
        private readonly PetHealthDbContext _context;

        public ProdutosServices(PetHealthDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> CadastrarProduto(ProdutoDto produtoDto)
        {
            if (produtoDto == null)
            {
                return new BadRequestObjectResult("Fornecedor inválido.");
            }

            var fornecedorExistente = await _context.Fornecedores
                .AnyAsync(f => f.Id == produtoDto.IdFornecedor);


            var produto = new Produto
            {
                Nome = produtoDto.Nome,
                Descricao = produtoDto.Descricao,
                Quantidade = produtoDto.Quantidade,
                Preco = produtoDto.Preco,
                IdFornecedor = produtoDto.IdFornecedor,
            };

            try
            {
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();

                var proDto = new ProdutoCreatedDto
                {
                    ProdId = produto.Id,
                };

                return new OkObjectResult(proDto);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Erro interno: {ex.Message}") { StatusCode = 500 };
            }
        }

        public async Task<ActionResult> ConsultarProduto(long idProduto)
        {
            try
            {
                var produto = await _context.Produtos
                                            .FirstOrDefaultAsync(p  => p.Id == idProduto);
                bool ProdNotFound = produto == null;

                if (ProdNotFound)
                {
                    return new NotFoundResult();
                }

                var produtoResponse = new ProdutosResponse
                {
                    Nome_Produto = produto.Nome,
                    Descricao = produto.Descricao,
                    Quantidade = produto.Quantidade,
                    Preco = produto.Preco,
                };

                return new OkObjectResult(produtoResponse);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Erro interno: {ex.Message}") { StatusCode = 500 };
            }
        }
    }
}
