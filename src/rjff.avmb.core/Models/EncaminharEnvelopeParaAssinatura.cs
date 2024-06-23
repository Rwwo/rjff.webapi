using rjff.avmb.core.InputModels;

namespace rjff.avmb.core.Models
{
    public class EncaminharEnvelopeParaAssinatura : Entity
    {
        public string token { get; set; }
        public ParamsEncaminharEnvelopeParaAssinaturaInputModel @params { get; set; }

    }
}
