using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class XmlauxiliarInputModel
    {

        [DefaultValue(null)]
        public string? nomeArquivo { get; set; }

        [DefaultValue(null)]
        public string? conteudoXML { get; set; }
        public List<ListaxmlsignatarioInputModel>? listaXMLSignatario { get; set; }
    }
}
