using AppleStore.DataAccess.Utils;
using AppleStore.Domain.Entities.Categories;
using AppleStore.Domain.Entities.Discounts;
using AppleStore.Service.Dtos.Categories;
using AppleStore.Service.Dtos.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleStore.Service.Interfaces.Discounts;

public interface IDiscountService
{
    public Task<bool> CreatAsync(DiscountCreateDto dto);

    public Task<bool> DeleteAsync(long discountId);

    public Task<long> CountAsync();

    public Task<IList<Discount>> GetAllAsync(PaginationParams @params);

    public Task<Discount> GetByIdAsync(long discountId);

    public Task<bool> UpdateAsync(long discountId, DiscountUpdateDto dto);
}
