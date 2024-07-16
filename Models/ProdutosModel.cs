using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{

    [Table("tb_produtos")]
    public class Produtos
    {

        [Column("id_produtos")]
        [Key]
        public Guid? Id { get; set; }

        [Column("nome_produto")]
        [MaxLength(50)]
        public required string Nome_Produto { get; set; }

        [Column("descricao")]
        
        public required string Descricao { get; set; }

        [Column("quantidade")]
        public required int Quantidade { get; set; }

        [Column("preco")]
        public required double Preco { get; set; }

    }
}