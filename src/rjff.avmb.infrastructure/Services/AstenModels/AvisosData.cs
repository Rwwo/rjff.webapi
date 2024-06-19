using Newtonsoft.Json;

namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class AvisosData
    {
        [JsonProperty("aviso")]
        public Aviso Aviso { get; set; }
    }


}
