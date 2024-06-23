using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class XmlsignatarioInputModel
    {

        [DefaultValue(null)]
        public string? emailSignatario { get;  set; }
        [DefaultValue(null)]
        public string? idNodeAssinatura { get;  set; }
        [DefaultValue(null)]
        public string? restringirTiposCertificados { get;  set; }
        [DefaultValue(null)]
        public string? restringirPessoaFisica { get;  set; }
        [DefaultValue(null)]
        public string? restringirPessoaJuridica { get;  set; }
        [DefaultValue(null)]
        public string? cpfCnpjAceito { get;  set; }
        [DefaultValue(null)]
        public string? carimboInterno { get;  set; }

    }


}
