using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class ConfigassinaturaInputModel
    {
        public ConfigassinaturaInputModel(string emailSignatario, string nomeSignatario, object? celularSignatario, object? opcaoAutenticacao, int tipoAssinatura, string permitirDelegar, string apenasCelular, string exigirLogin, string exigirCodigo, string exigirDadosIdentif, string assinaturaPresencial, object? nomeSignPresencial, object? cpfSignPresencial, string ignorarRecusa, object? codigoExigido, string incluirImagensAutentEnvelope, string analisarFaceImagem, int percentualPrecisaoFace, string intervaloPaginaDesenho)
        {
            this.emailSignatario = emailSignatario;
            this.nomeSignatario = nomeSignatario;
            this.celularSignatario = celularSignatario;
            this.opcaoAutenticacao = opcaoAutenticacao;
            this.tipoAssinatura = tipoAssinatura;
            this.permitirDelegar = permitirDelegar;
            this.apenasCelular = apenasCelular;
            this.exigirLogin = exigirLogin;
            this.exigirCodigo = exigirCodigo;
            this.exigirDadosIdentif = exigirDadosIdentif;
            this.assinaturaPresencial = assinaturaPresencial;
            this.nomeSignPresencial = nomeSignPresencial;
            this.cpfSignPresencial = cpfSignPresencial;
            this.ignorarRecusa = ignorarRecusa;
            this.codigoExigido = codigoExigido;
            this.incluirImagensAutentEnvelope = incluirImagensAutentEnvelope;
            this.analisarFaceImagem = analisarFaceImagem;
            this.percentualPrecisaoFace = percentualPrecisaoFace;
            this.intervaloPaginaDesenho = intervaloPaginaDesenho;
        }

        [DefaultValue("usuario2@avmb.com.br")]
        public string emailSignatario { get; private set; }

        [DefaultValue("Nome do Usuário")]
        public string nomeSignatario { get; private set; }

        [DefaultValue(null)]
        public object? celularSignatario { get; private set; }

        [DefaultValue(null)]
        public object? opcaoAutenticacao { get; private set; }

        [DefaultValue(1)]
        public int tipoAssinatura { get; private set; }
        [DefaultValue("N")]
        public string permitirDelegar { get; private set; }
        [DefaultValue("N")]
        public string apenasCelular { get; private set; }
        [DefaultValue("N")]
        public string exigirLogin { get; private set; }
        [DefaultValue("N")]
        public string exigirCodigo { get; private set; }
        [DefaultValue("N")]
        public string exigirDadosIdentif { get; private set; }
        [DefaultValue("N")]
        public string assinaturaPresencial { get; private set; }

        [DefaultValue(null)]
        public object? nomeSignPresencial { get; private set; }
        [DefaultValue(null)]
        public object? cpfSignPresencial { get; private set; }

        [DefaultValue("N")]
        public string ignorarRecusa { get; private set; }

        [DefaultValue(null)]
        public object? codigoExigido { get; private set; }
        [DefaultValue("N")]
        public string incluirImagensAutentEnvelope { get; private set; }

        [DefaultValue("N")]
        public string analisarFaceImagem { get; private set; }

        [DefaultValue(0)]
        public int percentualPrecisaoFace { get; private set; }

        [DefaultValue("1,3,4-10")]
        public string intervaloPaginaDesenho { get; private set; }
    }
}
