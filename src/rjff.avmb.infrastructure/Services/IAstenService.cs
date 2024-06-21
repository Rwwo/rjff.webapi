using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Services.AstenModels;

namespace rjff.avmb.infrastructure.Services
{
    public interface IAstenService
    {
        string GetToken();
        Task<GenericResult<EnvelopeData>> CriarNovoEnvelope(AstenModels.CriarEnvelope envelope);
    }
}