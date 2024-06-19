using System.Net;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using rjff.avmb.application.Commands;
using rjff.avmb.core.InputModels;
using rjff.avmb.core.Interfaces;

namespace rjff.avmb.api.Controllers
{

    [Route("api/envelope")]
    public class EnvelopeController : MainController
    {
        private readonly IMediator _mediator;
        public EnvelopeController(IMediator mediator, INotificador notificador) : base(notificador)
        {
            _mediator = mediator;
        }

        [HttpPost("novo-envelope")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<EnvelopeInputModel>> Adicionar(EnvelopeInputModel EnvelopeInputModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var criarCorretorCommand = new CriarEnvelopeCommand(EnvelopeInputModel);
            var result = await _mediator.Send(criarCorretorCommand);

            return CustomResponse(HttpStatusCode.Created, EnvelopeInputModel);
        }
    }
}
