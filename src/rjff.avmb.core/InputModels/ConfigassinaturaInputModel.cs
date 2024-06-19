namespace rjff.avmb.core.InputModels
{
    public class ConfigassinaturaInputModel
    {
        public string emailSignatario { get; set; }
        public string nomeSignatario { get; set; }
        public object celularSignatario { get; set; }
        public object opcaoAutenticacao { get; set; }
        public int tipoAssinatura { get; set; }
        public string permitirDelegar { get; set; }
        public string apenasCelular { get; set; }
        public string exigirLogin { get; set; }
        public string exigirCodigo { get; set; }
        public string exigirDadosIdentif { get; set; }
        public string assinaturaPresencial { get; set; }
        public object nomeSignPresencial { get; set; }
        public object cpfSignPresencial { get; set; }
        public string ignorarRecusa { get; set; }
        public object codigoExigido { get; set; }
        public string incluirImagensAutentEnvelope { get; set; }
        public string analisarFaceImagem { get; set; }
        public int percentualPrecisaoFace { get; set; }
        public string intervaloPaginaDesenho { get; set; }
    }
}
