using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
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
        
        // Obter informações do produto pela Id
        [HttpGet("{idProduto}")]
        public async Task<ActionResult<ProdutosResponse>> ObterProdutoPelaId(Guid id)
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

                return Ok(Produtos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Não foi possível realizar a consulta.");
            }
        }
    }
}
using Contexts;
using Microsoft.AspNetCore.HttpGet
using (Controllers)
using System;
using System.Collections.Generic;

namespace Controllers
{
    record Produto(string Nome, decimal valor, int Quantidade, string Descricao)
    {
        public override string ToString()
        {
            return $"Nome: {Nome}, Preço: {valor:C}, Quantidade: {Quantidade}, Descrição: {Descricao}";
        }
    }

    class Program
    {
        static List<Produto> produtos = new List<Produto>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Adicionar Produto");
                Console.WriteLine("2. Listar Produtos");
                Console.WriteLine("3. Sair");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarProduto();
                        break;
                    case "2":
                        ListarProdutos();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void AdicionarProduto()
        {
            Console.Write("Nome do Produto: ");
            string nome = Console.ReadLine();

            Console.Write("Preço do Produto: ");
            decimal preco;
            while (!decimal.TryParse(Console.ReadLine(), out preco))
            {
                Console.Write("Preço inválido. Digite novamente: ");
            }

            Console.Write("Quantidade: ");
            int quantidade;
            while (!int.TryParse(Console.ReadLine(), out quantidade))
            {
                Console.Write("Quantidade inválida. Digite novamente: ");
            }

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Produto produto = new Produto(nome, preco, quantidade, descricao);
            produtos.Add(produto);

            Console.WriteLine($"Produto {nome} adicionado com sucesso!");
        }

        static void ListarProdutos()
        {
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto registrado ainda.");
                return;
            }

            foreach (Produto produto in produtos)
            {
                Console.WriteLine(produto);
            }
        }
    }
}

