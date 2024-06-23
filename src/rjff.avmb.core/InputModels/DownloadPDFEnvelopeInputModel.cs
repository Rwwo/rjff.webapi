namespace rjff.avmb.core.InputModels
{
    public class DownloadPDFEnvelopeInputModel
    {
        public string token { get; private set; }
        public ParamsDownloadPDFEnvelopeInputModel @params { get; private set; }

        public DownloadPDFEnvelopeInputModel(ParamsDownloadPDFEnvelopeInputModel @params, string token)
        {
            this.token = token;
            this.@params = @params;
        }
    }
}