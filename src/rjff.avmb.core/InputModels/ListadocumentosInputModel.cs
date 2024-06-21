using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class ListadocumentosInputModel
    {
        [DefaultValue(typeof(List<DocumentoInputModel>), "[]")]
        public List<DocumentoInputModel> Documento { get; set; }
    }
}
