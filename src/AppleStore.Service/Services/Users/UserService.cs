using AppleStore.DataAccess.Interfaces.Users;
using AppleStore.DataAccess.Utils;
using AppleStore.Domain.Entities.Users;
using AppleStore.Domain.Exceptions.Users;
using AppleStore.Service.Common.Helpers;
using AppleStore.Service.Common.Securities;
using AppleStore.Service.Dtos.Users;
using AppleStore.Service.Interfaces.Users;

namespace AppleStore.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        this._repository = repository;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> DeleteAsync(long userId)
    {
        var user = await _repository.GetByIdAsync(userId);
        if (user is null) throw new UserNotFoundException();

        var result = await _repository.DeleteAsync(userId);
        return result > 0;
    }

    public async Task<IList<User>> GetAllAsync(PaginationParams @params)
    {
        var users = await _repository.GetAllAsync(@params);
        return users;
    }

    public async Task<User> GetByIdAsync(long userId)
    {
        var user = await _repository.GetByIdAsync(userId);
        if (user is null) throw new UserNotFoundException();
        return user;
    }

    public async Task<bool> UpdateAsync(long userId, UserUpdateDto dto)
    {
        var user = await _repository.GetByIdAsync(userId);
        if (user is null) throw new UserNotFoundException();
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.PhoneNumber = dto.PhoneNumber;

        var hasherResult = PasswordHasher.Hash(dto.Password);
        user.PasswordHash = hasherResult.Hash;
        user.Salt = hasherResult.Salt;
        user.Region = dto.Region;
        user.IdentityRole = Domain.Enums.IdentityRole.User;
        user.UpdatedAt = TimeHelper.GetDateTime();

        var rbResult = await _repository.UpdateAsync(userId, user);
        return rbResult > 0;
    }

}
