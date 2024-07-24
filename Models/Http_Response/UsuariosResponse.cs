namespace Models.HttpResponse
{
    public class UsuariosResponse
    {
        public required Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required Enderecos Enderecos { get; set; }
    }

    public class Enderecos
    {
        public Guid Id { get; set; }
        public required string Rua { get; set; }
        public required string Numero { get; set; }
        public required string Complemento { get; set; }
        public required string Bairro { get; set; }
        public required string Estado { get; set; }
        public required string CEP { get; set; }
        public required string Cidade { get; set; }
    }
}