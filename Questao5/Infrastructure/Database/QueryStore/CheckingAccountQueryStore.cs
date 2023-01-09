using Questao5.Application.Commands;
using Questao5.Application.Queries;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.CommandStore.Common;
using Questao5.Infrastructure.Database.CommandStore.Common.DatabaseQueries.Sqlite;
using Questao5.Infrastructure.Database.QueryStore.Common;
using Questao5.Infrastructure.Database.QueryStore.Common.DatabaseQueries.Sqlite;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.QueryStore
{
    public class CheckingAccountQueryStore : BaseQueryStore<CheckingAccount>, ICheckingAccountQueryStore
    {
        public CheckingAccountQueryStore(DatabaseConfig databaseConfig) : base(databaseConfig)
        {
        }

        public CheckingAccount Get(string checkingAccountId)
        {
            string query = Common.DatabaseQueries.Sqlite.CheckingAccountQueries.GetById(checkingAccountId);

            var result = QueryFirstOrDefault(query);

            return result;
        }
    }
}
