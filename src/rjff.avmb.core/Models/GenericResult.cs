using Newtonsoft.Json;

namespace rjff.avmb.core.Models
{
    public class GenericResult<T>
    {
        [JsonProperty("response")]
        public ApiResponse<T> ApiResponse { get; set; }
    }


}
