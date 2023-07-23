using AppleStore.DataAccess.Common.Interfaces;
using AppleStore.DataAccess.Utils;
using AppleStore.DataAccess.ViewModels.Users;
using AppleStore.Domain.Entities.Users;

namespace AppleStore.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, UserViewModel>, 
                 IGetAll<UserViewModel>, ISearchable<UserViewModel>
{
    public Task<User?> GetByPhoneAsync(string phone);
}

