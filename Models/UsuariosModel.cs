namespace Models

{
    public class Usuario
    {
        public int Id { get; set; } 
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required long Cpf { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}