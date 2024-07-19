using System.Net;
using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.HttpRequests;
using Models;


namespace Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CredenciaisControllers : ControllerBase
    {
        private readonly PetHealthDbContext _contexto;
        // Este é o construtor da classe CredenciaisControllers, que recebe o contexto do banco de dados como parâmetro
        public CredenciaisControllers(PetHealthDbContext contexto)
        {
            _contexto = contexto;
        }
        // Rota "api/CredenciaisControllers/autenticarusuario"
        // Ele autentica um usuário com base nas credenciais fornecidas no objeto CredencialRequest
        [HttpPost("autenticarusuario")]
        public void AutenticarUsuario(CredencialRequest credencial) 
        {

        }

        // Rota "api/CredenciaisControllers/registrar"
        // Ele registra um novo usuário com base no objeto UsuarioRequest fornecido no corpo da requisição
        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(
            // Esse parâmetro representa a ficha de cadastro do usuário que 
            // será enviada no corpo da requisição [FromBody].
            [FromBody] UsuarioRequest registroUsuario
        )
        {
            // Esse techo de código representa o monitoramento do cadastro.
            var transacaoCadastro = await _contexto.Database.BeginTransactionAsync();

            try
            {
                // Nesse trecho do código é realizado o cadastro o endereço no banco de dados.
                var enderecos = new Endereco
                // Verificar CredencialRequest, não contém referência
                {
                            Rua = registroUsuario.Endereco.Rua,
                            Numero = registroUsuario.Endereco.Numero,
                            Complemento = registroUsuario.Endereco.Complemento,
                            Bairro = registroUsuario.Endereco.Bairro,
                            Cidade = registroUsuario.Endereco.Cidade,
                            Estado = registroUsuario.Endereco.Estado,
                            Cep = registroUsuario.Endereco.CEP
                };
                _contexto.Enderecos.Add(enderecos);
                // Após realizar o cadastro do endereço no banco de dados é necessário confirmar a operação.
                await _contexto.SaveChangesAsync();

                registroUsuario.Endereco.Id = enderecos.Id;

                var usuario = new Usuario

                {
                    Nome            = registroUsuario.Nome,
                    Sobrenome       = registroUsuario.Sobrenome,
                    EnderecoId      = registroUsuario.Endereco.Id
                };

                //Aguardando verificar erros
            }
        }
    }
}
   



