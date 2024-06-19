namespace rjff.avmb.core.InputModels
{
    public class CriarEnvelopeInputModel
    {
        public string Token { get; private set; }
        public ParamsCriarEnvelopeInputModel Params { get; private set; }

        public CriarEnvelopeInputModel(string token, ParamsCriarEnvelopeInputModel @params)
        {
            Token = token;
            Params = @params;
        }
    }
}
