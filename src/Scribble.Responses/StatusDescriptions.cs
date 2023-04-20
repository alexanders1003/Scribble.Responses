using Microsoft.AspNetCore.Http;

namespace Scribble.Responses;

public static class StatusDescriptions
{
    private const string Ok200 = "OK";
    private const string Created201 = "Created";
    private const string NotFound400 = "Not Found";
    private const string InternalServerError500 = "Internal Server Error";

    public static string Define(int statusCode)
    {
        return statusCode switch
        {
            StatusCodes.Status200OK => Ok200,
            StatusCodes.Status201Created => Created201,
            StatusCodes.Status404NotFound => NotFound400,
            _ => InternalServerError500
        };
    }
}