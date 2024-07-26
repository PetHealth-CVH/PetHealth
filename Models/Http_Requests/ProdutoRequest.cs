namespace Models.HttpRequests 
{
    public class ProdutoRequest
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }   
        public required string Descricao { get; set; }
        public Guid? IdFornecedor { get; set; }
    }
}