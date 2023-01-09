using Questao5.Application.Commands;
using Questao5.Application.Commands.Validators;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.CommandStore.Common;
using Questao5.Infrastructure.Database.CommandStore.Common.DatabaseQueries.Sqlite;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.CommandStore
{
    public class IdempotencyCommandStore : BaseCommandStore, IIdempotencyCommandStore
    {
        public IdempotencyCommandStore(DatabaseConfig databaseConfig) : base(databaseConfig)
        {
        }

        public void Add(Idempotency entity)
        {
            string query = IdempotencyQueries.Add(entity);

            Execute(query);
        }

        public void Update(Idempotency entity)
        {
            string query = IdempotencyQueries.Update(entity);

            Execute(query);
        }
    }
}
