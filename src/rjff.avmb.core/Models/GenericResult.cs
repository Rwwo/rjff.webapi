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
        //public string code { get; set; }
        //public string message { get; set; }
        //public Details details { get; set; }
    }

    //public class Details
    //{
    //    [JsonExtensionData]
    //    public Dictionary<string, object> AdditionalData { get; set; }
    //}


}
