namespace Questao5.Application.Commands.Requests
{
    public class IdempotencyRequest
    {
        public string Body { get; set; }

        public string Query { get; set; }

        public string Path { get; set; }

        public string Host { get; set; }

        public string IsHttps { get; set; }
    }
}
