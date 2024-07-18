using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosControllers : ControllerBase
    {
        // Rota "api/UsuariosControllers/{id}"
        // Ele retorna um objeto UsuarioResponse com informações do usuário com o ID fornecido
        [HttpGet("{id}")]
        public UsuarioResponse UsuarioId(Guid id)
        {
            return new UsuarioResponse
            {
                Id = 1,
                Nome = "Ana Júlia",
                Sobrenome = "Mantovani",
                Cpf = 12345678900,
                DataCadastro = DateTime.Now,
            }
        }

        // Rota "api/UsuariosControllers"
        // Ele recebe um objeto Usuario no corpo da solicitação e registra um novo usuário
        [HttpPost]
        public void Registrar([FromBody] Usuario usuario)
        {

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
}
