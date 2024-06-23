namespace rjff.avmb.core.ViewModel
{

    public class StatusEnvelopeViewModel
    {
        public ResponseStatusEnvViewModel response { get; set; }
    }

    public class ResponseStatusEnvViewModel
    {
        public string id { get; set; }
        public RepositorioViewModel Repositorio { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public string descricao { get; set; }
        public string conteudo { get; set; }
        public string incluirHashTodasPaginas { get; set; }
        public string permitirDespachos { get; set; }
        public string usarOrdem { get; set; }
        public string hashSHA256 { get; set; }
        public string hashSHA512 { get; set; }
        public string mensagem { get; set; }
        public string mensagemObservadores { get; set; }
        public string motivoCancelamento { get; set; }
        public string numeroPaginas { get; set; }
        public string status { get; set; }
        public DateTime dataHoraCriacao { get; set; }
        public DateTime dataHoraAlteracao { get; set; }
        public string objetoContrato { get; set; }
        public string statusContrato { get; set; }
        public string numContrato { get; set; }
        public string descricaoContratante { get; set; }
        public string descricaoContratado { get; set; }
        public string bloquearDesenhoPaginas { get; set; }
        public string Envelope { get; set; }
    }

    public class RepositorioViewModel
    {
        public string id { get; set; }
    }

    public class UsuarioViewModel
    {
        public string id { get; set; }
    }

}
