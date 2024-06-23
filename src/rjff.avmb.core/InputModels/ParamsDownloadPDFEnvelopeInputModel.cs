using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class ParamsDownloadPDFEnvelopeInputModel
    {
        public ParamsDownloadPDFEnvelopeInputModel(string hashSHA256, string incluirDocs = "N", string? versaoSemCertificado = null)
        {
            this.hashSHA256 = hashSHA256;
            this.incluirDocs = incluirDocs;
            this.versaoSemCertificado = versaoSemCertificado;
        }

        [DefaultValue("3f2f91ace674c844fbb9805bcdcb9cacc88e956dd17b9a69e156a0fe34782060")]
        public string hashSHA256 { get; private set; }
        [DefaultValue("N")]
        public string incluirDocs { get; private set; }

        [DefaultValue(null)]
        public string? versaoSemCertificado { get; private set; }
    }

}