using Microsoft.AspNetCore.Mvc;
using Models;
using Models.HttpRequests;
using Models.HttpResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosControllers : ControllerBase
    {
        private static List<UsuarioRequest> registrosUsuarios = new List<UsuarioRequest>();

        // Construtor sem DbContext
        public UsuariosControllers()
        {
        }

        [HttpGet("{idUsuarioQueEstaBuscando}")]
        public ActionResult<UsuariosResponse> ObterPeloId(Guid idUsuarioQueEstaBuscando)
        {
            var usuarioQueEstaBuscando = registrosUsuarios.FirstOrDefault(u => u.Id == idUsuarioQueEstaBuscando);

            if (usuarioQueEstaBuscando == null)
            {
                return NotFound();
            }

            var enderecoResponse = new Enderecos
            {
                // Preencher com dados fictícios ou de outra fonte
                Id = Guid.NewGuid(),
                Rua = "Rua Exemplo",
                Numero = "123",
                Complemento = "Apto 1",
                Bairro = "Bairro Exemplo",
                Cidade = "Cidade Exemplo",
                Estado = "Estado Exemplo",
                CEP = "00000-000"
            };

            var usuarioResponse = new UsuariosResponse
            {
                Id = usuarioQueEstaBuscando.Id,
                Nome = usuarioQueEstaBuscando.Nome,
                Sobrenome = usuarioQueEstaBuscando.Sobrenome,
                Enderecos = enderecoResponse
            };

            return Ok(usuarioResponse);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPorId(Guid id, [FromBody] UsuarioRequest request)
        {
            if (request == null)
            {
                return BadRequest("O corpo da requisição não pode estar vazio.");
            }

            var usuarioQueEstaBuscando = registrosUsuarios.FirstOrDefault(u => u.Id == id);
            if (usuarioQueEstaBuscando == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            // Atualize os campos do usuário existente com os dados do request
            usuarioQueEstaBuscando.Nome = request.Nome;
            usuarioQueEstaBuscando.Sobrenome = request.Sobrenome;
            usuarioQueEstaBuscando.Cpf = request.Cpf;

            return NoContent(); // 204 No Content
        }

        [HttpPost("registrar")]
        public IActionResult Registrar([FromBody] UsuarioRequest registroUsuario)
        {
            if (registroUsuario == null)
            {
                return BadRequest();
            }

            registroUsuario.Id = Guid.NewGuid();
            registrosUsuarios.Add(registroUsuario);

            return CreatedAtAction(nameof(ObterPeloId), new { idUsuarioQueEstaBuscando = registroUsuario.Id }, registroUsuario);
        }
    }
}
