using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Definição da classe
namespace Models 
{
    [Table("tb_contato")]
    public class Contato
    {
        [Key]
        [Column("id_contato")]
        public Guid Id {get; set;}

        // Mapeia suas propriedades para colunas em uma tabela de banco de dados.
        [Column("celular")]
        [MaxLength(14)]
        public string celular {get; set;}

        [ForeignKey("email")]
        [Column("email")]
        [MaxLength(100)]
        public string Email {get; set;}
        public Credencial email {get; set;}      
    }
}