using Questao5.Application.Commands.Requests;
using FluentValidation;
using Questao5.Application.Queries;
using Questao5.Domain.Enumerators;

namespace Questao5.Application.Commands.Validators
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        private static ICheckingAccountQueryStore _checkingAccountQueryStore;

        public CreateTransactionCommandValidator(ICheckingAccountQueryStore checkingAccountQueryStore)
        {
            _checkingAccountQueryStore = checkingAccountQueryStore;

            RuleFor(x => x.CheckingAccountId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(IsValidCheckingAccount)
                .WithMessage("A conta deve ser válida")
                .WithErrorCode("INVALID_ACCOUNT")
                .Must(IsEnabledCheckingAccount)
                .WithMessage("A conta deve estar ativa")
                .WithErrorCode("INACTIVE_ACCOUNT");

            RuleFor(x => x.Value)
                .GreaterThan(0)
                .WithMessage("O valor deve ser positivo")
                .WithErrorCode("INVALID_VALUE");

            RuleFor(x => x.TransactionType)
                .IsEnumName(typeof(TransactionTypeEnum))
                .WithMessage("Somente os tipos crédito (C) ou débito (D) são aceitos")
                .WithErrorCode("INVALID_TYPE");
        }
        private static bool IsValidCheckingAccount(string checkingAccountId)
        {
            return _checkingAccountQueryStore.Get(checkingAccountId) == null ? false : true;
        }

        private static bool IsEnabledCheckingAccount(string checkingAccountId)
        {
            return _checkingAccountQueryStore.Get(checkingAccountId).IsActive ? true : false;
        }
    }
}
