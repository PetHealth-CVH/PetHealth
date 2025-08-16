namespace Models.HttpRequests
{
    public class FornecedorRequest
    {
        public long Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}