using Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;
using Models.HttpResponse;
using PetHealth.Dtos;
using PetHealth.Services.Abstracts;

namespace PetHealth.Services
{
    public class FornecedoresServices : IFornecedoresServices
    {
        private readonly PetHealthDbContext _context;

        public FornecedoresServices(PetHealthDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Cadastrar(FornecedorDto fornecedorDto)
        {
            if (fornecedorDto == null)
            {
                return new BadRequestObjectResult("Fornecedor inválido.");
            }

            var FornecedorExiste = await _context.Fornecedores.Where(f => f.Cnpj == fornecedorDto.Cnpj).FirstOrDefaultAsync();
            if (FornecedorExiste != null)
            {
                return new BadRequestObjectResult("Fornecedor existente com esse CNPJ!");
            }

            var fornecedor = new Fornecedor
            {
                RazaoSocial = fornecedorDto.RazaoSocial,
                Cnpj = fornecedorDto.Cnpj,
                Telefone = fornecedorDto.Telefone,
                Email = fornecedorDto.Email
            };

            try
            {
                _context.Fornecedores.Add(fornecedor);
                await _context.SaveChangesAsync();

                var forDto = new FornecedorCreatedDto
                {
                    ForId = fornecedor.Id,
                };

                return new OkObjectResult(forDto);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Erro interno: {ex.Message}") { StatusCode = 500 };
            }
        }

        public async Task<ActionResult> ObterPelaId(long idFornecedor)
        {
            try
            {
                var fornecedor = await _context.Fornecedores
                                               .FirstOrDefaultAsync(f => f.Id == idFornecedor);
                bool fornecedorNaoEncontrado = fornecedor == null;

                if (fornecedorNaoEncontrado)
                {
                    return new NotFoundResult();
                }

                var fornecedorResponse = new FornecedorResponse
                {
                    Id = fornecedor.Id,
                    Razao = fornecedor.RazaoSocial,
                    Cnpj = fornecedor.Cnpj,
                    Telefone = fornecedor.Telefone,
                    Email = fornecedor.Email,
                };

                return new OkObjectResult(fornecedorResponse);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Erro interno: {ex.Message}") { StatusCode = 500 };
            }
        }
    }
}