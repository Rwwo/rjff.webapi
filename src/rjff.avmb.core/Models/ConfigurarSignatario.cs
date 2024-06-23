using rjff.avmb.core.InputModels;

namespace rjff.avmb.core.Models
{
    public class ConfigurarSignatario : Entity
    {
        public string token { get; set; }
        public ParamsConfigurarSignatarioInputModel @params { get; set; }
    }
}
