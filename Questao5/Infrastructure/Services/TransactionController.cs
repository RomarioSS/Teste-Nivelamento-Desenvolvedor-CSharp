using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Questao5.Application.Commands;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Commands.Validators;
using Questao5.Application.Queries;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Services.Controllers.Requests;
using Questao5.Infrastructure.Validators;
using System.Net;

namespace Questao5.Infrastructure.Services
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/transaction")]
    public class TransactionController : ControllerBase
    {
        private IMediator _mediator;
        private ICheckingAccountQueryStore _checkingAccountQueryStore;
        private IIdempotencyCommandStore _idempotencyCommandStore;

        public TransactionController(IMediator mediator,
            ICheckingAccountQueryStore checkingAccountQueryStore,
            IIdempotencyCommandStore idempotencyCommandStore)
        {
            _mediator = mediator;
            _checkingAccountQueryStore = checkingAccountQueryStore;
            _idempotencyCommandStore = idempotencyCommandStore;
        }

        /// <summary>
        /// Cria um movimento na conta corrente. 
        /// </summary>
        /// <param name="request">Requisicao para criacao de movimento na conta corrente.</param>
        /// <returns>Identificador do movimento criado.</returns>
        /// <response code=201>O movimento foi criado com sucesso.</response>
        /// <response code=400>A requisicao esta malformada ou invalida.</response>
        [HttpPost]
        [MapToApiVersion("1.0")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CreateTransactionResponse>> Create([FromBody] CreateTransactionRequest request)
        {
            IdempotencyRequest idempotencyRequest = new()
            {
                Body = JsonConvert.SerializeObject(request),
                Query = Request.QueryString.Value ?? "",
                Path = Request.Path,
                Host = Request.Host.Value,
                IsHttps = Request.IsHttps.ToString()
            };

            Idempotency idempotency = new Idempotency
            {
                Key = Guid.NewGuid().ToString().ToUpper(),
                Request = JsonConvert.SerializeObject(idempotencyRequest)
            };

            _idempotencyCommandStore.Add(idempotency);

            var command = new CreateTransactionCommand(
                request.TransactionId,
                request.CheckingAccountId,
                (decimal)request.Value,
                request.TransactionType);

            var validator = new CreateTransactionCommandValidator(_checkingAccountQueryStore);

            var validationResult = validator.Validate(command);

            if (validationResult.Errors.Count > 0)
            {
                var errorResponse = ValidationErrorResponseBuilder.Build(validationResult);

                idempotency.Response = JsonConvert.SerializeObject(errorResponse);
                _idempotencyCommandStore.Update(idempotency);

                return BadRequest(errorResponse);
            }

            var response = await _mediator.Send(command);

            idempotency.Response = JsonConvert.SerializeObject(response);
            _idempotencyCommandStore.Update(idempotency);

            return response;
        }
    }
}
