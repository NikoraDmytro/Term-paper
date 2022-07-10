using System.Text.Json;

namespace Api
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ErrorDetails(string message, int code)
        {
            Message = message;
            StatusCode = code;
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
