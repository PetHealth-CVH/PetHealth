using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Definição da classe
namespace Models
{
    [Table("tb_enderecos")]
    public class Endereco
    {
        [Key]
        [Column("id_endereco")]
        public long Id { get; set; }

        [Column("estado")]
        public required string Estado { get; set; }

        [Column("bairro")]
        public required string Bairro { get; set; }

        [Column("cidade")]
        public required string Cidade { get; set; } 

        [Column("rua")]
        public required string Rua { get; set; }

        [Column("numero")]
        public required string Numero { get; set; }

        [Column("cep")]
        [MaxLength(8)]
        public required string Cep { get; set; }

        [Column("complemento")]
        [MaxLength(200)]
        public string? Complemento { get; set; }
        public Usuario Usuario { get; set; }
    }
}