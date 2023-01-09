using Questao5.Application.Commands;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.CommandStore.Common;
using Questao5.Infrastructure.Database.CommandStore.Common.DatabaseQueries.Sqlite;
using Questao5.Infrastructure.Sqlite;


namespace Questao5.Infrastructure.Database.CommandStore
{
    public class TransactionCommandStore : BaseCommandStore, ITransactionCommandStore
    {
        public TransactionCommandStore(DatabaseConfig databaseConfig) : base(databaseConfig)
        {
        }

        public void Add(Transaction entity)
        {
            string query = TransactionQueries.Add(entity);

            Execute(query);
        }
    }
}
