namespace Models.HttpRequests
{
    public class EnderecoRequest
    {
        public required string Estado {get; set;}
        public required string Bairro {get; set;}
        public required string Cidade {get; set;} 
        public required string Rua {get; set;}
        public required string Numero {get; set;}
        public required string Cep {get; set;}
        public string? Complemento {get; set;}
    }
    public class CredencialRequest
    {
        public required string Email {get; set;}
        public required string Senha {get; set;}
    }
    public class UsuarioRequest
    {
        public Guid Id {get; set;}
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Cpf { get; set; }
        public required CredencialRequest Credencial { get; set; }
        public required EnderecoRequest Endereco { get; set; }
    }
}