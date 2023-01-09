using MediatR;
using Questao5.Application.Commands;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;


namespace Questao5.Application.Handlers
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, CreateTransactionResponse>
    {
        private readonly ITransactionCommandStore _transactionCommandStore;

        public CreateTransactionCommandHandler(ITransactionCommandStore transactionCommandStore)
        {
            _transactionCommandStore = transactionCommandStore;
        }

        public async Task<CreateTransactionResponse> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Transaction transaction = new()
                {
                    CheckingAccountId = request.CheckingAccountId,
                    Id = request.RequestId,
                    TransactionDate = DateTime.UtcNow,
                    TransactionType = Enum.Parse<TransactionTypeEnum>(request.TransactionType),
                    Value = request.Value
                };

                _transactionCommandStore.Add(transaction);
            }
            catch (Exception)
            {
                throw;
            }

            return await Task.FromResult(new CreateTransactionResponse(request.RequestId));
        }
    }
}
