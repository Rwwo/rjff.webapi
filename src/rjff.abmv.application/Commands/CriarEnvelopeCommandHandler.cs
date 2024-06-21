using AutoMapper;

using MediatR;

using rjff.avmb.core.InputModels;
using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Models.Validations;
using rjff.avmb.core.Services;
using rjff.avmb.infrastructure.Services;
using rjff.avmb.infrastructure.Services.AstenModels;


namespace rjff.avmb.application.Commands
{
    public class CriarEnvelopeCommandHandler : BaseService, IRequestHandler<CriarEnvelopeCommand, CriarEnvelopeInputModel>
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


        public async Task<CriarEnvelopeInputModel> Handle(CriarEnvelopeCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var criarEnvelopeMap = _mapper.Map<core.Models.CriarEnvelope>(request.CriarEnvelopeInputModel);

                if (!ExecutarValidacao(new CriarEnvelopeValidation(), criarEnvelopeMap))
                    return request.CriarEnvelopeInputModel;

                var criarEnvelopeAsten = new CriarEnvelopeBuilder();
                criarEnvelopeAsten.ComToken(_astenService.GetToken());

                var env = new EnvelopeBuilder();
                env.ComDescricao(criarEnvelopeMap.@params.Envelope.descricao);
                env.ComRepositorio(criarEnvelopeMap.@params.Envelope.Repositorio);
                env.ComMensagem(criarEnvelopeMap.@params.Envelope.mensagem);
                env.ComListaDocumentos(criarEnvelopeMap.@params.Envelope.listaDocumentos);
                env.ComListaSignatarios(criarEnvelopeMap.@params.Envelope.listaSignatariosEnvelope);
                env.ComListaObservadores(criarEnvelopeMap.@params.Envelope.listaObservadores);
                env.ComListaTags(criarEnvelopeMap.@params.Envelope.listaTags);
                env.ComListaInfoAdicional(criarEnvelopeMap.@params.Envelope.listaInfoAdicional);

                criarEnvelopeAsten.ComEnvelope(env.Build());

                criarEnvelopeAsten.ComGerarTags(criarEnvelopeMap.@params.gerarTags);
                criarEnvelopeAsten.ComEncaminharImediatamente(criarEnvelopeMap.@params.encaminharImediatamente);
                criarEnvelopeAsten.ComDetectarCampos(criarEnvelopeMap.@params.detectarCampos);
                criarEnvelopeAsten.ComVerificarDuplicidadeConteudo(criarEnvelopeMap.@params.verificarDuplicidadeConteudo);
                criarEnvelopeAsten.ComProcessarImagensEmSegundoPlano(criarEnvelopeMap.@params.processarImagensEmSegundoPlano);

                var envFinal = criarEnvelopeAsten.Build();

                await _astenService.CriarNovoEnvelope(envFinal);

                await _uow.CriarEnvelopeRepository.Adicionar(criarEnvelopeMap);


            }
            catch (AutoMapperMappingException ex)
            {
                Console.WriteLine();
            }

            return request.CriarEnvelopeInputModel;

        }
    }

}
