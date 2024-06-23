using System.ComponentModel;

using rjff.avmb.core.Models;

namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class ParamsDownloadPDFEnvelope
    {
        [DefaultValue("3f2f91ace674c844fbb9805bcdcb9cacc88e956dd17b9a69e156a0fe34782060")]
        public string hashSHA256 { get; set; }
        [DefaultValue("N")]
        public string incluirDocs { get; set; }

        [DefaultValue(null)]
        public string? versaoSemCertificado { get; set; }
    }
}