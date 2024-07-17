using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Definição da classe
namespace Models

{
    [Table("tb_usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public Guid Id {get; set;} 

        // Mapeia suas propriedades para colunas em uma tabela de banco de dados.
        [Column("nome")]
        [MaxLength(50)]
        public required string Nome { get; set; }

        [Column("sobrenome")]
        [MaxLength(50)]
        public required string Sobrenome { get; set; }

        [Column("cpf")]
        [MaxLength(11)]
        public required long Cpf { get; set; }

        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; }

        // Relacionamentos da tb_usuarios = tb_enderecos.id_enderecos
        [ForeignKey("Endereco")]
        [Column("id_endereco")]
        public Guid EnderecoId {get; set;}
        public Credencial Credencial {get; set;}
        public Endereco Endereco {get; set;}
    }
}