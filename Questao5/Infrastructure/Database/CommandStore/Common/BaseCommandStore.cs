using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Application.Commands.Common;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.CommandStore.Common
{
    public class BaseCommandStore : ICommandStore
    {
        private readonly DatabaseConfig databaseConfig;
        public BaseCommandStore(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }
        public void Execute(string command)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            connection.Execute(command);
        }
    }
}
