using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class ListasignatariosenvelopeInputModel
    {
        [DefaultValue(typeof(List<object>), "[]")]
        public List<object> SignatarioEnvelope { get; set; } = Enumerable.Empty<object>().ToList();
    }
}
