using Microsoft.AspNetCore.Mvc;
using PetHealth.Dtos;

namespace PetHealth.Services.Abstracts
{
    public interface IAuthServices
    {
        Task<ActionResult> Login([FromBody]CredencialDTO credencialDTO);
    }
}

