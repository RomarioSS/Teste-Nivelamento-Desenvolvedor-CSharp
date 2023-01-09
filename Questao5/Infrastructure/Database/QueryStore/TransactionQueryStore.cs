using Questao5.Application.Queries;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.QueryStore.Common;
using Questao5.Infrastructure.Sqlite;
using Questao5.Infrastructure.Database.QueryStore.Common.DatabaseQueries.Sqlite;

namespace Questao5.Infrastructure.Database.QueryStore
{
    public class TransactionQueryStore : BaseQueryStore<Transaction>, ITransactionQueryStore
    {
        public TransactionQueryStore(DatabaseConfig databaseConfig) : base(databaseConfig)
        {
        }

        public float GetBalance(string checkingAccountId)
        {
            string query = TransactionQueries.GetBalanceByCheckingAccountId(checkingAccountId);

            var balance = QueryFloat(query);

            return balance;
        }
    }
}
