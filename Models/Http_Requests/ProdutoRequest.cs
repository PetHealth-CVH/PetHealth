namespace Models.HttpRequests 
{
    public class ProdutoRequest
    {
        public long Id { get; set; }
        public required string Nome { get; set; }   
        public required string Descricao { get; set; }
        public required long Quantidade { get; set; }
        public double Preco { get; set; }
        public long? IdFornecedor { get; set; }
    }
}