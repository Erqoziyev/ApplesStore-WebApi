using System.Net;

namespace AppleStore.Domain.Exceptions;

public class ExpiredExeptions : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.Gone;

    public string TitleMessage { get; protected set; } = string.Empty;
}
