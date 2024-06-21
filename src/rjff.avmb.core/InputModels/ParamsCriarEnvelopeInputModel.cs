using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class ParamsCriarEnvelopeInputModel
    {
        public ParamsCriarEnvelopeInputModel(EnvelopeInputModel envelope,
                                                        string gerarTags,
                                                        string encaminharImediatamente,
                                                        string detectarCampos,
                                                        string verificarDuplicidadeConteudo,
                                                        string processarImagensEmSegundoPlano)
        {
            Envelope = envelope;
            this.gerarTags = gerarTags;
            this.encaminharImediatamente = encaminharImediatamente;
            this.detectarCampos = detectarCampos;
            this.verificarDuplicidadeConteudo = verificarDuplicidadeConteudo;
            this.processarImagensEmSegundoPlano = processarImagensEmSegundoPlano;
        }

        public EnvelopeInputModel Envelope { get; private set; }

        [DefaultValue("N")]
        public string gerarTags { get; private set; }

        [DefaultValue("N")]
        public string encaminharImediatamente { get; private set; }

        [DefaultValue("N")]
        public string detectarCampos { get; private set; }

        [DefaultValue("N")]
        public string verificarDuplicidadeConteudo { get; private set; }

        [DefaultValue("N")]
        public string processarImagensEmSegundoPlano { get; private set; }
    }
}
