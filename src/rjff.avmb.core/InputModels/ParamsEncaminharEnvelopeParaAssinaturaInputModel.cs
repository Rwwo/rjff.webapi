using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class ParamsEncaminharEnvelopeParaAssinaturaInputModel
    {
        public ParamsEncaminharEnvelopeParaAssinaturaInputModel(EnvelopeDTOInputModel Envelope, string agendarEnvio, string detectarCampos, string? dataEnvioAgendado = null, string? horaEnvioAgendado = null)
        {
            this.Envelope = Envelope;
            this.agendarEnvio = agendarEnvio;
            this.detectarCampos = detectarCampos;
            this.dataEnvioAgendado = dataEnvioAgendado;
            this.horaEnvioAgendado = horaEnvioAgendado;
        }

        public EnvelopeDTOInputModel Envelope { get; private set; }

        [DefaultValue("N")]
        public string agendarEnvio { get; private set; }
        
        [DefaultValue("N")]
        public string detectarCampos { get; private set; }
        
        [DefaultValue(null)]
        public string? dataEnvioAgendado { get; private set; }
        
        [DefaultValue(null)]
        public string? horaEnvioAgendado { get; private set; }


    }
}