using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Models.HttpResponse;
using Models;
using Models.HttpRequests;



namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosControllers : ControllerBase
    {
        private readonly PetHealthDbContext _contexto;
        public UsuariosControllers(PetHealthDbContext contexto)
        {
            _contexto = contexto;
        }
        // Rota "api/UsuariosControllers/{id}"
        // Ele retorna um objeto UsuarioResponse com informações do usuário com o ID fornecido
        [HttpGet("{idUsuarioQueEstaBuscando}")]
        public async Task<ActionResult<UsuariosResponse>> ObterPelaId(Guid idUsuarioQueEstaBuscando)
        {
            try
            {
                var usuarioQueEstaBuscando = await _contexto.Usuarios
                    .Include(tb_usuarios => tb_usuarios.Endereco)
                    .FirstOrDefaultAsync(tb_usuarios => tb_usuarios.Id == idUsuarioQueEstaBuscando);

                bool usuarioNaoEncontrado = usuarioQueEstaBuscando == null;

                if (usuarioNaoEncontrado)
                {
                    return NotFound();
                }

                return Ok(

                    new UsuariosResponse

                    {
                        Id = usuarioQueEstaBuscando.Id,
                        Nome = usuarioQueEstaBuscando.Nome,
                        Sobrenome = usuarioQueEstaBuscando.Sobrenome,
                        Endereco = new EnderecosResponse

                        {
                            Rua = usuarioQueEstaBuscando.Endereco.Rua,
                            Numero = usuarioQueEstaBuscando.Endereco.Numero,
                            Complemento = usuarioQueEstaBuscando.Endereco.Complemento,
                            Bairro = usuarioQueEstaBuscando.Endereco.Bairro,
                            Cidade = usuarioQueEstaBuscando.Endereco.Cidade,
                            Estado = usuarioQueEstaBuscando.Endereco.Estado,
                            CEP = usuarioQueEstaBuscando.Endereco.CEP
                        }
                    }
                );
            }
            catch (Exception)
            {
                return StatusCode(500, "Não foi possível realizar a consulta.");
            }

        }

        // Rota "api/UsuariosControllers/{id}"
        // Ele atualiza as informações do usuário com o ID fornecido 

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPorId(Guid id, [FromBody] UsuarioRequest request)
        {
            if (request == null)
            {
                return BadRequest("O corpo da requisição não pode estar vazio.");
            }

            var usuarioQueEstaBuscando = await _contexto.Usuarios.FindAsync(id);
            if (usuarioQueEstaBuscando == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            // Atualize os campos do usuário existente com os dados do request
            usuarioQueEstaBuscando.Nome = request.Nome;
            usuarioQueEstaBuscando.Sobrenome = request.Sobrenome;
            usuarioQueEstaBuscando.Cpf = request.Cpf;
            

            // Salve as mudanças
            var resultado = await _contexto.AtualizarPorId(usuarioQueEstaBuscando);

            if (!resultado)
            {
                return StatusCode(500, "Ocorreu um problema ao atualizar o usuário.");
            }

            return NoContent(); // 204 No Content
        }
    }

}


