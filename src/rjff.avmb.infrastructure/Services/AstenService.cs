using Flurl.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using rjff.avmb.core.Models;
using rjff.avmb.core.Utils;
using rjff.avmb.infrastructure.Services.AstenModels;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace rjff.avmb.infrastructure.Services
{
    public class AstenService : IAstenService
    {
        private readonly string _urlBase;
        private readonly string _token;
        private readonly AstenServiceCredencials _credentials;

        public AstenService(IOptions<AstenServiceCredencials> credentials)
        {
            _credentials = credentials.Value;
            _token = _credentials.Token;
            _urlBase = _credentials.IsDevelopment ? Constantes.URL_BASE_HOMOLOGACAO : Constantes.URL_BASE_PRODUCAO;
        }

        public string GetToken()
        {
            return _token;
        }

        private async Task<GenericResult<T>> ExecuteRequestAsync<T>(string endpoint, HttpMethod method, object body = null)
        {
            var url = _urlBase + endpoint;
            try
            {
                var request = url
                    .WithOAuthBearerToken(_token)
                    .WithHeader("accept", "application/json")
                    .WithHeader("Content-Type", "application/json");

                IFlurlResponse response;

                if (method == HttpMethod.Post)
                    response = await request.PostJsonAsync(body);
                else if (method == HttpMethod.Put)
                    response = await request.PutJsonAsync(body);
                else if (method == HttpMethod.Delete)
                    response = await request.DeleteAsync();
                else
                    response = await request.GetAsync();

                var responseContent = await response.GetStringAsync();

                // Deserializa o conteúdo da resposta para o tipo genérico T

                return new GenericResult<T>
                {
                    HttpCode = response.StatusCode,
                    Result = JsonConvert.DeserializeObject<T>(responseContent),
                    Errors = null
                };

            }
            catch (JsonException ex)
            {
                return new GenericResult<T>
                {
                    HttpCode = 500,
                    Result = default,
                    Errors = new List<Error>
                    {
                        new Error { error = ex.Message }
                    }
                };
            }
            catch (FlurlHttpException ex)
            {
                var errorDetails = await ex.GetResponseStringAsync();
                List<Error> errors = DeserializeErrorDetails(errorDetails, ex);

                return new GenericResult<T>
                {
                    HttpCode = (int)ex.StatusCode,
                    Result = default,
                    Errors = errors
                };
            }
            catch (Exception ex)
            {
                return new GenericResult<T>
                {
                    HttpCode = 500,
                    Result = default,
                    Errors = new List<Error>
                    {
                        new Error { error = ex.Message }
                    }
                };
            }
        }

        private List<Error> DeserializeErrorDetails(string errorDetails, FlurlHttpException ex)
        {
            List<Error> errors = TryDeserializeList<Error>(errorDetails);

            if (errors == null)
            {
                // Se falhar, tenta desserializar como um único erro
                var singleError = TryDeserialize<Error>(errorDetails);
                errors = singleError != null ? new List<Error> { singleError } : new List<Error> { new Error { error = ex.Message } };
            }

            return errors;
        }

        private T TryDeserialize<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (JsonException)
            {
                return default;
            }
        }
        private List<T> TryDeserializeList<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch (JsonException)
            {
                return null;
            }
        }

        public Task<GenericResult<ResponseCriarEnvelope>> CriarNovoEnvelope(AstenModels.CriarEnvelope envelope)
        {
            return ExecuteRequestAsync<ResponseCriarEnvelope>(Constantes.URL_CRIAR_ENVELOPE, HttpMethod.Post, envelope);
        }

        public Task<GenericResult<ResponseConfigurarSignatario>> ConfigurarSignatario(AstenModels.ConfigurarSignatario envFinal)
        {
            return ExecuteRequestAsync<ResponseConfigurarSignatario>(Constantes.URL_INSERIR_SIGNATARIO_ENVELOPE, HttpMethod.Post, envFinal);
        }

        public Task<GenericResult<ResponseStatusEnvelope>> StatusEnvelope(StatusEnvelope envFinal)
        {
            return ExecuteRequestAsync<ResponseStatusEnvelope>(Constantes.URL_STATUS_ENVELOPE, HttpMethod.Post, envFinal);
        }

        public Task<GenericResult<BaseResponse<BaseDataWithAvisos>>> EncaminharEnvelopeParaAssinatura(AstenModels.EncaminharEnvelopeParaAssinatura envFinal)
        {
            return ExecuteRequestAsync<BaseResponse<BaseDataWithAvisos>>(Constantes.URL_ENCAMINHAR_ENVELOPE_ASSINATURA, HttpMethod.Post, envFinal);
        }
    }
}
