namespace Models.HttpResponse
{
    public class UsuarioResponse
    {
        public required Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Cpf { get; set; }
        public required EnderecoResponse Endereco { get; set; }
    }

    public class EnderecoResponse
    {
        public Guid Id { get; set; }
        public required string Rua { get; set; }
        public required string Numero { get; set; }
        public required string Complemento { get; set; }
        public required string Bairro { get; set; }
        public required string Estado { get; set; }
        public required string Cep { get; set; }
        public required string Cidade { get; set; }
    }
}