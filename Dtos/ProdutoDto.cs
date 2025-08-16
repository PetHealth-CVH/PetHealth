namespace PetHealth.Dtos
{
    public class ProdutoCreatedDto
    {
        public long ProdId { get; set; }
    }
    public class ProdutoDto
    {
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public long Quantidade { get; set; }
        public double Preco { get; set; }
        public long IdFornecedor { get; set; }
    }
}
