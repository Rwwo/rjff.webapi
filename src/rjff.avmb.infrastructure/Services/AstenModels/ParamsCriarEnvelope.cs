using rjff.avmb.core.Interfaces;

namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class ParamsCriarEnvelope 
    {
        public Envelope Envelope { get; set; }
        public string gerarTags { get; set; }
        public string encaminharImediatamente { get; set; }
        public string detectarCampos { get; set; }
        public string verificarDuplicidadeConteudo { get; set; }
        public string processarImagensEmSegundoPlano { get; set; }
    }





}
