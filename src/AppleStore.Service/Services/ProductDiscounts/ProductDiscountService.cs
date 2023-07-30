using AppleStore.DataAccess.Interfaces.ProductDiscounties;
using AppleStore.DataAccess.Interfaces.Products;
using AppleStore.DataAccess.Utils;
using AppleStore.Domain.Entities.Products;
using AppleStore.Domain.Exceptions.Categories;
using AppleStore.Domain.Exceptions.Files;
using AppleStore.Domain.Exceptions.Products;
using AppleStore.Service.Common.Helpers;
using AppleStore.Service.Dtos.Products;
using AppleStore.Service.Interfaces.Common;
using AppleStore.Service.Interfaces.ProductDiscounts;
using AppleStore.Service.Services.Common;

namespace AppleStore.Service.Services;

public class ProductDiscountService : IProductDiscountService
{
    private readonly IProductDiscountRepository _repository;
    private readonly IPaginator _paginator;

    public ProductDiscountService(IProductDiscountRepository repository, IPaginator paginator)
    {
        this._repository = repository;
        this._paginator = paginator;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(ProductDiscountCreateDto dto)
    {
        ProductDiscount productDiscount = new ProductDiscount()
        {
            ProductId = dto.ProductId,
            DiscountId = dto.DiscountId,
            Percentage = dto.Percentage,
            StartAt = dto.StartAt,
            EndAt = dto.EndAt,
            Description = dto.Description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        return await _repository.CreateAsync(productDiscount) > 0;
    }

    public async Task<bool> DeleteAsync(long productDiscountId)
    {
        var discount = await _repository.GetByIdAsync(productDiscountId);
        if (discount == null) throw new ProductNotFoundException();

        var dbResult = await _repository.DeleteAsync(productDiscountId);
        return dbResult > 0;
    }

    public async Task<IList<ProductDiscount>> GetAllAsync(PaginationParams @params)
    {
        var products = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return products;
    }

    public async Task<ProductDiscount> GetByIdAsync(long productDiscountId)
    {
        var product = await _repository.GetByIdAsync(productDiscountId);
        if (product is null) throw new ProductNotFoundException();
        return product;
    }

    public async Task<bool> UpdateAsync(long productDiscountId, ProductDiscountUpdateDto dto)
    {
        var product = await _repository.GetByIdAsync(productDiscountId);
        if (product is null) throw new ProductNotFoundException();

        // parse new items to category
        product.ProductId = dto.ProductId;
        product.DiscountId = dto.DiscountId;
        product.Description = dto.Description;
        product.Percentage = dto.Percentage;
        product.StartAt = dto.StartAt;
        product.EndAt = dto.EndAt;
        product.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(productDiscountId, product);
        return dbResult > 0;
    }
}
