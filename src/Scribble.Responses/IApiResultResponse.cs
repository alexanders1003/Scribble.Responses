namespace Scribble.Responses;

public interface IApiResultResponse<out TResult> : IApiResponse
{
    TResult? Result { get; }
}