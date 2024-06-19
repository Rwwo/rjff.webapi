using rjff.avmb.core.InputModels;

namespace rjff.avmb.core.Models
{
    public class CriarEnvelope : Entity
    {
        public string Token { get; set; }
        public CriarEnvelopeInputModel Params { get; set; }
    }
}
