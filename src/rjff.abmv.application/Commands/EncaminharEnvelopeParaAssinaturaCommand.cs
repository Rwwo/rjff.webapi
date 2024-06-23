using MediatR;

using rjff.avmb.core.InputModels;
using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Services.AstenModels;

namespace rjff.avmb.application.Commands
{
    public class EncaminharEnvelopeParaAssinaturaCommand : IRequest<GenericResult<BaseResponse<BaseDataWithAvisos>>>
    {
        public EncaminharEnvelopeParaAssinaturaCommand(EncaminharEnvelopeParaAssinaturaInputModel encaminharEnvelopeParaAssinaturaInputModel)
        {
            EncaminharEnvelopeParaAssinaturaInputModel = encaminharEnvelopeParaAssinaturaInputModel;
        }

        public EncaminharEnvelopeParaAssinaturaInputModel EncaminharEnvelopeParaAssinaturaInputModel { get; private set; }

    }
}


