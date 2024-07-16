using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models 
{
    [Table("tb_contato")]
    public class Contato
    {
        [Key]
        [Column("id_contato")]
        public Guid Id {get; set;}

        [Column("celular")]
        [MaxLength(14)]
        public int celular {get; set;}

        [Column("email")]
        [MaxLength(100)]
        public string Email {get; set;}
    }
}