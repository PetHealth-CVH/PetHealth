using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
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
                            Cep = Enderecos.CEP
                };

                return Ok(EnderecosResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, "Não foi possível realizar a consulta.");
            }
        }


        // Rota "api/EnderecosControllers"
        // Ele cria um novo endereço com base no objeto Enderecos fornecido no corpo da requisição
        [HttpPost]
        public void Registrar([FromBody] Endereco enderecos)
        {

        }

        // Rota "api/EnderecosControllers/{id}"
        // Ele atualiza as informações de um endereço com base no ID fornecido
        [HttpPut("{id}")]
        public void AtualizarEnderecoId(Guid id)
        {

        }
        
        // Rota "api/EnderecosControllers/{id}"
        // Ele exclui um endereço com base no ID fornecido
        [HttpDelete("{id}")]
        public void DeletarEnderecoId(Guid id)
        {
            
        }
    }
}
