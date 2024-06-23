using AutoMapper;

using MediatR;

using rjff.avmb.core.InputModels;
using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Models;
using rjff.avmb.core.Models.Validations;
using rjff.avmb.core.Services;
using rjff.avmb.infrastructure.Services;
using rjff.avmb.infrastructure.Services.AstenModels;


namespace rjff.avmb.application.Commands
{
    public class CriarEnvelopeCommandHandler : BaseService, IRequestHandler<CriarEnvelopeCommand, GenericResult<ResponseCriarEnvelope>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAstenService _astenService;
        public CriarEnvelopeCommandHandler(IUnitOfWork uow,
                                            IMapper mapper,
                                            IAstenService astenService,
                                            INotificador notificador)
            : base(notificador)
        {
            _uow = uow;
            _mapper = mapper;
            _astenService = astenService;
        }


        public async Task<GenericResult<ResponseCriarEnvelope>> Handle(CriarEnvelopeCommand request, CancellationToken cancellationToken)
        {

            var criarEnvelopeMap = _mapper.Map<core.Models.CriarEnvelope>(request.CriarEnvelopeInputModel);

            criarEnvelopeMap.token = _astenService.GetToken();

            if (!ExecutarValidacao(new CriarEnvelopeValidation(), criarEnvelopeMap))
            {
                var erro = new GenericResult<ResponseCriarEnvelope>()
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

            var envFinal = BuildEnvelope(criarEnvelopeMap);

            var retornoAsten = await _astenService.CriarNovoEnvelope(envFinal);

            if (retornoAsten.Errors != null)
            {
                foreach (var erro in retornoAsten.Errors)
                {
                    Notificar(erro.error);
                }
            }
            else
            {
                await _uow.CriarEnvelopeRepository.Adicionar(criarEnvelopeMap);
            }


            return retornoAsten;
        }

        public infrastructure.Services.AstenModels.CriarEnvelope BuildEnvelope(core.Models.CriarEnvelope criarEnvelopeMap)
        {
            var criarEnvelopeAsten = new CriarEnvelopeBuilder()
                .ComToken(_astenService.GetToken());

            var env = new EnvelopeBuilder()
                .ComDescricao(criarEnvelopeMap.@params.Envelope.descricao)
                .ComRepositorio(criarEnvelopeMap.@params.Envelope.Repositorio)
                .ComMensagem(criarEnvelopeMap.@params.Envelope.mensagem)
                .ComListaDocumentos(criarEnvelopeMap.@params.Envelope.listaDocumentos)
                .ComListaSignatarios(criarEnvelopeMap.@params.Envelope.listaSignatariosEnvelope)
                .ComListaObservadores(criarEnvelopeMap.@params.Envelope.listaObservadores)
                .ComListaTags(criarEnvelopeMap.@params.Envelope.listaTags)
                .ComListaInfoAdicional(criarEnvelopeMap.@params.Envelope.listaInfoAdicional);

            criarEnvelopeAsten.ComEnvelope(env.Build())
                             .ComGerarTags(criarEnvelopeMap.@params.gerarTags)
                             .ComEncaminharImediatamente(criarEnvelopeMap.@params.encaminharImediatamente)
                             .ComDetectarCampos(criarEnvelopeMap.@params.detectarCampos)
                             .ComVerificarDuplicidadeConteudo(criarEnvelopeMap.@params.verificarDuplicidadeConteudo)
                             .ComProcessarImagensEmSegundoPlano(criarEnvelopeMap.@params.processarImagensEmSegundoPlano);

            return criarEnvelopeAsten.Build();
        }
    }

}
