using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.HttpResponse;
using Models.HttpRequests;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosControllers : ControllerBase
    {
        // Rota "api/EnderecosControllers/{id}"
        // Ele retorna as informações de um endereço com base no ID fornecido
        private readonly PetHealthDbContext _contexto;

        public EnderecosControllers (PetHealthDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet("{idEndereco}")]

        public async Task<ActionResult<EnderecosResponse>> ObterProdutoPelaId(Guid id)

        {
            try
            {
                var Enderecos = await _contexto.Enderecos
                                .FirstOrDefaultAsync(tb_enderecos => tb_enderecos.Id == id);

                if (Enderecos == null)
                {
                    return NotFound();
                }

                new EnderecosResponse
                {
                            Rua = Enderecos.Rua,
                            Numero = Enderecos.Numero,
                            Complemento = Enderecos.Complemento,
                            Bairro = Enderecos.Bairro,
                            Cidade = Enderecos.Cidade,
                            Estado = Enderecos.Estado,
                            CEP = Enderecos.CEP
                };

                return Ok(Enderecos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Não foi possível realizar a consulta.");
            }
        }

        // Rota "api/EnderecosControllers/{id}"
        // Ele atualiza as informações de um endereço com base no ID fornecido
        [HttpPut("{id}")]
        public async Task<IActionResult>AtualizarPorId(Guid id, [FromBody] EnderecoRequest enderecoAtualizado)
        {
            if (enderecoAtualizado == null)
            {
                return BadRequest("O corpo da requisição não pode estar vazio");
            }
            var EnderecoBusca = await _contexto.Enderecos.FindAsync(id);
            if (EnderecoBusca == null)
            {
                return NotFound("Endereço não encontrado.");
            }

            // Atualiza os dados de endereço do usuário
            EnderecoBusca.Estado = enderecoAtualizado.Estado;
            EnderecoBusca.Bairro = enderecoAtualizado.Bairro;
            EnderecoBusca.Cidade = enderecoAtualizado.Cidade;
            EnderecoBusca.Rua = enderecoAtualizado.Rua;
            EnderecoBusca.Numero = enderecoAtualizado.Numero;
            EnderecoBusca.CEP = enderecoAtualizado.CEP;
            EnderecoBusca.Complemento = enderecoAtualizado.Complemento;

            // Salva as mudanças
            _contexto.Entry(enderecoAtualizado).State = EntityState.Modified;

            return NoContent(); // 204 No Content
        }
    }
}
