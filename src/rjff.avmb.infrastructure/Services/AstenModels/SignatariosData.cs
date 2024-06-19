using Newtonsoft.Json;

namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class SignatariosData
    {
        [JsonProperty("DadosSignatarioReenvio")]
        public List<DadosSignatario> DadosSignatarioReenvio { get; set; }
    }


}
