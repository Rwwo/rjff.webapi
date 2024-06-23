using System.ComponentModel;

namespace rjff.avmb.core.InputModels
{
    public class EnvelopeInputModel
    {
        public EnvelopeInputModel(string descricao, RepositorioInputModel Repositorio, string? mensagem, string? mensagemObservadores, string? mensagemNotificacaoSMS, string? dataExpiracao, string? horaExpiracao, string usarOrdem, ConfigAuxiliarInputModel ConfigAuxiliar, ListadocumentosInputModel listaDocumentos, ListasignatariosenvelopeInputModel listaSignatariosEnvelope, ListaobservadoresInputModel listaObservadores, ListatagsInputModel listaTags, ListainfoadicionalInputModel listaInfoAdicional, string incluirHashTodasPaginas, string permitirDespachos, string ignorarNotificacoes, string ignorarNotificacoesPendentes, string? qrCodePosLeft, string? qrCodePosTop, string? dataIniContrato, string? dataFimContrato, string? objetoContrato, string? numContrato, decimal? valorContrato, string? descricaoContratante, string? descricaoContratado, string bloquearDesenhoPaginas)
        {
            this.descricao = descricao;
            this.Repositorio = Repositorio;
            this.mensagem = mensagem;
            this.mensagemObservadores = mensagemObservadores;
            this.mensagemNotificacaoSMS = mensagemNotificacaoSMS;
            this.dataExpiracao = dataExpiracao;
            this.horaExpiracao = horaExpiracao;
            this.usarOrdem = usarOrdem;
            this.ConfigAuxiliar = ConfigAuxiliar;
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

        [DefaultValue("Novo Contrato")]
        public string descricao { get; set; }
        public RepositorioInputModel Repositorio { get; set; }

        [DefaultValue(null)]
        public string? mensagem { get; set; }
        [DefaultValue(null)]
        public string? mensagemObservadores { get; set; }
        [DefaultValue(null)]
        public string? mensagemNotificacaoSMS { get; set; }
        [DefaultValue(null)]
        public string? dataExpiracao { get; set; }
        [DefaultValue(null)]
        public string? horaExpiracao { get; set; }

        [DefaultValue("S")]
        public string usarOrdem { get; set; }
        public ConfigAuxiliarInputModel ConfigAuxiliar { get; set; }
        public ListadocumentosInputModel listaDocumentos { get; set; }
        public ListasignatariosenvelopeInputModel listaSignatariosEnvelope { get; set; }
        public ListaobservadoresInputModel listaObservadores { get; set; }
        public ListatagsInputModel listaTags { get; set; }
        public ListainfoadicionalInputModel listaInfoAdicional { get; set; }

        [DefaultValue("S")]
        public string incluirHashTodasPaginas { get; set; }

        [DefaultValue("S")]
        public string permitirDespachos { get; set; }

        [DefaultValue("N")]
        public string ignorarNotificacoes { get; set; }

        [DefaultValue("N")]
        public string ignorarNotificacoesPendentes { get; set; }

        [DefaultValue(null)]
        public string? qrCodePosLeft { get; set; }

        [DefaultValue(null)]
        public string? qrCodePosTop { get; set; }

        [DefaultValue(null)]
        public string? dataIniContrato { get; set; }

        [DefaultValue(null)]
        public string? dataFimContrato { get; set; }

        [DefaultValue(null)]
        public string? objetoContrato { get; set; }

        [DefaultValue(null)]
        public string? numContrato { get; set; }

        [DefaultValue(null)]
        public decimal? valorContrato { get; set; }

        [DefaultValue(null)]
        public string? descricaoContratante { get; set; }

        [DefaultValue(null)]
        public string? descricaoContratado { get; set; }

        [DefaultValue("S")]
        public string bloquearDesenhoPaginas { get; set; }
    }
}
