using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.CommandStore.Common.DatabaseQueries.Sqlite
{
    public static class TransactionQueries
    {
        public static string Add(Transaction transaction)
        {
            var value = transaction.Value.ToString().Replace(',', '.');
            return @$"INSERT INTO movimento (idcontacorrente, datamovimento, tipomovimento, valor)
               VALUES('{transaction.CheckingAccountId}', 
                      '{transaction.TransactionDate:yyyy-MM-dd}', 
                      '{transaction.TransactionType}', 
                       {value})";
        }

    }
}
