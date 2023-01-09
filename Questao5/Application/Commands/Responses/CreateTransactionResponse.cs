using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Questao5.Application.Commands.Responses
{
    public class CreateTransactionResponse
    {
        [Display(Name = "IdMovimento")]
        public string TransactionId { get; private set; }

        public CreateTransactionResponse(string transactionId)
        {
            TransactionId = transactionId;
        }
    }
}
