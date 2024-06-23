using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class DocumentoInputModel
    {

        [DefaultValue("texto.txt")]
        public string? nomeArquivo { get; set; }

        [DefaultValue("text/html")]
        public string? mimeType { get; set; }

        [DefaultValue("cnViZW5zIGZhY2NvLCB0ZXN0ZSB0w6ljbmljbw==")]
        public string? conteudo { get; set; }
        public ListaxmlauxiliarInputModel? listaXMLAuxiliar { get; set; }
    }
}
