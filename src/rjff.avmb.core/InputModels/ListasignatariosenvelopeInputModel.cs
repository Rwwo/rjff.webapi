using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace rjff.avmb.core.InputModels
{
    public class ListasignatariosenvelopeInputModel
    {
        public List<string> SignatarioEnvelope { get; set; } = Enumerable.Empty<string>().ToList();
    }
}
