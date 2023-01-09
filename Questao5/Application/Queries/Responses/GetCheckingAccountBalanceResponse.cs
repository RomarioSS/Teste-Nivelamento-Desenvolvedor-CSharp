namespace Questao5.Application.Queries.Responses
{
    public class GetCheckingAccountBalanceResponse
    {
        public int AccountNumber { get; private set; }

        public string Holder { get; private set; }

        public DateTime RequestTime { get; private set; }

        public string Balance { get; private set; }
        public GetCheckingAccountBalanceResponse(int accountNumber, string holder, DateTime requestTime, float balance)
        {
            AccountNumber = accountNumber;
            Holder = holder;
            RequestTime = requestTime;
            Balance = balance.ToString("N2");
        }
    }
}
