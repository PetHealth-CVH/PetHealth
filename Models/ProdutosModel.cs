namespace Models
{
    public class Produtos
    {
        public Guid? Id { get; set; }
        public required string NomeProduto { get; set; }
        public required string Descricao { get; set; }
        public required int Quantidade { get; set; }
        public required double Preco { get; set; }

    }
}