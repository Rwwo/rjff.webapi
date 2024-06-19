using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Services.AstenModels;

namespace rjff.avmb.infrastructure.Services
{
    public interface IAstenService
    {
        Task<GenericResult<ApiResponse<EnvelopeData>>> CriarNovoEnvelope(AstenModels.Envelope envelope);
    }
}