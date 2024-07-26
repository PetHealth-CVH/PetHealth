using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("tb_produtos")]
    public class Produto
    {
        [Column("id_produto")]
        [Key]
        public Guid Id { get; set; }

        [Column("nome")]
        [MaxLength(50)]
        public required string Nome { get; set; }

        [Column("descricao")]
        public required string Descricao { get; set; }

        [ForeignKey("Fornecedores")]
        [Column("id_fornecedor")] 
        public Guid FornecedorId {get; set;}
        
        public Fornecedor Fornecedor {get; set;}
    }
}