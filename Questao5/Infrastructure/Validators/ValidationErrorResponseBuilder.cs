using FluentValidation.Results;

namespace Questao5.Infrastructure.Validators
{
    public class ValidationErrorResponseBuilder
    {
        public static ValidationErrorResponse Build(ValidationResult validationResult)
        {
            ValidationErrorResponse response = new();

            ValidationErrorResponse.ErrorDetails errorDetails;

            if (!validationResult.IsValid)
            {
                response.Titulo = "Um ou mais erros de validação ocorreram";

                List<ValidationFailure> errors = validationResult.Errors.ToList();

                foreach (var error in errors)
                {
                    errorDetails = new()
                    {
                        Mensagem = error.ErrorMessage,
                        Propriedade = error.PropertyName,
                        Codigo = error.ErrorCode
                    };

                    response.Erros.Add(errorDetails);
                }
            }

            return response;
        }
    }
}
