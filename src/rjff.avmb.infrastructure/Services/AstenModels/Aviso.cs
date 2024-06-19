using Newtonsoft.Json;

namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class Aviso
    {
        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }
    }


}
