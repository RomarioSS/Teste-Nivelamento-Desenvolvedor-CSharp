namespace Questao5.Infrastructure.Services.Controllers.Requests
{
    public class CreateTransactionRequest
    {
        public string TransactionId { get; set; }
        public string CheckingAccountId { get; set; }
        public float Value { get; set; }
        public string TransactionType { get; set; }
    }
}
