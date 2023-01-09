using Questao5.Domain.Entities;

namespace Questao5.Application.Commands
{
    public interface IIdempotencyCommandStore
    {
        void Add(Idempotency entity);

        void Update(Idempotency entity);
    }
}
