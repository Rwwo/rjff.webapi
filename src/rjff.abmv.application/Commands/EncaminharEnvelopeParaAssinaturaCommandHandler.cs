using AutoMapper;

using MediatR;

using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Models;
using rjff.avmb.core.Models.Validations;
using rjff.avmb.core.Services;
using rjff.avmb.infrastructure.Services;
using rjff.avmb.infrastructure.Services.AstenModels;

namespace rjff.avmb.application.Commands
{
    public class EncaminharEnvelopeParaAssinaturaCommandHandler : BaseService, IRequestHandler<EncaminharEnvelopeParaAssinaturaCommand, GenericResult<BaseResponse<BaseDataWithAvisos>>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAstenService _astenService;
        public EncaminharEnvelopeParaAssinaturaCommandHandler(IUnitOfWork uow,
                                            IMapper mapper,
                                            IAstenService astenService,
                                            INotificador notificador)
            : base(notificador)
        {
            _uow = uow;
            _mapper = mapper;
            _astenService = astenService;
        }


        public async Task<GenericResult<BaseResponse<BaseDataWithAvisos>>> Handle(EncaminharEnvelopeParaAssinaturaCommand request, CancellationToken cancellationToken)
        {
            var EncaminharEnvelopeAssinaturaMap = _mapper.Map<core.Models.EncaminharEnvelopeParaAssinatura>(request.EncaminharEnvelopeParaAssinaturaInputModel);

            EncaminharEnvelopeAssinaturaMap.token = request.EncaminharEnvelopeParaAssinaturaInputModel.token;

            if (!ExecutarValidacao(new EncaminharEnvelopeParaAssinaturaValidation(), EncaminharEnvelopeAssinaturaMap))
            {
                var erro = new GenericResult<BaseResponse<BaseDataWithAvisos>>()
                {
                    HttpCode = 500,
                    Result = null,
                    Errors = new List<Error>()
                    {
                        new Error()
                        {
                            error = "Erro de Validação dos campos;"
                        }
                    }
                };

                return erro;
            }

            var envFinal = BuildEncaminhamento(EncaminharEnvelopeAssinaturaMap);

            var retornoAsten = await _astenService.EncaminharEnvelopeParaAssinatura(envFinal);

            if (retornoAsten.Errors != null)
            {
                foreach (var erro in retornoAsten.Errors)
                {
                    Notificar(erro.error);
                }
            }
            else
            {
                await _uow.EncaminharEnvelopeParaAssinaturaRepository.Adicionar(EncaminharEnvelopeAssinaturaMap);
            }


            return retornoAsten;
        }

        private infrastructure.Services.AstenModels.EncaminharEnvelopeParaAssinatura BuildEncaminhamento(core.Models.EncaminharEnvelopeParaAssinatura encaminharEnvelopeAssinaturaMap)
        {
            var criarEncaminhamentoAsten = new EncaminharEnvelopeParaAssinaturaBuilder()
               .ComToken(_astenService.GetToken())
               .ComEnvelope(encaminharEnvelopeAssinaturaMap.@params.Envelope.id)
               .ComAgendarEnvio(encaminharEnvelopeAssinaturaMap.@params.agendarEnvio)
               .ComDetectarCampos(encaminharEnvelopeAssinaturaMap.@params.detectarCampos)
               .ComDataEnvioAgendado(encaminharEnvelopeAssinaturaMap.@params.dataEnvioAgendado)
               .ComHoraEnvioAgendado(encaminharEnvelopeAssinaturaMap.@params.horaEnvioAgendado)
               ;



            return criarEncaminhamentoAsten.Build();
        }
    }
}


