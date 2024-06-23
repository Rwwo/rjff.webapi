using rjff.avmb.core.Interfaces;

namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class ParamsEncaminharAssinatura : Params
    {
        public EnvelopeInputDTO Envelope { get; set; }
        public string agendarEnvio { get; set; }
        public string detectarCampos { get; set; }
        public string? dataEnvioAgendado { get; set; }
        public string? horaEnvioAgendado { get; set; }
    }





}
