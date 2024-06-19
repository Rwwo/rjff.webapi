namespace rjff.avmb.core.InputModels
{
    public class ParamsCriarEnvelopeInputModel
    {
        public ParamsCriarEnvelopeInputModel(EnvelopeInputModel envelope,
                                                        string gerarTags = "N",
                                                        string encaminharImediatamente = "N",
                                                        string detectarCampos = "N",
                                                        string verificarDuplicidadeConteudo = "N",
                                                        string processarImagensEmSegundoPlano = "N")
        {
            Envelope = envelope;
            this.gerarTags = gerarTags;
            this.encaminharImediatamente = encaminharImediatamente;
            this.detectarCampos = detectarCampos;
            this.verificarDuplicidadeConteudo = verificarDuplicidadeConteudo;
            this.processarImagensEmSegundoPlano = processarImagensEmSegundoPlano;
        }

        public EnvelopeInputModel Envelope { get; private set; }
        public string gerarTags { get; private set; }
        public string encaminharImediatamente { get; private set; }
        public string detectarCampos { get; private set; }
        public string verificarDuplicidadeConteudo { get; private set; }
        public string processarImagensEmSegundoPlano { get; private set; }
    }
}
