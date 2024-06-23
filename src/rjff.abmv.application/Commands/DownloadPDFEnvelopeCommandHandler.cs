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
    public class DownloadPDFEnvelopeCommandHandler : BaseService, IRequestHandler<DownloadPDFEnvelopeCommand, GenericResult<ResponseDownloadPDFEnvelope>>
    {
        private readonly IMapper _mapper;
        private readonly IAstenService _astenService;
        public DownloadPDFEnvelopeCommandHandler(IMapper mapper,
                                                 IAstenService astenService,
                                                 INotificador notificador)
            : base(notificador)
        {
            _mapper = mapper;
            _astenService = astenService;
        }


        public async Task<GenericResult<ResponseDownloadPDFEnvelope>> Handle(DownloadPDFEnvelopeCommand request, CancellationToken cancellationToken)
        {

            var pdfDownloadMap = _mapper.Map<core.Models.DownloadPDFEnvelope>(request.DownloadPDFEnvelopeInputModel);
            pdfDownloadMap.token = _astenService.GetToken();

            if (!ExecutarValidacao(new DownloadPDFEnvelopeValidation(), pdfDownloadMap))
            {
                var erro = new GenericResult<ResponseDownloadPDFEnvelope>()
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

            var envFinal = BuilderDownloadPDFEnvelope(pdfDownloadMap);

            var retornoAsten = await _astenService.DownloadPDFEnvelope(envFinal);

            if (retornoAsten.Errors != null)
            {
                foreach (var erro in retornoAsten.Errors)
                {
                    Notificar(erro.error);
                }
            }

            return retornoAsten;
        }

        private infrastructure.Services.AstenModels.DownloadPDFEnvelope BuilderDownloadPDFEnvelope(core.Models.DownloadPDFEnvelope pdfDownloadMap)
        {
            var downloadPDFEnvelopeBuilder = new DownloadPDFEnvelopeBuilder()
                .ComToken(pdfDownloadMap.token)
                .ComHashSHA256(pdfDownloadMap.@params.hashSHA256)
                .ComIncluirDocs(pdfDownloadMap.@params.incluirDocs)
                .ComVersaoSemCertificado(pdfDownloadMap.@params.versaoSemCertificado);

            return downloadPDFEnvelopeBuilder.Build();
        }
    }
}

