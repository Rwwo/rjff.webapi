using MediatR;

using rjff.avmb.core.InputModels;
using rjff.avmb.core.ViewModel;

namespace rjff.avmb.application.Queries
{
    public class StatusEnvelopeQuery : IRequest<StatusEnvelopeViewModel>
    {

        public StatusEnvelopeQuery(StatusEnvelopeInputModel statusEnvelopeInputModel)
        {
            StatusEnvelopeInputModel = statusEnvelopeInputModel;
        }

        public StatusEnvelopeInputModel StatusEnvelopeInputModel { get; private set; }

    }
}
