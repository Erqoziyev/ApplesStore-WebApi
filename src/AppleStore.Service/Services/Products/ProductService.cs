using AppleStore.DataAccess.Interfaces.Products;
using AppleStore.DataAccess.Utils;
using AppleStore.Domain.Entities.Categories;
using AppleStore.Domain.Entities.Products;
using AppleStore.Domain.Exceptions.Categories;
using AppleStore.Domain.Exceptions.Files;
using AppleStore.Domain.Exceptions.Products;
using AppleStore.Service.Common.Helpers;
using AppleStore.Service.Dtos.Products;
using AppleStore.Service.Interfaces.Common;
using AppleStore.Service.Interfaces.Products;
using AppleStore.Service.Services.Common;
using Microsoft.Extensions.Caching.Memory;

namespace AppleStore.Service.Services.Products;

public class ProductService : IProductService
{
    private IProductRepository _repository;
    private IFileService _fileservice;
    private IPaginator _paginator;

    public ProductService(IProductRepository productRepository,
        IFileService fileService, IPaginator paginator)
    {
        this._repository = productRepository;
        this._fileservice = fileService;
        this._paginator = paginator;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(ProductCreateDto dto)
    {
        string imagePath = await _fileservice.UploadImageAsync(dto.Image);

        Product product = new Product()
        {
            CategoryId = dto.CategoryId,
            ImagePath = imagePath,
            Name = dto.Name,
            Price = dto.Price,
            Color = dto.Color,
            Description = dto.Description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        return await _repository.CreateAsync(product) > 0;
    }

    public async Task<bool> DeleteAsync(long productId)
    {
        var category = await _repository.GetByIdAsync(productId);
        if (category == null) throw new ProductNotFoundException();

        var result = await _fileservice.DeleteImageAsync(category.ImagePath);
        if (result == false) throw new ImageNotFoundException();

        var dbResult = await _repository.DeleteAsync(productId);
        return dbResult > 0;
    }

    public async Task<IList<Product>> GetAllAsync(PaginationParams @params)
    {
        var products = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return products;
    }

    public async Task<Product> GetByIdAsync(long productId)
    {
        var product = await _repository.GetByIdAsync(productId);
        if (product is null) throw new ProductNotFoundException();
        return product;
    }

    public async Task<bool> UpdateAsync(long productId, ProductUpdateDto dto)
    {
        var product = await _repository.GetByIdAsync(productId);
        if (product is null) throw new ProductNotFoundException();

        // parse new items to category
        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.Color = dto.Color;
        product.CategoryId = dto.CategoryId;

        if (dto.Image is not null)
        {
            // delete old image
            var deleteResult = await _fileservice.DeleteImageAsync(product.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            // upload new image
            string newImagePath = await _fileservice.UploadImageAsync(dto.Image);

            product.ImagePath = newImagePath;
        }
        product.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(productId, product);
        return dbResult > 0;
    }
}