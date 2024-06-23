using rjff.avmb.core.InputModels;

namespace rjff.avmb.core.Models
{
    public class DownloadPDFEnvelope : Entity
    {
        public string token { get; set; }
        public ParamsDownloadPDFEnvelopeInputModel @params { get; private set; }
        public DownloadPDFEnvelope(string token, ParamsDownloadPDFEnvelopeInputModel @params)
        {
            this.@params = @params;
            this.token = token;
        }
    }
}