using AutoMapper;

using rjff.avmb.core.InputModels;
using rjff.avmb.infrastructure.Services.AstenModels;



namespace rjff.avmb.application.Profiles
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
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