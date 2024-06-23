using AutoMapper;

using rjff.avmb.core.InputModels;
using rjff.avmb.core.ViewModel;
using rjff.avmb.infrastructure.Services.AstenModels;



namespace rjff.avmb.application.Profiles
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<DownloadPDFEnvelopeInputModel, core.Models.DownloadPDFEnvelope>()
                .ForMember(dest => dest.@params, opt => opt.MapFrom(src => src.@params));


            CreateMap<EncaminharEnvelopeParaAssinaturaInputModel, core.Models.EncaminharEnvelopeParaAssinatura>()
                .ForMember(dest => dest.@params, opt => opt.MapFrom(src => src.@params));


            CreateMap<ConfigurarSignatarioInputModel, core.Models.ConfigurarSignatario>()
                .ForMember(dest => dest.@params, opt => opt.MapFrom(src => src.@params));


            CreateMap<ResponseStatusEnvelope, StatusEnvelopeViewModel>()
                .ForMember(dest => dest.response, opt => opt.MapFrom(src => src.response));

            // Mapping for Response to ResponseViewModel
            CreateMap<ResponseStatusEnv, ResponseStatusEnvViewModel>()
                .ForMember(dest => dest.Repositorio, opt => opt.MapFrom(src => src.Repositorio))
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario));

            // Mapping for Repositorio to RepositorioViewModel
            CreateMap<Repositorio, RepositorioViewModel>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id));

            // Mapping for Usuario to UsuarioViewModel
            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id));


            CreateMap<CriarEnvelopeInputModel, core.Models.CriarEnvelope>()
                .ForMember(dest => dest.token, opt => opt.MapFrom(src => src.token))
                .ForMember(dest => dest.@params, opt => opt.MapFrom(src => src.@params));

            // CreateMap<rjff.avmb.core.Models.CriarEnvelope, rjff.avmb.infrastructure.Services.AstenModels.CriarEnvelope>()
            //     .ForMember(dest => dest.token, opt => opt.MapFrom(src => src.token))
            //     .ForMember(dest => dest.@params, opt => opt.MapFrom(src => src.@params));

            CreateMap<rjff.avmb.core.Models.CriarEnvelope, rjff.avmb.infrastructure.Services.AstenModels.CriarEnvelope>()
                .ForMember(dest => dest.token, opt => opt.MapFrom(src => src.token))
                .ConstructUsing((src, context) =>
                {
                    var paramsModel = context.Mapper.Map<rjff.avmb.infrastructure.Services.AstenModels.ParamsCriarEnvelope>(src.@params);
                    return new rjff.avmb.infrastructure.Services.AstenModels.CriarEnvelope
                    {
                        token = src.token,
                        @params = paramsModel
                    };
                });

        }
    }
}