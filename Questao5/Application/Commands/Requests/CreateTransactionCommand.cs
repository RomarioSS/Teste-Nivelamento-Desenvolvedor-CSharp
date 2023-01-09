using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Questao5.Application.Commands.Responses;

namespace Questao5.Application.Commands.Requests
{
    public class CreateTransactionCommand : IRequest<CreateTransactionResponse>
    {
        [BindRequired]
        public string RequestId { get; private set; }

        [BindRequired]
        public string CheckingAccountId { get; private set; }

        [BindRequired]
        public decimal Value { get; private set; }

        [BindRequired]
        public string TransactionType { get; private set; }

        public CreateTransactionCommand(string requestId, string checkingAccountId, decimal value, string transactionType)
        {
            RequestId = requestId;
            CheckingAccountId = checkingAccountId;
            Value = value;
            TransactionType = transactionType;
        }
    }

}

