using Microsoft.AspNetCore.Http;

namespace AppleStore.Service.Dtos.Products;

public class ProductUpdateDto
{
    public long CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;

    public IFormFile? Image { get; set; }

    public double Price { get; set; }

    public string Description { get; set; } = string.Empty;
}
