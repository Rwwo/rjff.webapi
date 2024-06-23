using System.Net;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using rjff.avmb.application.Commands;
using rjff.avmb.application.Queries;
using rjff.avmb.core.InputModels;
using rjff.avmb.core.Interfaces;
using rjff.avmb.core.ViewModel;
using rjff.avmb.infrastructure.Services.AstenModels;

namespace rjff.avmb.api.Controllers
{

    [Route("api/envelope")]
    //[Authorize]
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

            var criarEnvelopeCommand = new CriarEnvelopeCommand(EnvelopeInputModel);
            var result = await _mediator.Send(criarEnvelopeCommand);

            return CustomResponse(HttpStatusCode.Created, EnvelopeInputModel);
        }

        [HttpPost("encaminhar-envelope-assinatura")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CriarEnvelopeInputModel>> EncaminharParaAssinatura(EncaminharEnvelopeParaAssinaturaInputModel EncaminharInputModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var EncaminharParaAssinaturaCommand = new EncaminharEnvelopeParaAssinaturaCommand(EncaminharInputModel);
            var result = await _mediator.Send(EncaminharParaAssinaturaCommand);

            return CustomResponse(HttpStatusCode.OK, EncaminharInputModel);
        }

        [HttpPost("download-pdf-envelope")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseDownloadPDFEnvelope>> EncaminharParaAssinatura(DownloadPDFEnvelopeInputModel input)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var downloadPDFEnvelopeCommand = new DownloadPDFEnvelopeCommand(input);
            var result = await _mediator.Send(downloadPDFEnvelopeCommand);

            return CustomResponse(HttpStatusCode.OK, result.Result);
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
