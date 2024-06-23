using System.Net;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using rjff.avmb.application.Commands;
using rjff.avmb.application.Queries;
using rjff.avmb.core.InputModels;
using rjff.avmb.core.Interfaces;
using rjff.avmb.core.ViewModel;

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
        public async Task<ActionResult<CriarEnvelopeInputModel>> Adicionar(CriarEnvelopeInputModel EnvelopeInputModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var criarCorretorCommand = new CriarEnvelopeCommand(EnvelopeInputModel);
            var result = await _mediator.Send(criarCorretorCommand);

            return CustomResponse(HttpStatusCode.Created, EnvelopeInputModel);
        }

        [HttpGet("status-envelope/{idEnvelope:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StatusEnvelopeViewModel>> BuscarStatus(int idEnvelope)
        {
            var StatusEnvelopeInputModel = new StatusEnvelopeInputModel("", new ParamsStatusEnvelopeInputModel(idEnvelope, "N"));

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var statusEnvelopeInputModel = new StatusEnvelopeQuery(StatusEnvelopeInputModel);
            var result = await _mediator.Send(statusEnvelopeInputModel);

            return CustomResponse(HttpStatusCode.OK, result);
        }
    }
}
