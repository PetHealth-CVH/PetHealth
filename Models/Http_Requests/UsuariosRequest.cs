namespace Models.HttpRequests
{

    public class Endereco

    public class Endereco 

    {
        public required string Estado {get; set;}
        public required string Bairro {get; set;}
        public required string Cidade {get; set;} 
        public required string Rua {get; set;}
        public required string Numero {get; set;}
        public required string CEP {get; set;}
        public string? Complemento {get; set;}

        public string CEP {get; set;}
        public string Complemento {get; set;}

    }
    public class Credencial
    {
        public required string Email {get; set;}
        public required string Senha {get; set;}
    }
    public class UsuarioRequest
    {
        public required long Cpf { get; set; }
        public DateTime DataCadastro { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required Credencial Credencial { get; set; }
        public required Endereco Endereco { get; set; }
    }
}