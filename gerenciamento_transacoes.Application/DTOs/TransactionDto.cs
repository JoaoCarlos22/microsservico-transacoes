namespace gerenciamento_transacoes.Application.DTOs
{
    public class TransactionDto
    {
        public string Id { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public string NameReceiver { get; set; }
        public string NameSender { get; set; }
        public DateTime DateOnly { get; set; }
    }
}