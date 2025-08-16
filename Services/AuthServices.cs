using Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using PetHealth.Dtos;
using PetHealth.Services.Abstracts;
using PetHealth.Utilities;

namespace PetHealth.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly PetHealthDbContext _context;

        // Construtor
        public AuthServices(PetHealthDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Login([FromBody]CredencialDTO credencialDTO)
        {
            var credencialExiste = await _context.Credenciais
                .Include(c => c.Usuario)
                .Where(c => c.Email == credencialDTO.Email)
                .Where(c => c.Senha == PasswordHelper.HashPassword(credencialDTO.Senha))
                .FirstOrDefaultAsync();

            if (credencialExiste == null)
            {
                return new BadRequestObjectResult("Credenciais inválidas!");
            }

            // Gera um token
            var token = Guid.NewGuid().ToString();

            // Armazena o token no banco
            if (credencialExiste.Usuario != null)
            {
                credencialExiste.Usuario.Token = token;
                await _context.SaveChangesAsync();
            }

            return new OkObjectResult(new { token });
        }
    }
}