using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class ListaxmlsignatarioInputModel
    {
        [DefaultValue(typeof(List<XmlsignatarioInputModel>), "[]")]
        public List<XmlsignatarioInputModel> XMLSignatario { get; set; } = new List<XmlsignatarioInputModel>();
    }
}
