using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoControllers : ControllerBase
    {
        [HttpPost("AddContato")]
        public void AddContato([FromBody] ContatoRequest contato)
        {
            
        }
    }
}
