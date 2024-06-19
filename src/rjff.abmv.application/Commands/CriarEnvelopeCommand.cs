using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using rjff.avmb.core.InputModels;

namespace rjff.avmb.application.Commands
{

    public class CriarEnvelopeCommand : IRequest<EnvelopeInputModel>
    {
        public CriarEnvelopeCommand(EnvelopeInputModel envelope)
        {
            Envelope = envelope;
        }

        public EnvelopeInputModel Envelope { get; private set; }
    }

}
