namespace Scribble.Responses;

public interface IApiResponse
{
    int? StatusCode { get; }
    string? StatusDescription { get; }
    string? Message { get; }
}