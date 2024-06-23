namespace rjff.avmb.infrastructure.Services.AstenModels
{

    public class EnvelopeInputDTO
    {
        public int id { get; set; }
    }
    public class Envelope : EnvelopeInputDTO
    {
        public string descricao { get; set; }
        public Repositorio Repositorio { get; set; }
        public string? mensagem { get; set; }
        public string? mensagemObservadores { get; set; }
        public string? mensagemNotificacaoSMS { get; set; }
        public string? dataExpiracao { get; set; }
        public string? horaExpiracao { get; set; }
        public string usarOrdem { get; set; }
        public Configauxiliar ConfigAuxiliar { get; set; }
        public Listadocumentos listaDocumentos { get; set; }
        public Listasignatariosenvelope listaSignatariosEnvelope { get; set; }
        public Listaobservadores listaObservadores { get; set; }
        public Listatags listaTags { get; set; }
        public Listainfoadicional listaInfoAdicional { get; set; }
        public string incluirHashTodasPaginas { get; set; }
        public string permitirDespachos { get; set; }
        public string ignorarNotificacoes { get; set; }
        public string ignorarNotificacoesPendentes { get; set; }
        public object qrCodePosLeft { get; set; }
        public object qrCodePosTop { get; set; }
        public object dataIniContrato { get; set; }
        public object dataFimContrato { get; set; }
        public object objetoContrato { get; set; }
        public object numContrato { get; set; }
        public object valorContrato { get; set; }
        public object descricaoContratante { get; set; }
        public object descricaoContratado { get; set; }
        public object bloquearDesenhoPaginas { get; set; }
    }

}
