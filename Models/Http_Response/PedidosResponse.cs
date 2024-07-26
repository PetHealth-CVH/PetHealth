namespace Models.HttpResponse
{
    public class PedidosResponse
    {
        public required Guid Id {get;set;}
        public DateTime data_pedido {get; set;}
        public int quantidade {get; set;}
        public double preco {get; set;} 
    }
}