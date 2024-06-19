namespace rjff.avmb.core.InputModels
{
    public class DocumentoInputModel
    {
        public DocumentoInputModel(string nomeArquivo, string mimeType, string conteudo, ListaxmlauxiliarInputModel listaXMLAuxiliar)
        {
            this.nomeArquivo = nomeArquivo;
            this.mimeType = mimeType;
            this.conteudo = conteudo;
            this.listaXMLAuxiliar = listaXMLAuxiliar;
        }

        public string nomeArquivo { get; set; }
        public string mimeType { get; set; }
        public string conteudo { get; set; }
        public ListaxmlauxiliarInputModel listaXMLAuxiliar { get; set; }
    }
}
