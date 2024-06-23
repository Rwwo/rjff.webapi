namespace rjff.avmb.core.InputModels
{
    public class StatusEnvelopeInputModel
    {
        public string token { get; private set; }
        public ParamsStatusEnvelopeInputModel @params { get; private set; }

        public StatusEnvelopeInputModel(string token, ParamsStatusEnvelopeInputModel @params)
        {
            this.token = token;
            this.@params = @params;
        }
    }
}
