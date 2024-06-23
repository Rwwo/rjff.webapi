using AutoMapper;

using Moq;

using rjff.avmb.application.Commands;
using rjff.avmb.core.InputModels;
using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Services;
using rjff.avmb.infrastructure.Services.AstenModels;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

public partial class CriarEnvelopeCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IAstenService> _mockAstenService;
    private readonly Mock<INotificador> _mockNotificador;
    private readonly CriarEnvelopeCommandHandler _handler;

    private readonly IMapper _mapper;

    public CriarEnvelopeCommandHandlerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _mockAstenService = new Mock<IAstenService>();
        _mockNotificador = new Mock<INotificador>();


        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CriarEnvelopeInputModel, rjff.avmb.core.Models.CriarEnvelope>()
                .ForMember(dest => dest.token, opt => opt.MapFrom(src => src.token))
                .ForMember(dest => dest.@params, opt => opt.MapFrom(src => src.@params));
        });

        _mockMapper.Setup(m => m.Map<rjff.avmb.core.Models.CriarEnvelope>(It.IsAny<CriarEnvelopeInputModel>()))
                  .Returns<CriarEnvelopeInputModel>(input =>
                  {
                      var mapper = mapperConfig.CreateMapper();
                      return mapper.Map<rjff.avmb.core.Models.CriarEnvelope>(input);
                  });

        _handler = new CriarEnvelopeCommandHandler(_mockUnitOfWork.Object, _mockMapper.Object, _mockAstenService.Object, _mockNotificador.Object);

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task EntradaDeDadosOK_Executado_RetornaCriado()
    {
        CriarEnvelopeCommand request = NovoEnvelope();

        var criarEnvelopeModel = _mapper.Map<rjff.avmb.core.Models.CriarEnvelope>(request.CriarEnvelopeInputModel);

        var t = _handler.BuildEnvelope(criarEnvelopeModel);

        var genericResult = new GenericResult<ResponseCriarEnvelope>
        {
            HttpCode = 201,
            Errors = null,
            Result = new ResponseCriarEnvelope()
            {
                response = new ResponseData<DataCriarEnvelope>()
                {
                    data = new DataCriarEnvelope()
                    {
                        idEnvelope = "dummy_id",
                        hashSHA256 = "dummy_hash",
                        listaDadosSignatarios = null,
                        listaAvisos = new ListaAvisos()
                        {
                            aviso = new Aviso()
                            {
                                mensagem = "",
                                tipo = ""
                            }
                        }
                    },
                    mensagem = ""
                }
            }
        };


        _mockAstenService.Setup(s => s.GetToken())
                         .Returns("dummy_token");

        _mockAstenService.Setup(s => s.CriarNovoEnvelope(It.IsAny<rjff.avmb.infrastructure.Services.AstenModels.CriarEnvelope>()))
                         .ReturnsAsync(genericResult);

        _mockUnitOfWork.Setup(u => u.CriarEnvelopeRepository.Adicionar(It.IsAny<rjff.avmb.core.Models.CriarEnvelope>()))
                       .Returns(Task.CompletedTask);

        // Verifique se request não é null
        Assert.NotNull(request);

        // Verifique se request.CriarEnvelopeInputModel não é null e outros campos necessários não são null
        Assert.NotNull(request.CriarEnvelopeInputModel);
        Assert.NotNull(request.CriarEnvelopeInputModel.@params);

        // Chame o método Handle somente se todos os campos necessários estiverem preenchidos corretamente
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        //Assert.Equal(request., result);
        _mockAstenService.Verify(s => s.CriarNovoEnvelope(It.IsAny<rjff.avmb.infrastructure.Services.AstenModels.CriarEnvelope>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.CriarEnvelopeRepository.Adicionar(It.IsAny<rjff.avmb.core.Models.CriarEnvelope>()), Times.Once);
    }

    private static CriarEnvelopeCommand NovoEnvelope()
    {
        return new CriarEnvelopeCommand
                (
                    criarEnvelopeInputModel: new CriarEnvelopeInputModel
                    (
                        token: "dummy_token",
                        @params: new ParamsCriarEnvelopeInputModel
                        (
                            envelope: new EnvelopeInputModel
                            (
                                descricao: "string",
                                Repositorio: new RepositorioInputModel
                                (
                                    id: 1
                                ),
                                mensagem: "dummy_message",
                                mensagemObservadores: "dummy_message_observers",
                                mensagemNotificacaoSMS: "dummy_message_sms",
                                dataExpiracao: DateTime.Now.AddDays(10).ToString(),
                                horaExpiracao: "18:00",
                                usarOrdem: "S",
                                ConfigAuxiliar: new ConfigAuxiliarInputModel
                                (
                                    documentosComXMLs: "N",
                                    urlCarimboTempo: "dummy_url"
                                ),
                                listaDocumentos: new ListadocumentosInputModel
                                {
                                    Documento = new List<DocumentoInputModel>
                                    {
                                new DocumentoInputModel()
                                {
                                    nomeArquivo = "document1.pdf",
                                    mimeType = "application/pdf",
                                    conteudo = "base64encodedstring",
                                    listaXMLAuxiliar = new ListaxmlauxiliarInputModel()
                                    {
                                        XMLAuxiliar = new List<XmlauxiliarInputModel>()
                                        {
                                            new XmlauxiliarInputModel()
                                            {
                                                conteudoXML = null,
                                                nomeArquivo = null,
                                                listaXMLSignatario = new List<ListaxmlsignatarioInputModel>()
                                                {
                                                    new ListaxmlsignatarioInputModel()
                                                    {
                                                        XMLSignatario = new List<XmlsignatarioInputModel>()
                                                        {
                                                            new XmlsignatarioInputModel()
                                                            {
                                                                carimboInterno = null,
                                                                cpfCnpjAceito = null,
                                                                emailSignatario = null,
                                                                idNodeAssinatura = null,
                                                                restringirPessoaFisica = null,
                                                                restringirPessoaJuridica = null,
                                                                restringirTiposCertificados = null
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                    }
                                },
                                listaSignatariosEnvelope: null,
                                listaObservadores: null,
                                listaTags: null,
                                listaInfoAdicional: null,
                                incluirHashTodasPaginas: "S",
                                permitirDespachos: "S",
                                ignorarNotificacoes: "N",
                                ignorarNotificacoesPendentes: "N",
                                qrCodePosLeft: "10",
                                qrCodePosTop: "10",
                                dataIniContrato: DateTime.Now.AddMonths(-1).ToString(),
                                dataFimContrato: DateTime.Now.AddMonths(11).ToString(),
                                objetoContrato: "Contrato de teste",
                                numContrato: "12345",
                                valorContrato: 10000,
                                descricaoContratante: "Empresa Contratante",
                                descricaoContratado: "Empresa Contratada",
                                bloquearDesenhoPaginas: "S"
                            ),
                            gerarTags: "N",
                            encaminharImediatamente: "N",
                            detectarCampos: "N",
                            verificarDuplicidadeConteudo: "N",
                            processarImagensEmSegundoPlano: "N"
                        )
                    )
                );
    }

    [Fact]
    public async Task EntradaDeDadosErrado_Executado_RetornaErros()
    {

        var handler = new CriarEnvelopeCommandHandler(
            _mockUnitOfWork.Object,
            _mockMapper.Object,
            _mockAstenService.Object,
            _mockNotificador.Object
        );

        CriarEnvelopeCommand request = NovoEnvelope();

        var criarEnvelopeModel = _mapper.Map<rjff.avmb.core.Models.CriarEnvelope>(request.CriarEnvelopeInputModel);

        var t = _handler.BuildEnvelope(criarEnvelopeModel);

        var cancellationToken = new CancellationToken();

        var mockResult = new GenericResult<ResponseCriarEnvelope>
        {
            HttpCode = 500,
            Result = null,
            Errors = new List<Error>
            {
                new Error { error = "Erro de Validação dos campos" }
            }
        };

        _mockAstenService.Setup(service => service.CriarNovoEnvelope(It.IsAny<rjff.avmb.infrastructure.Services.AstenModels.CriarEnvelope>()))
                        .ReturnsAsync(mockResult);

        // Act
        var result = await handler.Handle(request, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(500, result.HttpCode);
        Assert.NotNull(result.Errors);
        Assert.Null(result.Result); // Verifica se o resultado está vazio em caso de erro
    }

}
