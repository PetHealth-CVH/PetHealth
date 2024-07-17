using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("tb_pedidos")]
    public class Pedidos 
    {
        [Key]
        [Column("id_pedidos")]
        public Guid Id {get; set;}

        [Column("data_pedido")]
        public DateTime data_pedido {get; set;}

        [Column("quantidade")]
        public int quantidade {get; set;}

        [Column("preco")]
        public double preco {get; set;}

        [ForeignKey("UsuarioId")]
        [Column("id_usuario")]
        public Guid UsuarioId {get; set;}
        public Usuario Usuario {get; set;}

        [ForeignKey("ProdutosId")]
        [Column("id_prosutos")]
        public Guid ProdutosId {get; set;}
        public Produtos produtos {get; set;}


    }
}