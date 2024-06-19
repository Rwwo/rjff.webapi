using Newtonsoft.Json;

namespace rjff.avmb.core.Models
{
    public class ApiResponse<T>
    {
        [JsonProperty("response")]
        public T Response { get; set; }
    }


}
