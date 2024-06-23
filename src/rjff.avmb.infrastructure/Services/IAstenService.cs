using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Services.AstenModels;

namespace rjff.avmb.infrastructure.Services
{
    public interface IAstenService
    {
        string GetToken();
        Task<GenericResult<ResponseCriarEnvelope>> CriarNovoEnvelope(AstenModels.CriarEnvelope envelope);
        Task<GenericResult<ResponseConfigurarSignatario>> ConfigurarSignatario(AstenModels.ConfigurarSignatario envFinal);
        Task<GenericResult<ResponseStatusEnvelope>> StatusEnvelope(AstenModels.StatusEnvelope envFinal);
        Task<GenericResult<BaseResponse<BaseDataWithAvisos>>> EncaminharEnvelopeParaAssinatura(AstenModels.EncaminharEnvelopeParaAssinatura envFinal);
        Task<GenericResult<ResponseDownloadPDFEnvelope>> DownloadPDFEnvelope(AstenModels.DownloadPDFEnvelope envFinal);
    }
}