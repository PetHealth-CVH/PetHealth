using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.HttpRequests;
using Models.HttpResponse;

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

        [HttpGet("{idFornecedor}")]

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


        // Rota "api/EnderecosControllers"
        // Ele cria um novo endereço com base no objeto Enderecos fornecido no corpo da requisição
        [HttpPost]
        public void Registrar([FromBody] EnderecosControllers enderecos)
        {

        }

        // Rota "api/EnderecosControllers/{id}"
        // Ele atualiza as informações de um endereço com base no ID fornecido
        [HttpPut("{id}")]
        public async Task<IActionResult>AtualizarEPorId(Guid id, [FromBody] EnderecosRequest request)
        {
            if (request == null)
            {
                return BadRequest("O corpo da requisição não pode estar vazio")
            }
            var EnderecoBusca = await _contexto.Enderecos.FindAsync(id);
            if (EnderecoBusca == null)
            {
                return NotFound("Endereço não encontrado.");
            }

            // Atualiza os dados de endereço do usuário
            EnderecoBusca.Estado = request.Estado;
            EnderecoBusca.Bairro = request.Bairro;
            EnderecoBusca.Cidade = request.Cidade;
            EnderecoBusca.Rua = request.Rua;
            EnderecoBusca.Numero = request.Numero;
            EnderecoBusca.CEP = request.CEP;
            EnderecoBusca.Complemento = request.Complemento;

            // Salva as mudanças
            var resultado = await _contexto.AtualizarEPorId(EnderecoBusca);

            if (!resultado)
            {
                return StatusCode(500, "Ocorreu um  problema ao atualizar o endereço.")
            }

            return NoContent(); // 204 No Content
        }
    }
}
