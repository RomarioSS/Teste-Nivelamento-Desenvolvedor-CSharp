using Questao5.Domain.Entities;

namespace Questao5.Application.Queries
{
    public interface ITransactionQueryStore
    {
        float GetBalance(string checkingAccountId);
    }
}
