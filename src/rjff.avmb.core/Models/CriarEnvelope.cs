using rjff.avmb.core.InputModels;

namespace rjff.avmb.core.Models
{
    public class CriarEnvelope : Entity
    {
        public string token { get; set; }
        public ParamsCriarEnvelopeInputModel @params { get; set; }
        
    }
}
