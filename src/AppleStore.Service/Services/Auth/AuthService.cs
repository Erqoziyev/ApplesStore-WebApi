using AppleStore.DataAccess.Interfaces.Users;
using AppleStore.Domain.Exceptions.Users;
using AppleStore.Service.Dtos.Auth;
using AppleStore.Service.Interfaces.Auth;
using Microsoft.Extensions.Caching.Memory;

namespace AppleStore.Service.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IUserRepository _repository;

    private const int CACHED_MINUTES_FOR_REGISTER = 60;
    private const int CACHED_MINUTES_FOR_VERIFICATION = 5;

    public AuthService(IMemoryCache memoryCache, IUserRepository userRepository)
    {
        this._memoryCache = memoryCache;
        this._repository = userRepository;
    }

    public async Task<(bool Result, int CachedMinutes)> RegisterAsync(RegistorDto dto)
    {
        var user = await _repository.GetByPhoneAsync(dto.PhoneNumber);
        if (user is not null) throw new UserAlreadyExistException(dto.PhoneNumber);

        if (_memoryCache.TryGetValue(dto.PhoneNumber, out RegistorDto cachedRegistorDto))
        {
            cachedRegistorDto.FirstName = cachedRegistorDto.FirstName;
            _memoryCache.Remove(dto.PhoneNumber);
        }
        else _memoryCache.Set(dto.PhoneNumber, dto,
            TimeSpan.FromMinutes(CACHED_MINUTES_FOR_REGISTER));
        return (Result: true, CachedMinutes: CACHED_MINUTES_FOR_REGISTER);
    }

    public Task<(bool Result, int CachedVerificationMinutes)> SenderCodeForRegisterAsync(string phone)
    {
        throw new NotImplementedException();
    }

    public Task<(bool Result, string Token)> VerifyRegistorAsync(string phone, int code)
    {
        throw new NotImplementedException();
    }
}
