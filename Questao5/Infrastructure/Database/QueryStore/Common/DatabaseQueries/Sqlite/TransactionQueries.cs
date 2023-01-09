namespace Questao5.Infrastructure.Database.QueryStore.Common.DatabaseQueries.Sqlite
{
    public class TransactionQueries
    {
        public static string GetBalanceByCheckingAccountId(string checkingAccountId) =>
          @$"SELECT ROUND(
                    COALESCE((SELECT SUM(valor) FROM movimento WHERE tipomovimento='C' AND idcontacorrente='{checkingAccountId}'), 0) - 
                    COALESCE((SELECT SUM(valor) FROM movimento WHERE tipomovimento='D' AND idcontacorrente='{checkingAccountId}'), 0), 2)";
    }
}
