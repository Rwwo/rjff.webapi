namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class EncaminharEnvelopeParaAssinaturaBuilder
    {
        public EncaminharEnvelopeParaAssinatura _encaminharParaAssinatura;

        public EncaminharEnvelopeParaAssinaturaBuilder()
        {
            _encaminharParaAssinatura = new EncaminharEnvelopeParaAssinatura();
        }

        public EncaminharEnvelopeParaAssinaturaBuilder ComToken(string token)
        {
            _encaminharParaAssinatura.token = token;
            return this;
        }

        public EncaminharEnvelopeParaAssinaturaBuilder ComEnvelope(int id)
        {
            if (_encaminharParaAssinatura.@params == null)
                _encaminharParaAssinatura.@params = new();

            _encaminharParaAssinatura.@params.Envelope = new EnvelopeInputDTO()
            {
                id = id,
            };

            return this;
        }

        public EncaminharEnvelopeParaAssinaturaBuilder ComAgendarEnvio(string agendarEnvio)
        {
            if (_encaminharParaAssinatura.@params == null)
                _encaminharParaAssinatura.@params = new();

            _encaminharParaAssinatura.@params.agendarEnvio = agendarEnvio;
            return this;
        }

        public EncaminharEnvelopeParaAssinaturaBuilder ComDetectarCampos(string detectarCampos)
        {
            if (_encaminharParaAssinatura.@params == null)
                _encaminharParaAssinatura.@params = new();

            _encaminharParaAssinatura.@params.detectarCampos = detectarCampos;
            return this;
        }

        public EncaminharEnvelopeParaAssinaturaBuilder ComDataEnvioAgendado(string? dataEnvioAgendado)
        {
            if (_encaminharParaAssinatura.@params == null)
                _encaminharParaAssinatura.@params = new();

            _encaminharParaAssinatura.@params.horaEnvioAgendado = dataEnvioAgendado;
            return this;
        }

        public EncaminharEnvelopeParaAssinaturaBuilder ComHoraEnvioAgendado(string? horaEnvioAgendado)
        {
            if (_encaminharParaAssinatura.@params == null)
                _encaminharParaAssinatura.@params = new();

            _encaminharParaAssinatura.@params.horaEnvioAgendado = horaEnvioAgendado;
            return this;
        }

        public EncaminharEnvelopeParaAssinatura Build()
        {
            return _encaminharParaAssinatura;
        }
    }





}
