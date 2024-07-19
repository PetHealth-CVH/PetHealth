using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Controllers;

// Definição da classe
namespace Models
{

    [Table("tb_produtos")]
    public class Produtos
    {

        [Column("id_produtos")]
        [Key]
        public Guid? Id { get; set; }

        // Mapeia suas propriedades para colunas em uma tabela de banco de dados.
        [Column("nome_produto")]
        [MaxLength(50)]
        public required string Nome_Produto { get; set; }

        [Column("descricao")]
        public required string Descricao { get; set; }

        [Column("quantidade")]
        public required int Quantidade { get; set; }

        [Column("preco")]
        public required double Preco { get; set; }

        [ForeignKey("tb_fornecedores")]
        [Column("id_fornecedor")] 

        public Guid ForncedorId {get; set;}
        public tb_fornecedores Fornecedores {get; set;}
    }
}