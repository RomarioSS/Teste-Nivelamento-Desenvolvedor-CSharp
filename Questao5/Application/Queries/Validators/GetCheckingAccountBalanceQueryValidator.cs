using FluentValidation;
using Questao5.Application.Queries.Requests;

namespace Questao5.Application.Queries.Validators
{
    public class GetCheckingAccountBalanceQueryValidator : AbstractValidator<GetCheckingAccountBalanceQuery>
    {
        private static ICheckingAccountQueryStore _checkingAccountQueryStore;

        public GetCheckingAccountBalanceQueryValidator(ICheckingAccountQueryStore checkingAccountQueryStore)
        {
            _checkingAccountQueryStore = checkingAccountQueryStore;

            RuleFor(x => x.CheckingAccountId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(IsValidCheckingAccount)
                .WithMessage("A conta deve ser válida")
                .WithErrorCode("INVALID_ACCOUNT")
                .Must(IsActiveCheckingAccount)
                .WithMessage("A conta deve estar ativa")
                .WithErrorCode("INACTIVE_ACCOUNT");
        }

        private static bool IsValidCheckingAccount(string checkingAccountId)
        {
            return _checkingAccountQueryStore.Get(checkingAccountId) == null ? false : true;
        }

        private static bool IsActiveCheckingAccount(string checkingAccountId)
        {
            return _checkingAccountQueryStore.Get(checkingAccountId).IsActive ? true : false;
        }
    }
}
