using Newtonsoft.Json;

namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class DadosSignatario
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("celular")]
        public string Celular { get; set; }

        [JsonProperty("linkAcesso")]
        public string LinkAcesso { get; set; }
    }


}
