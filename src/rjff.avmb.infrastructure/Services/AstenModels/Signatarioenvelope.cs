namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class Signatarioenvelope
    {
        public Envelope Envelope { get; set; }
        public int ordem { get; set; }
        public object tagAncoraCampos { get; set; }
        public Configassinatura ConfigAssinatura { get; set; }
    }


}
