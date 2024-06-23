using AutoMapper;

using MediatR;

using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Services;
using rjff.avmb.core.ViewModel;
using rjff.avmb.infrastructure.Services;
using rjff.avmb.infrastructure.Services.AstenModels;

namespace rjff.avmb.application.Queries
{
    public class StatusEnvelopeQueryHandler : BaseService, IRequestHandler<StatusEnvelopeQuery, StatusEnvelopeViewModel>
    {

        private readonly IMapper _mapper;
        private readonly IAstenService _astenService;
        public StatusEnvelopeQueryHandler(IMapper mapper, IAstenService astenService,
                                            INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _astenService = astenService;
        }


        public async Task<StatusEnvelopeViewModel> Handle(StatusEnvelopeQuery request, CancellationToken cancellationToken)
        {
            var statusEnvelope = new StatusEnvelope()
            {
                token = _astenService.GetToken(),
                @params = new ParamsStatusEnvelope()
                {
                    getLobs = request.StatusEnvelopeInputModel.@params.getLobs,
                    idEnvelope = request.StatusEnvelopeInputModel.@params.idEnvelope
                }
            };

             var statusEnv = await _astenService.StatusEnvelope(statusEnvelope);

            if(statusEnv.Result != null)
            {
                return _mapper.Map<StatusEnvelopeViewModel>(statusEnv.Result);
            }else
            {
                Notificar("Não foi possível persistir o status do envelope. Verifique comunicação com Asten");
            }

            return null;
        }
    }
}
