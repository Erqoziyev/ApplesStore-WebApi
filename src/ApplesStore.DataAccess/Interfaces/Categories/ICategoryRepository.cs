using AppleStore.DataAccess.Common.Interfaces;
using AppleStore.Domain.Entities.Categories;

namespace AppleStore.DataAccess.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category, Category>, IGetAll<Category>
{
}
