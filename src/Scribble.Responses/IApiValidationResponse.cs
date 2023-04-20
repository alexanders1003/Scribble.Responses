namespace Scribble.Responses;

public interface IApiValidationResponse<out TValidationError> : IApiResponse
 where TValidationError : class
{
    IEnumerable<TValidationError>? Errors { get; }
}