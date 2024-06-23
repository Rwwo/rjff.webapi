namespace rjff.avmb.core.InputModels
{
    public class EncaminharEnvelopeParaAssinaturaInputModel
    {
        public string token { get; private set; }
        public ParamsEncaminharEnvelopeParaAssinaturaInputModel @params { get; private set; }

        public EncaminharEnvelopeParaAssinaturaInputModel(ParamsEncaminharEnvelopeParaAssinaturaInputModel @params, string token )
        {
            this.token = token;
            this.@params = @params;
        }
    }
}
