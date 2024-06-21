using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class ListainfoadicionalInputModel
    {
        [DefaultValue(typeof(List<object>), "[]")]
        public List<object> InfoAdicional { get; set; } = Enumerable.Empty<object>().ToList();
    }
}
