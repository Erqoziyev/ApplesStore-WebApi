using System.Net;

namespace AppleStore.Domain.Exceptions;

public class AlreadyExistsException : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public string TitleMessage { get; protected set; } = string.Empty;
}
