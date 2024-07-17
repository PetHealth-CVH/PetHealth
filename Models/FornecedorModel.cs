using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Models 
{
    [Table("tb_fornecedores")]
    public class tb_fornecedores
    {
        [Key]
        [Column("id_fornecedor")]
        public Guid id { get; set; }
        [Required]
        [MaxLength(64)]
        [Column("razao")]
        public string Razao { get; set; }
        [Required]
        [MaxLength(14)]
        [Column("cnpj")]
        public string CNPJ { get; set; }
        [Required]
        [MaxLength(12)]
        [Column("telefone")]
        public string Telefone { get; set; }
        [Required]
        [MaxLength(128)]
        [Column("email")]
        public string Email { get; set; }
    }
}