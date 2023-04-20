using System.Text.Json.Serialization;

namespace Scribble.Responses;

public class ApiResponse : IApiResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? StatusCode { get; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StatusDescription { get; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; }
    
    public ApiResponse(string message, int statusCode)
    {
        Message = message;
        StatusCode = statusCode;
        StatusDescription = StatusDescriptions.Define(statusCode);
    }
}