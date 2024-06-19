namespace rjff.avmb.core.InputModels
{
    public class XmlauxiliarInputModel
    {
        public XmlauxiliarInputModel(string? nomeArquivo, string? conteudoXML, List<ListaxmlsignatarioInputModel> listaXMLSignatario)
        {
            this.nomeArquivo = nomeArquivo;
            this.conteudoXML = conteudoXML;
            this.listaXMLSignatario = listaXMLSignatario;
        }

        public string? nomeArquivo { get; private set; }
        public string? conteudoXML { get; private set; }
        public List<ListaxmlsignatarioInputModel> listaXMLSignatario { get; private set; }
    }
}
