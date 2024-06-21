using System.ComponentModel;

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

        [DefaultValue(null)]
        public string nomeArquivo { get; set; }
        
        [DefaultValue(null)]
        public string mimeType { get; set; }
        
        [DefaultValue(null)]
        public string conteudo { get; set; }
        public ListaxmlauxiliarInputModel listaXMLAuxiliar { get; set; }
    }
}
