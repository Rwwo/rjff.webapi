using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class SignatarioenvelopeInputModel
    {
        public SignatarioenvelopeInputModel(EnvelopeDTOInputModel Envelope, int ordem, ConfigassinaturaInputModel ConfigAssinatura)
        {
            this.Envelope = Envelope;
            this.ordem = ordem;
            this.ConfigAssinatura = ConfigAssinatura;
        }

        public EnvelopeDTOInputModel Envelope { get; private set; }

        [DefaultValue("1")]
        public int ordem { get; private set; }

        [DefaultValue(null)]
        public object? tagAncoraCampos { get; set; }
        public ConfigassinaturaInputModel ConfigAssinatura { get; private set; }
    }
}
