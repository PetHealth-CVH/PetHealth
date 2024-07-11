namespace Models

{
    public class Usuario
    {
        public int Id { get; set; } 
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Cpf { get; set; }
        public DateTime Data_cadastro { get; set; }
    }
}