using rjff.avmb.core.Models;

namespace rjff.avmb.core.InputModels
{
    public class SignatarioenvelopeInputModel
    {
        public Envelope Envelope { get; set; }
        public int ordem { get; set; }
        public object tagAncoraCampos { get; set; }
        public ConfigassinaturaInputModel ConfigAssinatura { get; set; }
    }
}
