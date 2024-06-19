using rjff.avmb.core.Interfaces;

namespace rjff.avmb.core.Models
{

    public class JwtSettings
    {
        public string? Segredo { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string? Emissor { get; set; }
        public string? Audiencia { get; set; }
    }


    public class Rootobject
    {
        public string token { get; set; }
        public Params @params { get; set; }
    }

}
