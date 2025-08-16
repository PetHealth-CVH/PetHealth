using Microsoft.AspNetCore.Mvc;
using PetHealth.Dtos;

namespace PetHealth.Services.Abstracts
{
    public interface IUsuarioServices
    {
        Task<ActionResult> RegistrarUsuario([FromBody]UsuarioDTO usuarioDto);
        Task<ActionResult> ConsultarUsuario(long idUsuario);
        Task<ActionResult> Login(CredencialDTO credencialDTO);
    }
}
