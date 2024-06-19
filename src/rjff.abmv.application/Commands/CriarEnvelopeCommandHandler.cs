using AutoMapper;

using MediatR;

using rjff.avmb.core.InputModels;
using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Models;
using rjff.avmb.core.Models.Validations;
using rjff.avmb.core.Services;

namespace rjff.avmb.application.Commands
{
    public class CriarEnvelopeCommandHandler : BaseService, IRequestHandler<CriarEnvelopeCommand, EnvelopeInputModel>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CriarEnvelopeCommandHandler(IUnitOfWork uow, IMapper mapper, INotificador notificador)
            : base(notificador)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<EnvelopeInputModel> Handle(CriarEnvelopeCommand request, CancellationToken cancellationToken)
        {
            var envelopeMap = _mapper.Map<Envelope>(request.Envelope);

            if (!ExecutarValidacao(new EnvelopeValidation(), envelopeMap))
                return request.Envelope;

            await _uow.EnvelopeRepository.Adicionar(envelopeMap);

            return request.Envelope;

        }
    }

}
