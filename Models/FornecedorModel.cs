using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models 
{
    [Table("tb_fornecedores")]
    public class Fornecedor
    {
        [Key]
        [Column("id_fornecedor")]
        public long Id { get; set; }

        [Required]
        [MaxLength(64)]
        [Column("razao")]
        public string RazaoSocial { get; set; }
        
        [Required]
        [MaxLength(14)]
        [Column("cnpj")]
        public string Cnpj { get; set; }

        [Required]
        [MaxLength(12)]
        [Column("telefone")]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(128)]
        [Column("email")]
        public string Email { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}