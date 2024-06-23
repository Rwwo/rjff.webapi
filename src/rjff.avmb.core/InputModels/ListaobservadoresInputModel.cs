using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class ListaobservadoresInputModel
    {

        public List<string> Observador { get; set; } = Enumerable.Empty<string>().ToList();
    }
}
