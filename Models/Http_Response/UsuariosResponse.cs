namespace Models.HttpResponse
{
        public class UsuariosResponse
    {
        public required Guid Id {get;set;}
        public required string Nome {get;set;}
        public required string Sobrenome {get;set;}
        public required EnderecoResponse Endereco {get;set;}
    }
    public class EnderecoResponse 
    {
        public Guid Id {get; set;}
        public required string rua {get;set;}
        public required string numero {get;set;}
        public required string complemento {get;set;}
        public required string bairro {get;set;}
        public required string municipio {get;set;}
        public required string estado {get;set;}
        public required int CEP {get;set;}
        public required string cidade {get;set;}
    }

   
}