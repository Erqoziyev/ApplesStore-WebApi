using AppleStore.DataAccess.Interfaces.Discounts;
using AppleStore.DataAccess.Utils;
using AppleStore.Domain.Entities.Categories;
using AppleStore.Domain.Entities.Discounts;
using AppleStore.Domain.Exceptions.Categories;
using AppleStore.Domain.Exceptions.Discounts;
using AppleStore.Domain.Exceptions.Files;
using AppleStore.Service.Common.Helpers;
using AppleStore.Service.Dtos.Discounts;
using AppleStore.Service.Interfaces.Common;
using AppleStore.Service.Interfaces.Discounts;
using AppleStore.Service.Services.Common;
using System.Runtime.CompilerServices;

namespace AppleStore.Service.Services.Discounts;

public class DiscountService : IDiscountService
{
    private readonly IDiscountRepository _repository;
    private readonly IPaginator _paginator;

    public DiscountService(IDiscountRepository repository, IPaginator paginator)
    {
        this._repository = repository;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();
   

    public async Task<bool> CreatAsync(DiscountCreateDto dto)
    {
        Discount discount = new Discount()
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
        };
        var result = await _repository.CreateAsync(discount);
        return result > 0;
    }
    
    public async Task<bool> DeleteAsync(long discountId)
    {
        var result = await _repository.GetByIdAsync(discountId);
        if (result == null) throw new DiscountNotFoundException();

        var dbresult = await _repository.DeleteAsync(discountId);
        return dbresult > 0;
    }

    public async Task<IList<Discount>> GetAllAsync(PaginationParams @params)
    {
        var categories = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return categories;
    }

    public async Task<Discount> GetByIdAsync(long discountId)
    {
        var discount = await _repository.GetByIdAsync(discountId);
        if (discount is null) throw new DiscountNotFoundException();
        return discount;
    }

    public async Task<bool> UpdateAsync(long discountId, DiscountUpdateDto dto)
    {
        var discount = await _repository.GetByIdAsync(discountId);
        if (discount is null) throw new DiscountNotFoundException();

        discount.Name = dto.Name;
        discount.Description = dto.Description;
        discount.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(discountId, discount);
        return dbResult > 0;
    }
}
