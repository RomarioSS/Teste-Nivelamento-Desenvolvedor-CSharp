using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.CommandStore.Common.DatabaseQueries.Sqlite
{
    public static class IdempotencyQueries
    {
        public static string Add(Idempotency entity) =>
            $@"INSERT INTO idempotencia (chave_idempotencia, requisicao, resultado)
               VALUES('{entity.Key}','{entity.Request}','{entity.Response}')";

        public static string Update(Idempotency entity) =>
            $@"UPDATE idempotencia
               SET requisicao='{entity.Request}', resultado='{entity.Response}'
               WHERE chave_idempotencia='{entity.Key}'";
    }
}
