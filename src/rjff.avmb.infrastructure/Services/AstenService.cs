using Flurl.Http;

using MediatR.NotificationPublishers;

using Microsoft.Extensions.Options;

using Newtonsoft.Json;

using rjff.avmb.core.Models;
using rjff.avmb.core.Utils;
using rjff.avmb.infrastructure.Services.AstenModels;


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
                    //.WithOAuthBearerToken(_token)
                    .WithHeader("accept", "application/json")
                    .WithHeader("Content-Type", "application/json");

                IFlurlResponse response;

                // Condicional para o método HTTP
                if (method == HttpMethod.Post)
                    response = await request.PostJsonAsync(body);
                else if (method == HttpMethod.Put)
                    response = await request.PutJsonAsync(body);
                else if (method == HttpMethod.Delete)
                    response = await request.DeleteAsync();
                else
                    response = await request.GetAsync();

                // Captura o conteúdo da resposta
                var responseContent = await response.GetStringAsync();
                return JsonConvert.DeserializeObject<GenericResult<T>>(responseContent);
            }
            catch (JsonException ex)
            {
                return new GenericResult<T>
                {
                    HttpCode = 500, // Código de erro genérico
                    Result = default,
                    Errors = new List<Error>
                    {
                        new Error()
                        {
                            error = ex.Message
                        }
                    }
                };
            }
            catch (FlurlHttpException ex)
            {
                var errorDetails = await ex.GetResponseStringAsync();
                GenericResult<T> retorno;

                var error = JsonConvert.DeserializeObject<Error>(errorDetails);

                // Caso haja um erro na deserialização da resposta de erro
                retorno = new GenericResult<T>
                {
                    HttpCode = (int)ex.StatusCode,
                    Result = default,
                    Errors = new List<Error>
                    {
                        error
                    }
                };


                return retorno;
            }
            catch (Exception ex)
            {
                return new GenericResult<T>
                {
                    HttpCode = 500, // Código de erro genérico
                    Result = default,
                    Errors = new List<Error>
                    {
                        new Error()
                        {
                            error = ex.Message
                        }
                    }
                };
            }
        }

        public async Task<GenericResult<EnvelopeData>> CriarNovoEnvelope(AstenModels.CriarEnvelope envelope)
        {
            return await ExecuteRequestAsync<EnvelopeData>(Constantes.URL_CRIAR_ENVELOPE, HttpMethod.Post, envelope);
        }
    }
}
