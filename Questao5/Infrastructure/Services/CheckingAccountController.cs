using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands;
using Questao5.Application.Queries;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Application.Queries.Validators;
using Questao5.Infrastructure.Validators;
using System.Net;

namespace Questao5.Infrastructure.Services
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/checking-account")]
    public class CheckingAccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private ICheckingAccountQueryStore _checkingAccountQueryStore;

        public CheckingAccountController(IMediator mediator,
            ICheckingAccountQueryStore checkingAccountQueryStore)
        {
            _mediator = mediator;
            _checkingAccountQueryStore = checkingAccountQueryStore;
        }

        /// <summary>
        /// Retorna o saldo da conta corrente.
        /// </summary>
        /// <param name="id">O identificador da conta corrente.</param>
        /// <returns></returns>
        /// <response code="200">A conta corrente foi obtida com sucesso.</response>
        /// <response code="400">A requisicao esta malformada ou inválida.</response>
        [HttpGet("{id}/balance")]
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<GetCheckingAccountBalanceResponse>> GetBalance([FromRoute] string id)
        {
            var command = new GetCheckingAccountBalanceQuery(id);

            var validator = new GetCheckingAccountBalanceQueryValidator(_checkingAccountQueryStore);

            var validationResult = validator.Validate(command);

            if (validationResult.Errors.Any())
            {
                var errorResponse = ValidationErrorResponseBuilder.Build(validationResult);

                return BadRequest(errorResponse);
            }

            var response = await _mediator.Send(command);

            return response;
        }
    }
}