using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetHealth.Dtos
{
    public class FornecedorCreatedDto
    {
        public long ForId { get; set; }
    }
    public class FornecedorDto
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
