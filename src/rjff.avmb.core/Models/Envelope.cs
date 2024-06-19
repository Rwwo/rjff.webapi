using System.ComponentModel.DataAnnotations.Schema;

namespace rjff.avmb.core.Models
{
    public class Envelope : Entity
    {
        public int id { get; set; }
        public string descricao { get; set; }

        [NotMapped] public object Repositorio { get; set; }
        [NotMapped] public object mensagem { get; set; }
        [NotMapped] public object mensagemObservadores { get; set; }
        [NotMapped] public object mensagemNotificacaoSMS { get; set; }
        [NotMapped] public object dataExpiracao { get; set; }
        [NotMapped] public object horaExpiracao { get; set; }
        [NotMapped] public string usarOrdem { get; set; }
        [NotMapped] public object ConfigAuxiliar { get; set; }
        [NotMapped] public object listaDocumentos { get; set; }
        [NotMapped] public object listaSignatariosEnvelope { get; set; }
        [NotMapped] public object listaObservadores { get; set; }
        [NotMapped] public object listaTags { get; set; }
        [NotMapped] public object listaInfoAdicional { get; set; }
        [NotMapped] public string incluirHashTodasPaginas { get; set; }
        [NotMapped] public string permitirDespachos { get; set; }
        [NotMapped] public string ignorarNotificacoes { get; set; }
        [NotMapped] public string ignorarNotificacoesPendentes { get; set; }
        [NotMapped] public object qrCodePosLeft { get; set; }
        [NotMapped] public object qrCodePosTop { get; set; }
        [NotMapped] public object dataIniContrato { get; set; }
        [NotMapped] public object dataFimContrato { get; set; }
        [NotMapped] public object objetoContrato { get; set; }
        [NotMapped] public object numContrato { get; set; }
        [NotMapped] public object valorContrato { get; set; }
        [NotMapped] public object descricaoContratante { get; set; }
        [NotMapped] public object descricaoContratado { get; set; }
        [NotMapped] public string bloquearDesenhoPaginas { get; set; }
    }
}
