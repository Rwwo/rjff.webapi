using MediatR;

using rjff.avmb.core.InputModels;
using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Services.AstenModels;

namespace rjff.avmb.application.Commands
{

    public class CriarEnvelopeCommand : IRequest<GenericResult<ResponseCriarEnvelope>>
    {
        public CriarEnvelopeCommand(CriarEnvelopeInputModel criarEnvelopeInputModel)
        {
            CriarEnvelopeInputModel = criarEnvelopeInputModel;
        }

        public CriarEnvelopeInputModel CriarEnvelopeInputModel { get; private set; }

    }
}

