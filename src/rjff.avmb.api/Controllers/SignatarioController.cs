using System.Net;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using rjff.avmb.application.Commands;
using rjff.avmb.core.InputModels;
using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Services.AstenModels;

namespace rjff.avmb.api.Controllers
{
    [Route("api/signatario")]
    //[Authorize]
    public class SignatarioController : MainController
    {
        private readonly IMediator _mediator;
        public SignatarioController(IMediator mediator, INotificador notificador) : base(notificador)
        {
            _mediator = mediator;
        }

        [HttpPost("configurar-signatario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<GenericResult<ResponseConfigurarSignatario>>> Adicionar(ConfigurarSignatarioInputModel input)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var inputCommand = new ConfigurarSignatarioCommand(input);
            var result = await _mediator.Send(inputCommand);

            return CustomResponse(HttpStatusCode.OK, result);
        }
    }
}
