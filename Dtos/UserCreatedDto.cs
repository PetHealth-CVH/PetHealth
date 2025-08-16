namespace PetHealth.Dtos
{
    public class UserCreatedDto
    {
        public long UserId { get; set; }
    }
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public CredencialDTO Credencial { get; set; }
    }

    public class EnderecoDTO
    {
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
    }

    public class CredencialDTO
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
