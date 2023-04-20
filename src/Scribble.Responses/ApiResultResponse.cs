using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Scribble.Responses;

public class ApiResultResponse : ApiResultResponse<object>
{
    public ApiResultResponse(object? result, string message, int statusCode = StatusCodes.Status200OK) 
        : base(result, message, statusCode) { }
}

public class ApiResultResponse<TResult> : IApiResultResponse<TResult>
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? StatusCode { get; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StatusDescription { get; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TResult? Result { get; }

    public ApiResultResponse(TResult? result, string message, int statusCode = StatusCodes.Status200OK)
    {
        Result = result;
        Message = message;
        StatusCode = statusCode;
        StatusDescription = StatusDescriptions.Define(statusCode);
    }
}