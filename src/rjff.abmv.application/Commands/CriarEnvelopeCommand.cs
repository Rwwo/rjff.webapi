using MediatR;

using rjff.avmb.core.InputModels;

namespace rjff.avmb.application.Commands
{

    public class CriarEnvelopeCommand : IRequest<CriarEnvelopeInputModel>
    {
        public CriarEnvelopeCommand(CriarEnvelopeInputModel criarEnvelopeInputModel)
        {
            CriarEnvelopeInputModel = criarEnvelopeInputModel;
        }

        public CriarEnvelopeInputModel CriarEnvelopeInputModel { get; private set; }
    }

}
