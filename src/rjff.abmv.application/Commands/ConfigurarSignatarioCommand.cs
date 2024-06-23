using MediatR;

using rjff.avmb.core.InputModels;
using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Services.AstenModels;

namespace rjff.avmb.application.Commands
{
    public class ConfigurarSignatarioCommand : IRequest<GenericResult<ResponseConfigurarSignatario>>
    {
        public ConfigurarSignatarioCommand(ConfigurarSignatarioInputModel configurarSignatarioInputModel)
        {
            ConfigurarSignatarioInputModel = configurarSignatarioInputModel;
        }

        public ConfigurarSignatarioInputModel ConfigurarSignatarioInputModel { get; private set; }
    }
}

