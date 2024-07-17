namespace Models.HttpRequests
{
     public class EnderecoRequest
    {
        public required string Estado {get; set;}
        public required string Bairro {get; set;}
        public required string Cidade {get; set;} 
        public required string Rua {get; set;}
        public required string Numero {get; set;}
        public required string CEP {get; set;}
        public required string Complemento {get; set;}

    }
}