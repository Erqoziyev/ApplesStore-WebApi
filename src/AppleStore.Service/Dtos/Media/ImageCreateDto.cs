using Microsoft.AspNetCore.Http;

namespace AppleStore.Service.Dtos.Media;

public class ImageCreateDto
{
    public IFormFile File { get; set; } = default!;
}
