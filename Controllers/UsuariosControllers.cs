using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosControllers : ControllerBase
    {
        [HttpGet("{id}")]
        public void UsuarioId(Guid id) 
        {

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
