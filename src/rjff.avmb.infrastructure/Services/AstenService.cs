using System.Text.Json;

using Microsoft.Extensions.Options;

using RestSharp;

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

        

        private async Task<GenericResult<ApiResponse<T>>> ExecuteRequestAsync<T>(string endpoint, Method method, object body = null)
        {
            try
            {
                var url = _urlBase + endpoint;

                var options = new RestClientOptions(url);
                var client = new RestClient(options);
                var request = new RestRequest(url, method);
                request.AddHeader("accept", "application/json");
                request.AddHeader("Authorization", $"Bearer {_token}");

                if (body != null)
                {
                    request.AddJsonBody(JsonSerializer.Serialize(body));
                }

                RestResponse response = method switch
                {
                    Method.Post => await client.PostAsync(request),
                    Method.Put => await client.PutAsync(request),
                    Method.Delete => await client.DeleteAsync(request),
                    _ => await client.GetAsync(request),
                };

                if (response.IsSuccessful)
                {
                    return JsonSerializer.Deserialize<GenericResult<ApiResponse<T>>>(response.Content);
                }
                else
                {
                    return new GenericResult<ApiResponse<T>>
                    {
                    };
                }
            }
            catch (Exception ex)
            {
                return new GenericResult<ApiResponse<T>>
                {

                };
            }
        }

        public Task<GenericResult<ApiResponse<EnvelopeData>>> CriarNovoEnvelope(AstenModels.Envelope envelope)
        {
            return ExecuteRequestAsync<EnvelopeData>(Constantes.URL_CRIAR_ENVELOPE, Method.Post, envelope);
        }
    }
}
