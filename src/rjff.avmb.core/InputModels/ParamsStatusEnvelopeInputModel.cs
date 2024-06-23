using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class ParamsStatusEnvelopeInputModel
    {
        public ParamsStatusEnvelopeInputModel(int idEnvelope, string getLobs)
        {
            this.idEnvelope = idEnvelope;
            this.getLobs = getLobs;
        }
        public int idEnvelope { get; set; }

        [DefaultValue("N")]
        public string getLobs { get; private set; }
    }
}
