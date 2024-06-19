using Newtonsoft.Json;

namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class EnvelopeData
    {
        [JsonProperty("idEnvelope")]
        public string IdEnvelope { get; set; }

        [JsonProperty("hashSHA256")]
        public string HashSHA256 { get; set; }

        [JsonProperty("listaDadosSignatarios")]
        public SignatariosData ListaDadosSignatarios { get; set; }

        [JsonProperty("listaAvisos")]
        public AvisosData ListaAvisos { get; set; }
    }


}
