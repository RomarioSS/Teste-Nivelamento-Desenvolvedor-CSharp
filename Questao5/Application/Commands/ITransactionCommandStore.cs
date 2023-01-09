
using Questao5.Domain.Entities;

namespace Questao5.Application.Commands
{
    public interface ITransactionCommandStore
    {
        void Add(Transaction entity);
    }
}
