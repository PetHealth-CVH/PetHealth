namespace Models.HttpResponse
{
    public class ProdutosResponse
    {
        public required string Nome_Produto {get;set;}   
        public required string Descricao {get;set;}
        public required int Quantidade {get;set;}
        public required double Preco {get;set;}
    }
}