using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class ListaobservadoresInputModel
    {
        [DefaultValue(typeof(List<object>), "[]")]
        public List<object> Observador { get; set; } = Enumerable.Empty<object>().ToList();  
    }
}
