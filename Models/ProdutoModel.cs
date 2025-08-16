using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("tb_produtos")]
    public class Produto
    {
        [Column("id_produtos")]
        [Key]
        public long Id { get; set; }

        [Column("nome_produto")]
        [MaxLength(50)]
        public required string Nome { get; set; }

        [Column("descricao")]
        public required string Descricao { get; set; }
        [Column("quantidade")]
        public required long Quantidade { get; set; }
        [Column("preco")]
        public required double Preco { get; set; }

        [ForeignKey("Fornecedores")]
        [Column("id_fornecedor")] 
        public long IdFornecedor {get; set;}
        
        public Fornecedor Fornecedor {get; set;}
    }
}