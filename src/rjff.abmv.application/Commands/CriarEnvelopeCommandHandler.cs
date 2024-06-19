using AutoMapper;

using MediatR;

using rjff.avmb.core.InputModels;
using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Models;
using rjff.avmb.core.Models.Validations;
using rjff.avmb.core.Services;

namespace rjff.avmb.application.Commands
{
    public class CriarEnvelopeCommandHandler : BaseService, IRequestHandler<CriarEnvelopeCommand, CriarEnvelopeInputModel>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CriarEnvelopeCommandHandler(IUnitOfWork uow, IMapper mapper, INotificador notificador)
            : base(notificador)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<CriarEnvelopeInputModel> Handle(CriarEnvelopeCommand request, CancellationToken cancellationToken)
        {
            var criarEnvelopeMap = _mapper.Map<CriarEnvelope>(request.Envelope);

            if (!ExecutarValidacao(new CriarEnvelopeValidation(), criarEnvelopeMap))
                return request.Envelope;

            await _uow.CriarEnvelopeRepository.Adicionar(criarEnvelopeMap);

            return request.Envelope;

        }
    }

}
