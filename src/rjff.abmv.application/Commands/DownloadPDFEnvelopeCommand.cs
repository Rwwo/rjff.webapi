using MediatR;

using rjff.avmb.core.InputModels;
using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Services.AstenModels;

namespace rjff.avmb.application.Commands
{
    public class DownloadPDFEnvelopeCommand : IRequest<GenericResult<ResponseDownloadPDFEnvelope>>
    {
        public DownloadPDFEnvelopeCommand(DownloadPDFEnvelopeInputModel downloadPDFEnvelopeInputModel)
        {
            DownloadPDFEnvelopeInputModel = downloadPDFEnvelopeInputModel;
        }

        public DownloadPDFEnvelopeInputModel DownloadPDFEnvelopeInputModel { get; private set; }
    }
}

