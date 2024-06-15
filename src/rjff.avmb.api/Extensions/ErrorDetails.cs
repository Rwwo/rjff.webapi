namespace rjff.avmb.api.Extensions
{
    public class ErrorDetails
    {
        public ErrorDetails(int statusCode, string message, List<string> errors)
        {
            StatusCode = statusCode;
            Message = message;
            Errors = errors;
        }

        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public List<string> Errors { get; private set; }
    }
}
