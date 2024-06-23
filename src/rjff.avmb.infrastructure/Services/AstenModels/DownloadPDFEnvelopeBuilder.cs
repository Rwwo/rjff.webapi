namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class DownloadPDFEnvelopeBuilder
    {
        public DownloadPDFEnvelope _DownloadPDFEnvelope;
        public DownloadPDFEnvelopeBuilder()
        {
            _DownloadPDFEnvelope = new DownloadPDFEnvelope();
        }

        public DownloadPDFEnvelopeBuilder ComToken(string token)
        {
            _DownloadPDFEnvelope.token = token;
            return this;
        }
        public DownloadPDFEnvelopeBuilder ComHashSHA256(string hashSHA256)
        {
            if (_DownloadPDFEnvelope.@params == null)
                _DownloadPDFEnvelope.@params = new();

            _DownloadPDFEnvelope.@params.hashSHA256 = hashSHA256;
            return this;
        }

        public DownloadPDFEnvelopeBuilder ComIncluirDocs(string incluirDocs)
        {
            if (_DownloadPDFEnvelope.@params == null)
                _DownloadPDFEnvelope.@params = new();

            _DownloadPDFEnvelope.@params.incluirDocs = incluirDocs;
            return this;
        }

        public DownloadPDFEnvelopeBuilder ComVersaoSemCertificado(string? versaoSemCertificado)
        {
            if (_DownloadPDFEnvelope.@params == null)
                _DownloadPDFEnvelope.@params = new();

            _DownloadPDFEnvelope.@params.versaoSemCertificado = versaoSemCertificado;
            return this;
        }

        public DownloadPDFEnvelope Build()
        {
            return _DownloadPDFEnvelope;
        }
    }
}