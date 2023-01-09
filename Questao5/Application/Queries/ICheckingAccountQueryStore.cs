using Questao5.Domain.Entities;

namespace Questao5.Application.Queries
{
    public interface ICheckingAccountQueryStore
    {
        CheckingAccount Get(string checkingAccountId);
    }
}
