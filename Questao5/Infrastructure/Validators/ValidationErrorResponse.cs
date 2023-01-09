namespace Questao5.Infrastructure.Validators
{
    public class ValidationErrorResponse
    {
        public string Titulo { get; set; }

        public List<ErrorDetails> Erros { get; set; } = new List<ErrorDetails>();

        public class ErrorDetails
        {
            public string Propriedade { get; set; }

            public string Mensagem { get; set; }

            public string Codigo { get; set; }
        }
    }
}
