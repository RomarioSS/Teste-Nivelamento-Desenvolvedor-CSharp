namespace Questao5.Infrastructure.Database.QueryStore.Common.DatabaseQueries.Sqlite
{
    public class CheckingAccountQueries
    {
        public static string GetById(string checkingAccountId) =>
                @$"SELECT idcontacorrente AS Id, numero AS Number, nome AS Holder, ativo AS IsActive
                   FROM contacorrente
                   WHERE idcontacorrente='{checkingAccountId}'";
    }
}
