using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Definição da classe
namespace Models
{
    [Table("tb_enderecos")]
    public class Endereco
    {
        [Key]
        [Column("id_enderecos")]
        public Guid Id {get; set;}

        // Mapeia suas propriedades para colunas em uma tabela de banco de dados.
        [Column("estado")]
        public required string Estado {get; set;}

        [Column("bairro")]
        public required string Bairro {get; set;}

        [Column("cidade")]
        public required string Cidade {get; set;} 

        [Column("rua")]
        public required string Rua {get; set;}

        [Column("numero")]
        public required string Numero {get; set;}


        [Column("cep")]
        [MaxLength(8)]
        public string CEP {get; set;}

        [Column("complemento")]
        [MaxLength(200)]
        public string Complemento {get; set;}

    }
}