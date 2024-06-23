using rjff.avmb.core.Interfaces;

namespace rjff.avmb.core.InputModels
{
    public class CriarEnvelopeInputModel
    {
        public string token { get; private set; }
        public ParamsCriarEnvelopeInputModel @params { get; private set; }

        public CriarEnvelopeInputModel(string token, ParamsCriarEnvelopeInputModel @params)
        {
            this.token = token;
            this.@params = @params;
        }
    }
}
