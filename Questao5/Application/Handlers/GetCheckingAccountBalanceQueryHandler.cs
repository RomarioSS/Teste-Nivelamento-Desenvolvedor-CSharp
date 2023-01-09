using MediatR;
using Questao5.Application.Queries;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.QueryStore;

namespace Questao5.Application.Handlers
{
    public class GetCheckingAccountBalanceQueryHandler : IRequestHandler<GetCheckingAccountBalanceQuery, GetCheckingAccountBalanceResponse>
    {
        private readonly TransactionQueryStore _transactionQueryStore;
        private readonly ICheckingAccountQueryStore _checkingAccountQueryStore;
        public GetCheckingAccountBalanceQueryHandler(
            TransactionQueryStore transactionQueryStore,
            ICheckingAccountQueryStore checkingAccountQueryStore)
        {
            _transactionQueryStore = transactionQueryStore;
            _checkingAccountQueryStore = checkingAccountQueryStore;
        }

        public async Task<GetCheckingAccountBalanceResponse> Handle(GetCheckingAccountBalanceQuery request, CancellationToken cancellationToken)
        {
            float balance;

            CheckingAccount account;

            GetCheckingAccountBalanceResponse response;

            try
            {
                balance = _transactionQueryStore.GetBalance(request.CheckingAccountId);

                account = _checkingAccountQueryStore.Get(request.CheckingAccountId);

                response = new GetCheckingAccountBalanceResponse
                (
                    accountNumber: account.Number,
                    holder: account.Holder,
                    requestTime: DateTime.Now,
                    balance: balance
                );
            }
            catch (Exception)
            {
                throw;
            }

            return await Task.FromResult(response);
        }
    }
}
