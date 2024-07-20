using Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.HttpResponse;

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
                            Cep = usuarioQueEstaBuscando.Endereco.CEP
                        }
                    }
                );
            }
            catch (Exception)
            {
                return StatusCode(500, "Não foi possível realizar a consulta.");
            }

        }

    }
    // Rota "api/UsuariosControllers/{id}"
    // Ele atualiza as informações do usuário com o ID fornecido 
    [HttpPut("{id}")]
    public void AtualizarPorId(Guid id)
    {

    }

    // Rota "api/UsuariosControllers/{id}"
    // Ele deleta o usuário com o ID fornecido
    [HttpDelete("{id}")]
    public void DeletarPorId(Guid id)
    {

    }
}

