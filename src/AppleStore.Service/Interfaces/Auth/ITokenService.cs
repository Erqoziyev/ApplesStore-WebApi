using AppleStore.Domain.Entities.Users;

namespace AppleStore.Service.Interfaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);
}
