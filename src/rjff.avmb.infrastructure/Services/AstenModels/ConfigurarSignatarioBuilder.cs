using rjff.avmb.core.InputModels;

namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class ConfigurarSignatarioBuilder
    {
        private ConfigurarSignatario _confSignatario;
        public ConfigurarSignatarioBuilder()
        {
            _confSignatario = new ConfigurarSignatario();
        }
        public ConfigurarSignatarioBuilder ComToken(string token)
        {
            _confSignatario.token = token;
            return this;
        }
        public ConfigurarSignatarioBuilder ComEnvelope(EnvelopeInputDTO envelope)
        {
            if (_confSignatario.@params == null)
                _confSignatario.@params = new ParamsConfigurarSignatario();

            if (_confSignatario.@params.SignatarioEnvelope == null)
                _confSignatario.@params.SignatarioEnvelope = new Signatarioenvelope();

            _confSignatario.@params.SignatarioEnvelope.Envelope = new Envelope()
            {
                id = envelope.id,
            };
            return this;
        }

        public ConfigurarSignatarioBuilder ComOrdem(int ordem)
        {
            if (_confSignatario.@params == null)
                _confSignatario.@params = new ParamsConfigurarSignatario();


            _confSignatario.@params.SignatarioEnvelope.ordem = ordem;
            return this;
        }

        public ConfigurarSignatarioBuilder ComTag(object tag)
        {
            if (_confSignatario.@params == null)
                _confSignatario.@params = new ParamsConfigurarSignatario();

            _confSignatario.@params.SignatarioEnvelope.tagAncoraCampos = tag;
            return this;
        }

        public ConfigurarSignatarioBuilder ComAssinatura(ConfigassinaturaInputModel configAssinatura)
        {
            if (_confSignatario.@params == null)
                _confSignatario.@params = new ParamsConfigurarSignatario();

            _confSignatario.@params.SignatarioEnvelope.ConfigAssinatura = new Configassinatura()
            {
                analisarFaceImagem = configAssinatura.analisarFaceImagem,
                apenasCelular = configAssinatura.apenasCelular,
                assinaturaPresencial = configAssinatura.assinaturaPresencial,
                celularSignatario = configAssinatura.celularSignatario,
                codigoExigido = configAssinatura.codigoExigido,
                cpfSignPresencial = configAssinatura.cpfSignPresencial,
                emailSignatario = configAssinatura.emailSignatario,
                exigirCodigo = configAssinatura.exigirCodigo,
                exigirDadosIdentif = configAssinatura.exigirDadosIdentif,
                exigirLogin = configAssinatura.exigirLogin,
                ignorarRecusa = configAssinatura.ignorarRecusa,
                incluirImagensAutentEnvelope = configAssinatura.incluirImagensAutentEnvelope,
                intervaloPaginaDesenho = configAssinatura.intervaloPaginaDesenho,
                nomeSignatario = configAssinatura.nomeSignatario,
                nomeSignPresencial = configAssinatura.nomeSignPresencial,
                opcaoAutenticacao = configAssinatura.opcaoAutenticacao,
                percentualPrecisaoFace = configAssinatura.percentualPrecisaoFace,
                permitirDelegar = configAssinatura.permitirDelegar,
                tipoAssinatura = configAssinatura.tipoAssinatura
            };

            return this;
        }

        public ConfigurarSignatario Build()
        {
            return _confSignatario;
        }
    }




}
