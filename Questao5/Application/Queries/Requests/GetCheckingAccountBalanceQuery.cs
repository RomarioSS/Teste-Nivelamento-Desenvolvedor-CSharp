using MediatR;
using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Requests
{
    public class GetCheckingAccountBalanceQuery : IRequest<GetCheckingAccountBalanceResponse>
    {
        public string CheckingAccountId { get; set; }

        public GetCheckingAccountBalanceQuery(string checkingAccountId)
        {
            CheckingAccountId = checkingAccountId;
        }
    }
}
