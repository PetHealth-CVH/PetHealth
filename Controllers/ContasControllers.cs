using Microsoft.AspNetCore.Mvc;
using Contexts;
using Models;
using Models.HttpRequests;
using Models.HttpResponse;
using Microsoft.EntityFrameworkCore;
using PetHealth.Dtos;
using Microsoft.Exchange.WebServices.Data;
using PetHealth.Services.Abstracts;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;

        public ContasController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        // POST: api/contas/cadastrar
        [HttpPost("cadastrar")]

        public async Task<ActionResult> RegistrarUsuario([FromBody] UsuarioDTO usuarioDto)
        {
            return await _usuarioServices.RegistrarUsuario(usuarioDto);
        }

        // GET: api/contas/{idUsuario}
        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<UsuarioResponse>> ConsultarUsuario(long idUsuario)
        {
            return await _usuarioServices.ConsultarUsuario(idUsuario);
        }


    }
}
