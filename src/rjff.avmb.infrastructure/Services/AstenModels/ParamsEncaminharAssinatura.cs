using rjff.avmb.core.Interfaces;

namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class ParamsEncaminharAssinatura : Params
    {
        public Envelope Envelope { get; set; }
        public string agendarEnvio { get; set; }
        public string detectarCampos { get; set; }
        public object dataEnvioAgendado { get; set; }
        public object horaEnvioAgendado { get; set; }
    }





}
