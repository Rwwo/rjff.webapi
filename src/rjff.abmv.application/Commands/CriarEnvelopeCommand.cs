using MediatR;

using rjff.avmb.core.InputModels;

namespace rjff.avmb.application.Commands
{

    public class CriarEnvelopeCommand : IRequest<CriarEnvelopeInputModel>
    {
        public CriarEnvelopeCommand(CriarEnvelopeInputModel envelope)
        {
            Envelope = envelope;
        }

        public CriarEnvelopeInputModel Envelope { get; private set; }
    }

}
