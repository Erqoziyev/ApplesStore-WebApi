using AppleStore.DataAccess.Utils;
using AppleStore.Domain.Entities.Products;
using AppleStore.Service.Dtos.Products;

namespace AppleStore.Service.Interfaces.ProductDiscounts;

public interface IProductDiscountService
{
    public Task<bool> CreateAsync(ProductDiscountCreateDto dto);

    public Task<bool> DeleteAsync(long productDiscountId);

    public Task<IList<ProductDiscount>> GetAllAsync(PaginationParams @params);

    public Task<ProductDiscount> GetByIdAsync(long productDiscountId);

    public Task<bool> UpdateAsync(long productDiscountId, ProductDiscountUpdateDto dto);

    public Task<long> CountAsync();
}
