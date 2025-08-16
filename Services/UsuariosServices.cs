using Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.HttpResponse;
using PetHealth.Dtos;
using PetHealth.Services.Abstracts;
using System;
using System.Linq;
using System.Threading.Tasks;
using PetHealth.Utilities;

namespace PetHealth.Services
{
    public class UsuariosServices : IUsuarioServices
    {
        private readonly PetHealthDbContext _context;

        public UsuariosServices(PetHealthDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> RegistrarUsuario(UsuarioDTO usuarioDto)
        {

            if (usuarioDto == null)
            {
                return new BadRequestObjectResult("Usuario inválido.");
            }

            var UsuarioExiste = await _context.Usuarios
                .Where(u => u.Cpf == usuarioDto.Cpf)
                .FirstOrDefaultAsync();

            var EmailExiste = await _context.Usuarios
                .Where(u => u.Credencial.Email == usuarioDto.Credencial.Email)
                .FirstOrDefaultAsync();

            if (UsuarioExiste != null)
            {
                return new BadRequestObjectResult("Usuário existente com esse CPF!");
            }

            var usuario = new Usuario
            {
                Nome = usuarioDto.Nome,
                Sobrenome = usuarioDto.Sobrenome,
                Cpf = usuarioDto.Cpf,
                Endereco = new Endereco
                {
                    Estado = usuarioDto.Endereco.Estado,
                    Bairro = usuarioDto.Endereco.Bairro,
                    Cidade = usuarioDto.Endereco.Cidade,
                    Rua = usuarioDto.Endereco.Rua,
                    Numero = usuarioDto.Endereco.Numero,
                    Cep = usuarioDto.Endereco.Cep,
                    Complemento = usuarioDto.Endereco.Complemento
                },
                Credencial = new Credencial
                {
                    Email = usuarioDto.Credencial.Email,
                    Senha = PasswordHelper.HashPassword(usuarioDto.Credencial.Senha)
                }
            };

            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                var userDto = new UserCreatedDto
                {
                    UserId = usuario.Id,
                };


                return new OkObjectResult(userDto);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Erro interno: {ex.Message}") { StatusCode = 500};
            }
        }
        public async Task<ActionResult> ConsultarUsuario(long idUsuario)
        {
            try
            {
                var usuario = await _context.Usuarios
                                            .Include(u => u.Endereco)
                                            .FirstOrDefaultAsync(u => u.Id == idUsuario);
                bool usuarioNaoEncontrado = usuario == null;

                if (usuarioNaoEncontrado)
                {
                    return new NotFoundResult();
                }

                var usuarioResponse = new UsuarioResponse
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Sobrenome = usuario.Sobrenome,
                    Cpf = usuario.Cpf,
                    Endereco = new EnderecoResponse
                    {
                        Cep = usuario.Endereco.Cep,
                        Rua = usuario.Endereco.Rua,
                        Bairro = usuario.Endereco.Bairro,
                        Numero = usuario.Endereco.Numero,
                        Complemento = usuario.Endereco.Complemento,
                        Estado = usuario.Endereco.Estado,
                        Cidade = usuario.Endereco.Cidade

                    }
                };

                return new OkObjectResult(usuarioResponse);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Erro interno: {ex.Message}") { StatusCode = 500 };
            }
        }

        public async Task<ActionResult> Login(CredencialDTO credencialDTO)
        {
            var CredencialExiste = await _context.Credenciais
                .Where(c => c.Email == credencialDTO.Email )
                .Where(c => c.Senha == PasswordHelper.HashPassword(credencialDTO.Senha) )
                .FirstOrDefaultAsync();

            if (CredencialExiste == null)
            {
                return new BadRequestObjectResult("Email e ou senha incorretos.");
            }

            return new OkObjectResult("Usuário autenticado.");
        }
    }
}
