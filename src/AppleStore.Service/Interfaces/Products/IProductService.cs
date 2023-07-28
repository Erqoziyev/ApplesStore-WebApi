using AppleStore.DataAccess.Utils;
using AppleStore.Domain.Entities.Products;
using AppleStore.Service.Dtos.Products;

namespace AppleStore.Service.Interfaces.Products;

public interface IProductService
{
    public Task<bool> CreateAsync(ProductCreateDto dto);

    public Task<bool> DeleteAsync(long productId);

    public Task<IList<Product>> GetAllAsync(PaginationParams @params);

    public Task<Product> GetByIdAsync(long productId);

    public Task<bool> UpdateAsync(long productId, ProductUpdateDto dto);

    public Task<long> CountAsync();
}
