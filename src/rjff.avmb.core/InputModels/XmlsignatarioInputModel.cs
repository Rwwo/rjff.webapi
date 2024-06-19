namespace rjff.avmb.core.InputModels
{
    public class XmlsignatarioInputModel
    {
        public XmlsignatarioInputModel(string? emailSignatario = null,
                                       string? idNodeAssinatura = null,
                                       string? restringirTiposCertificados = null,
                                       string? restringirPessoaFisica = null,
                                       string? restringirPessoaJuridica = null,
                                       string? cpfCnpjAceito = null,
                                       string? carimboInterno = null)
        {
            this.emailSignatario = emailSignatario;
            this.idNodeAssinatura = idNodeAssinatura;
            this.restringirTiposCertificados = restringirTiposCertificados;
            this.restringirPessoaFisica = restringirPessoaFisica;
            this.restringirPessoaJuridica = restringirPessoaJuridica;
            this.cpfCnpjAceito = cpfCnpjAceito;
            this.carimboInterno = carimboInterno;
        }

        public string? emailSignatario { get; private set; }
        public string? idNodeAssinatura { get; private set; }
        public string? restringirTiposCertificados { get; private set; }
        public string? restringirPessoaFisica { get; private set; }
        public string? restringirPessoaJuridica { get; private set; }
        public string? cpfCnpjAceito { get; private set; }
        public string? carimboInterno { get; private set; }
    }


}
