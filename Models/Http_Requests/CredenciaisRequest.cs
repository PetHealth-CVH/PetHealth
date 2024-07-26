namespace Models.HttpRequests
{
    public class CredenciaisRequest
    {
        public Guid Id {get; set;}
        public required string Email {get; set;}
        public string? Celular {get; set;}
        public required string Senha {get; set;}
        public Guid UsuarioId {get; set;}
        public Usuario Usuario {get; set;}
        public Endereco endereco { get; set; }
    }
}