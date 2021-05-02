namespace ConsoleApp.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        /// <summary>
        /// CPF/CNPJ
        /// </summary>
        public string Documento { get; set; }
        public int CidadeId { get; set; }
        
        // Navegação pela foreign key
        public Cidade Cidade { get; set; }
    }
}