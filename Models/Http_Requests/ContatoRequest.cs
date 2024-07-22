namespace Models.HttpRequests
{
    public class ContatoRequest
    {
        public Guid Id {get; set;}
        public string celular {get; set;}
        public string Email {get; set;}
        public Credencial email {get; set;}    
    }
}