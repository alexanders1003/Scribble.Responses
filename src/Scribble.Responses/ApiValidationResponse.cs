using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Scribble.Responses;

public class ApiValidationResponse : ApiValidationResponse<object>
{
    public ApiValidationResponse(IEnumerable<object> errors, string message, int statusCode = StatusCodes.Status400BadRequest) 
        : base(errors, message, statusCode) { }
}

public class ApiValidationResponse<TValidationError> : IApiValidationResponse<TValidationError>
    where TValidationError : class
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? StatusCode { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StatusDescription { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<TValidationError>? Errors { get; }

    public ApiValidationResponse(IEnumerable<TValidationError> errors, string message,
        int statusCode = StatusCodes.Status400BadRequest)
    {
        Errors = errors;
        Message = message;
        StatusCode = statusCode;
        StatusDescription = StatusDescriptions.Define(statusCode);
    }
}