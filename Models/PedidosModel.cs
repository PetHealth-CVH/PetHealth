using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// Definição da classe
namespace Models
{
    [Table("tb_pedidos")]
    public class Pedidos 
    {
        [Key]
        [Column("id_pedidos")]
        public Guid Id {get; set;}

        // Propriedades da classe
        [Column("data_pedido")]
        public DateTime data_pedido {get; set;}

        [Column("quantidade")]
        public int quantidade {get; set;}

        [Column("preco")]
        public double preco {get; set;}

        // Relacionamentos da tb_pedidos = tb_usuario.id_usuario
        [ForeignKey("UsuarioId")]
        [Column("id_usuario")]
        public Guid UsuarioId {get; set;}
        public Usuario usuario {get; set;}

        [ForeignKey("ProdutosId")]
        [Column("id_produtos")]
        public Guid ProdutosId {get; set;}
        public Produtos produtos {get; set;}

    }
}