using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// Definição da classe
namespace Models
{
    [Table("tb_pedidos")]
    public class Pedido 
    {
        [Key]
        [Column("id_pedido")]
        public Guid Id {get; set;}

        // Propriedades da classe
        [Column("data_pedido")]
        public DateTime Data {get; set;}

        [Column("quantidade")]
        public int Quantidade {get; set;}

        [Column("preco")]
        public double Preco {get; set;}

        // Relacionamentos da tb_pedidos = tb_usuario.id_usuario
        [ForeignKey("UsuarioId")]
        [Column("id_usuario")]
        public Guid UsuarioId {get; set;}

        [ForeignKey("ProdutoId")]
        [Column("id_produto")]
        public Guid ProdutoId {get; set;}
        
        public required Usuario Usuario {get; set;}
        public IEnumerable<Produto> Produtos {get; set;}
    }
}