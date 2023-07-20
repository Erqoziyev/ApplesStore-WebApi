using AppleStore.DataAccess.Utils;
using AppleStore.Domain.Entities.Categories;
using AppleStore.Service.Dtos.Categories;

namespace AppleStore.Service.Interfaces.Categories;

public interface ICategoryService
{
    public Task<bool> CreatAsync(CategoryCreateDto dto);

    public Task<bool> DeleteAsync(long categoryId);

    public Task<long> CountAsync();

    public Task<IList<Category>> GetAllAsync(PaginationParams @params);

    public Task<Category> GetByIdAsync(long categoryId);
}
