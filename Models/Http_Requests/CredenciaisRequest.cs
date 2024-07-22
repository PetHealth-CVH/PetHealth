namespace Models.HttpRequests
{
    public class Credenciais
    {
        public Guid Id {get; set;}
        public required string Email {get; set;}
        public required string Senha {get; set;}
        public Guid UsuarioId {get; set;}
        public Usuario Usuario {get; set;}
    }
}