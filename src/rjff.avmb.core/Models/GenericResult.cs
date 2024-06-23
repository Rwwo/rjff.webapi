using Newtonsoft.Json;

namespace rjff.avmb.core.Models
{
    public class GenericResult<T>
    {
        [JsonProperty("http_code")]
        public int HttpCode { get; set; }

        [JsonProperty("result")]
        public T Result { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }


    public class Error
    {
        public string error { get; set; }
        
    }
}
