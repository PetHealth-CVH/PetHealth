using Microsoft.AspNetCore.Mvc;

using Contexts;
using Models;
using Models.HttpRequests;
using Models.HttpResponse;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly PetHealthDbContext _contexto;

        public ContasController(PetHealthDbContext contexto)
        {
            _contexto = contexto;
        }

        // POST: api/contas/cadastrar
        [HttpPost("cadastrar")]
        public ActionResult CadastrarUsuario([FromBody] UsuarioRequest cadastro)
        {
            var transacaoDeCadastro = _contexto.Database.BeginTransaction();

            try 
            {
                var endereco = new Endereco {
                    Cep = cadastro.Endereco.Cep,
                    Rua = cadastro.Endereco.Rua,
                    Complemento = cadastro.Endereco.Complemento,
                    Cidade = cadastro.Endereco.Cidade,
                    Estado = cadastro.Endereco.Estado,
                    Bairro = cadastro.Endereco.Bairro,
                    Numero = cadastro.Endereco.Numero
                };
                _contexto.Enderecos.Add(endereco);

                _contexto.SaveChanges();
                
                var usuario = new Usuario
                {
                    Nome = cadastro.Nome,
                    Sobrenome = cadastro.Sobrenome,
                    Cpf = cadastro.Cpf,
                    EnderecoId = endereco.Id
                };
                
                _contexto.Usuarios.Add(usuario);

                _contexto.SaveChanges();

                cadastro.Id = usuario.Id;

                var credencial = new Credencial
                {
                    Email = cadastro.Credencial.Email,
                    Senha = cadastro.Credencial.Senha,
                    UsuarioId = cadastro.Id
                };

                _contexto.Credenciais.Add(credencial);

                _contexto.SaveChanges();

                transacaoDeCadastro.Commit();

                return StatusCode(201, new { idUsuario = cadastro.Id });
            }
            catch (Exception)
            {
                transacaoDeCadastro.Rollback();

                return StatusCode(500);
            }
        }

        // GET: api/contas/{idUsuario}
        [HttpGet("{idUsuario}")]
        public ActionResult<UsuarioResponse> ObterContaPeloIdUsuario(Guid idUsuario)
        {
            try 
            {
                var usuario = _contexto.Usuarios
                                                .Include(tabelaUsuario => tabelaUsuario.Endereco)
                                                .FirstOrDefault(tabelaUsuario => tabelaUsuario.Id == idUsuario);
                bool usuarioNaoEncontrado = usuario == null;

                if(usuarioNaoEncontrado){
                    return NotFound();
                }

                return Ok(
                    new UsuarioResponse 
                    {
                        Id                  = usuario.Id,
                        Nome                = usuario.Nome,
                        Sobrenome           = usuario.Sobrenome,
                        Cpf                 = usuario.Cpf,
                        Endereco            = new EnderecoResponse
                        {
                            Cep             = usuario.Endereco.Cep,
                            Rua             = usuario.Endereco.Rua,
                            Bairro          = usuario.Endereco.Bairro,
                            Numero          = usuario.Endereco.Numero,
                            Complemento     = usuario.Endereco.Complemento,
                            Estado          = usuario.Endereco.Estado,
                            Cidade          = usuario.Endereco.Cidade

                        }
                    }
                );
                
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
