using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Application.Queries.Common;
using Questao5.Domain.SeedWork;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.QueryStore.Common
{
    public class BaseQueryStore<T> : IQueryStore<T>, ICustomQueryStore, IDisposable where T : Entity
    {
        private readonly SqliteConnection _connection;

        public BaseQueryStore(DatabaseConfig databaseConfig)
        {
            _connection = new SqliteConnection(databaseConfig.Name);
        }
        public T QuerySingle(string query)
        {
            return _connection.QuerySingle<T>(query);
        }

        public T QueryFirstOrDefault(string query)
        {
            return _connection.QueryFirstOrDefault<T>(query);
        }

        public IEnumerable<T> Query(string query)
        {
            return _connection.Query<T>(query);
        }

        public float QueryFloat(string query)
        {
            return _connection.QueryFirstOrDefault<float>(query);
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
