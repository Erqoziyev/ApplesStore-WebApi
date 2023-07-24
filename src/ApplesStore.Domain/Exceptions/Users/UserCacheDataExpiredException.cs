using System.Security.Claims;

namespace AppleStore.Domain.Exceptions.Users;

public class UserCacheDataExpiredException : ExpiredExeptions
{
    public UserCacheDataExpiredException()
    {
        TitleMessage = "User data has expired!";
    }
}
