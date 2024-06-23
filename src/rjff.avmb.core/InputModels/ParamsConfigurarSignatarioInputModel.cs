namespace rjff.avmb.core.InputModels
{
    public class ParamsConfigurarSignatarioInputModel
    {
        public ParamsConfigurarSignatarioInputModel(SignatarioenvelopeInputModel signatarioEnvelope)
        {
            SignatarioEnvelope = signatarioEnvelope;
        }

        public SignatarioenvelopeInputModel SignatarioEnvelope { get; private set; }
    }
}
