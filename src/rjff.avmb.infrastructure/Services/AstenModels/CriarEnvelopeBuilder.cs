namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class CriarEnvelopeBuilder
    {
        private CriarEnvelope _criarEnvelope;
        public CriarEnvelopeBuilder()
        {
            _criarEnvelope = new CriarEnvelope();
        }
        public CriarEnvelopeBuilder ComToken(string token)
        {
            _criarEnvelope.token = token;
            return this;
        }
        public CriarEnvelopeBuilder ComEnvelope(Envelope envelope)
        {
            if (_criarEnvelope.@params == null)
                _criarEnvelope.@params = new ParamsCriarEnvelope();

            _criarEnvelope.@params.Envelope = envelope;
            return this;
        }
        public CriarEnvelopeBuilder ComGerarTags(string gerarTags)
        {
            if (_criarEnvelope.@params == null)
                _criarEnvelope.@params = new ParamsCriarEnvelope();

            if (!string.IsNullOrEmpty(gerarTags))
                _criarEnvelope.@params.gerarTags = gerarTags;
            else
                _criarEnvelope.@params.gerarTags = "S";

            return this;
        }
        public CriarEnvelopeBuilder ComEncaminharImediatamente(string encaminharImediatamente)
        {
            if (_criarEnvelope.@params == null)
                _criarEnvelope.@params = new ParamsCriarEnvelope();

            if (!string.IsNullOrEmpty(encaminharImediatamente))
                _criarEnvelope.@params.encaminharImediatamente = encaminharImediatamente;
            else
                _criarEnvelope.@params.encaminharImediatamente = "N";

            return this;
        }
        public CriarEnvelopeBuilder ComDetectarCampos(string detectarCampos)
        {
            if (_criarEnvelope.@params == null)
                _criarEnvelope.@params = new ParamsCriarEnvelope();

            if (!string.IsNullOrEmpty(detectarCampos))
                _criarEnvelope.@params.detectarCampos = detectarCampos;
            else
                _criarEnvelope.@params.detectarCampos = "N";

            return this;
        }
        public CriarEnvelopeBuilder ComVerificarDuplicidadeConteudo(string verificarDuplicidadeConteudo)
        {
            if (_criarEnvelope.@params == null)
                _criarEnvelope.@params = new ParamsCriarEnvelope();

            if (!string.IsNullOrEmpty(verificarDuplicidadeConteudo))
                _criarEnvelope.@params.verificarDuplicidadeConteudo = verificarDuplicidadeConteudo;
            else
                _criarEnvelope.@params.verificarDuplicidadeConteudo = "N";

            return this;
        }
        public CriarEnvelopeBuilder ComProcessarImagensEmSegundoPlano(string processarImagensEmSegundoPlano)
        {
            if (_criarEnvelope.@params == null)
                _criarEnvelope.@params = new ParamsCriarEnvelope();

            if (!string.IsNullOrEmpty(processarImagensEmSegundoPlano))
                _criarEnvelope.@params.processarImagensEmSegundoPlano = processarImagensEmSegundoPlano;
            else
                _criarEnvelope.@params.processarImagensEmSegundoPlano = "N";

            return this;
        }
        public CriarEnvelope Build()
        {
            return _criarEnvelope;
        }
    }




}
