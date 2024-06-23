namespace rjff.avmb.core.InputModels
{
    public class EncaminharEnvelopeParaAssinaturaInputModel
    {
        //private string token { get; private set; }
        public ParamsEncaminharEnvelopeParaAssinaturaInputModel @params { get; private set; }

        public EncaminharEnvelopeParaAssinaturaInputModel( ParamsEncaminharEnvelopeParaAssinaturaInputModel @params)
        {
            //this.token = token;
            this.@params = @params;
        }
    }
}
