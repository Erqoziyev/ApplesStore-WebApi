using AppleStore.DataAccess.Utils;
using AppleStore.Domain.Entities.Categories;
using AppleStore.Domain.Entities.Users;
using AppleStore.Service.Dtos.Categories;
using AppleStore.Service.Dtos.Users;

namespace AppleStore.Service.Interfaces.Users;

public interface IUserService
{
    public Task<bool> DeleteAsync(long userId);

    public Task<long> CountAsync();

    public Task<IList<User>> GetAllAsync(PaginationParams @params);

    public Task<User> GetByIdAsync(long userId);

    public Task<bool> UpdateAsync(long userId, UserUpdateDto dto);
}
