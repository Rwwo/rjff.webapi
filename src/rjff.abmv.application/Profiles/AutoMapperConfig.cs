using AutoMapper;

using rjff.avmb.core.InputModels;
using rjff.avmb.core.Models;

namespace rjff.avmb.application.Profiles
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CriarEnvelope, CriarEnvelopeInputModel>().ReverseMap();
        }
    }
}