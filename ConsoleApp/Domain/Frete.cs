namespace ConsoleApp.Domain
{
    public class Frete
    {
        public int Id { get; set; }
        public int RemetenteId { get; set; }
        public int DestinatarioId { get; set; }
        public decimal Valor { get; set; }
        
        // Navegação pela foreign key
        public Cliente Remetente { get; set; }
        public Cliente Destinatario { get; set; }
    }
}