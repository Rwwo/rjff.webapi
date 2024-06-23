using MediatR.NotificationPublishers;

namespace rjff.avmb.infrastructure.Services.AstenModels
{
    // Classe base para todas as respostas genéricas
    public class BaseResponse<T>
    {
        public ResponseData<T> response { get; set; }
    }

    // Classe base para os dados das respostas genéricas
    public class ResponseData<T>
    {
        public string mensagem { get; set; }
        public T data { get; set; }
    }

    // Classe base para lista de avisos
    public class BaseDataWithAvisos
    {
        public ListaAvisos listaAvisos { get; set; }
    }

    // Classe genérica para dados de criação de envelope
    public class DataCriarEnvelope : BaseDataWithAvisos
    {
        public string idEnvelope { get; set; }
        public string hashSHA256 { get; set; }
        public ListaDadosSignatarios listaDadosSignatarios { get; set; }
    }

    // Classe específica para a resposta de criação de envelope
    public class ResponseCriarEnvelope : BaseResponse<DataCriarEnvelope>
    {
    }

    // Classe genérica para dados de configuração de signatário
    public class DataConfigurarSignatario : BaseDataWithAvisos
    {
        public string idSignatarioEnv { get; set; }
    }

    // Classe específica para a resposta de configuração de signatário
    public class ResponseConfigurarSignatario : BaseResponse<DataConfigurarSignatario>
    {
    }



    // Classe de dados de signatário para reenvio
    public class DadosSignatarioReenvio
    {
        public string nome { get; set; }
        public string email { get; set; }
        public object celular { get; set; }
        public string linkAcesso { get; set; }
    }

    // Lista de dados de signatários
    public class ListaDadosSignatarios
    {
        public DadosSignatarioReenvio[] DadosSignatarioReenvio { get; set; }
    }

    // Classe de aviso
    public class Aviso
    {
        public string tipo { get; set; }
        public string mensagem { get; set; }
    }

    // Lista de avisos
    public class ListaAvisos
    {
        public Aviso aviso { get; set; }
    }



    public class ResponseStatusEnvelope
    {
        public ResponseStatusEnv response { get; set; }
    }

    public class ResponseStatusEnv
    {
        public string id { get; set; }
        public Repositorio Repositorio { get; set; }
        public Usuario Usuario { get; set; }
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

    public class Usuario
    {
        public string id { get; set; }
    }


}
