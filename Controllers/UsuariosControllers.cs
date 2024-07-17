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
        [HttpPost]
        public void Registrar([FromBody] Usuario usuario)
        {

        }
        [HttpPut("{id}")]
        public void AtualizarPorId(Guid id)
        {

        }
        [HttpDelete("{id}")]
        public void DeletarPorId(Guid id)
        {

        }
    }
}
