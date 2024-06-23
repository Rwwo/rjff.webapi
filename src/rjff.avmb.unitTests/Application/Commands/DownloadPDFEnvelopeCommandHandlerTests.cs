using AutoMapper;

using Moq;

using rjff.avmb.application.Commands;
using rjff.avmb.application.Profiles;
using rjff.avmb.core.InputModels;
using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Services;
using rjff.avmb.infrastructure.Services.AstenModels;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;



public class DownloadPDFEnvelopeCommandHandlerTests
{
    [Fact]
    public async Task EntradaDeDadosOK_Executado_RetornaSucesso()
    {
        // Arrange
        var mockMapper = new Mock<IMapper>();
        var mockAstenService = new Mock<IAstenService>();
        var mockNotificador = new Mock<INotificador>();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DownloadPDFEnvelopeInputModel, rjff.avmb.core.Models.DownloadPDFEnvelope>()
                .ForMember(dest => dest.token, opt => opt.MapFrom(src => src.token))
                .ForMember(dest => dest.@params, opt => opt.MapFrom(src => src.@params));
        });

        mockMapper.Setup(m => m.Map<rjff.avmb.core.Models.DownloadPDFEnvelope>(It.IsAny<DownloadPDFEnvelopeInputModel>()))
           .Returns<DownloadPDFEnvelopeInputModel>(input =>
           {
               var mapper = mapperConfig.CreateMapper();
               return mapper.Map<rjff.avmb.core.Models.DownloadPDFEnvelope>(input);
           });


        var handler = new DownloadPDFEnvelopeCommandHandler(
                mockMapper.Object,
                mockAstenService.Object,
                mockNotificador.Object
            );


        var request = new DownloadPDFEnvelopeCommand(
            new DownloadPDFEnvelopeInputModel(
                @params: new ParamsDownloadPDFEnvelopeInputModel(
                    hashSHA256: "145d51735aca436b1332883f92ba2931bba4b44427ef8ee8c73d31259a1892f5",
                    incluirDocs: "N",
                    versaoSemCertificado: null
                ),
                token: "NcRW0Bpyn6Z5QypP2huHk2OOJfr1FyeQ79p1tt3JCiIoH93GbnkwxF6S60yFQoZwYCzUwZVb-Lk9KvOx1EDnvc+e2TCldfRjLAHtV8W+7m9W6YlVJ9iH53HxiplvUkag7JlcW8n8NbY2PT4n+FY2dqKzUdoQqRPe"
            )
        );
        var cancellationToken = new CancellationToken();

        var mockResult = new GenericResult<ResponseDownloadPDFEnvelope>
        {
            HttpCode = 200,
            Result = new ResponseDownloadPDFEnvelope(), // Mock objeto de resposta
            Errors = null
        };

        mockAstenService.Setup(service => service.DownloadPDFEnvelope(It.IsAny<rjff.avmb.infrastructure.Services.AstenModels.DownloadPDFEnvelope>()))
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
        var mockMapper = new Mock<IMapper>();
        var mockAstenService = new Mock<IAstenService>();
        var mockNotificador = new Mock<INotificador>();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DownloadPDFEnvelopeInputModel, rjff.avmb.core.Models.DownloadPDFEnvelope>()
                .ForMember(dest => dest.token, opt => opt.MapFrom(src => src.token))
                .ForMember(dest => dest.@params, opt => opt.MapFrom(src => src.@params));
        });

        mockMapper.Setup(m => m.Map<rjff.avmb.core.Models.DownloadPDFEnvelope>(It.IsAny<DownloadPDFEnvelopeInputModel>()))
         .Returns<DownloadPDFEnvelopeInputModel>(input =>
         {
             var mapper = mapperConfig.CreateMapper();
             return mapper.Map<rjff.avmb.core.Models.DownloadPDFEnvelope>(input);
         });

        var handler = new DownloadPDFEnvelopeCommandHandler(
            mockMapper.Object,
            mockAstenService.Object,
            mockNotificador.Object
        );

        var request = new DownloadPDFEnvelopeCommand(
            new DownloadPDFEnvelopeInputModel(
                @params: new ParamsDownloadPDFEnvelopeInputModel(
                    hashSHA256: "145d51735aca436b1332883f92ba2931bba4b44427ef8ee8c73d31259a1892f5",
                    incluirDocs: "N",
                    versaoSemCertificado: null
                ),
                token: "NcRW0Bpyn6Z5QypP2huHk2OOJfr1FyeQ79p1tt3JCiIoH93GbnkwxF6S60yFQoZwYCzUwZVb-Lk9KvOx1EDnvc+e2TCldfRjLAHtV8W+7m9W6YlVJ9iH53HxiplvUkag7JlcW8n8NbY2PT4n+FY2dqKzUdoQqRPe"
            )
        );
        var cancellationToken = new CancellationToken();

        var mockResult = new GenericResult<ResponseDownloadPDFEnvelope>
        {
            HttpCode = 500,
            Result = null,
            Errors = new List<Error>
            {
                new Error { error = "Erro de Validação dos campos" }
            }
        };

        mockAstenService.Setup(service => service.DownloadPDFEnvelope(It.IsAny<rjff.avmb.infrastructure.Services.AstenModels.DownloadPDFEnvelope>()))
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


