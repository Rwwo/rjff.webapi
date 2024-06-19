using Newtonsoft.Json;

namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class ResponseData
    {
        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }

        [JsonProperty("data")]
        public EnvelopeData Data { get; set; }
    }


}
