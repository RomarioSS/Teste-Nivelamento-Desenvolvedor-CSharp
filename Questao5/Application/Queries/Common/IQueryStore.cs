using Questao5.Domain.SeedWork;
using static Dapper.SqlMapper;


namespace Questao5.Application.Queries.Common
{
    public interface IQueryStore<T> where T : Entity
    {
        T QuerySingle(string query);
        T QueryFirstOrDefault(string query);
        IEnumerable<T> Query(string query);
    }
}
