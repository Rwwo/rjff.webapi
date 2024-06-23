using AutoMapper;

using Moq;

using rjff.avmb.application.Commands;
using rjff.avmb.core.InputModels;
using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Services;
using rjff.avmb.infrastructure.Services.AstenModels;

public class EncaminharEnvelopeParaAssinaturaCommandHandlerTests
{
    [Fact]
    public async Task EntradaDeDadosOK_Executado_RetornaOK()
    {
        // Arrange
        var mockUow = new Mock<IUnitOfWork>();
        var encaminharEnvelopeRepo = new Mock<IEncaminharEnvelopeParaAssinaturaRepository>();

        mockUow.SetupGet(uow => uow.EncaminharEnvelopeParaAssinaturaRepository).Returns(encaminharEnvelopeRepo.Object);

        var mockMapper = new Mock<IMapper>();
        var mockAstenService = new Mock<IAstenService>();
        var mockNotificador = new Mock<INotificador>();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<EncaminharEnvelopeParaAssinaturaInputModel, rjff.avmb.core.Models.EncaminharEnvelopeParaAssinatura>()
                .ForMember(dest => dest.token, opt => opt.MapFrom(src => src.token))
                .ForMember(dest => dest.@params, opt => opt.MapFrom(src => src.@params));
        });

        mockMapper.Setup(m => m.Map<rjff.avmb.core.Models.EncaminharEnvelopeParaAssinatura>(It.IsAny<EncaminharEnvelopeParaAssinaturaInputModel>()))
         .Returns<EncaminharEnvelopeParaAssinaturaInputModel>(input =>
         {
             var mapper = mapperConfig.CreateMapper();
             return mapper.Map<rjff.avmb.core.Models.EncaminharEnvelopeParaAssinatura>(input);
         });

        var handler = new EncaminharEnvelopeParaAssinaturaCommandHandler(
            mockUow.Object,
            mockMapper.Object,
            mockAstenService.Object,
            mockNotificador.Object
        );

        var request = new EncaminharEnvelopeParaAssinaturaCommand(
            new EncaminharEnvelopeParaAssinaturaInputModel(
                new ParamsEncaminharEnvelopeParaAssinaturaInputModel(
                    new EnvelopeDTOInputModel(64646),
                    "N", "N", null, null
                ),
                "NcRW0Bpyn6Z5QypP2huHk2OOJfr1FyeQ79p1tt3JCiIoH93GbnkwxF6S60yFQoZwYCzUwZVb-Lk9KvOx1EDnvc+e2TCldfRjLAHtV8W+7m9W6YlVJ9iH53HxiplvUkag7JlcW8n8NbY2PT4n+FY2dqKzUdoQqRPe"
            )
        );

        var cancellationToken = new CancellationToken();

        var mockResult = new GenericResult<BaseResponse<BaseDataWithAvisos>>
        {
            HttpCode = 200,
            Result = new BaseResponse<BaseDataWithAvisos>(), // Mock objeto de resposta
            Errors = null
        };

        mockAstenService.Setup(service => service.EncaminharEnvelopeParaAssinatura(It.IsAny<rjff.avmb.infrastructure.Services.AstenModels.EncaminharEnvelopeParaAssinatura>()))
                        .ReturnsAsync(mockResult);

        // Act
        var result = await handler.Handle(request, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.HttpCode);
        Assert.Null(result.Errors);
        Assert.NotNull(result.Result);
    }

    [Fact]
    public async Task EntradaDeDadosErrado_Executado_RetornaErro()
    {
        // Arrange
        var mockUow = new Mock<IUnitOfWork>();
        var mockMapper = new Mock<IMapper>();
        var mockAstenService = new Mock<IAstenService>();
        var mockNotificador = new Mock<INotificador>();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<EncaminharEnvelopeParaAssinaturaInputModel, rjff.avmb.core.Models.EncaminharEnvelopeParaAssinatura>()
                .ForMember(dest => dest.token, opt => opt.MapFrom(src => src.token))
                .ForMember(dest => dest.@params, opt => opt.MapFrom(src => src.@params));
        });

        mockMapper.Setup(m => m.Map<rjff.avmb.core.Models.EncaminharEnvelopeParaAssinatura>(It.IsAny<EncaminharEnvelopeParaAssinaturaInputModel>()))
         .Returns<EncaminharEnvelopeParaAssinaturaInputModel>(input =>
         {
             var mapper = mapperConfig.CreateMapper();
             return mapper.Map<rjff.avmb.core.Models.EncaminharEnvelopeParaAssinatura>(input);
         });

        var handler = new EncaminharEnvelopeParaAssinaturaCommandHandler(
            mockUow.Object,
            mockMapper.Object,
            mockAstenService.Object,
            mockNotificador.Object
        );

        var request = new EncaminharEnvelopeParaAssinaturaCommand(
            new EncaminharEnvelopeParaAssinaturaInputModel(
                new ParamsEncaminharEnvelopeParaAssinaturaInputModel(
                    new EnvelopeDTOInputModel(64646),
                    "N", "N", null, null
                ),
                "NcRW0Bpyn6Z5QypP2huHk2OOJfr1FyeQ79p1tt3JCiIoH93GbnkwxF6S60yFQoZwYCzUwZVb-Lk9KvOx1EDnvc+e2TCldfRjLAHtV8W+7m9W6YlVJ9iH53HxiplvUkag7JlcW8n8NbY2PT4n+FY2dqKzUdoQqRPe"
            )
        );
        var cancellationToken = new CancellationToken();

        var mockResult = new GenericResult<BaseResponse<BaseDataWithAvisos>>
        {
            HttpCode = 500,
            Result = null,
            Errors = new List<Error>
            {
                new Error { error = "Erro de Validação dos campos" }
                }
        };

        mockAstenService.Setup(service => service.EncaminharEnvelopeParaAssinatura(It.IsAny<rjff.avmb.infrastructure.Services.AstenModels.EncaminharEnvelopeParaAssinatura>()))
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


