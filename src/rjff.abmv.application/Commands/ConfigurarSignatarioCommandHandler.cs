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
    public class ConfigurarSignatarioCommandHandler : BaseService, IRequestHandler<ConfigurarSignatarioCommand, GenericResult<ResponseConfigurarSignatario>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAstenService _astenService;
        public ConfigurarSignatarioCommandHandler(IUnitOfWork uow,
                                            IMapper mapper,
                                            IAstenService astenService,
                                            INotificador notificador)
            : base(notificador)
        {
            _uow = uow;
            _mapper = mapper;
            _astenService = astenService;
        }


        public async Task<GenericResult<ResponseConfigurarSignatario>> Handle(ConfigurarSignatarioCommand request, CancellationToken cancellationToken)
        {

            var ConfSignatarioMap = _mapper.Map<core.Models.ConfigurarSignatario>(request.ConfigurarSignatarioInputModel);
            ConfSignatarioMap.token = _astenService.GetToken();

            if (!ExecutarValidacao(new ConfigurarSignatarioValidation(), ConfSignatarioMap))
            {
                var erro = new GenericResult<ResponseConfigurarSignatario>()
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

            var envFinal = BuilderConfigurarSignatario(ConfSignatarioMap);

            var retornoAsten = await _astenService.ConfigurarSignatario(envFinal);

            if (retornoAsten.Errors != null)
            {
                foreach (var erro in retornoAsten.Errors)
                {
                    Notificar(erro.error);
                }
            }
            else
            {
                await _uow.ConfigurarSignatarioRepository.Adicionar(ConfSignatarioMap);
            }



            return retornoAsten;
        }

        private infrastructure.Services.AstenModels.ConfigurarSignatario BuilderConfigurarSignatario(core.Models.ConfigurarSignatario confSignatarioMap)
        {
            var configSignatarioAsten = new ConfigurarSignatarioBuilder()
              .ComToken(_astenService.GetToken())
              .ComEnvelope(new EnvelopeInputDTO() { id = confSignatarioMap.@params.SignatarioEnvelope.Envelope.id })
              .ComOrdem(confSignatarioMap.@params.SignatarioEnvelope.ordem)
              .ComTag(confSignatarioMap.@params.SignatarioEnvelope.tagAncoraCampos)
              .ComAssinatura(confSignatarioMap.@params.SignatarioEnvelope.ConfigAssinatura);

            return configSignatarioAsten.Build();
        }
    }
}

