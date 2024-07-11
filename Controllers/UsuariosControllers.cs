using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosControllers : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Usuario> SolicitarUsuarios()
        {

            List<Usuario> usuarios = new List<Usuario> {
                new Usuario 
                {
                    Id = 1,
                    Nome = "Ana Júlia",
                    Sobrenome = "Mantovani",
                    Cpf = 12345678900,
                    DataCadastro = DateTime.Now,
                },
                new Usuario 
                {
                    Id = 2,
                    Nome = "Victor",
                    Sobrenome = "Padilha",
                    Cpf = 98765432100,
                    DataCadastro = DateTime.Now,
                }
            };

            return usuarios;
        }
    }
}
