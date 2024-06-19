namespace rjff.avmb.core.InputModels
{
    public class EnvelopeInputModel
    {
        public EnvelopeInputModel(
                string descricao,
                RepositorioInputModel repositorio,
                string mensagem,
                string mensagemObservadores,
                string mensagemNotificacaoSMS,
                string dataExpiracao,
                string horaExpiracao,
                string usarOrdem,
                ConfigAuxiliarInputModel configAuxiliar,
                ListadocumentosInputModel listaDocumentos,
                ListasignatariosenvelopeInputModel listaSignatariosEnvelope,
                ListaobservadoresInputModel listaObservadores,
                ListatagsInputModel listaTags,
                ListainfoadicionalInputModel listaInfoAdicional,
                string incluirHashTodasPaginas,
                string permitirDespachos,
                string ignorarNotificacoes,
                string ignorarNotificacoesPendentes,
                string qrCodePosLeft,
                string qrCodePosTop,
                string dataIniContrato,
                string dataFimContrato,
                string objetoContrato,
                string numContrato,
                string valorContrato,
                string descricaoContratante,
                string descricaoContratado,
                string bloquearDesenhoPaginas)
        {
            this.descricao = descricao;
            this.Repositorio = repositorio;
            this.mensagem = mensagem;
            this.mensagemObservadores = mensagemObservadores;
            this.mensagemNotificacaoSMS = mensagemNotificacaoSMS;
            this.dataExpiracao = dataExpiracao;
            this.horaExpiracao = horaExpiracao;
            this.usarOrdem = usarOrdem;
            this.ConfigAuxiliar = configAuxiliar;
            this.listaDocumentos = listaDocumentos;
            this.listaSignatariosEnvelope = listaSignatariosEnvelope;
            this.listaObservadores = listaObservadores;
            this.listaTags = listaTags;
            this.listaInfoAdicional = listaInfoAdicional;
            this.incluirHashTodasPaginas = incluirHashTodasPaginas;
            this.permitirDespachos = permitirDespachos;
            this.ignorarNotificacoes = ignorarNotificacoes;
            this.ignorarNotificacoesPendentes = ignorarNotificacoesPendentes;
            this.qrCodePosLeft = qrCodePosLeft;
            this.qrCodePosTop = qrCodePosTop;
            this.dataIniContrato = dataIniContrato;
            this.dataFimContrato = dataFimContrato;
            this.objetoContrato = objetoContrato;
            this.numContrato = numContrato;
            this.valorContrato = valorContrato;
            this.descricaoContratante = descricaoContratante;
            this.descricaoContratado = descricaoContratado;
            this.bloquearDesenhoPaginas = bloquearDesenhoPaginas;
        }

        public string descricao { get; set; }
        public RepositorioInputModel Repositorio { get; set; }
        public string? mensagem { get; set; }
        public string? mensagemObservadores { get; set; }
        public string? mensagemNotificacaoSMS { get; set; }
        public string? dataExpiracao { get; set; }
        public string? horaExpiracao { get; set; }
        public string usarOrdem { get; set; }
        public ConfigAuxiliarInputModel ConfigAuxiliar { get; set; }
        public ListadocumentosInputModel listaDocumentos { get; set; }
        public ListasignatariosenvelopeInputModel listaSignatariosEnvelope { get; set; }
        public ListaobservadoresInputModel listaObservadores { get; set; }
        public ListatagsInputModel listaTags { get; set; }
        public ListainfoadicionalInputModel listaInfoAdicional { get; set; }
        public string incluirHashTodasPaginas { get; set; } = "S";
        public string permitirDespachos { get; set; } = "S";
        public string ignorarNotificacoes { get; set; } = "N";
        public string ignorarNotificacoesPendentes { get; set; } = "N";
        public object qrCodePosLeft { get; set; }
        public object qrCodePosTop { get; set; }
        public object dataIniContrato { get; set; }
        public object dataFimContrato { get; set; }
        public object objetoContrato { get; set; }
        public object numContrato { get; set; }
        public object valorContrato { get; set; }
        public object descricaoContratante { get; set; }
        public object descricaoContratado { get; set; }
        public string bloquearDesenhoPaginas { get; set; } = "S";
    }
}
